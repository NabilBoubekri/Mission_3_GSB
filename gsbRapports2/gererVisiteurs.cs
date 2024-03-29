using gsbRapports2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace gsbRapports
{
    public partial class gererVisiteurs : Form
    {
        private gsbrapportsEntities gV1;
        public gererVisiteurs(gsbrapportsEntities gV1)
        {
            InitializeComponent();
            this.gV1 = gV1;
            this.bindingSource1.DataSource = gV1.visiteur.ToList();
        }

        private void gererVisiteurs_Load(object sender, EventArgs e)
        {

        }
        private visiteur newVisiteur()
        {
            visiteur v = new visiteur();
            v.id = textBox8.Text;
            v.nom = textBox1.Text;
            v.prenom = textBox2.Text;
            v.login= textBox3.Text;
            v.mdp= textBox4.Text;
            v.adresse= textBox5.Text;
            v.cp = textBox6.Text ;
            v.ville = textBox7.Text ;
            v.dateEmbauche = dateTimePicker1.Value;
            return v ;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.bindingSource1.EndEdit();
            try
            {
                this.gV1.visiteur.Add(newVisiteur());
                this.gV1.SaveChanges();
                MessageBox.Show("Enregistrement Validé");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement : {ex.Message}");
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            using (var context = new gsbrapportsEntities())
            {
                var idASupprimer = textBox8.Text;
                var entiteASupprimer = context.visiteur.FirstOrDefault(vi => vi.id == idASupprimer);
                //var entiteASupprimer2 = context.rapport.FirstOrDefault(rapport => rapport.idVisiteur == idASupprimer);
                /*var reqId = (from ra in this.gV1.rapport
                             where ra.idVisiteur == idASupprimer
                             select ra
                             );*/
                var rapportsASupprimer = this.gV1.rapport.Where(ra => ra.idVisiteur == idASupprimer);
                int compteur = rapportsASupprimer.Count();
                if(compteur > 0)
                {
                    DialogResult result = MessageBox.Show($"Il y a {compteur} rapport(s) lié(s) à ce visiteur. Êtes-vous sûr de vouloir supprimer ?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        this.gV1.rapport.RemoveRange(rapportsASupprimer);
                        this.gV1.SaveChanges();
                        MessageBox.Show("Les rapports ont été supprimés avec succès.");
                    }
                    else if(result == DialogResult.No)
                    {
                        MessageBox.Show("Suppression annulée.");
                        /* TEST XML
                         * XElement contacts =
                            new XElement("Contacts",
                                new XElement("Contact",
                                    new XElement("Name", entiteASupprimer.prenom),
                                    new XElement("Phone", "206-555-0144"),
                                    new XElement("Address",
                                        new XElement("Street1", entiteASupprimer.adresse),
                                        new XElement("City", "Mercer Island"),
                                        new XElement("State", "WA"),
                                        new XElement("Postal", "68042")
                                    )
                                )
                            );
                        MessageBox.Show(contacts.ToString());*/
                    }
                }
                else if (entiteASupprimer != null)
                {
                    context.visiteur.Remove(entiteASupprimer);
                    context.SaveChanges();
                    bindingSource1.RemoveCurrent();
                    MessageBox.Show("Enregistrer supprimé");
                }
                    //A FINIR **********************************************************
                    /*var reqDel = (from ra in this.gV1.rapport
                                  where ra.idVisiteur == idASupprimer
                                  delete ra
                                  );
                    **********************************************************************/
                    /*if (entiteASupprimer != null)
                    {
                        /*if(entiteASupprimer2 != null)
                        {
                            context.rapport.Remove(entiteASupprimer2);
                        }*/
                    /*context.visiteur.Remove(entiteASupprimer);
                    context.SaveChanges();
                    bindingSource1.RemoveCurrent();
                    MessageBox.Show("Enregistrer supprimé");
                }*/
                }
            }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //**A FINIR **

            this.gV1.SaveChanges();
            MessageBox.Show("Modification Validé");
            /*
            try
            {
                this.gV1.SaveChanges();
                MessageBox.Show("Modification Validé");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification : {ex.Message}");
            }*/
        }

        private void xmlRapport()
        {
            /*var idASupprimer = textBox8.Text;
            var entiteASupprimer = context.visiteur.FirstOrDefault(vi => vi.id == idASupprimer);

            XElement contacts =
                            new XElement("Rapports",
                                new XElement("Rapport",
                                    new XElement("Name", entiteASupprimer.prenom),
                                    new XElement("Phone", "206-555-0144"),
                                    new XElement("Address",
                                        new XElement("Street1", entiteASupprimer.adresse),
                                        new XElement("City", "Mercer Island"),
                                        new XElement("State", "WA"),
                                        new XElement("Postal", "68042")
                                    )
                                )
                            );
            MessageBox.Show(contacts.ToString());*/
        }
    }
}
