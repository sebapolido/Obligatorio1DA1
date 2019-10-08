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
        Panel panel;
        SystemController system;
        Validator validator;
        public int costForMinutes { get; set; }

        public Settings(Panel principalPanel, SystemController systemController, int actualCostForMinutes)
        {
            InitializeComponent();
            panel = principalPanel;
            system = systemController;
            validator = new Validator();
            costForMinutes = actualCostForMinutes;
            SetActualCostForMinute();
        }

        private void SetActualCostForMinute()
        {
            lblActualCostForMinutes.Text = "El costo por minuto actual es de: " + costForMinutes;
            
        }

        private void lblNumberPhone_Click(object sender, EventArgs e)
        {

        }

        private void txtCostForMinutes_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            ValidateCorrectNumber();
        }

        private void ValidateCorrectNumber()
        {
            if (validator.ValidateIsNumeric(txtCostForMinutes.Text))
            {
                lblAnswer.ForeColor = Color.Green;
                costForMinutes = CostForMinutes();
                SetActualCostForMinute();
                SetMessage("El costo por minuto ha sido actualizado.");
            }
            else
                SetMessage("Debe ingresar un número.");
        }

        public int CostForMinutes()
        {
            if (txtCostForMinutes.Text.Length == 0)
                return 1;
            else
                return int.Parse(txtCostForMinutes.Text);
        }

        private void SetMessage(string textToShow)
        {
            lblAnswer.Visible = true;
            lblAnswer.Text = textToShow;
            timerOfAnswer.Start();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            panel.Visible = true;
        }

        private void timerOfAnswer_Tick_1(object sender, EventArgs e)
        {
            lblAnswer.Visible = false;
            timerOfAnswer.Enabled = false;
        }
    }
}
