using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Xml;

namespace gsbRapports2
{
    public partial class ListeRapport : Form
    {
        gsbrapportsEntities lstR;
        List<rapport> lstRapports;
        public ListeRapport(gsbrapportsEntities lstR)
        {
            InitializeComponent();
            this.lstR = lstR;
            this.dataGridView1.AutoGenerateColumns = false;
            this.comboBox1.DataSource = lstR.visiteur.ToList();
            this.comboBox1.DisplayMember = "id";
            this.comboBox1.ValueMember = "id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var idVisiteur = comboBox1.SelectedValue;

            dataGridView1.DataSource = lstR.rapport.Where(ra =>ra.idVisiteur == idVisiteur).ToList();
            DataGridViewTextBoxColumn motif = new DataGridViewTextBoxColumn();
            motif.HeaderText = "Motif";
            motif.Name = "motif";
            motif.DataPropertyName = "motif";
            this.dataGridView1.Columns.Add(motif);

            DataGridViewTextBoxColumn bilan = new DataGridViewTextBoxColumn();
            bilan.HeaderText = "Bilan";
            bilan.Name = "bilan";
            bilan.DataPropertyName = "bilan";
            this.dataGridView1.Columns.Add(bilan);

            DataGridViewTextBoxColumn idMedecin = new DataGridViewTextBoxColumn();
            idMedecin.HeaderText = "Id du medecin";
            idMedecin.Name = "idMedecin";
            idMedecin.DataPropertyName = "idMedecin";
            this.dataGridView1.Columns.Add(idMedecin);

            DataGridViewTextBoxColumn idVisitant = new DataGridViewTextBoxColumn();
            idVisitant.HeaderText = "Id du visiteur";
            idVisitant.Name = "idVisiteur";
            idVisitant.DataPropertyName = "idVisiteur";
            this.dataGridView1.Columns.Add(idVisitant);

            DataGridViewTextBoxColumn date = new DataGridViewTextBoxColumn();
            date.HeaderText = "Date de consultation";
            date.Name = "date";
            date.DataPropertyName = "date";
            this.dataGridView1.Columns.Add(date);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var idVisiteur = comboBox1.SelectedValue;

            var lesRapports = lstR.rapport.Where(ra => ra.idVisiteur == idVisiteur).ToList();

            XElement xmlRapport = new XElement("Rapports");

            foreach(var unRapport in lesRapports ) 
            {
                xmlRapport.Add(
                    new XElement("Rapport",
                        new XElement("id", unRapport.id),
                        new XElement("date", unRapport.date.ToString().Split(' ')[0]),
                        new XElement("motif", unRapport.motif),
                        new XElement("bilan", unRapport.bilan),
                        new XElement("idVisiteur", unRapport.idVisiteur),
                        new XElement("idMedecin", unRapport.idMedecin)
                        ));
            }
            xmlRapport.Save("C:/Users/nabil/Desktop/TestXml/rapports.xml");
            //MessageBox.Show(xmlRapport.ToString());
            /*XDocument RejectedXmlList = new XDocument
            (
                new XDeclaration("1.0", "utf-8", null)
            );
            RejectedXmlList.Add(xmlRapport);
            MessageBox.Show(RejectedXmlList.ToString());*/
        }
    }
}
