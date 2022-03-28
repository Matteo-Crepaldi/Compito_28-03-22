using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AS2122_4H_INF_Prof_ProvaGestioneArticoli
{
    public partial class frmMain : Form
    {
        List<Articolo> articoli;

        public frmMain()
        {
            InitializeComponent();

            // TODO: (4) creazione lista articoli
            articoli = new List<Articolo>();
        }

        private void btnAggiungiArticolo_Click(object sender, EventArgs e)
        {
            string misura, descrizione;
            double prezzo;
            int id;

            frmArticolo f = new frmArticolo();

            f.ShowDialog();

            if (f.Status == DialogResult.OK)
            {
                // aggiungi l'articolo all'elenco di articoli
                // TODO: (1) aggiungere l'articolo creato dai dati di frmArticoli nella lista articoli

                misura = f.UnitaMisura;
                descrizione = f.Descrizione;
                prezzo = f.Prezzo;
                id = GetID();

                Articolo a = new Articolo(id, descrizione, misura, prezzo);
                articoli.Add(a);

                lblArticoliInseriti.Text = $"Articoli ({articoli.Count})";
            }
        }

        private int GetID()
        {
            if (articoli.Count == 0) return 0;
            else return articoli[articoli.Count - 1].Codice + 1;
        }

        private void btnVisualizza_Click(object sender, EventArgs e)
        {
            lstElenco.Items.Clear();

            switch (cmbVisualizza.Text)
            {
                case "Visualizza articoli":
                    // TODO: (2) aggiungere visualizzazione articoli inseriti nella listbox
                    foreach(Articolo a in articoli) lstElenco.Items.Add(a.Visualizzati());
                    break;
            }
        }

        private void lstElenco_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = lstElenco.SelectedItem.ToString();

            // Find the string in ListBox.
            int index = lstElenco.FindString(curItem);

            // TODO: (3) aggiungere visualizzazione dettaglio articolo nelle label
            if(index != -1)
            {
                Articolo art = articoli[index];

                lblDescrizione.Text = art.Descrizione;
                lblPrezzo.Text = art.Prezzo.ToString();
                lblUnitaMisura.Text = art.UnitaMisura;
            }
            else
            {
                lblDescrizione.Text = "...";
                lblPrezzo.Text = "...";
                lblUnitaMisura.Text = "...";
            }
        }
    }
}
