using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XArchiveDragon;
using System.IO;

namespace Test
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        IMG_Archive Archive = null;
        string CurrentFilePath = string.Empty;
        private void open_BTN_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "IMG|*.img";
                if (ofd.ShowDialog() == DialogResult.OK)
                    OpenArchive(ofd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void RefreshArchive()
        {
            if (CurrentFilePath != string.Empty)
                OpenArchive(CurrentFilePath);
        }
        void OpenArchive(string filePath)
        {
            Archive = new IMG_Archive(filePath);
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Offset", typeof(uint));
            dt.Columns.Add("Size", typeof(int));
            for (int a = 0; a < Archive.Items.Count; a++)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = Archive.Items[a].Name;
                dr["Offset"] = Archive.Items[a].OffsetInBytes;
                dr["Size"] = Archive.Items[a].SizeInBytes;
                dt.Rows.Add(dr);
            }
            dt.Columns["Offset"].ColumnName = "Offset (bytes)";
            dt.Columns["Size"].ColumnName = "Size (bytes)";
            dataGridView1.DataSource = dt;
            CurrentFilePath = filePath;
        }
        bool ValidateX
        { get { return Archive != null; } }
        private void rebuild_BTN_Click(object sender, EventArgs e)
        {
            if (ValidateX)
            {
                ShowMessage(Archive.Rebuild(0, progressBar1));
                RefreshArchive();
            }
        }

        private void add_BTN_Click(object sender, EventArgs e)
        {
            if (ValidateX)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Add File(s)";
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage(Archive.Add(ofd.FileNames, true, progressBar1));
                    RefreshArchive();
                }
            }
        }

        private void extract_BTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0 && ValidateX)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    for (int a = 0; a < dataGridView1.SelectedRows.Count; a++)
                        Archive.Items[dataGridView1.SelectedRows[a].Index].Extract(fbd.SelectedPath);
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0 && ValidateX)
            {
                string tpath = Archive.Items[dataGridView1.SelectedRows[0].Index].Extract(Path.GetTempPath());
                System.Diagnostics.Process.Start(tpath);
            }
        }

        private void delete_BTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0 && ValidateX)
            {
                string backupDirPath = string.Empty;
                if (MessageBox.Show("Would you like to backup all the deleting files ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                        backupDirPath = fbd.SelectedPath;
                    else
                        return;
                }
                string[] filesNames = new string[dataGridView1.SelectedRows.Count];
                for (int a = 0; a < filesNames.Length; a++)
                    filesNames[a] = dataGridView1.SelectedRows[a].Cells["Name"].Value.ToString();
                ShowMessage(Archive.Delete(filesNames, true, backupDirPath));
                RefreshArchive();
            }
        }
        void ShowMessage(XOutput output)
        {
            MessageBox.Show(output.Message + "\n" + output.OtherInfo, Application.ProductName, MessageBoxButtons.OK,
                output.IsException ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        private void rename_BTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0 && ValidateX)
            {
                /*string newName = Microsoft.VisualBasic.Interaction.InputBox("New name must less than or equals to " + XArchiveDragon.IMG_Item.MAX_NAME_LENGTH + ", exceeded characters will be trimmed off.", "Enter New Name",
                    dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString(), this.Location.X + 50, this.Location.Y + 50);*/
                if (newName.Trim().Length != 0)
                {
                    // No need following validation code, its built-in

                    //if (newName.Length > XArchiveDragon.IMG_Item.MAX_NAME_LENGTH)
                    //    newName = newName.Substring(newName.Length - XArchiveDragon.IMG_Item.MAX_NAME_LENGTH);

                    ShowMessage(
                        // can rename multiple files, but old names and new names must be respectivily
                        Archive.Rename(new string[] { dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString() },
                        new string[] { newName }, true, progressBar1)
                        );
                    dataGridView1.SelectedRows[0].Cells["Name"].Value = newName;
                }
            }
        }

        private void replace_BTN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0 && ValidateX)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string backupDirPath = string.Empty;
                    if (MessageBox.Show("Would you like to backup the replacing file ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FolderBrowserDialog fbd = new FolderBrowserDialog();
                        if (fbd.ShowDialog() == DialogResult.OK)
                            backupDirPath = fbd.SelectedPath;
                        else
                            return;
                    }
                    ShowMessage(
                        // can replace multiple files, but current names and new file paths must be respectivily
                        Archive.Replace(new string[] { ofd.FileName },
                        new string[] { dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString() },
                        true, backupDirPath, progressBar1)
                        );
                    RefreshArchive();
                }
            }
        }

        private void about_BTN_Click(object sender, EventArgs e)
        {
            //About about = new About();
            about.ShowDialog();
        }
    }
}