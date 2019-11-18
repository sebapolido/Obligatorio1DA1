namespace UI
{
    partial class CheckPurchase
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
            this.lblDate = new System.Windows.Forms.Label();
            this.txtEnrollment = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConsult = new System.Windows.Forms.Button();
            this.lblEnrollment = new System.Windows.Forms.Label();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.lblCheckPurchase = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.DateTimePicker();
            this.timerOfAnswer = new System.Windows.Forms.Timer(this.components);
            this.lblHour = new System.Windows.Forms.Label();
            this.cboHour = new System.Windows.Forms.ComboBox();
            this.cboMinutes = new System.Windows.Forms.ComboBox();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(57, 147);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(97, 15);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "Ingrese la fecha:";
            // 
            // txtEnrollment
            // 
            this.txtEnrollment.Location = new System.Drawing.Point(190, 108);
            this.txtEnrollment.Name = "txtEnrollment";
            this.txtEnrollment.Size = new System.Drawing.Size(149, 20);
            this.txtEnrollment.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::UI.Properties.Resources.returnBack;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(40, 245);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 45);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnConsult
            // 
            this.btnConsult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsult.Image = global::UI.Properties.Resources.consult;
            this.btnConsult.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsult.Location = new System.Drawing.Point(203, 245);
            this.btnConsult.Name = "btnConsult";
            this.btnConsult.Size = new System.Drawing.Size(136, 45);
            this.btnConsult.TabIndex = 11;
            this.btnConsult.Text = "Consultar";
            this.btnConsult.UseVisualStyleBackColor = true;
            this.btnConsult.Click += new System.EventHandler(this.BtnConsult_Click);
            // 
            // lblEnrollment
            // 
            this.lblEnrollment.AutoSize = true;
            this.lblEnrollment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnrollment.Location = new System.Drawing.Point(57, 113);
            this.lblEnrollment.Name = "lblEnrollment";
            this.lblEnrollment.Size = new System.Drawing.Size(118, 15);
            this.lblEnrollment.TabIndex = 10;
            this.lblEnrollment.Text = "Ingrese la matrícula:";
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer.Location = new System.Drawing.Point(37, 322);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(0, 18);
            this.lblAnswer.TabIndex = 17;
            // 
            // lblCheckPurchase
            // 
            this.lblCheckPurchase.AutoSize = true;
            this.lblCheckPurchase.Font = new System.Drawing.Font("Copperplate Gothic Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckPurchase.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblCheckPurchase.Location = new System.Drawing.Point(16, 51);
            this.lblCheckPurchase.Name = "lblCheckPurchase";
            this.lblCheckPurchase.Size = new System.Drawing.Size(344, 35);
            this.lblCheckPurchase.TabIndex = 19;
            this.lblCheckPurchase.Text = "Consultar compra";
            // 
            // lblDateTime
            // 
            this.lblDateTime.Location = new System.Drawing.Point(190, 143);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(149, 20);
            this.lblDateTime.TabIndex = 20;
            // 
            // timerOfAnswer
            // 
            this.timerOfAnswer.Interval = 5000;
            this.timerOfAnswer.Tick += new System.EventHandler(this.TimerOfAnswer_Tick);
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHour.Location = new System.Drawing.Point(57, 180);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(92, 15);
            this.lblHour.TabIndex = 21;
            this.lblHour.Text = "Ingrese la hora:";
            // 
            // cboHour
            // 
            this.cboHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHour.FormattingEnabled = true;
            this.cboHour.Location = new System.Drawing.Point(190, 174);
            this.cboHour.Name = "cboHour";
            this.cboHour.Size = new System.Drawing.Size(36, 21);
            this.cboHour.TabIndex = 22;
            // 
            // cboMinutes
            // 
            this.cboMinutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMinutes.FormattingEnabled = true;
            this.cboMinutes.Location = new System.Drawing.Point(190, 205);
            this.cboMinutes.Name = "cboMinutes";
            this.cboMinutes.Size = new System.Drawing.Size(36, 21);
            this.cboMinutes.TabIndex = 24;
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.Location = new System.Drawing.Point(57, 211);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(117, 15);
            this.lblMinutes.TabIndex = 23;
            this.lblMinutes.Text = "Ingrese los minutos:";
            // 
            // CheckPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.cboMinutes);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.cboHour);
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.lblCheckPurchase);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtEnrollment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConsult);
            this.Controls.Add(this.lblEnrollment);
            this.Name = "CheckPurchase";
            this.Size = new System.Drawing.Size(383, 473);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtEnrollment;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConsult;
        private System.Windows.Forms.Label lblEnrollment;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Label lblCheckPurchase;
        private System.Windows.Forms.DateTimePicker lblDateTime;
        private System.Windows.Forms.Timer timerOfAnswer;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.ComboBox cboHour;
        private System.Windows.Forms.ComboBox cboMinutes;
        private System.Windows.Forms.Label lblMinutes;
    }
}
