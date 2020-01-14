using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csv_test
{
    public partial class mainForm : Form
    {

        private DataTable dt;

        public mainForm()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string selectedFile = "";

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Open csv file";
            fileDialog.InitialDirectory = @"c:\";
            fileDialog.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFile = fileDialog.FileName;
            }
            dt = AstronomyParser.readCSV(selectedFile);
            gridView.DataSource = dt;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
           
                using (var db = new AstronomyLogsEntities())
                {
                    foreach (AstronomyEntry entry in AstronomyParser.fillSQLEntry(dt))
                    {
                        db.AstronomyEntries.Add(entry);
                    }
                    db.SaveChanges();
                }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditForm edit = new EditForm();
            if (dt != null)
            {
                dt.Clear();
            }
            edit.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            constellationForm constellation = new constellationForm();
            if (dt != null)
            {
                dt.Clear();
            }
            constellation.Show();
        }
    }
}



