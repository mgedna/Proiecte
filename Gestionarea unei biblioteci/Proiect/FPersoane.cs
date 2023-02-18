using System;
using System.Data;
using System.Windows.Forms;


namespace Proiect
{
    public partial class FPersoane : Form
    {
        public FPersoane()
        {
            InitializeComponent();
        }

        private void FPersoane_Load(object sender, EventArgs e)
        {
            //A1
            config(true);
            refresh();
        }

        private void config(bool v)
        {
            dataGridView1.AllowUserToAddRows = !v;
            dataGridView1.AllowUserToDeleteRows = !v;
            dataGridView1.ReadOnly = v;

            btnActualizare.Enabled = v;

            btnSalvare.Visible = !v;
            btnRenuntare.Visible = !v;
        }

        private void refresh()
        {
            persoaneTableAdapter.Fill(dataSet1.Persoane);
        }

        private void btnActualizare_Click(object sender, EventArgs e)
        {
            //A2
            config(false);
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
            if (!completareCampuri()) return;
            try
            {
                persoaneTableAdapter.Update(dataSet1.Persoane);
                config(true);
                refresh();
            }
            catch (Exception exc)
            {
                string s = exc.Message;
                //MessageBox.Show(s);
                if (s.IndexOf("valori dublate") > 0)
                    MessageBox.Show("Inregistrare deja existenta !");
                else if (s.IndexOf("Imposibil de șters") == 0)
                    MessageBox.Show("Ati sters inregistrari referite in alte tabele !");
            }

        }

        private void btnRenuntare_Click(object sender, EventArgs e)
        {
            //A3
            config(true);
            refresh();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Format eronat");
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            const string mesaj = "Confirmati stergerea";
            const string titlu = "Stergere inregistrare";
            var rezultat = MessageBox.Show(mesaj, titlu, MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning);
            if (rezultat == DialogResult.No) e.Cancel = true;
        }

        private bool completareCampuri()
        {
            bool raspuns = true;
            foreach (DataRow r in dataSet1.Persoane)
            {
                if (r.RowState == DataRowState.Deleted) continue;
                if (r["Nume"] == DBNull.Value)
                {
                    MessageBox.Show("Completati Nume la linia cu Id " + r["IdPersoana"]);
                    raspuns = false;
                }
               
            }
            return raspuns;
        }
    }
}
