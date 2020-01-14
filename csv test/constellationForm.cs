using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csv_test
{
    public partial class constellationForm : Form
    {
        private List<AstronomyEntry> top10Entries;
        private RectangleF sun;
        private List<RectangleF> stars = new List<RectangleF>();
        public constellationForm()
        {
            InitializeComponent();
            using (var db = new AstronomyLogsEntities())
            {
                top10Entries = db.AstronomyEntries.Take(10).ToList();
            }

            PointF sunPoint = new PointF(this.ClientSize.Width /5F, this.ClientSize.Height / 2F);
            sun = new RectangleF(sunPoint, new SizeF(10 * 2F, 10 * 2F));
        }

        private void constellationForm_Load(object sender, EventArgs e)
        {

        }

        private void generateStar(Graphics graphics, decimal? mag, decimal? dist)
        {
            PointF starPoint = new PointF(sun.X + Math.Abs((float)dist), this.ClientSize.Height / 2F);
            RectangleF star = new RectangleF(starPoint, new SizeF((float)mag * 1F, (float)mag * 1F));
            Pen penYellow = new Pen(Color.Yellow);
            SolidBrush fillYellow = new SolidBrush(Color.Yellow);
            graphics.DrawEllipse(penYellow, star);
            graphics.FillEllipse(fillYellow, star);
        }

        private void constellationForm_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            g.DrawLine(new Pen(Color.White), new PointF(0, ClientSize.Height / 2), new PointF(ClientSize.Width, ClientSize.Height / 2));
            g.DrawEllipse(new Pen(Color.Orange), sun);
            g.FillEllipse(new SolidBrush(Color.Orange), sun);

            top10Entries.ForEach(star => generateStar(g, star.Mag, star.Dist));
        }
    }
}
