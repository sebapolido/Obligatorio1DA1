using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParkingSystem;

namespace UI
{
    public partial class Settings : UserControl

    {
        private Panel panel;
        private Validator validator;
        public int costForMinutes { get; set; }

        public Settings(Panel principalPanel, int actualCostForMinutes)
        {
            InitializeComponent();
            panel = principalPanel;
            validator = new Validator();
            costForMinutes = actualCostForMinutes;
            SetActualCostForMinute();
        }

        private void SetActualCostForMinute()
        {
            lblActualCostForMinutes.Text = "El costo por minuto actual es de: " + costForMinutes;
        }

        private void TxtCostForMinutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsPunctuation(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            ValidateCorrectNumber();
        }

        private void ValidateCorrectNumber()
        {
            if (validator.ValidateIsNumeric(txtCostForMinutes.Text))
            {
                lblAnswer.ForeColor = Color.Green;
                costForMinutes = int.Parse(txtCostForMinutes.Text);
                SetActualCostForMinute();
                SetMessage("El costo por minuto ha sido actualizado.");
            }
            else
                SetMessage("Debe ingresar un número.");
        }
        
        private void SetMessage(string textToShow)
        {
            lblAnswer.Visible = true;
            lblAnswer.Text = textToShow;
            timerOfAnswer.Start();
        }

        private void TimerOfAnswer_Tick(object sender, EventArgs e)
        {
            lblAnswer.Visible = false;
            timerOfAnswer.Enabled = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            panel.Visible = true;
        }
    }
}
