namespace MTUOptimizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridViewInterfaces = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSetMTU = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelMTU = new System.Windows.Forms.Label();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInterfaces)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewInterfaces
            // 
            this.dataGridViewInterfaces.AllowUserToAddRows = false;
            this.dataGridViewInterfaces.AllowUserToDeleteRows = false;
            this.dataGridViewInterfaces.AllowUserToOrderColumns = true;
            this.dataGridViewInterfaces.AllowUserToResizeRows = false;
            this.dataGridViewInterfaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewInterfaces.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInterfaces.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridViewInterfaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInterfaces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridViewInterfaces.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewInterfaces.Location = new System.Drawing.Point(12, 64);
            this.dataGridViewInterfaces.Name = "dataGridViewInterfaces";
            this.dataGridViewInterfaces.ReadOnly = true;
            this.dataGridViewInterfaces.RowHeadersVisible = false;
            this.dataGridViewInterfaces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInterfaces.Size = new System.Drawing.Size(568, 240);
            this.dataGridViewInterfaces.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Interface";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Type";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "MTU";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // buttonSetMTU
            // 
            this.buttonSetMTU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetMTU.Location = new System.Drawing.Point(405, 311);
            this.buttonSetMTU.Name = "buttonSetMTU";
            this.buttonSetMTU.Size = new System.Drawing.Size(175, 23);
            this.buttonSetMTU.TabIndex = 1;
            this.buttonSetMTU.Text = "Set MTU for selected interfaces";
            this.buttonSetMTU.UseVisualStyleBackColor = true;
            this.buttonSetMTU.Click += new System.EventHandler(this.buttonSetMTU_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelMTU);
            this.groupBox1.Controls.Add(this.buttonAnalyze);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 52);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // labelMTU
            // 
            this.labelMTU.AutoSize = true;
            this.labelMTU.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMTU.Location = new System.Drawing.Point(6, 14);
            this.labelMTU.Name = "labelMTU";
            this.labelMTU.Size = new System.Drawing.Size(306, 30);
            this.labelMTU.TabIndex = 4;
            this.labelMTU.Text = "Optimal MTU: - not calculated -";
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnalyze.Location = new System.Drawing.Point(482, 12);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(82, 34);
            this.buttonAnalyze.TabIndex = 3;
            this.buttonAnalyze.Text = "Analyze MTU";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "* if MTU changes do not work, start MTU Optimizer \"as Administrator\"";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 346);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSetMTU);
            this.Controls.Add(this.dataGridViewInterfaces);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(608, 385);
            this.Name = "Form1";
            this.Text = "MTU Optimizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInterfaces)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInterfaces;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button buttonSetMTU;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.Label labelMTU;
        private System.Windows.Forms.Label label1;
    }
}

