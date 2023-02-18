using Proiect.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class Carti : Form
    {
        const int SpPozaIndex = 5;
        public Carti()
        {
            InitializeComponent();
        }

        private void Carti_Load(object sender, EventArgs e)
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
        cartiTableAdapter.Fill(dataSet1.Carti);
        pictureBox1.ImageLocation = txtSpImagine.Text;
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
            cartiTableAdapter.Update(dataSet1.Carti);
            config(true);
            refresh();
        }
        catch (Exception exc)
        {
            string s = exc.Message;
            //MessageBox.Show(s);
            if (s.IndexOf("duplicate values") > 0)
                MessageBox.Show("Inregistrare deja existenta !");
            else if (s.IndexOf("cannot be deleted") > 0)
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
            if (btnRenuntare.Focused)
            {
                dataGridView1.CancelEdit();
                //A3
                config(true);
                refresh();

                return;

            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (btnActualizare.Enabled) return;

            if (dataGridView1.CurrentCell.ColumnIndex == SpPozaIndex)
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string s = openFileDialog1.FileName; ;
                    dataGridView1.CurrentRow.Cells[SpPozaIndex].Value = s;
                    pictureBox1.ImageLocation = s;
                    dataGridView1.EndEdit();

                }
        }


        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
    {
        const string mesaj = "Confirmati stergerea";
        const string titlu = "Stergere inregistrare";
        var rezultat = MessageBox.Show(mesaj, titlu, MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Warning);
        if (rezultat == DialogResult.No) e.Cancel = true;
    }

        private void clientiBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = txtSpImagine.Text;
        }


        private bool completareCampuri()
    {
        bool raspuns = true;
        foreach (DataRow r in dataSet1.Carti)
        {
            if (r.RowState == DataRowState.Deleted) continue;
            if (r["Titlu"] == DBNull.Value)
            {
                MessageBox.Show("Completati Titlu la linia cu Id " + r["IdCarte"]);
                raspuns = false;
            }
                if (r["Autor"] == DBNull.Value)
                {
                    MessageBox.Show("Completati Autor la linia cu Id " + r["IdCarte"]);
                    raspuns = false;
                }
                if (r["NrInventar"] == DBNull.Value)
                {
                    MessageBox.Show("Completati NrInvetar la linia cu Id " + r["IdCarte"]);
                    raspuns = false;
                }
                if (r["TarifZi"] == DBNull.Value)
                {
                    MessageBox.Show("Completati TarifZi la linia cu Id " + r["IdCarte"]);
                    raspuns = false;
                }
                if (r["SpImagine"] == DBNull.Value)
                {
                    MessageBox.Show("Completati SpImagine la linia cu Id " + r["IdCarte"]);
                    raspuns = false;
                }
            }
            return raspuns;
    }
}
}
