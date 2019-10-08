namespace UI
{
    partial class Settings
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.lblProcessPurchase = new System.Windows.Forms.Label();
            this.lblCostForMinute = new System.Windows.Forms.Label();
            this.txtCostForMinutes = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblActualCostForMinutes = new System.Windows.Forms.Label();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.timerOfAnswer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblProcessPurchase
            // 
            this.lblProcessPurchase.AutoSize = true;
            this.lblProcessPurchase.Font = new System.Drawing.Font("Copperplate Gothic Light", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessPurchase.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblProcessPurchase.Location = new System.Drawing.Point(39, 34);
            this.lblProcessPurchase.Name = "lblProcessPurchase";
            this.lblProcessPurchase.Size = new System.Drawing.Size(297, 37);
            this.lblProcessPurchase.TabIndex = 20;
            this.lblProcessPurchase.Text = "Configuración";
            // 
            // lblCostForMinute
            // 
            this.lblCostForMinute.AutoSize = true;
            this.lblCostForMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCostForMinute.Location = new System.Drawing.Point(43, 161);
            this.lblCostForMinute.Name = "lblCostForMinute";
            this.lblCostForMinute.Size = new System.Drawing.Size(183, 17);
            this.lblCostForMinute.TabIndex = 21;
            this.lblCostForMinute.Text = "Actualizar costo por minuto:";
            this.lblCostForMinute.Click += new System.EventHandler(this.lblNumberPhone_Click);
            // 
            // txtCostForMinutes
            // 
            this.txtCostForMinutes.Location = new System.Drawing.Point(232, 160);
            this.txtCostForMinutes.Name = "txtCostForMinutes";
            this.txtCostForMinutes.Size = new System.Drawing.Size(100, 20);
            this.txtCostForMinutes.TabIndex = 22;
            this.txtCostForMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostForMinutes_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(42, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 45);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.Image")));
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.Location = new System.Drawing.Point(205, 232);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(136, 45);
            this.btnAccept.TabIndex = 23;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblActualCostForMinutes
            // 
            this.lblActualCostForMinutes.AutoSize = true;
            this.lblActualCostForMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblActualCostForMinutes.Location = new System.Drawing.Point(43, 120);
            this.lblActualCostForMinutes.Name = "lblActualCostForMinutes";
            this.lblActualCostForMinutes.Size = new System.Drawing.Size(218, 17);
            this.lblActualCostForMinutes.TabIndex = 25;
            this.lblActualCostForMinutes.Text = "El costo por minuto actual es de: ";
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblAnswer.ForeColor = System.Drawing.Color.Green;
            this.lblAnswer.Location = new System.Drawing.Point(43, 332);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(0, 17);
            this.lblAnswer.TabIndex = 26;
            // 
            // timerOfAnswer
            // 
            this.timerOfAnswer.Interval = 5000;
            this.timerOfAnswer.Tick += new System.EventHandler(this.timerOfAnswer_Tick_1);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.lblActualCostForMinutes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtCostForMinutes);
            this.Controls.Add(this.lblCostForMinute);
            this.Controls.Add(this.lblProcessPurchase);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(383, 473);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProcessPurchase;
        private System.Windows.Forms.Label lblCostForMinute;
        private System.Windows.Forms.TextBox txtCostForMinutes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblActualCostForMinutes;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Timer timerOfAnswer;
    }
}
