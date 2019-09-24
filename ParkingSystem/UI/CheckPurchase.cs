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
    public partial class CheckPurchase : UserControl
    {
        Panel panel;
        SystemController system;

        public CheckPurchase(Panel principalPanel, SystemController systemController)
        {
            InitializeComponent();
            panel = principalPanel;
            system = systemController;
        }

        private void lblNumberPhone_Click(object sender, EventArgs e)
        {

        }

        private void lblBalanceToAdd_Click(object sender, EventArgs e)
        {

        }

        private void txtNumberPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            panel.Visible = true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtEnrollment.Text.Length > 0 && txtEnrollment.Text.Length < 8)
            {
                string[] line = txtEnrollment.Text.Split(' ');
                if (line[0].Length == 3 && line.Length == 2 && line[1].Length == 4)
                {
                    if (system.ValidateFormatOfEnrollment(line[0] + line[1]))
                        ValidateDate();
                    else
                        SetMessage("El formato de la matricula no es valido.");
                }
                else
                    if (line[0].Length == 7)
                    {
                    if (system.ValidateFormatOfEnrollment(line[0]))
                        ValidateDate();
                    else
                        SetMessage("El formato de la matricula no es valido.");
                    }
                    else
                        SetMessage("El formato de la matricula no es valido.");
            }
            else
                SetMessage("Debe ingresar una matricula.");
        }

        private void ValidateDate()
        {
            
        }

        private void txtBalanceToAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
        
        public void SetMessage(string textToShow)
        {
            lblAnswer.Visible = true;
            lblAnswer.Text = textToShow;
            timerOfAnswer.Start();
        }

        private void timerOfAnswer_Tick(object sender, EventArgs e)
        {
            lblAnswer.Visible = false;
            timerOfAnswer.Enabled = false;
        }
    }
}
