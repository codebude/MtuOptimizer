using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace MTUOptimizer
{
    public partial class Form1 : Form
    {
        private int version = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += $" - {Application.ProductVersion}";
            if (!UpdateAvailable())
                LoadInterfaces();
            else
            {
                try
                {
                    this.Close();
                    Application.Exit();
                }
                catch { }
            }
        }

        private bool UpdateAvailable()
        {
            bool update = false;
            try
            {
                WebClient wc = new WebClient();
                var onlineVersion = int.Parse(wc.DownloadString("https://code-bude.net/downloads/mtu-optimizer/version.txt"));
                if (onlineVersion > version)
                {
                    var frm = new FormUpdate();
                    frm.ShowDialog();
                    update = true;                
                }
            }
            catch (Exception ee) { }
            return update;
        }

        private void LoadInterfaces()
        {
            var ifaces = NetworkInterface.GetAllNetworkInterfaces().Where(x => x.GetIPProperties() != null && x.Supports(NetworkInterfaceComponent.IPv4) && x.GetIPProperties().GetIPv4Properties() != null);
            dataGridViewInterfaces.Rows.Clear();
            foreach (var iface in ifaces)
            {
                dataGridViewInterfaces.Rows.Add(1);
                var dgvr = dataGridViewInterfaces.Rows[dataGridViewInterfaces.Rows.GetLastRow(DataGridViewElementStates.None)];
                dgvr.Cells[0].Value = iface.NetworkInterfaceType.ToString().ToLower().Contains("wireless") ? Properties.Resources._1485864245_network_wireless : Properties.Resources._1485864239_network_ethernet;                                
                dgvr.Cells[1].Value = iface.Name;
                dgvr.Cells[2].Value = iface.NetworkInterfaceType.ToString();
                var mtu = iface.GetIPProperties().GetIPv4Properties().Mtu.ToString();                
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo("cmd", "/c netsh interface ipv4 show subinterface " + iface.GetIPProperties().GetIPv4Properties().Index) { CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden, Verb = "runas", UseShellExecute = false, RedirectStandardOutput = true };
                p.Start();
                var res = p.StandardOutput.ReadToEnd();                
                p.WaitForExit();
                var lines = res.Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith("------"))
                    {
                        dgvr.Cells[3].Value = lines[i + 1].Trim().Substring(0, lines[i + 1].Trim().IndexOf(' '));
                        break;
                    }
                }

                dgvr.Tag = iface.GetIPProperties().GetIPv4Properties().Index;          
            }
            dataGridViewInterfaces.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewInterfaces.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewInterfaces.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewInterfaces.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewInterfaces.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private int GetStringWidth(Font strFont, string input)
        {
            SizeF stringSize = new SizeF();
            stringSize = Graphics.FromImage(new Bitmap(500,500)).MeasureString(input, strFont);
            return (int)Math.Ceiling(stringSize.Width);
        }

        public bool PingTooBig(string host, int packetSize, int packetCount)
        {
            bool toBig = false;
            int timeout = 3000;
            byte[] packet = new byte[packetSize];

            Ping pinger = new Ping();            
            for (int i = 0; i < packetCount; ++i)
            {
                var rep = pinger.Send(host, timeout, packet, new PingOptions(timeout, true));
                if (rep.Status == IPStatus.PacketTooBig)
                    toBig = true;
            }
            return toBig;
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            string tempMtu = string.Empty;
            string tempIndex = string.Empty;
            labelMTU.Text = "Analyzing. Please wait.";
            BackgroundWorker bgw = new BackgroundWorker();

            UdpClient u = new UdpClient("google.de", 1);
            IPAddress localAddr = ((IPEndPoint)u.Client.LocalEndPoint).Address;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                IPInterfaceProperties ipProps = nic.GetIPProperties();
                if (ipProps.UnicastAddresses.Select(x => x.Address).Contains(localAddr))
                {
                    if (nic.Supports(NetworkInterfaceComponent.IPv4) && nic.GetIPProperties().GetIPv4Properties() != null)
                    {
                        tempIndex = nic.GetIPProperties().GetIPv4Properties().Index.ToString();
                        foreach (DataGridViewRow dgvr in dataGridViewInterfaces.Rows)
                        {
                            if (dgvr.Tag.ToString() == tempIndex)
                            {
                                tempMtu = dgvr.Cells[3].Value.ToString();
                                if (!string.IsNullOrEmpty(tempMtu))
                                    SetMTU(tempIndex, "9000");                                
                            }
                        }
                    }
                    break;
                }
            }

            bgw.DoWork += (object s, DoWorkEventArgs de) =>
            {
                int mtu = 0;
                try
                {
                    for (int packetSize = 1500; packetSize >= 0; packetSize--)
                    {
                        if (!PingTooBig("t-online.de", packetSize, 1))
                        {
                            mtu = (28 + packetSize);
                            break;
                        }
                    }
                }
                catch
                {
                    try
                    {
                        for (int packetSize = 1500; packetSize >= 0; packetSize--)
                        {
                            if (!PingTooBig("google.de", packetSize, 4))
                            {
                                mtu = (28 + packetSize);
                                break;
                            }
                        }
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("An error occured while testing for the perfect MTU:\r\n" + ee.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                bgw.ReportProgress(mtu);
            };

            bgw.ProgressChanged += (object s, ProgressChangedEventArgs pe) =>
            {
                if (pe.ProgressPercentage != 0)
                {
                    labelMTU.Text = "Optimal MTU: " + pe.ProgressPercentage + " bytes";
                    labelMTU.Tag = pe.ProgressPercentage;
                }
            };

            bgw.RunWorkerCompleted += (object s, RunWorkerCompletedEventArgs ce) =>
            {
                if (!string.IsNullOrEmpty(tempMtu))
                    SetMTU(tempIndex, tempMtu);
                LoadInterfaces();
            };

            bgw.WorkerReportsProgress = true;
            bgw.RunWorkerAsync();       
            
        }

        private void SetMTU(string interfaceId, string mtu)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("cmd", "/c netsh interface ipv4 set subinterface " + interfaceId + "  mtu=" + mtu + " store=persistent") { CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden, Verb = "runas" };
            p.Start();
            p.WaitForExit();
        }

        private void buttonSetMTU_Click(object sender, EventArgs e)
        {
            if (labelMTU.Tag == null)
            {
                MessageBox.Show("Please calculate optimal MTU before setting MTU to interface!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (DataGridViewRow dvgr in dataGridViewInterfaces.SelectedRows)
            {
                SetMTU(dvgr.Tag.ToString(), labelMTU.Tag.ToString());
            }
            LoadInterfaces();
            Timer ti = new Timer();
            ti.Tick += (object s, EventArgs ee) =>
            {
                (s as Timer).Stop();
                LoadInterfaces();
            };
            ti.Interval = 3000;
            ti.Start();
            MessageBox.Show("Optimal MTU settings set.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);     
        }

        
    }
}
