
namespace Proiect
{
    partial class FStart
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cartiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.persoaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprumuturiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitlu = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.lblUtilizator = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblParola = new System.Windows.Forms.Label();
            this.txtParola = new System.Windows.Forms.TextBox();
            this.txtUtilizator = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cartiToolStripMenuItem,
            this.persoaneToolStripMenuItem,
            this.imprumuturiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(429, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cartiToolStripMenuItem
            // 
            this.cartiToolStripMenuItem.Name = "cartiToolStripMenuItem";
            this.cartiToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.cartiToolStripMenuItem.Text = "Model simplu Carti";
            this.cartiToolStripMenuItem.Click += new System.EventHandler(this.cartiToolStripMenuItem_Click);
            // 
            // persoaneToolStripMenuItem
            // 
            this.persoaneToolStripMenuItem.Name = "persoaneToolStripMenuItem";
            this.persoaneToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.persoaneToolStripMenuItem.Text = "Model avansat Persoane";
            this.persoaneToolStripMenuItem.Click += new System.EventHandler(this.persoaneToolStripMenuItem_Click);
            // 
            // imprumuturiToolStripMenuItem
            // 
            this.imprumuturiToolStripMenuItem.Name = "imprumuturiToolStripMenuItem";
            this.imprumuturiToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.imprumuturiToolStripMenuItem.Text = "Imprumuturi";
            this.imprumuturiToolStripMenuItem.Click += new System.EventHandler(this.imprumuturiToolStripMenuItem_Click);
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitlu.Location = new System.Drawing.Point(16, 41);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(390, 17);
            this.lblTitlu.TabIndex = 1;
            this.lblTitlu.Text = "Aplicatie pentru imprumutul cartilor dintr-o biblioteca";
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblAutor.Location = new System.Drawing.Point(16, 72);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(146, 15);
            this.lblAutor.TabIndex = 2;
            this.lblAutor.Text = "Memedula Ghionul-Edna";
            // 
            // lblUtilizator
            // 
            this.lblUtilizator.AutoSize = true;
            this.lblUtilizator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUtilizator.Location = new System.Drawing.Point(105, 105);
            this.lblUtilizator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUtilizator.Name = "lblUtilizator";
            this.lblUtilizator.Size = new System.Drawing.Size(47, 13);
            this.lblUtilizator.TabIndex = 3;
            this.lblUtilizator.Text = "Utilizator";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lblParola
            // 
            this.lblParola.AutoSize = true;
            this.lblParola.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblParola.Location = new System.Drawing.Point(115, 149);
            this.lblParola.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParola.Name = "lblParola";
            this.lblParola.Size = new System.Drawing.Size(37, 13);
            this.lblParola.TabIndex = 4;
            this.lblParola.Text = "Parola";
            // 
            // txtParola
            // 
            this.txtParola.Location = new System.Drawing.Point(156, 146);
            this.txtParola.Margin = new System.Windows.Forms.Padding(2);
            this.txtParola.Name = "txtParola";
            this.txtParola.PasswordChar = '*';
            this.txtParola.Size = new System.Drawing.Size(118, 20);
            this.txtParola.TabIndex = 5;
            // 
            // txtUtilizator
            // 
            this.txtUtilizator.Location = new System.Drawing.Point(156, 102);
            this.txtUtilizator.Margin = new System.Windows.Forms.Padding(2);
            this.txtUtilizator.Name = "txtUtilizator";
            this.txtUtilizator.Size = new System.Drawing.Size(118, 20);
            this.txtUtilizator.TabIndex = 6;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(169, 180);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(83, 33);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 274);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtUtilizator);
            this.Controls.Add(this.txtParola);
            this.Controls.Add(this.lblParola);
            this.Controls.Add(this.lblUtilizator);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.lblTitlu);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FStart";
            this.Text = "FStart";
            this.Load += new System.EventHandler(this.FStart_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lblTitlu;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.Label lblUtilizator;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblParola;
        private System.Windows.Forms.TextBox txtParola;
        private System.Windows.Forms.TextBox txtUtilizator;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ToolStripMenuItem persoaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cartiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprumuturiToolStripMenuItem;
    }
}