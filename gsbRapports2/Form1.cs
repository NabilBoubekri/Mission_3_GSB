using gsbRapports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gsbRapports2
{
    public partial class Form1 : Form
    {
        private gsbrapportsEntities mesDonneesVisiteur;
        public Form1()
        {
            this.InitializeComponent();
            this.mesDonneesVisiteur = new gsbrapportsEntities();
        }

        private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void gérerToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            gererVisiteurs gV1 = new gererVisiteurs(mesDonneesVisiteur);
            //gV1.MdiParent = this;
            gV1.Show();
        }

        private void quitterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rapportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListeRapport lstR = new ListeRapport(mesDonneesVisiteur);
            lstR.Show();
        }
    }
}
