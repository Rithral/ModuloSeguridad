﻿namespace VISTA
{
    partial class frmGrupo
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
            this.btnCANCELAR = new System.Windows.Forms.Button();
            this.btnGUARDAR = new System.Windows.Forms.Button();
            this.pDATOS = new System.Windows.Forms.Panel();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCODIGO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDESCRIPCION = new System.Windows.Forms.TextBox();
            this.chkUSUARIOS = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkPermisos = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFORMULARIO = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pDATOS.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCANCELAR
            // 
            this.btnCANCELAR.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCANCELAR.Location = new System.Drawing.Point(227, 536);
            this.btnCANCELAR.Name = "btnCANCELAR";
            this.btnCANCELAR.Size = new System.Drawing.Size(93, 46);
            this.btnCANCELAR.TabIndex = 10;
            this.btnCANCELAR.Text = "Cancelar";
            this.btnCANCELAR.UseVisualStyleBackColor = true;
            this.btnCANCELAR.Click += new System.EventHandler(this.btnCANCELAR_Click);
            // 
            // btnGUARDAR
            // 
            this.btnGUARDAR.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGUARDAR.Location = new System.Drawing.Point(95, 536);
            this.btnGUARDAR.Name = "btnGUARDAR";
            this.btnGUARDAR.Size = new System.Drawing.Size(97, 46);
            this.btnGUARDAR.TabIndex = 9;
            this.btnGUARDAR.Text = "Guardar";
            this.btnGUARDAR.UseVisualStyleBackColor = true;
            this.btnGUARDAR.Click += new System.EventHandler(this.btnGUARDAR_Click);
            // 
            // pDATOS
            // 
            this.pDATOS.Controls.Add(this.label7);
            this.pDATOS.Controls.Add(this.chkEstado);
            this.pDATOS.Controls.Add(this.label3);
            this.pDATOS.Controls.Add(this.txtCODIGO);
            this.pDATOS.Controls.Add(this.label1);
            this.pDATOS.Controls.Add(this.label2);
            this.pDATOS.Controls.Add(this.txtDESCRIPCION);
            this.pDATOS.Location = new System.Drawing.Point(12, 29);
            this.pDATOS.Name = "pDATOS";
            this.pDATOS.Size = new System.Drawing.Size(476, 119);
            this.pDATOS.TabIndex = 14;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(102, 89);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(56, 17);
            this.chkEstado.TabIndex = 6;
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estado:";
            // 
            // txtCODIGO
            // 
            this.txtCODIGO.Location = new System.Drawing.Point(102, 22);
            this.txtCODIGO.Name = "txtCODIGO";
            this.txtCODIGO.Size = new System.Drawing.Size(145, 20);
            this.txtCODIGO.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción:";
            // 
            // txtDESCRIPCION
            // 
            this.txtDESCRIPCION.Location = new System.Drawing.Point(83, 59);
            this.txtDESCRIPCION.Name = "txtDESCRIPCION";
            this.txtDESCRIPCION.Size = new System.Drawing.Size(365, 20);
            this.txtDESCRIPCION.TabIndex = 4;
            // 
            // chkUSUARIOS
            // 
            this.chkUSUARIOS.FormattingEnabled = true;
            this.chkUSUARIOS.Location = new System.Drawing.Point(36, 167);
            this.chkUSUARIOS.Name = "chkUSUARIOS";
            this.chkUSUARIOS.Size = new System.Drawing.Size(383, 169);
            this.chkUSUARIOS.TabIndex = 7;
            this.chkUSUARIOS.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkUSUARIOS_ItemCheck);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Usuarios del grupo:";
            // 
            // chkPermisos
            // 
            this.chkPermisos.FormattingEnabled = true;
            this.chkPermisos.Location = new System.Drawing.Point(81, 372);
            this.chkPermisos.Name = "chkPermisos";
            this.chkPermisos.Size = new System.Drawing.Size(239, 139);
            this.chkPermisos.TabIndex = 5;
            this.chkPermisos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkPermisos_ItemCheck);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 372);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Permisos:";
            // 
            // cmbFORMULARIO
            // 
            this.cmbFORMULARIO.FormattingEnabled = true;
            this.cmbFORMULARIO.Location = new System.Drawing.Point(81, 342);
            this.cmbFORMULARIO.Name = "cmbFORMULARIO";
            this.cmbFORMULARIO.Size = new System.Drawing.Size(239, 21);
            this.cmbFORMULARIO.TabIndex = 3;
            this.cmbFORMULARIO.SelectedIndexChanged += new System.EventHandler(this.cmbFORMULARIO_SelectedIndexChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Formulario:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Datos del Grupo";
            // 
            // frmGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 623);
            this.Controls.Add(this.chkPermisos);
            this.Controls.Add(this.chkUSUARIOS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbFORMULARIO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pDATOS);
            this.Controls.Add(this.btnCANCELAR);
            this.Controls.Add(this.btnGUARDAR);
            this.Name = "frmGrupo";
            this.Text = "Grupo";
            this.Load += new System.EventHandler(this.frmGrupo_Load);
            this.pDATOS.ResumeLayout(false);
            this.pDATOS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCANCELAR;
        private System.Windows.Forms.Button btnGUARDAR;
        private System.Windows.Forms.Panel pDATOS;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCODIGO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDESCRIPCION;
        private System.Windows.Forms.CheckedListBox chkUSUARIOS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox chkPermisos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbFORMULARIO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
    }
}