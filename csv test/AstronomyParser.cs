using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csv_test
{
    static class AstronomyParser
    {
        public static List<AstronomyEntry> fillSQLEntry(DataTable dt)
        {
            List<AstronomyEntry> entries = new List<AstronomyEntry>();
            dt.Rows.GetType().GetProperties();
            //foreach (DataRow row in dt.Rows)
            for (int i = 0; i < 1000; i++)
            {
                DataRow row = dt.Rows[i];
                AstronomyEntry entry = new AstronomyEntry();
                bool validation;

                entry.IDEntry = Convert.ToInt32(row["id"]);
                validation = int.TryParse(row["id"].ToString(), out int id);
                entry.IDEntry = id;

                validation = int.TryParse(row["hip"].ToString(), out int hip);
                entry.Hip = hip;


                validation = int.TryParse(row["hd"].ToString(), out int hd);
                entry.Hd = hd;

                validation = int.TryParse(row["hr"].ToString(), out int hr);
                entry.Hr = hr;

                validation = int.TryParse(row["gl"].ToString(), out int gl);
                entry.Gl = gl;

                validation = int.TryParse(row["bf"].ToString(), out int bf);
                entry.Bf = bf;

                entry.Proper = row["proper"].ToString();

                validation = int.TryParse(row["ra"].ToString(), out int ra);
                entry.Ra = ra;

                validation = int.TryParse(row["dec"].ToString(), out int dec);
                entry.Dec = dec;

                validation = decimal.TryParse(row["dist"].ToString(), out decimal dist);
                entry.Dist = dist;

                validation = decimal.TryParse(row["pmra"].ToString(), out decimal pmra);
                entry.Pmra = pmra;

                validation = decimal.TryParse(row["pmdec"].ToString(), out decimal pmdec);
                entry.Pmdec = pmdec;

                validation = decimal.TryParse(row["rv"].ToString(), out decimal rv);
                entry.Rv = rv;

                entry.Mag = Convert.ToDecimal(row["mag"]);

                validation = decimal.TryParse(row["absmag"].ToString(), out decimal absmag);
                entry.Absmag = absmag;

                entry.Spect = row["spect"].ToString();

                validation = decimal.TryParse(row["ci"].ToString(), out decimal ci);
                entry.Ci = ci;

                validation = decimal.TryParse(row["x"].ToString(), out decimal x);
                entry.X = x;

                validation = decimal.TryParse(row["y"].ToString(), out decimal y);
                entry.Y = y;

                validation = decimal.TryParse(row["z"].ToString(), out decimal z);
                entry.Z = z;

                validation = decimal.TryParse(row["vx"].ToString(), out decimal vx);
                entry.Vx = vx;

                validation = decimal.TryParse(row["vy"].ToString(), out decimal vy);
                entry.Vy = vy;

                validation = decimal.TryParse(row["vz"].ToString(), out decimal vz);
                entry.Vz = vz;

                validation = decimal.TryParse(row["rarad"].ToString(), out decimal rarad);
                entry.Rrad = rarad;

                validation = decimal.TryParse(row["decrad"].ToString(), out decimal decrad);
                entry.Decrad = decrad;

                validation = decimal.TryParse(row["pmrarad"].ToString(), out decimal pmrarad);
                entry.Pmrarad = pmrarad;

                validation = decimal.TryParse(row["pmdecrad"].ToString(), out decimal pmdecrad);
                entry.Pmdecrad = pmdecrad;

                entry.Bayer = row["bayer"].ToString();

                validation = int.TryParse(row["flam"].ToString(), out int flam);
                entry.Flam = flam;

                entry.Con = row["con"].ToString();

                validation = int.TryParse(row["comp"].ToString(), out int comp);
                entry.Comp = comp;

                validation = int.TryParse(row["comp_primary"].ToString(), out int comp_primary);
                entry.Comp_primary = comp_primary;

                entry.Base = row["base"].ToString();

                validation = decimal.TryParse(row["lum"].ToString(), out decimal lum);
                entry.Lum = lum;

                entry.Var = row["var"].ToString();
                validation = decimal.TryParse(row["var_min"].ToString(), out decimal var_min);

                entry.Var_min = var_min;
                validation = decimal.TryParse(row["var_max"].ToString(), out decimal var_max);
                entry.Var_max = var_max;

                if (!validation)
                {
                    //throw new Exception("error parsing astronomy row");
                }
                entries.Add(entry);
            }
            return entries;
        }

        public static DataTable readCSV(string filePath)
        {
            var dt = new DataTable();
            
            File.ReadLines(filePath).Take(1)
                .SelectMany(x => x.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(x => dt.Columns.Add(x.Trim()));

            File.ReadLines(filePath).Skip(1)
                .Select(x => x.Split(','))
                .ToList()
                .ForEach(line => dt.Rows.Add(line));
            return dt;
        }

    }
}
