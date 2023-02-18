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
    public partial class Imprumuturi : Form
    {
        public Imprumuturi()
        {
            InitializeComponent();
        }

        private void refreshGrid()
        {
            imprumuturiTableAdapter.Fill(dataSet1.Imprumuturi);
            imprumuturiContinutTableAdapter.Fill(dataSet1.ImprumuturiContinut);
        }


        private void Imprumuturi_Load(object sender, EventArgs e)
        {
            txtIdImprumut.Visible = false;
            refreshGrid();

            try
            {
                imprumuturiContinutBindingSource.Filter = "IdImprumut=" + txtIdImprumut.Text;
            }
            catch { }

        }

        private void imprumuturiBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                imprumuturiContinutBindingSource.Filter = "IdImprumut=" + txtIdImprumut.Text;
            }
            catch { }
        }

        private void btnImprumutNou_Click(object sender, EventArgs e)
        {
            FImprumuturiAct f = new FImprumuturiAct();
            f.completeazaTitlu("IMPRUMUT NOU");
            f.ShowDialog();
            refreshGrid();
        }

        private void btnModificareImprumut_Click(object sender, EventArgs e)
        {
            FImprumuturiAct f = new FImprumuturiAct();
            f.completeazaTitlu("MODIFICARE IMPRUMUT");
            f.bs1 = imprumuturiBindingSource;
            f.bs2 = imprumuturiContinutBindingSource;
            f.ShowDialog();
            refreshGrid();
        }

        private void btnStergeImprumut_Click(object sender, EventArgs e)
        {
            const string mesaj = "Confirmati stergerea";
            const string titlu = "Stergere inregistrare";

            var rezultat = MessageBox.Show(mesaj, titlu, MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning);
            if (rezultat == DialogResult.No) return;

            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            con.ConnectionString = imprumuturiTableAdapter.Connection.ConnectionString;

            cmd.Connection = con;

            // Sterg continut imprumut
            cmd.CommandText = "Delete From ImprumuturiContinut Where IdImprumut = " + txtIdImprumut.Text;

            //MessageBox.Show(cmd.CommandText);

            con.Open();

            cmd.ExecuteNonQuery();

            // Sterg imprumut
            cmd.CommandText = "Delete From Imprumuturi Where IdImprumut = " + txtIdImprumut.Text;
            //MessageBox.Show(cmd.CommandText);
            cmd.ExecuteNonQuery();

            con.Close();

            // Refresh grid-uri
            refreshGrid();
            try
            {
                imprumuturiContinutBindingSource.Filter = "IdImprumut=" + txtIdImprumut.Text;
            }
            catch { }
        }

        
    }
}

