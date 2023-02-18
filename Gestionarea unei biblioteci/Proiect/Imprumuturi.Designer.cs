namespace Proiect
{
    partial class Imprumuturi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStergeImprumut = new System.Windows.Forms.Button();
            this.btnModificaImprumut = new System.Windows.Forms.Button();
            this.btnImprumutNou = new System.Windows.Forms.Button();
            this.txtIdImprumut = new System.Windows.Forms.TextBox();
            this.imprumuturiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Proiect.DataSet1();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.idImprumutDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCarteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titluDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrInventarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarifZiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrZileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valoareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imprumuturiContinutBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idImprumutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataImprumutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPersoanaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imprumuturiTableAdapter = new Proiect.DataSet1TableAdapters.ImprumuturiTableAdapter();
            this.imprumuturiContinutTableAdapter = new Proiect.DataSet1TableAdapters.ImprumuturiContinutTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.imprumuturiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imprumuturiContinutBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStergeImprumut
            // 
            this.btnStergeImprumut.Location = new System.Drawing.Point(702, 169);
            this.btnStergeImprumut.Name = "btnStergeImprumut";
            this.btnStergeImprumut.Size = new System.Drawing.Size(116, 23);
            this.btnStergeImprumut.TabIndex = 11;
            this.btnStergeImprumut.Text = "Sterge imprumut";
            this.btnStergeImprumut.UseVisualStyleBackColor = true;
            this.btnStergeImprumut.Click += new System.EventHandler(this.btnStergeImprumut_Click);
            // 
            // btnModificaImprumut
            // 
            this.btnModificaImprumut.Location = new System.Drawing.Point(702, 123);
            this.btnModificaImprumut.Name = "btnModificaImprumut";
            this.btnModificaImprumut.Size = new System.Drawing.Size(116, 23);
            this.btnModificaImprumut.TabIndex = 10;
            this.btnModificaImprumut.Text = "Modificare imprumut";
            this.btnModificaImprumut.UseVisualStyleBackColor = true;
            this.btnModificaImprumut.Click += new System.EventHandler(this.btnModificareImprumut_Click);
            // 
            // btnImprumutNou
            // 
            this.btnImprumutNou.Location = new System.Drawing.Point(702, 69);
            this.btnImprumutNou.Name = "btnImprumutNou";
            this.btnImprumutNou.Size = new System.Drawing.Size(116, 23);
            this.btnImprumutNou.TabIndex = 9;
            this.btnImprumutNou.Text = "Imprumut nou";
            this.btnImprumutNou.UseVisualStyleBackColor = true;
            this.btnImprumutNou.Click += new System.EventHandler(this.btnImprumutNou_Click);
            // 
            // txtIdImprumut
            // 
            this.txtIdImprumut.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.imprumuturiBindingSource, "IdImprumut", true));
            this.txtIdImprumut.Location = new System.Drawing.Point(702, 27);
            this.txtIdImprumut.Name = "txtIdImprumut";
            this.txtIdImprumut.Size = new System.Drawing.Size(116, 20);
            this.txtIdImprumut.TabIndex = 8;
            // 
            // imprumuturiBindingSource
            // 
            this.imprumuturiBindingSource.DataMember = "Imprumuturi";
            this.imprumuturiBindingSource.DataSource = this.dataSet1;
            this.imprumuturiBindingSource.PositionChanged += new System.EventHandler(this.imprumuturiBindingSource_PositionChanged);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idImprumutDataGridViewTextBoxColumn1,
            this.nrcDataGridViewTextBoxColumn,
            this.idCarteDataGridViewTextBoxColumn,
            this.titluDataGridViewTextBoxColumn,
            this.nrInventarDataGridViewTextBoxColumn,
            this.tarifZiDataGridViewTextBoxColumn,
            this.nrZileDataGridViewTextBoxColumn,
            this.valoareDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.imprumuturiContinutBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(12, 231);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(849, 197);
            this.dataGridView2.TabIndex = 7;
            // 
            // idImprumutDataGridViewTextBoxColumn1
            // 
            this.idImprumutDataGridViewTextBoxColumn1.DataPropertyName = "IdImprumut";
            this.idImprumutDataGridViewTextBoxColumn1.HeaderText = "IdImprumut";
            this.idImprumutDataGridViewTextBoxColumn1.Name = "idImprumutDataGridViewTextBoxColumn1";
            this.idImprumutDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idImprumutDataGridViewTextBoxColumn1.Visible = false;
            // 
            // nrcDataGridViewTextBoxColumn
            // 
            this.nrcDataGridViewTextBoxColumn.DataPropertyName = "Nrc";
            this.nrcDataGridViewTextBoxColumn.HeaderText = "Nrc";
            this.nrcDataGridViewTextBoxColumn.Name = "nrcDataGridViewTextBoxColumn";
            this.nrcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idCarteDataGridViewTextBoxColumn
            // 
            this.idCarteDataGridViewTextBoxColumn.DataPropertyName = "IdCarte";
            this.idCarteDataGridViewTextBoxColumn.HeaderText = "IdCarte";
            this.idCarteDataGridViewTextBoxColumn.Name = "idCarteDataGridViewTextBoxColumn";
            this.idCarteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCarteDataGridViewTextBoxColumn.Visible = false;
            // 
            // titluDataGridViewTextBoxColumn
            // 
            this.titluDataGridViewTextBoxColumn.DataPropertyName = "Titlu";
            this.titluDataGridViewTextBoxColumn.HeaderText = "Titlu";
            this.titluDataGridViewTextBoxColumn.Name = "titluDataGridViewTextBoxColumn";
            this.titluDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrInventarDataGridViewTextBoxColumn
            // 
            this.nrInventarDataGridViewTextBoxColumn.DataPropertyName = "NrInventar";
            this.nrInventarDataGridViewTextBoxColumn.HeaderText = "NrInventar";
            this.nrInventarDataGridViewTextBoxColumn.Name = "nrInventarDataGridViewTextBoxColumn";
            this.nrInventarDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tarifZiDataGridViewTextBoxColumn
            // 
            this.tarifZiDataGridViewTextBoxColumn.DataPropertyName = "TarifZi";
            this.tarifZiDataGridViewTextBoxColumn.HeaderText = "TarifZi";
            this.tarifZiDataGridViewTextBoxColumn.Name = "tarifZiDataGridViewTextBoxColumn";
            this.tarifZiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrZileDataGridViewTextBoxColumn
            // 
            this.nrZileDataGridViewTextBoxColumn.DataPropertyName = "NrZile";
            this.nrZileDataGridViewTextBoxColumn.HeaderText = "NrZile";
            this.nrZileDataGridViewTextBoxColumn.Name = "nrZileDataGridViewTextBoxColumn";
            this.nrZileDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valoareDataGridViewTextBoxColumn
            // 
            this.valoareDataGridViewTextBoxColumn.DataPropertyName = "Valoare";
            this.valoareDataGridViewTextBoxColumn.HeaderText = "Valoare";
            this.valoareDataGridViewTextBoxColumn.Name = "valoareDataGridViewTextBoxColumn";
            this.valoareDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // imprumuturiContinutBindingSource
            // 
            this.imprumuturiContinutBindingSource.DataMember = "ImprumuturiContinut";
            this.imprumuturiContinutBindingSource.DataSource = this.dataSet1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idImprumutDataGridViewTextBoxColumn,
            this.dataImprumutDataGridViewTextBoxColumn,
            this.idPersoanaDataGridViewTextBoxColumn,
            this.numeDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.imprumuturiBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(562, 201);
            this.dataGridView1.TabIndex = 6;
            // 
            // idImprumutDataGridViewTextBoxColumn
            // 
            this.idImprumutDataGridViewTextBoxColumn.DataPropertyName = "IdImprumut";
            this.idImprumutDataGridViewTextBoxColumn.HeaderText = "IdImprumut";
            this.idImprumutDataGridViewTextBoxColumn.Name = "idImprumutDataGridViewTextBoxColumn";
            this.idImprumutDataGridViewTextBoxColumn.ReadOnly = true;
            this.idImprumutDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataImprumutDataGridViewTextBoxColumn
            // 
            this.dataImprumutDataGridViewTextBoxColumn.DataPropertyName = "DataImprumut";
            this.dataImprumutDataGridViewTextBoxColumn.HeaderText = "DataImprumut";
            this.dataImprumutDataGridViewTextBoxColumn.Name = "dataImprumutDataGridViewTextBoxColumn";
            this.dataImprumutDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idPersoanaDataGridViewTextBoxColumn
            // 
            this.idPersoanaDataGridViewTextBoxColumn.DataPropertyName = "IdPersoana";
            this.idPersoanaDataGridViewTextBoxColumn.HeaderText = "IdPersoana";
            this.idPersoanaDataGridViewTextBoxColumn.Name = "idPersoanaDataGridViewTextBoxColumn";
            this.idPersoanaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPersoanaDataGridViewTextBoxColumn.Visible = false;
            // 
            // numeDataGridViewTextBoxColumn
            // 
            this.numeDataGridViewTextBoxColumn.DataPropertyName = "Nume";
            this.numeDataGridViewTextBoxColumn.HeaderText = "Nume";
            this.numeDataGridViewTextBoxColumn.Name = "numeDataGridViewTextBoxColumn";
            this.numeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // imprumuturiTableAdapter
            // 
            this.imprumuturiTableAdapter.ClearBeforeFill = true;
            // 
            // imprumuturiContinutTableAdapter
            // 
            this.imprumuturiContinutTableAdapter.ClearBeforeFill = true;
            // 
            // Imprumuturi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 467);
            this.Controls.Add(this.btnStergeImprumut);
            this.Controls.Add(this.btnModificaImprumut);
            this.Controls.Add(this.btnImprumutNou);
            this.Controls.Add(this.txtIdImprumut);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Imprumuturi";
            this.Text = "Imprumuturi";
            this.Load += new System.EventHandler(this.Imprumuturi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imprumuturiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imprumuturiContinutBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStergeImprumut;
        private System.Windows.Forms.Button btnModificaImprumut;
        private System.Windows.Forms.Button btnImprumutNou;
        private System.Windows.Forms.TextBox txtIdImprumut;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource imprumuturiBindingSource;
        private DataSet1TableAdapters.ImprumuturiTableAdapter imprumuturiTableAdapter;
        private System.Windows.Forms.BindingSource imprumuturiContinutBindingSource;
        private DataSet1TableAdapters.ImprumuturiContinutTableAdapter imprumuturiContinutTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idImprumutDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCarteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titluDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrInventarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarifZiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrZileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valoareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idImprumutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataImprumutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPersoanaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
    }
}