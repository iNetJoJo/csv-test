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
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
            using (var db = new AstronomyLogsEntities())
            {
                dbGrid.DataSource = db.AstronomyEntries.Where(e => !String.IsNullOrEmpty(e.Proper)).ToList();
            }
            
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dbGrid.Rows)
            {
                using (var db = new AstronomyLogsEntities())
                {
                    AstronomyEntry entry = db.AstronomyEntries.Where(en => en.IDEntry == int.Parse(row.Cells[0].Value.ToString())).FirstOrDefault();
                    entry.Name = row.Cells["Name"].Value.ToString();
                    db.Entry(entry).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
    }
}
