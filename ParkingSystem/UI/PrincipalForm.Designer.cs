namespace UI
{
    partial class PrincipalForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.PrincipalPanel = new System.Windows.Forms.Panel();
            this.btnReports = new System.Windows.Forms.Button();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.btnAccountRegister = new System.Windows.Forms.Button();
            this.SecundaryPanel = new System.Windows.Forms.Panel();
            this.timerOfAnswer = new System.Windows.Forms.Timer(this.components);
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnProcessPurchase = new System.Windows.Forms.Button();
            this.btnCheckPurchase = new System.Windows.Forms.Button();
            this.btnAddBalance = new System.Windows.Forms.Button();
            this.PrincipalPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Copperplate Gothic Light", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblWelcome.Location = new System.Drawing.Point(28, 14);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(300, 51);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Bienvenido";
            // 
            // PrincipalPanel
            // 
            this.PrincipalPanel.Controls.Add(this.btnReports);
            this.PrincipalPanel.Controls.Add(this.btnSettings);
            this.PrincipalPanel.Controls.Add(this.lblAnswer);
            this.PrincipalPanel.Controls.Add(this.btnProcessPurchase);
            this.PrincipalPanel.Controls.Add(this.btnCheckPurchase);
            this.PrincipalPanel.Controls.Add(this.btnAddBalance);
            this.PrincipalPanel.Controls.Add(this.btnAccountRegister);
            this.PrincipalPanel.Controls.Add(this.lblWelcome);
            this.PrincipalPanel.Location = new System.Drawing.Point(2, 3);
            this.PrincipalPanel.Name = "PrincipalPanel";
            this.PrincipalPanel.Size = new System.Drawing.Size(356, 427);
            this.PrincipalPanel.TabIndex = 1;
            // 
            // btnReports
            // 
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Image = global::UI.Properties.Resources.report;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(68, 291);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(224, 36);
            this.btnReports.TabIndex = 7;
            this.btnReports.Text = "Reportes";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.BtnReports_Click);
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer.ForeColor = System.Drawing.Color.Red;
            this.lblAnswer.Location = new System.Drawing.Point(4, 346);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(352, 18);
            this.lblAnswer.TabIndex = 5;
            this.lblAnswer.Text = "Primero debe haber al menos una cuenta registrada.";
            // 
            // btnAccountRegister
            // 
            this.btnAccountRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountRegister.Image = global::UI.Properties.Resources.accountRegister1;
            this.btnAccountRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountRegister.Location = new System.Drawing.Point(68, 86);
            this.btnAccountRegister.Name = "btnAccountRegister";
            this.btnAccountRegister.Size = new System.Drawing.Size(224, 36);
            this.btnAccountRegister.TabIndex = 1;
            this.btnAccountRegister.Text = " Registrar cuenta";
            this.btnAccountRegister.UseVisualStyleBackColor = true;
            this.btnAccountRegister.Click += new System.EventHandler(this.BtnAccountRegister_Click);
            // 
            // SecundaryPanel
            // 
            this.SecundaryPanel.Location = new System.Drawing.Point(2, 3);
            this.SecundaryPanel.Name = "SecundaryPanel";
            this.SecundaryPanel.Size = new System.Drawing.Size(359, 427);
            this.SecundaryPanel.TabIndex = 2;
            // 
            // timerOfAnswer
            // 
            this.timerOfAnswer.Interval = 5000;
            this.timerOfAnswer.Tick += new System.EventHandler(this.TimerOfAnswer_Tick);
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Image = global::UI.Properties.Resources.settings;
            this.btnSettings.Location = new System.Drawing.Point(306, 377);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(47, 42);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // btnProcessPurchase
            // 
            this.btnProcessPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessPurchase.Image = global::UI.Properties.Resources.processPurchase;
            this.btnProcessPurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcessPurchase.Location = new System.Drawing.Point(68, 189);
            this.btnProcessPurchase.Name = "btnProcessPurchase";
            this.btnProcessPurchase.Size = new System.Drawing.Size(224, 36);
            this.btnProcessPurchase.TabIndex = 4;
            this.btnProcessPurchase.Text = "  Procesar compra";
            this.btnProcessPurchase.UseVisualStyleBackColor = true;
            this.btnProcessPurchase.Click += new System.EventHandler(this.BtnProcessPurchase_Click);
            // 
            // btnCheckPurchase
            // 
            this.btnCheckPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckPurchase.Image = global::UI.Properties.Resources.checkPurchase;
            this.btnCheckPurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckPurchase.Location = new System.Drawing.Point(68, 240);
            this.btnCheckPurchase.Name = "btnCheckPurchase";
            this.btnCheckPurchase.Size = new System.Drawing.Size(224, 36);
            this.btnCheckPurchase.TabIndex = 3;
            this.btnCheckPurchase.Text = "  Consultar compra";
            this.btnCheckPurchase.UseVisualStyleBackColor = true;
            this.btnCheckPurchase.Click += new System.EventHandler(this.BtnCheckPurchase_Click);
            // 
            // btnAddBalance
            // 
            this.btnAddBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBalance.Image = global::UI.Properties.Resources.addBalance;
            this.btnAddBalance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddBalance.Location = new System.Drawing.Point(68, 137);
            this.btnAddBalance.Name = "btnAddBalance";
            this.btnAddBalance.Size = new System.Drawing.Size(224, 36);
            this.btnAddBalance.TabIndex = 2;
            this.btnAddBalance.Text = "Agregar saldo";
            this.btnAddBalance.UseVisualStyleBackColor = true;
            this.btnAddBalance.Click += new System.EventHandler(this.BtnAddBalance_Click);
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(374, 441);
            this.Controls.Add(this.PrincipalPanel);
            this.Controls.Add(this.SecundaryPanel);
            this.MaximizeBox = false;
            this.Name = "PrincipalForm";
            this.Text = "Gestión de estacionamiento";
            this.PrincipalPanel.ResumeLayout(false);
            this.PrincipalPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel PrincipalPanel;
        private System.Windows.Forms.Button btnAccountRegister;
        private System.Windows.Forms.Button btnProcessPurchase;
        private System.Windows.Forms.Button btnCheckPurchase;
        private System.Windows.Forms.Button btnAddBalance;
        private System.Windows.Forms.Panel SecundaryPanel;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Timer timerOfAnswer;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnReports;
    }
}

