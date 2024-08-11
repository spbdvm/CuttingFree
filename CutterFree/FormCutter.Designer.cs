namespace CutterX
{
    partial class FormCutter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCutter));
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmdCutt = new System.Windows.Forms.Button();
            this.numLen = new System.Windows.Forms.NumericUpDown();
            this.cmdSetLeng = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlPage = new System.Windows.Forms.TabControl();
            this.tabPageArt = new System.Windows.Forms.TabPage();
            this.dwGrid = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dwCutt = new System.Windows.Forms.DataGridView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.TextBox();
            this.dwArtiklsData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdDelete2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdDelete1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnXLS = new System.Windows.Forms.Button();
            this.cmdAbout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlPage.SuspendLayout();
            this.tabPageArt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dwGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dwCutt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwArtiklsData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdLoad
            // 
            this.cmdLoad.Location = new System.Drawing.Point(3, 12);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(75, 23);
            this.cmdLoad.TabIndex = 0;
            this.cmdLoad.Text = "Load File";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdCutt
            // 
            this.cmdCutt.BackColor = System.Drawing.Color.LightCoral;
            this.cmdCutt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdCutt.Location = new System.Drawing.Point(84, 12);
            this.cmdCutt.Name = "cmdCutt";
            this.cmdCutt.Size = new System.Drawing.Size(103, 23);
            this.cmdCutt.TabIndex = 1;
            this.cmdCutt.Text = "Cutt  !";
            this.cmdCutt.UseVisualStyleBackColor = false;
            this.cmdCutt.Click += new System.EventHandler(this.cmdCutt_Click);
            // 
            // numLen
            // 
            this.numLen.Location = new System.Drawing.Point(124, 49);
            this.numLen.Maximum = new decimal(new int[] {
            25000,
            0,
            0,
            0});
            this.numLen.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numLen.Name = "numLen";
            this.numLen.Size = new System.Drawing.Size(120, 20);
            this.numLen.TabIndex = 3;
            this.numLen.Value = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            // 
            // cmdSetLeng
            // 
            this.cmdSetLeng.Location = new System.Drawing.Point(11, 38);
            this.cmdSetLeng.Name = "cmdSetLeng";
            this.cmdSetLeng.Size = new System.Drawing.Size(91, 38);
            this.cmdSetLeng.TabIndex = 4;
            this.cmdSetLeng.Text = "Sel Profile\r\nLength";
            this.cmdSetLeng.UseVisualStyleBackColor = true;
            this.cmdSetLeng.Click += new System.EventHandler(this.cmdSetAll_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(124, 10);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControlPage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel2.Controls.Add(this.lblInfo);
            this.splitContainer1.Panel2.Controls.Add(this.dwArtiklsData);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.cmdSetLeng);
            this.splitContainer1.Panel2.Controls.Add(this.numLen);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDown1);
            this.splitContainer1.Size = new System.Drawing.Size(1176, 499);
            this.splitContainer1.SplitterDistance = 659;
            this.splitContainer1.TabIndex = 8;
            // 
            // tabControlPage
            // 
            this.tabControlPage.Controls.Add(this.tabPageArt);
            this.tabControlPage.Controls.Add(this.tabPage2);
            this.tabControlPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPage.Location = new System.Drawing.Point(0, 0);
            this.tabControlPage.Name = "tabControlPage";
            this.tabControlPage.SelectedIndex = 0;
            this.tabControlPage.Size = new System.Drawing.Size(659, 499);
            this.tabControlPage.TabIndex = 0;
            // 
            // tabPageArt
            // 
            this.tabPageArt.Controls.Add(this.dwGrid);
            this.tabPageArt.Location = new System.Drawing.Point(4, 22);
            this.tabPageArt.Name = "tabPageArt";
            this.tabPageArt.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageArt.Size = new System.Drawing.Size(651, 473);
            this.tabPageArt.TabIndex = 0;
            this.tabPageArt.Text = "       List of cuts for Cutting       ";
            this.tabPageArt.UseVisualStyleBackColor = true;
            // 
            // dwGrid
            // 
            this.dwGrid.AllowUserToAddRows = false;
            this.dwGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dwGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwGrid.Location = new System.Drawing.Point(3, 3);
            this.dwGrid.Name = "dwGrid";
            this.dwGrid.RowHeadersWidth = 51;
            this.dwGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dwGrid.Size = new System.Drawing.Size(645, 467);
            this.dwGrid.TabIndex = 15;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Info;
            this.tabPage2.Controls.Add(this.dwCutt);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(651, 473);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "               Cutting Results                ";
            // 
            // dwCutt
            // 
            this.dwCutt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dwCutt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwCutt.Location = new System.Drawing.Point(3, 3);
            this.dwCutt.Name = "dwCutt";
            this.dwCutt.RowHeadersWidth = 51;
            this.dwCutt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dwCutt.Size = new System.Drawing.Size(645, 467);
            this.dwCutt.TabIndex = 16;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(209, 11);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(74, 17);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "SumEqual";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.BackColor = System.Drawing.SystemColors.Info;
            this.lblInfo.Location = new System.Drawing.Point(63, 269);
            this.lblInfo.Multiline = true;
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblInfo.Size = new System.Drawing.Size(360, 111);
            this.lblInfo.TabIndex = 16;
            this.lblInfo.Text = "Not visible  -  Logs For user";
            this.lblInfo.Visible = false;
            // 
            // dwArtiklsData
            // 
            this.dwArtiklsData.AllowUserToAddRows = false;
            this.dwArtiklsData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dwArtiklsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dwArtiklsData.Location = new System.Drawing.Point(11, 120);
            this.dwArtiklsData.Name = "dwArtiklsData";
            this.dwArtiklsData.RowHeadersWidth = 51;
            this.dwArtiklsData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dwArtiklsData.Size = new System.Drawing.Size(499, 373);
            this.dwArtiklsData.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdDelete2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(11, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 32);
            this.panel1.TabIndex = 18;
            // 
            // cmdDelete2
            // 
            this.cmdDelete2.BackColor = System.Drawing.Color.LemonChiffon;
            this.cmdDelete2.Location = new System.Drawing.Point(419, 4);
            this.cmdDelete2.Name = "cmdDelete2";
            this.cmdDelete2.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete2.TabIndex = 12;
            this.cmdDelete2.Text = "DeleteRow";
            this.cmdDelete2.UseVisualStyleBackColor = false;
            this.cmdDelete2.Click += new System.EventHandler(this.cmdDelete2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Profiles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Cutting width :";
            // 
            // cmdDelete1
            // 
            this.cmdDelete1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdDelete1.BackColor = System.Drawing.Color.LemonChiffon;
            this.cmdDelete1.Location = new System.Drawing.Point(580, 12);
            this.cmdDelete1.Name = "cmdDelete1";
            this.cmdDelete1.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete1.TabIndex = 9;
            this.cmdDelete1.Text = "DeleteRow";
            this.cmdDelete1.UseVisualStyleBackColor = false;
            this.cmdDelete1.Click += new System.EventHandler(this.cmdDelete1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnXLS
            // 
            this.btnXLS.BackColor = System.Drawing.Color.Lime;
            this.btnXLS.Location = new System.Drawing.Point(210, 12);
            this.btnXLS.Name = "btnXLS";
            this.btnXLS.Size = new System.Drawing.Size(98, 23);
            this.btnXLS.TabIndex = 10;
            this.btnXLS.Text = "Excel Report";
            this.btnXLS.UseVisualStyleBackColor = false;
            this.btnXLS.Click += new System.EventHandler(this.btnXLS_Click);
            // 
            // cmdAbout
            // 
            this.cmdAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAbout.Location = new System.Drawing.Point(1088, 12);
            this.cmdAbout.Name = "cmdAbout";
            this.cmdAbout.Size = new System.Drawing.Size(91, 23);
            this.cmdAbout.TabIndex = 11;
            this.cmdAbout.Text = "About";
            this.cmdAbout.UseVisualStyleBackColor = true;
            this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
            // 
            // FormCutter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 552);
            this.Controls.Add(this.cmdAbout);
            this.Controls.Add(this.btnXLS);
            this.Controls.Add(this.cmdDelete1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmdCutt);
            this.Controls.Add(this.cmdLoad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCutter";
            this.Text = "Free Cutter Software      spbdvm@gmail.com";
            this.Load += new System.EventHandler(this.FormCutter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlPage.ResumeLayout(false);
            this.tabPageArt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dwGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dwCutt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dwArtiklsData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Button cmdCutt;
        private System.Windows.Forms.NumericUpDown numLen;
        private System.Windows.Forms.Button cmdSetLeng;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button cmdDelete1;
        private System.Windows.Forms.TextBox lblInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dwArtiklsData;
        private System.Windows.Forms.TabControl tabControlPage;
        private System.Windows.Forms.TabPage tabPageArt;
        private System.Windows.Forms.DataGridView dwGrid;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dwCutt;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button cmdDelete2;
        private System.Windows.Forms.Button btnXLS;
        private System.Windows.Forms.Button cmdAbout;
    }
}

