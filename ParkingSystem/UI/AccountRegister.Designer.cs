namespace UI
{
    partial class AccountRegister
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
            this.lblNumberPhone = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtNumberPhone = new System.Windows.Forms.TextBox();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.lblAccountRegister = new System.Windows.Forms.Label();
            this.timerOfAnswer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblNumberPhone
            // 
            this.lblNumberPhone.AutoSize = true;
            this.lblNumberPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberPhone.Location = new System.Drawing.Point(24, 162);
            this.lblNumberPhone.Name = "lblNumberPhone";
            this.lblNumberPhone.Size = new System.Drawing.Size(162, 15);
            this.lblNumberPhone.TabIndex = 0;
            this.lblNumberPhone.Text = "Ingrese su número de movil:";
            // 
            // btnAccept
            // 
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Image = global::UI.Properties.Resources.iconAccept;
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.Location = new System.Drawing.Point(190, 238);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(136, 45);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::UI.Properties.Resources.returnBack;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(27, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 45);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // txtNumberPhone
            // 
            this.txtNumberPhone.Location = new System.Drawing.Point(192, 161);
            this.txtNumberPhone.Name = "txtNumberPhone";
            this.txtNumberPhone.Size = new System.Drawing.Size(134, 20);
            this.txtNumberPhone.TabIndex = 3;
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer.Location = new System.Drawing.Point(24, 321);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(0, 18);
            this.lblAnswer.TabIndex = 17;
            // 
            // lblAccountRegister
            // 
            this.lblAccountRegister.AutoSize = true;
            this.lblAccountRegister.Font = new System.Drawing.Font("Copperplate Gothic Light", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountRegister.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblAccountRegister.Location = new System.Drawing.Point(14, 53);
            this.lblAccountRegister.Name = "lblAccountRegister";
            this.lblAccountRegister.Size = new System.Drawing.Size(340, 37);
            this.lblAccountRegister.TabIndex = 18;
            this.lblAccountRegister.Text = "Registrar cuenta";
            // 
            // timerOfAnswer
            // 
            this.timerOfAnswer.Interval = 5000;
            this.timerOfAnswer.Tick += new System.EventHandler(this.TimerOfAnswer_Tick);
            // 
            // AccountRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.lblAccountRegister);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.txtNumberPhone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblNumberPhone);
            this.Name = "AccountRegister";
            this.Size = new System.Drawing.Size(383, 509);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumberPhone;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtNumberPhone;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Label lblAccountRegister;
        private System.Windows.Forms.Timer timerOfAnswer;
    }
}
