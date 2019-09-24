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
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(57, 182);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(97, 15);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "Ingrese la fecha:";
            this.lblDate.Click += new System.EventHandler(this.lblBalanceToAdd_Click);
            // 
            // txtEnrollment
            // 
            this.txtEnrollment.Location = new System.Drawing.Point(190, 137);
            this.txtEnrollment.Name = "txtEnrollment";
            this.txtEnrollment.Size = new System.Drawing.Size(134, 20);
            this.txtEnrollment.TabIndex = 13;
            this.txtEnrollment.TextChanged += new System.EventHandler(this.txtNumberPhone_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(40, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 45);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConsult
            // 
            this.btnConsult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsult.Location = new System.Drawing.Point(203, 238);
            this.btnConsult.Name = "btnConsult";
            this.btnConsult.Size = new System.Drawing.Size(136, 45);
            this.btnConsult.TabIndex = 11;
            this.btnConsult.Text = "Consultar";
            this.btnConsult.UseVisualStyleBackColor = true;
            this.btnConsult.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblEnrollment
            // 
            this.lblEnrollment.AutoSize = true;
            this.lblEnrollment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnrollment.Location = new System.Drawing.Point(57, 138);
            this.lblEnrollment.Name = "lblEnrollment";
            this.lblEnrollment.Size = new System.Drawing.Size(118, 15);
            this.lblEnrollment.TabIndex = 10;
            this.lblEnrollment.Text = "Ingrese la matrícula:";
            this.lblEnrollment.Click += new System.EventHandler(this.lblNumberPhone_Click);
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Location = new System.Drawing.Point(37, 322);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(0, 13);
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
            this.lblCheckPurchase.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.Location = new System.Drawing.Point(190, 177);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(134, 20);
            this.lblDateTime.TabIndex = 20;
            // 
            // timerOfAnswer
            // 
            this.timerOfAnswer.Interval = 5000;
            this.timerOfAnswer.Tick += new System.EventHandler(this.timerOfAnswer_Tick);
            // 
            // CheckPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.lblCheckPurchase);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtEnrollment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConsult);
            this.Controls.Add(this.lblEnrollment);
            this.Name = "CheckPurchase";
            this.Size = new System.Drawing.Size(383, 509);
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
    }
}
