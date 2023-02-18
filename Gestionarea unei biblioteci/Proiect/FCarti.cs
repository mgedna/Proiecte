using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Proiect
{
    public partial class FCarti : Form
    {
        public FCarti()
        {
            InitializeComponent();
        }

        private void FCarti_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Carti' table. You can move, or remove it, as needed.
            this.cartiTableAdapter.Fill(this.dataSet1.Carti);
            A1();
        }

        private void btnAdaugare_Click(object sender, EventArgs e)
        {
            A2();
        }

        private void btnRenuntare_Click(object sender, EventArgs e)
        {
            A3();
        }

        private void btnConfirmare_Click(object sender, EventArgs e)
        {
            A4();
        }

        private void txtNr_Leave(object sender, EventArgs e)
        {
            A5(txtNr);
        }

        private void txtTarif_Leave(object sender, EventArgs e)
        {
            A5(txtTarif);
        }

        private void txtSpImagine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            A6();
        }

        private void btnModificare_Click(object sender, EventArgs e)
        {
            A7();
        }

        private void btnStergere_Click(object sender, EventArgs e)
        {
            const string mesaj = "Confirmati stergerea";
            const string titlu = "Stergere inregistrare";
            var rezultat = MessageBox.Show(mesaj, titlu, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rezultat == DialogResult.No) return;
            A8();
        }

        private void A1()
        {

            //Umple cu date obiectele DataTable: Persoane, Localitati (din DataSet):
            cartiTableAdapter.Fill(dataSet1.Carti);

            //Configurare PB
            PB.SizeMode = PictureBoxSizeMode.StretchImage;

            //Protectie grid 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            //Protectie txtIdPersoana
            txtId.ReadOnly = true;

            A3();
        }

        private void A2()
        {
            //Configurare butoane
            configureazaButoane(false);

            //Dezlegare controale Panel
            legareControale(false);

            //Ridicare protectie controale Panel
            protectiePanel(false);

            //Modifcare lblOp
            lblOp.Text = "ADAUGARE";

            //Pozitionare cursor pe primul camp
            txtTitlu.Focus();

            // Golire campuri
            golireCampuri();
        }

        private void A3()
        {

            //Initializare lblOp
            lblOp.Text = "";

            //Çonfigurare(butoane)
            configureazaButoane(true);

            //Protectie componente Panel
            protectiePanel(true);

            //Legare controale
            legareControale(true);
        }

        private void A4()
        {
            if (lblOp.Text == "ADAUGARE")
            {
                if (!validareCampuriObligatorii()) return;

                adauga_inregistrare();

                golireCampuri();

                //Pune cursor pe primul camp
                txtTitlu.Focus();
                refresh_grid(cartiBindingSource.Position);
            }
            else if (lblOp.Text == "MODIFICARE")
            {
                modifica_inregistrare();
                refresh_grid(cartiBindingSource.Position);
                A3();
            }
            else
                MessageBox.Show("Operatie actualizare neefectuata");
        }

        private void A5(TextBox txtB)
        {
            decimal p;
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader r;

            if (lblOp.Text == "") return;
            if (txtB.Text == "") return;
            if (btnRenuntare.Focused) return;

            if (txtB == txtTarif)
            {
                // Validare numericitate
                try { p = Convert.ToDecimal(txtB.Text); }
                catch { MessageBox.Show("Format eronat"); txtB.Focus(); }
                return;
            }

            if (txtB == txtNr)
            {
                // Validare numericitate
                try { p = Convert.ToDecimal(txtB.Text); }
                catch { MessageBox.Show("Format eronat"); txtB.Focus(); }
                con.ConnectionString = cartiTableAdapter.Connection.ConnectionString;
                cmd.Connection = con;

                if (lblOp.Text == "ADAUGARE")
                {
                    cmd.CommandText = "Select Titlu From Carti where NrInventar='" + txtNr.Text + "'";
                    con.Open();
                    r = cmd.ExecuteReader();
                    if (r.Read())
                    {
                        MessageBox.Show("Nr. inventar deja existent");
                        txtNr.Focus();
                    }
                    con.Close();
                }

                else if (lblOp.Text == "MODIFICARE")
                {
                    cmd.CommandText = "Select Titlu From Carti where NrInventar='" + Convert.ToDecimal(txtNr.Text) +
                                      "' and IdCarte <> " + txtId.Text;
                    con.Open();
                    r = cmd.ExecuteReader();
                    if (r.Read())
                    {
                        MessageBox.Show("Nr. inventar deja existent");
                        txtNr.Focus();
                    }
                    con.Close();
                }
            }
        }

        private void A6()
        {
            if (lblOp.Text == "")
                return;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSpImagine.Text = openFileDialog1.FileName;
                PB.ImageLocation = txtSpImagine.Text;
            }
        }

        private void A7()
        {
            //Configurare butoane
            configureazaButoane(false);

            //Dezlegare controale Panel
            legareControale(false);

            //Ridicare protectie controale Panel
            protectiePanel(false);

            //Modifcare lblOp
            lblOp.Text = "MODIFICARE";

            //Pozitionare cursor pe primul camp
            txtTitlu.Focus();
        }

        private void A8()
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader r;

            con.ConnectionString = cartiTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            cmd.CommandText = "Select IdImprumut From ImprumuturiContinut where IdCarte=" + txtId.Text;
            con.Open();
            r = cmd.ExecuteReader();
            if (r.Read())
            {
                MessageBox.Show("Carte referita in tabela ImprumuturiContinut! Nu se poate sterge!");
                con.Close();
                return;
            }
            con.Close();

            con.ConnectionString = cartiTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            cmd.CommandText = "Delete From Carti Where IdCarte = " + txtId.Text;

            MessageBox.Show(cmd.CommandText);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            refresh_grid(cartiBindingSource.Position);

        }

        private void configureazaButoane(bool v)
        {
            btnRenuntare.Visible = !v;
            btnConfirmare.Visible = !v;

            btnAdaugare.Enabled = v;
            btnModificare.Enabled = v;
            btnStergere.Enabled = v;
        }

        private void legareControale(bool v)
        {
            if (v)
            {
                txtTitlu.DataBindings.Add("Text", cartiBindingSource, "Titlu");
                txtAutor.DataBindings.Add("Text", cartiBindingSource, "Autor");
                txtNr.DataBindings.Add("Text", cartiBindingSource, "NrInventar");
                txtTarif.DataBindings.Add("Text", cartiBindingSource, "TarifZi");
                txtSpImagine.DataBindings.Add("Text", cartiBindingSource, "SpImagine");
                txtId.DataBindings.Add("Text", cartiBindingSource, "IdCarte");
                PB.DataBindings.Add("ImageLocation", cartiBindingSource, "SpImagine");
            }
            else
            {
                txtTitlu.DataBindings.Clear();
                txtAutor.DataBindings.Clear();
                txtNr.DataBindings.Clear();
                txtTarif.DataBindings.Clear();
                txtSpImagine.DataBindings.Clear();
                txtId.DataBindings.Clear();
                PB.DataBindings.Clear();
            }
        }

        private void protectiePanel(bool v)
        {
            txtTitlu.ReadOnly = v;
            txtAutor.ReadOnly = v;
            txtNr.ReadOnly = v;
            txtTarif.ReadOnly = v;
            txtSpImagine.ReadOnly = v;
        }

        private void golireCampuri()
        {
            txtTitlu.Text = "";
            txtAutor.Text = "";
            txtId.Text = "";
            txtNr.Text = "";
            txtTarif.Text = "";
            txtSpImagine.Text = "";
            PB.ImageLocation = "";
        }

        private bool validareCampuriObligatorii()
        {
            //Validare de completare obligatorie campurile: Nume, CNP, Salariu, Localitate
            if (txtTitlu.Text == "")
            {
                MessageBox.Show("Completati Titlu !");
                txtTitlu.Focus();
                return false;
            }
            if (txtAutor.Text == "")
            {
                MessageBox.Show("Completati Autor !");
                txtAutor.Focus();
                return false;
            }
            if (txtNr.Text == "")
            {
                MessageBox.Show("Completati NrInventar !");
                txtNr.Focus();
                return false;
            }

            if (txtTarif.Text == "")
            {
                MessageBox.Show("Completati Tarif Zi !");
                txtTarif.Focus();
                return false;
            }

            return true;
        }

        private void adauga_inregistrare()
        {
            string listaCampuri;
            string listaValori;

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            con.ConnectionString = cartiTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            listaCampuri = "Titlu, Autor, NrInventar, TarifZi, SpImagine";
            listaValori = "'" + txtTitlu.Text + "'" +
                          ",'" + txtAutor.Text + "'" +
                          "," + txtNr.Text +
                          "," + txtTarif.Text +
                          ",'" + txtSpImagine.Text + "',";

            cmd.CommandText = "Insert into Carti(" + listaCampuri + ") " +
                              "Select " + listaValori;

            MessageBox.Show(cmd.CommandText);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void refresh_grid(int p)
        {
            cartiTableAdapter.Fill(dataSet1.Carti);
            cartiBindingSource.Position = p;
        }

        private void modifica_inregistrare()
        {
            string listaSet;

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            con.ConnectionString = cartiTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            listaSet = "'" + txtTitlu.Text + "'" +
                          ",'" + txtAutor.Text + "'" +
                          "," + txtNr.Text +
                          "," + txtTarif.Text +
                          ",'" + txtSpImagine.Text + "',";

            cmd.CommandText = "Update Carti Set " + listaSet + " Where IdCarte=" + txtId.Text;

            MessageBox.Show(cmd.CommandText);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
        }


    }
}

