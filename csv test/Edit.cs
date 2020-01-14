using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csv_test
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
            using (var db = new AstronomyLogsEntities())
            {
                dbGrid.DataSource = db.AstronomyEntries.Where(e => !String.IsNullOrEmpty(e.Proper)).ToList();

                dbGrid.Columns["Name"].DisplayIndex = 1;

                for (int i = 0; i < dbGrid.Columns.Count; i++)
                {
                        dbGrid.Columns[i].ReadOnly = dbGrid.Columns[i].Name != "Name";
                }
            }
            
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dbGrid.Rows)
            {
                using (var db = new AstronomyLogsEntities())
                {
                    int id = int.Parse(row.Cells[0].Value.ToString());
                    AstronomyEntry entry = db.AstronomyEntries.Where(en => en.IDEntry == id).FirstOrDefault();
                    string name = row.Cells["Name"].Value.ToString();
                    if (!string.IsNullOrEmpty(name))
                    {
                        entry.Name = row.Cells["Name"].Value.ToString();
                        db.Entry(entry).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}
