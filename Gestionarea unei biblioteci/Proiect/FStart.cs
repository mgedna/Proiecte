using System;
using System.Data.OleDb;
using System.Windows.Forms;


namespace Proiect
{
    public partial class FStart : Form
    {
        private OleDbConnection con = new OleDbConnection();
        private OleDbCommand cmd = new OleDbCommand();
        private OleDbDataReader rdr;

        public FStart()
        {
            InitializeComponent();
        }

        private void A1(Boolean v)
        {
            menuStrip1.Visible = !v;
            lblTitlu.Visible = !v;
            lblAutor.Visible = !v;
            lblParola.Visible = v;
            txtParola.Visible = v;
            lblUtilizator.Visible = v;
            txtUtilizator.Visible = v;
            if (v) btnStart.Text = "Log In";
            else btnStart.Text = "Log Out";
        }

        private Boolean Logare_OK()
        {
            if (txtUtilizator.Text == "")
            {
                MessageBox.Show("Completati utilizator !");
                txtUtilizator.Focus();
                return false;
            }
            if (txtParola.Text == "")
            {
                MessageBox.Show("Completati parola !");
                txtParola.Focus();
                return false;
            }

            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                   "Data Source=D:\\Facultate\\Tehnologii avansate de programare\\Proiect\\db-proiect.accdb";
            cmd.Connection = con;
            cmd.CommandText = "Select IdUtilizator,Parola from Utilizatori " +
                              "where Nume='" + txtUtilizator.Text + "'";
            con.Open();
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                if (txtParola.Text != rdr.GetString(1))
                {
                    MessageBox.Show("Parola eronata");
                    txtParola.Focus();
                    con.Close();
                    return false;
                }
                con.Close();
                return true;
            }
            else
            {
                MessageBox.Show("Utilizator eronat");
                txtUtilizator.Focus();
                con.Close();
                return false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            if (btnStart.Text == "Log In")
            {
                if (Logare_OK()) A1(false);
            }
            else A1(true);
        }

        private void FStart_Load(object sender, EventArgs e)
        {
            A1(true);
        }

        private void persoaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persoane f = new Persoane();
            f.ShowDialog();
        }

        private void cartiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Carti f = new Carti();
            f.ShowDialog();
        }

        private void imprumuturiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprumuturi f = new Imprumuturi();
            f.ShowDialog();
        }
    }
}

