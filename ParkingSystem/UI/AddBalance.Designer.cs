namespace UI
{
    partial class AddBalance
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
            this.txtNumberPhone = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblNumberPhone = new System.Windows.Forms.Label();
            this.txtBalanceToAdd = new System.Windows.Forms.TextBox();
            this.lblBalanceToAdd = new System.Windows.Forms.Label();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.lblAddBalance = new System.Windows.Forms.Label();
            this.timerOfAnswer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtNumberPhone
            // 
            this.txtNumberPhone.Location = new System.Drawing.Point(200, 144);
            this.txtNumberPhone.Name = "txtNumberPhone";
            this.txtNumberPhone.Size = new System.Drawing.Size(134, 20);
            this.txtNumberPhone.TabIndex = 7;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(37, 238);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(136, 45);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Atrás";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(200, 238);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(136, 45);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblNumberPhone
            // 
            this.lblNumberPhone.AutoSize = true;
            this.lblNumberPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberPhone.Location = new System.Drawing.Point(32, 145);
            this.lblNumberPhone.Name = "lblNumberPhone";
            this.lblNumberPhone.Size = new System.Drawing.Size(162, 15);
            this.lblNumberPhone.TabIndex = 4;
            this.lblNumberPhone.Text = "Ingrese su número de movil:";
            // 
            // txtBalanceToAdd
            // 
            this.txtBalanceToAdd.Location = new System.Drawing.Point(200, 176);
            this.txtBalanceToAdd.Name = "txtBalanceToAdd";
            this.txtBalanceToAdd.Size = new System.Drawing.Size(134, 20);
            this.txtBalanceToAdd.TabIndex = 9;
            this.txtBalanceToAdd.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblBalanceToAdd
            // 
            this.lblBalanceToAdd.AutoSize = true;
            this.lblBalanceToAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceToAdd.Location = new System.Drawing.Point(32, 177);
            this.lblBalanceToAdd.Name = "lblBalanceToAdd";
            this.lblBalanceToAdd.Size = new System.Drawing.Size(153, 15);
            this.lblBalanceToAdd.TabIndex = 8;
            this.lblBalanceToAdd.Text = "Ingrese el saldo a agregar:";
            this.lblBalanceToAdd.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer.Location = new System.Drawing.Point(34, 310);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(0, 18);
            this.lblAnswer.TabIndex = 17;
            // 
            // lblAddBalance
            // 
            this.lblAddBalance.AutoSize = true;
            this.lblAddBalance.Font = new System.Drawing.Font("Copperplate Gothic Light", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddBalance.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblAddBalance.Location = new System.Drawing.Point(30, 53);
            this.lblAddBalance.Name = "lblAddBalance";
            this.lblAddBalance.Size = new System.Drawing.Size(303, 38);
            this.lblAddBalance.TabIndex = 19;
            this.lblAddBalance.Text = "Agregar saldo";
            // 
            // timerOfAnswer
            // 
            this.timerOfAnswer.Interval = 5000;
            this.timerOfAnswer.Tick += new System.EventHandler(this.timerOfAnswer_Tick);
            // 
            // AddBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.lblAddBalance);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.txtBalanceToAdd);
            this.Controls.Add(this.lblBalanceToAdd);
            this.Controls.Add(this.txtNumberPhone);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblNumberPhone);
            this.Name = "AddBalance";
            this.Size = new System.Drawing.Size(383, 363);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumberPhone;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblNumberPhone;
        private System.Windows.Forms.TextBox txtBalanceToAdd;
        private System.Windows.Forms.Label lblBalanceToAdd;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Label lblAddBalance;
        private System.Windows.Forms.Timer timerOfAnswer;
    }
}
