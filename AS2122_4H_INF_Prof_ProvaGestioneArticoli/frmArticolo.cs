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
    public partial class frmArticolo : Form
    {
        DialogResult status = DialogResult.Cancel;

        // TODO: (5) aggiungere attributi privati dei dati inseriti nella frmArticoli
        string descrizione;
        string unitaMisura;
        double prezzo;
        int id;

        public DialogResult Status { get { return status; } }

        // TODO: (6) aggiungere property di sola lettura dei dati inseriti nella frmArticoli per l'utilizzo in frmMain
        public string Descrizione { get { return descrizione; } }
        public string UnitaMisura { get { return unitaMisura; } }
        public double Prezzo { get { return prezzo; } }
        public int Id { get { return id; } }

        public frmArticolo()
        {
            InitializeComponent();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            string descrizione, misura;
            double prezzo;

            // TODO: (7) passaggio all' attributo/property dei dati inseriti nella frmArticoli con controllo di valorizzazione del dato
            // ... descrizione, unitaMisura, prezzo

            if(txtDescrizione.Text != "" && txtPrezzo.Text != "" && cmbUnitaMisura.SelectedIndex != -1)
            {
                try { prezzo = Double.Parse(txtPrezzo.Text); }
                catch { prezzo = -1; }

                descrizione = txtDescrizione.Text;
                misura = cmbUnitaMisura.SelectedItem.ToString();

                if(prezzo  > 0)
                {
                    this.prezzo = prezzo;
                    this.descrizione = descrizione;
                    this.unitaMisura = misura;

                    status = DialogResult.OK;
                    Close();
                }
                else { MessageBox.Show("Inserire dati corretti"); }
            }
            else { MessageBox.Show("Compilare tutti i campi"); }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            status = DialogResult.Cancel;
            Close();
        }
    }
}
