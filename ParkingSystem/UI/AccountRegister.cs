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
    public partial class AccountRegister : UserControl

    {
        Panel panel;
        ISystemController system;
        
        public AccountRegister(Panel principalPanel, ISystemController systemController)
        {
            InitializeComponent();
            panel = principalPanel;
            system = systemController;
        }

        private void AccountRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            panel.Visible = true;

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            ValidateEmpty();
        }

        private void ValidateEmpty()
        {
            if(system.IsEmptyTextOfPhone(txtNumberPhone.Text.Length))
                SetMessage("Debe ingresar un número de movil.");
            else
            {
                string textOfPhone = txtNumberPhone.Text;
                textOfPhone = textOfPhone.Replace(" ", "");
                ValidateNumberFormat(textOfPhone);
            }
        }

        private void ValidateNumberFormat(string textOfPhone)
        {
            if (system.ValidateIsNumeric(textOfPhone))
                if (system.ValidateFormatNumber(ref textOfPhone))
                    ValidateRepeatNumber(textOfPhone);
                else
                    SetMessage("El número no coincide con el formato.");
            else
                SetMessage("El número que ingresó no es númerico.");
        }

        private void ValidateRepeatNumber(string textOfPhone)
        {
            if (system.GetAccounts().ToArray().Length > 0)
                if (!system.ValidateRepeatNumber(textOfPhone))
                    AddAccount(textOfPhone);
                else
                    SetMessage("El número que ingresó ya está registrado.");
            else
                AddAccount(textOfPhone);
        }

        private void AddAccount(string textOfPhone)
        {
            IAccount newAccount = new Account(0, textOfPhone);
            system.AddAccount(newAccount);
            MessageAccountAdded();
        }

        private void MessageAccountAdded()
        {
            lblAnswer.ForeColor = Color.Green;
            SetMessage("La cuenta ha sido registrada correctamente.");
            txtNumberPhone.Clear();
        }

        public void SetMessage(string textToShow)
        {
            lblAnswer.Visible = true;
            lblAnswer.Text = textToShow;
            timerOfAnswer.Start();
        }

        private void timerOfError_Tick(object sender, EventArgs e)
        {
            lblAnswer.Visible = false;
            timerOfAnswer.Enabled = false;
        }
    }
}
