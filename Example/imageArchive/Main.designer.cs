namespace Test
{
    partial class Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.about_BTN = new System.Windows.Forms.Button();
            this.replace_BTN = new System.Windows.Forms.Button();
            this.rename_BTN = new System.Windows.Forms.Button();
            this.delete_BTN = new System.Windows.Forms.Button();
            this.extract_BTN = new System.Windows.Forms.Button();
            this.add_BTN = new System.Windows.Forms.Button();
            this.rebuild_BTN = new System.Windows.Forms.Button();
            this.open_BTN = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.replace_BTN);
            this.panel1.Controls.Add(this.rename_BTN);
            this.panel1.Controls.Add(this.delete_BTN);
            this.panel1.Controls.Add(this.extract_BTN);
            this.panel1.Controls.Add(this.add_BTN);
            this.panel1.Controls.Add(this.rebuild_BTN);
            this.panel1.Controls.Add(this.open_BTN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(646, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(88, 312);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.about_BTN);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 284);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(88, 28);
            this.panel2.TabIndex = 7;
            // 
            // about_BTN
            // 
            this.about_BTN.Location = new System.Drawing.Point(7, 3);
            this.about_BTN.Name = "about_BTN";
            this.about_BTN.Size = new System.Drawing.Size(75, 23);
            this.about_BTN.TabIndex = 8;
            this.about_BTN.Text = "About";
            this.about_BTN.UseVisualStyleBackColor = true;
            this.about_BTN.Click += new System.EventHandler(this.about_BTN_Click);
            // 
            // replace_BTN
            // 
            this.replace_BTN.Location = new System.Drawing.Point(7, 232);
            this.replace_BTN.Name = "replace_BTN";
            this.replace_BTN.Size = new System.Drawing.Size(75, 23);
            this.replace_BTN.TabIndex = 6;
            this.replace_BTN.Text = "Replace";
            this.replace_BTN.UseVisualStyleBackColor = true;
            this.replace_BTN.Click += new System.EventHandler(this.replace_BTN_Click);
            // 
            // rename_BTN
            // 
            this.rename_BTN.Location = new System.Drawing.Point(7, 203);
            this.rename_BTN.Name = "rename_BTN";
            this.rename_BTN.Size = new System.Drawing.Size(75, 23);
            this.rename_BTN.TabIndex = 5;
            this.rename_BTN.Text = "Rename";
            this.rename_BTN.UseVisualStyleBackColor = true;
            this.rename_BTN.Click += new System.EventHandler(this.rename_BTN_Click);
            // 
            // delete_BTN
            // 
            this.delete_BTN.Location = new System.Drawing.Point(7, 174);
            this.delete_BTN.Name = "delete_BTN";
            this.delete_BTN.Size = new System.Drawing.Size(75, 23);
            this.delete_BTN.TabIndex = 4;
            this.delete_BTN.Text = "Delete";
            this.delete_BTN.UseVisualStyleBackColor = true;
            this.delete_BTN.Click += new System.EventHandler(this.delete_BTN_Click);
            // 
            // extract_BTN
            // 
            this.extract_BTN.Location = new System.Drawing.Point(7, 61);
            this.extract_BTN.Name = "extract_BTN";
            this.extract_BTN.Size = new System.Drawing.Size(75, 54);
            this.extract_BTN.TabIndex = 3;
            this.extract_BTN.Text = "Extract Selected Files";
            this.extract_BTN.UseVisualStyleBackColor = true;
            this.extract_BTN.Click += new System.EventHandler(this.extract_BTN_Click);
            // 
            // add_BTN
            // 
            this.add_BTN.Location = new System.Drawing.Point(7, 145);
            this.add_BTN.Name = "add_BTN";
            this.add_BTN.Size = new System.Drawing.Size(75, 23);
            this.add_BTN.TabIndex = 2;
            this.add_BTN.Text = "Add";
            this.add_BTN.UseVisualStyleBackColor = true;
            this.add_BTN.Click += new System.EventHandler(this.add_BTN_Click);
            // 
            // rebuild_BTN
            // 
            this.rebuild_BTN.Location = new System.Drawing.Point(6, 32);
            this.rebuild_BTN.Name = "rebuild_BTN";
            this.rebuild_BTN.Size = new System.Drawing.Size(75, 23);
            this.rebuild_BTN.TabIndex = 1;
            this.rebuild_BTN.Text = "Rebuild";
            this.rebuild_BTN.UseVisualStyleBackColor = true;
            this.rebuild_BTN.Click += new System.EventHandler(this.rebuild_BTN_Click);
            // 
            // open_BTN
            // 
            this.open_BTN.Location = new System.Drawing.Point(6, 3);
            this.open_BTN.Name = "open_BTN";
            this.open_BTN.Size = new System.Drawing.Size(75, 23);
            this.open_BTN.TabIndex = 0;
            this.open_BTN.Text = "Open";
            this.open_BTN.UseVisualStyleBackColor = true;
            this.open_BTN.Click += new System.EventHandler(this.open_BTN_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 18;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(636, 297);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(10, 312);
            this.progressBar1.Maximum = 100000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(636, 10);
            this.progressBar1.TabIndex = 21;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(10, 307);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(636, 5);
            this.splitter1.TabIndex = 22;
            this.splitter1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(744, 332);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "X Archive Dragon Tester";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button open_BTN;
        private System.Windows.Forms.Button rebuild_BTN;
        private System.Windows.Forms.Button add_BTN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button extract_BTN;
        private System.Windows.Forms.Button replace_BTN;
        private System.Windows.Forms.Button rename_BTN;
        private System.Windows.Forms.Button delete_BTN;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button about_BTN;
        private System.Windows.Forms.Splitter splitter1;
    }
}

