using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class FImprumuturiAct : Form
    {
        private OleDbConnection con = new OleDbConnection();
        private OleDbCommand cmd = new OleDbCommand();
        private OleDbDataReader rdr;
        private int idCda;
        public BindingSource bs1;
        public BindingSource bs2;

        public FImprumuturiAct()
        {
            InitializeComponent();
        }

        public void completeazaTitlu(String titlu)
        {
            lblOp.Text = titlu;
        }


        private void FImprumuturiAct_Load(object sender, EventArgs e)
        {
            A1();
        }

        private void completeazaImprumut()
        {
            DataRowView current = (DataRowView)bs1.Current;

            idCda = (int)current["IdImprumut"];
            txtNrImprumut.Text = Convert.ToString(current["IdImprumut"]);

            cmbPersoana.Text = current["Nume"].ToString();
            txtTotal.Text = current["Total"].ToString();

            dateTimePicker1.Value = Convert.ToDateTime(current["DataImprumut"]);

            bs2.MoveFirst();

            dataSet1.ImprumutContinutManevra.Clear();


            for (int i = 1; i <= bs2.Count; i++)
            {
                current = (DataRowView)bs2.Current;

                DataSet1.ImprumutContinutManevraRow r = dataSet1.ImprumutContinutManevra.NewImprumutContinutManevraRow();
                r.NrCrt = Convert.ToInt16(current["Nrc"]);
                r.Titlu = Convert.ToString(current["Titlu"]);
                r.NrInventar = Convert.ToInt32(current["NrInventar"]);
                r.TarifZi = Convert.ToDecimal(current["TarifZi"]);
                r.PerioadaImprumut = Convert.ToDecimal(current["NrZile"]);
                r.Valoare = Convert.ToDecimal(current["Valoare"]);
                r.IdCarte = Convert.ToInt32(current["IdCarte"]);
                con.ConnectionString = cartiTableAdapter.Connection.ConnectionString;

                cmd.Connection = con;
                cmd.CommandText = "SELECT SpImagine FROM Carti WHERE IdCarte = " + r.IdCarte;

                con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                r.SpImagine = rdr.GetString(0);
                rdr.Close();
                con.Close();

                dataSet1.ImprumutContinutManevra.Rows.Add(r);
                bs2.MoveNext();
            }
        }



        private void A1()
        {
            //Incarcare DataTable Carti
            cartiTableAdapter.Fill(dataSet1.Carti);

            //Incarcare DataTable Persoane
            persoaneTableAdapter.Fill(dataSet1.Persoane);

            // Protectie la modificare
            txtNrImprumut.ReadOnly = true;
            txtTotal.ReadOnly = true;
            nrCrtDataGridViewTextBoxColumn.ReadOnly = true;
            nrInventarDataGridViewTextBoxColumn.ReadOnly = true;
            tarifZiDataGridViewTextBoxColumn.ReadOnly = true;
            idCarteDataGridViewTextBoxColumn.ReadOnly = true;
            spImagineDataGridViewTextBoxColumn.ReadOnly = true;

            txtNrImprumut.Visible = false;
            label1.Visible = false;

            
            if (lblOp.Text == "MODIFICARE IMPRUMUT") completeazaImprumut();
            else if (lblOp.Text == "IMPRUMUT NOU") cmbPersoana.SelectedIndex = -1; // Initializare cmbPersoana

        }

        private void A2()
        {
            if (!validareCampuriObligatorii()) return;            
            if (lblOp.Text == "MODIFICARE IMPRUMUT")
            {
                modificaInregistrare();
                stergeContinut();
                adaugaInregistrariImprumuturiContinut();
                this.Close();
            }
            else if (lblOp.Text == "IMPRUMUT NOU")
            {

                // Scriu inregistrare in Imprumuturi si ImprumuturiContinut
                generez_nr_cda();
                adaugaInregistrareImprumuturi();
                //generez_nr_cda();
                cautaInregistrare();
                adaugaInregistrariImprumuturiContinut();
                MessageBox.Show("Imprumut adaugat cu succes!");
                golireCampuri();
            }

        }

        private void A3()
        {
            // Generare NrCrt
            DataRowView current = (DataRowView)imprumutContinutManevraBindingSource.Current;
            current["NrCrt"] = imprumutContinutManevraBindingSource.Position + 1;
        }

        private void A4()
        {
            try
            {
                if (dataGridView1.CurrentCell.ColumnIndex == 1)
                {
                    DataRowView current = (DataRowView)cartiBindingSource.Current;

                    dataGridView1.CurrentRow.Cells[2].Value = current["NrInventar"];
                    dataGridView1.CurrentRow.Cells[3].Value = current["TarifZi"];
                    dataGridView1.CurrentRow.Cells[6].Value = current["IdCarte"];
                    dataGridView1.CurrentRow.Cells[7].Value = current["SpImagine"];
                    calcTotal();
                }
                if (dataGridView1.CurrentCell.ColumnIndex == 4)
                {
                    imprumutContinutManevraBindingSource.EndEdit();
                    calcTotal();
                }
            }
            catch { }
        }

        private void A5(DataGridViewRowCancelEventArgs e)
        {

            const string mesaj = "Confirmati stergerea";
            const string titlu = "Stergere inregistrare";
            var rezultat = MessageBox.Show(mesaj, titlu,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (rezultat == DialogResult.No) e.Cancel = true;
        }

        private void imprumutContinutManevraBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            A3();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            A4();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            A5(e);
        }


        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Format eronat");
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            calcTotal();
        }

        private void btnConfirmare_Click(object sender, EventArgs e)
        {
            A2();
            //this.Close();
        }

        private void adaugaInregistrareImprumuturi()
        {
            con.ConnectionString = cartiTableAdapter.Connection.ConnectionString;
            cmd.Connection = con;

            string listaCampuri;
            string listaValori;
            DateTime d = dateTimePicker1.Value;

            listaCampuri = "IdImprumut, DataImprumut, IdPersoana";
            listaValori = Convert.ToString(txtNrImprumut.Text)
                               + ",#" + Convert.ToString(d.Month) + "/"
                               + Convert.ToString(d.Day) + "/"
                               + Convert.ToString(d.Year) + "#,"
                               + cmbPersoana.SelectedValue;

            cmd.CommandText = "Insert into Imprumuturi(" + listaCampuri + ") " +
                              "Select " + listaValori;

            //MessageBox.Show(cmd.CommandText);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void cautaInregistrare()
        {
            cmd.CommandText = "SELECT idImprumut From Imprumuturi Where IdImprumut = " + txtNrImprumut.Text;

            con.Open();
            rdr = cmd.ExecuteReader();
            rdr.Read();

            idCda = rdr.GetInt32(0);
            rdr.Close();
            con.Close();
        }

        private void adaugaInregistrariImprumuturiContinut()
        {
            string listaCampuri = "IdImprumut, Nrc, NrInventar, IdCarte, TarifZi, NrZile";
            string listaValori;

            con.Open();
            foreach (DataRow r in dataSet1.ImprumutContinutManevra)
            {
                listaValori = idCda + "," + r["NrCrt"] + "," + r["NrInventar"] + "," + r["IdCarte"] + "," +
r["TarifZi"] + "," + r["PerioadaImprumut"];

                cmd.CommandText = "Insert into ImprumuturiContinut(" + listaCampuri + ") " +
"Select " + listaValori;

                
                cmd.ExecuteNonQuery();
                
            }
            con.Close();
        }

        private void golireCampuri()
        {
            txtNrImprumut.Text = "";
            cmbPersoana.SelectedIndex = -1;
            txtTotal.Text = "";
            dataSet1.ImprumutContinutManevra.Clear();
        }

        private void calcTotal()
        { // Calcul total valori
            decimal t = 0;
            foreach (DataRow r in dataSet1.ImprumutContinutManevra)
            {
                if (r["Valoare"] != DBNull.Value)
                    t += (decimal)r["Valoare"];
            }

            txtTotal.Text = Convert.ToString(t);
        }


        private void generez_nr_cda()
        {
            con.ConnectionString = cartiTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;
            cmd.CommandText = "SELECT Max(Imprumuturi.IdImprumut) AS NrMax FROM Imprumuturi";

            con.Open();
            rdr = cmd.ExecuteReader();
            rdr.Read();
            if (!rdr.IsDBNull(0))
                txtNrImprumut.Text = Convert.ToString(rdr.GetInt32(0) + 1);
            else
                txtNrImprumut.Text = Convert.ToString(1);
            rdr.Close();
            con.Close();
            
        }

        private bool validareCampuriObligatorii()
        {
            //Validare de completare obligatorie campul Persoana
            if (cmbPersoana.Text == "")
            {
                MessageBox.Show("Completati Persoana !");
                cmbPersoana.Focus();
                return false;
            }

            // Validare completare continut
            if (imprumutContinutManevraBindingSource.Count == 0)
            {
                MessageBox.Show("Completati continut imprumut !");
                dataGridView1.Focus();
                return false;
            }

            // Validare completare PeriodaImprumut
            foreach (DataRow r in dataSet1.ImprumutContinutManevra)
            {
                if (r.RowState == DataRowState.Deleted) continue;
                if (r["Titlu"] == DBNull.Value)
                {
                    MessageBox.Show("Completati Titlu la linia " + r["NrCrt"]);
                    return false;
                }
                if (r["PerioadaImprumut"] == DBNull.Value)
                {
                    MessageBox.Show("Completati PerioadaImprumut la linia " + r["NrCrt"]);
                    return false;
                }
            }
                if (imprumutContinutManevraBindingSource.Count == 0)
            {
                MessageBox.Show("Completati continut imprumut !");
                dataGridView1.Focus();
                return false;
            }
            return true;
        }

        private void modificaInregistrare()
        {
            DateTime d1 = dateTimePicker1.Value;

            con.ConnectionString = cartiTableAdapter.Connection.ConnectionString;
            cmd.Connection = con;

            string clauzaWhere = " Where IdImprumut = " + idCda;

            string clauzaSet = "Set DataImprumut = #" + d1.Month + "/"
                               + d1.Day + "/"
                               + d1.Year + "#,"
                               + "IdPersoana = " + cmbPersoana.SelectedValue;

            cmd.CommandText = "Update Imprumuturi " + clauzaSet + clauzaWhere;

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void stergeContinut()
        {
            cmd.CommandText = "Delete from ImprumuturiContinut Where IdImprumut = " + idCda;

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void btnPersoane_Click(object sender, EventArgs e)
        {
            Persoane f = new Persoane();
            f.SetMaster(this);
            f.SetSelectVisible();
            f.ShowDialog();

        }

        public void refreshPersoane(int pozitie)
        {
            persoaneTableAdapter.Fill(dataSet1.Persoane);
            cmbPersoana.SelectedIndex = pozitie;
        }

        
    }
}