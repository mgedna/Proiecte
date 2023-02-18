using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class Persoane : Form
    {
        private Form master;
        private bool selectie;

        public Persoane()
        {
            InitializeComponent();
        }
        public void SetMaster(Form caller)
        {
            master = caller;
        }

        public void SetSelectVisible()
        {
            selectie = true;
        }

        private void Persoane_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Persoane' table. You can move, or remove it, as needed.
            this.persoaneTableAdapter.Fill(this.dataSet1.Persoane);
            //Configurare PB
            pb.SizeMode = PictureBoxSizeMode.StretchImage;

            //Protectie grid 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            btnSelectie.Visible = false;

            //Protectie txtIdPersoana
            txtId.ReadOnly = true;

            txtId.Visible = false;
            label6.Visible = false;

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
            txtNume.Focus();

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
                txtNume.Focus();
                refresh_grid(persoaneBindingSource.Position);
            }
            else if (lblOp.Text == "MODIFICARE")
            {
                modifica_inregistrare();
                refresh_grid(persoaneBindingSource.Position);
                A3();
            }
            else
                MessageBox.Show("Operatie actualizare neefectuata");
        }

        private void validareTel(TextBox txtB)
        {
            if (btnRenuntare.Focused) return;
            if (txtB.Text == "") return;
            if (txtB.Text.Length != 10)
            {
                MessageBox.Show("Format eronat");
                txtB.Focus();  
            }
            else
            {
                foreach (char c in txtB.Text)
                {
                    if (c < '0' || c > '9')
                    {
                        MessageBox.Show("Format eronat");
                        txtB.Focus();
                        return;
                    }
                }
            }
            
        }


        private void A5(TextBox txtB)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader r;

            if (lblOp.Text == "") return;
            if (txtB.Text == "") return;
            if (btnRenuntare.Focused) return;

            con.ConnectionString = persoaneTableAdapter.Connection.ConnectionString;
            cmd.Connection = con;

            if (lblOp.Text == "ADAUGARE")
            {
                cmd.CommandText = "Select IdPersoana From Persoane where Nume='" + txtNume.Text + "'";
                con.Open();
                r = cmd.ExecuteReader();
                if (r.Read())
                {
                    MessageBox.Show("Nume deja existent");
                    txtNume.Focus();
                }
                con.Close();
            }

            else if (lblOp.Text == "MODIFICARE")
            {
                cmd.CommandText = "Select IdPersoana From Persoane where Nume='" + txtNume.Text +
                                  "' and IdPersoana  <> " + txtId.Text;
                con.Open();
                r = cmd.ExecuteReader();
                if (r.Read())
                {
                    MessageBox.Show("Nume deja existent");
                    txtNume.Focus();
                }
                con.Close();
            }
        }

        private void A6()
        {
            if (lblOp.Text == "")
                return;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSpImagine.Text = openFileDialog1.FileName;
                pb.ImageLocation = txtSpImagine.Text;
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
            txtNume.Focus();
        }

        private bool verificareStergere()
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader r;

            con.ConnectionString = persoaneTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            cmd.CommandText = "Select IdPersoana From Imprumuturi where IdPersoana=" + txtId.Text;
            con.Open();
            r = cmd.ExecuteReader();
            if (r.Read())
            {
                MessageBox.Show("Persoana referita in tabela Imprumuturi! Nu se poate sterge!");
                con.Close();
                return false;
            }
            con.Close();
            return true;
        }

        private void A8()
        {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            //OleDbDataReader r;

            con.ConnectionString = persoaneTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            //cmd.CommandText = "Select IdPersoana From Imprumuturi where IdPersoana=" + txtId.Text;
            //con.Open();
            //r = cmd.ExecuteReader();
            //if (r.Read())
            //{
            //    MessageBox.Show("Client referit in tabela Imprumuturi! Nu se poate sterge!");
            //    con.Close();
            //    return;
            //}
            //con.Close();

            cmd.CommandText = "Delete From Persoane Where IdPersoana = " + txtId.Text;

            //MessageBox.Show(cmd.CommandText);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            refresh_grid(persoaneBindingSource.Position);

        }

        private void configureazaButoane(bool v)
        {
            btnRenuntare.Visible = !v;
            btnConfirmare.Visible = !v;

            btnAdaugare.Enabled = v;
            btnModificare.Enabled = v;
            btnStergere.Enabled = v;

            if (selectie) btnSelectie.Visible = v;
        }

        private void legareControale(bool v)
        {
            if (v)
            {
                txtNume.DataBindings.Add("Text", persoaneBindingSource, "Nume");
                txtAdresa.DataBindings.Add("Text", persoaneBindingSource, "Adresa");
                txtNrTel.DataBindings.Add("Text", persoaneBindingSource, "NrTelefon");
                txtSpImagine.DataBindings.Add("Text", persoaneBindingSource, "SpImagine");
                txtId.DataBindings.Add("Text", persoaneBindingSource, "IdPersoana");
                pb.DataBindings.Add("ImageLocation", persoaneBindingSource, "SpImagine");
            }
            else
            {
                txtNume.DataBindings.Clear();
                txtAdresa.DataBindings.Clear();
                txtNrTel.DataBindings.Clear();
                txtSpImagine.DataBindings.Clear();
                txtId.DataBindings.Clear();
                pb.DataBindings.Clear();
            }
        }
        private void protectiePanel(bool v)
        {
            txtNume.ReadOnly = v;
            txtNrTel.ReadOnly = v;
            txtAdresa.ReadOnly = v;
            txtSpImagine.ReadOnly = v;
        }
        private void golireCampuri()
        {
            txtNume.Text = "";
            txtNrTel.Text = "";
            txtId.Text = "";
            txtAdresa.Text = "";
            txtSpImagine.Text = "";
            pb.ImageLocation = "";
        }
        private bool validareCampuriObligatorii()
        {
            //Validare de completare obligatorie campurile: Nume, Adresa, Nr. Tel.
            if (txtNume.Text == "")
            {
                MessageBox.Show("Completati Nume !");
                txtNume.Focus();
                return false;
            }
            if (txtAdresa.Text == "")
            {
                MessageBox.Show("Completati Adresa !");
                txtAdresa.Focus();
                return false;
            }
            if (txtNrTel.Text == "")
            {
                MessageBox.Show("Completati Nr. Telefon !");
                txtNrTel.Focus();
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

            con.ConnectionString = persoaneTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            listaCampuri = "Nume, Adresa, NrTelefon, SpImagine";
            listaValori = "'" + txtNume.Text + "'" +
                          ",'" + txtAdresa.Text + "'" +
                          ",'" + txtNrTel.Text + "'" +
                          ",'" + txtSpImagine.Text + "'";

            cmd.CommandText = "Insert into Persoane(" + listaCampuri + ") " +
                              "Select " + listaValori;

            //MessageBox.Show(cmd.CommandText);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
        }
        private void refresh_grid(int p)
        {
            persoaneTableAdapter.Fill(dataSet1.Persoane);
            persoaneBindingSource.Position = p;
        }
        private void modifica_inregistrare()
        {
            string listaSet;

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            con.ConnectionString = persoaneTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            listaSet = "Nume = '" + txtNume.Text + "'," +
                       "Adresa = '" + txtAdresa.Text + "'," +
                       "NrTelefon = '" + txtNrTel.Text + "'," +
                       "SpImagine = '" + txtSpImagine.Text + "'";

            cmd.CommandText = "Update Persoane Set " + listaSet + " Where IdPersoana=" + txtId.Text;

            //MessageBox.Show(cmd.CommandText);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
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
        private void btnModificare_Click(object sender, EventArgs e)
        {
            A7();
        }

        private void btnStergere_Click(object sender, EventArgs e)
        {
            if (!verificareStergere())
            {
                return;
            }
            const string mesaj = "Confirmati stergerea";
            const string titlu = "Stergere inregistrare";
            var rezultat = MessageBox.Show(mesaj, titlu, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rezultat == DialogResult.No) return;
            A8();
        }

        private void txtSpPoza_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            A6();
        }

        private void txtNume_Leave(object sender, EventArgs e)
        {
            A5(txtNume);
        }

        private void btnSelectie_Click(object sender, EventArgs e)
        {
            FImprumuturiAct f = (FImprumuturiAct)master;
            f.refreshPersoane(persoaneBindingSource.Position);
            this.Close();
        }

        private void txtNrTel_Leave(object sender, EventArgs e)
        {
            validareTel(txtNrTel);
        }
    }
}

