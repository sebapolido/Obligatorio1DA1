namespace UI
{
    partial class Reports
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.pnlEnrollments = new System.Windows.Forms.Panel();
            this.txtEnrollment = new System.Windows.Forms.TextBox();
            this.lblEnrollment = new System.Windows.Forms.Label();
            this.pnlPurchase = new System.Windows.Forms.Panel();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.cboFinalMinutes = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblFinalMinutes = new System.Windows.Forms.Label();
            this.cboFinalHour = new System.Windows.Forms.ComboBox();
            this.lblFinalHour = new System.Windows.Forms.Label();
            this.lblFinalDateTime = new System.Windows.Forms.DateTimePicker();
            this.lblFinalDate = new System.Windows.Forms.Label();
            this.cboInitialMinutes = new System.Windows.Forms.ComboBox();
            this.lblInitialMinutes = new System.Windows.Forms.Label();
            this.cboInitialHour = new System.Windows.Forms.ComboBox();
            this.lblInitialHour = new System.Windows.Forms.Label();
            this.lblInitialDateTime = new System.Windows.Forms.DateTimePicker();
            this.lblInitialDate = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbtnEnrollments = new System.Windows.Forms.RadioButton();
            this.rbtnPurchase = new System.Windows.Forms.RadioButton();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.timerOfAnswer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.pnlEnrollments.SuspendLayout();
            this.pnlPurchase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Copperplate Gothic Light", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblWelcome.Location = new System.Drawing.Point(52, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(262, 51);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Reportes";
            // 
            // dgvReports
            // 
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Location = new System.Drawing.Point(24, 276);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.Size = new System.Drawing.Size(317, 117);
            this.dgvReports.TabIndex = 2;
            // 
            // pnlEnrollments
            // 
            this.pnlEnrollments.Controls.Add(this.txtEnrollment);
            this.pnlEnrollments.Controls.Add(this.lblEnrollment);
            this.pnlEnrollments.Location = new System.Drawing.Point(24, 84);
            this.pnlEnrollments.Name = "pnlEnrollments";
            this.pnlEnrollments.Size = new System.Drawing.Size(317, 134);
            this.pnlEnrollments.TabIndex = 3;
            // 
            // txtEnrollment
            // 
            this.txtEnrollment.Location = new System.Drawing.Point(158, 30);
            this.txtEnrollment.Name = "txtEnrollment";
            this.txtEnrollment.Size = new System.Drawing.Size(149, 20);
            this.txtEnrollment.TabIndex = 15;
            // 
            // lblEnrollment
            // 
            this.lblEnrollment.AutoSize = true;
            this.lblEnrollment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnrollment.Location = new System.Drawing.Point(25, 31);
            this.lblEnrollment.Name = "lblEnrollment";
            this.lblEnrollment.Size = new System.Drawing.Size(118, 15);
            this.lblEnrollment.TabIndex = 14;
            this.lblEnrollment.Text = "Ingrese la matrícula:";
            // 
            // pnlPurchase
            // 
            this.pnlPurchase.Controls.Add(this.cboCountry);
            this.pnlPurchase.Controls.Add(this.cboFinalMinutes);
            this.pnlPurchase.Controls.Add(this.lblCountry);
            this.pnlPurchase.Controls.Add(this.lblFinalMinutes);
            this.pnlPurchase.Controls.Add(this.cboFinalHour);
            this.pnlPurchase.Controls.Add(this.lblFinalHour);
            this.pnlPurchase.Controls.Add(this.lblFinalDateTime);
            this.pnlPurchase.Controls.Add(this.lblFinalDate);
            this.pnlPurchase.Controls.Add(this.cboInitialMinutes);
            this.pnlPurchase.Controls.Add(this.lblInitialMinutes);
            this.pnlPurchase.Controls.Add(this.cboInitialHour);
            this.pnlPurchase.Controls.Add(this.lblInitialHour);
            this.pnlPurchase.Controls.Add(this.lblInitialDateTime);
            this.pnlPurchase.Controls.Add(this.lblInitialDate);
            this.pnlPurchase.Location = new System.Drawing.Point(24, 84);
            this.pnlPurchase.Name = "pnlPurchase";
            this.pnlPurchase.Size = new System.Drawing.Size(317, 134);
            this.pnlPurchase.TabIndex = 16;
            // 
            // cboCountry
            // 
            this.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(56, 101);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(83, 21);
            this.cboCountry.TabIndex = 38;
            // 
            // cboFinalMinutes
            // 
            this.cboFinalMinutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinalMinutes.FormattingEnabled = true;
            this.cboFinalMinutes.Location = new System.Drawing.Point(239, 73);
            this.cboFinalMinutes.Name = "cboFinalMinutes";
            this.cboFinalMinutes.Size = new System.Drawing.Size(36, 21);
            this.cboFinalMinutes.TabIndex = 36;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(16, 107);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(34, 15);
            this.lblCountry.TabIndex = 37;
            this.lblCountry.Text = "País:";
            // 
            // lblFinalMinutes
            // 
            this.lblFinalMinutes.AutoSize = true;
            this.lblFinalMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalMinutes.Location = new System.Drawing.Point(163, 79);
            this.lblFinalMinutes.Name = "lblFinalMinutes";
            this.lblFinalMinutes.Size = new System.Drawing.Size(70, 15);
            this.lblFinalMinutes.TabIndex = 35;
            this.lblFinalMinutes.Text = "Minutos fin:";
            // 
            // cboFinalHour
            // 
            this.cboFinalHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinalHour.FormattingEnabled = true;
            this.cboFinalHour.Location = new System.Drawing.Point(238, 42);
            this.cboFinalHour.Name = "cboFinalHour";
            this.cboFinalHour.Size = new System.Drawing.Size(36, 21);
            this.cboFinalHour.TabIndex = 34;
            // 
            // lblFinalHour
            // 
            this.lblFinalHour.AutoSize = true;
            this.lblFinalHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalHour.Location = new System.Drawing.Point(163, 48);
            this.lblFinalHour.Name = "lblFinalHour";
            this.lblFinalHour.Size = new System.Drawing.Size(53, 15);
            this.lblFinalHour.TabIndex = 33;
            this.lblFinalHour.Text = "Hora fin:";
            // 
            // lblFinalDateTime
            // 
            this.lblFinalDateTime.Location = new System.Drawing.Point(238, 10);
            this.lblFinalDateTime.Name = "lblFinalDateTime";
            this.lblFinalDateTime.Size = new System.Drawing.Size(36, 20);
            this.lblFinalDateTime.TabIndex = 32;
            // 
            // lblFinalDate
            // 
            this.lblFinalDate.AutoSize = true;
            this.lblFinalDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalDate.Location = new System.Drawing.Point(163, 15);
            this.lblFinalDate.Name = "lblFinalDate";
            this.lblFinalDate.Size = new System.Drawing.Size(60, 15);
            this.lblFinalDate.TabIndex = 31;
            this.lblFinalDate.Text = "Fecha fin:";
            // 
            // cboInitialMinutes
            // 
            this.cboInitialMinutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInitialMinutes.FormattingEnabled = true;
            this.cboInitialMinutes.Location = new System.Drawing.Point(103, 74);
            this.cboInitialMinutes.Name = "cboInitialMinutes";
            this.cboInitialMinutes.Size = new System.Drawing.Size(36, 21);
            this.cboInitialMinutes.TabIndex = 30;
            // 
            // lblInitialMinutes
            // 
            this.lblInitialMinutes.AutoSize = true;
            this.lblInitialMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialMinutes.Location = new System.Drawing.Point(16, 80);
            this.lblInitialMinutes.Name = "lblInitialMinutes";
            this.lblInitialMinutes.Size = new System.Drawing.Size(86, 15);
            this.lblInitialMinutes.TabIndex = 29;
            this.lblInitialMinutes.Text = "Minutos inicio:";
            // 
            // cboInitialHour
            // 
            this.cboInitialHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInitialHour.FormattingEnabled = true;
            this.cboInitialHour.Location = new System.Drawing.Point(103, 43);
            this.cboInitialHour.Name = "cboInitialHour";
            this.cboInitialHour.Size = new System.Drawing.Size(36, 21);
            this.cboInitialHour.TabIndex = 28;
            // 
            // lblInitialHour
            // 
            this.lblInitialHour.AutoSize = true;
            this.lblInitialHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialHour.Location = new System.Drawing.Point(16, 49);
            this.lblInitialHour.Name = "lblInitialHour";
            this.lblInitialHour.Size = new System.Drawing.Size(69, 15);
            this.lblInitialHour.TabIndex = 27;
            this.lblInitialHour.Text = "Hora inicio:";
            // 
            // lblInitialDateTime
            // 
            this.lblInitialDateTime.Location = new System.Drawing.Point(103, 11);
            this.lblInitialDateTime.Name = "lblInitialDateTime";
            this.lblInitialDateTime.Size = new System.Drawing.Size(36, 20);
            this.lblInitialDateTime.TabIndex = 26;
            // 
            // lblInitialDate
            // 
            this.lblInitialDate.AutoSize = true;
            this.lblInitialDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialDate.Location = new System.Drawing.Point(16, 16);
            this.lblInitialDate.Name = "lblInitialDate";
            this.lblInitialDate.Size = new System.Drawing.Size(76, 15);
            this.lblInitialDate.TabIndex = 25;
            this.lblInitialDate.Text = "Fecha inicio:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::UI.Properties.Resources.consult;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.Location = new System.Drawing.Point(227, 224);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 36);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::UI.Properties.Resources.returnBack;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(24, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 36);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "      Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // rbtnEnrollments
            // 
            this.rbtnEnrollments.AutoSize = true;
            this.rbtnEnrollments.Location = new System.Drawing.Point(24, 61);
            this.rbtnEnrollments.Name = "rbtnEnrollments";
            this.rbtnEnrollments.Size = new System.Drawing.Size(126, 17);
            this.rbtnEnrollments.TabIndex = 18;
            this.rbtnEnrollments.TabStop = true;
            this.rbtnEnrollments.Text = "Ventas por matrícula.";
            this.rbtnEnrollments.UseVisualStyleBackColor = true;
            this.rbtnEnrollments.CheckedChanged += new System.EventHandler(this.RbtnEnrollments_CheckedChanged);
            // 
            // rbtnPurchase
            // 
            this.rbtnPurchase.AutoSize = true;
            this.rbtnPurchase.Location = new System.Drawing.Point(182, 61);
            this.rbtnPurchase.Name = "rbtnPurchase";
            this.rbtnPurchase.Size = new System.Drawing.Size(159, 17);
            this.rbtnPurchase.TabIndex = 19;
            this.rbtnPurchase.TabStop = true;
            this.rbtnPurchase.Text = "Compras por país y período.";
            this.rbtnPurchase.UseVisualStyleBackColor = true;
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnswer.Location = new System.Drawing.Point(21, 407);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(0, 18);
            this.lblAnswer.TabIndex = 20;
            // 
            // timerOfAnswer
            // 
            this.timerOfAnswer.Interval = 5000;
            this.timerOfAnswer.Tick += new System.EventHandler(this.TimerOfAnswer_Tick);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.pnlPurchase);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.rbtnPurchase);
            this.Controls.Add(this.rbtnEnrollments);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pnlEnrollments);
            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.lblWelcome);
            this.Name = "Reports";
            this.Size = new System.Drawing.Size(383, 473);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.pnlEnrollments.ResumeLayout(false);
            this.pnlEnrollments.PerformLayout();
            this.pnlPurchase.ResumeLayout(false);
            this.pnlPurchase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Panel pnlEnrollments;
        private System.Windows.Forms.TextBox txtEnrollment;
        private System.Windows.Forms.Label lblEnrollment;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbtnEnrollments;
        private System.Windows.Forms.RadioButton rbtnPurchase;
        private System.Windows.Forms.Panel pnlPurchase;
        private System.Windows.Forms.ComboBox cboInitialMinutes;
        private System.Windows.Forms.Label lblInitialMinutes;
        private System.Windows.Forms.ComboBox cboInitialHour;
        private System.Windows.Forms.Label lblInitialHour;
        private System.Windows.Forms.DateTimePicker lblInitialDateTime;
        private System.Windows.Forms.Label lblInitialDate;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.ComboBox cboFinalMinutes;
        private System.Windows.Forms.Label lblFinalMinutes;
        private System.Windows.Forms.ComboBox cboFinalHour;
        private System.Windows.Forms.Label lblFinalHour;
        private System.Windows.Forms.DateTimePicker lblFinalDateTime;
        private System.Windows.Forms.Label lblFinalDate;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Timer timerOfAnswer;
    }
}
