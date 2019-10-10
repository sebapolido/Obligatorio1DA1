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
        private Panel panel;
        private SystemController system;
        private ValidatorOfPhone validatorOfPhone;
        
        public AccountRegister(Panel principalPanel, SystemController systemController)
        {
            InitializeComponent();
            panel = principalPanel;
            system = systemController;
            validatorOfPhone = new ValidatorOfPhone();
        }     

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            panel.Visible = true;

        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            ValidateEmpty();
        }

        private void ValidateEmpty()
        {
            if(validatorOfPhone.IsEmpty(txtNumberPhone.Text))
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
            if (validatorOfPhone.ValidateIsNumeric(textOfPhone))
                if (validatorOfPhone.ValidateFormatNumber(ref textOfPhone))
                    ValidateRepeatNumber(textOfPhone);
                else
                    SetMessage("El número no coincide con el formato.");
            else
                SetMessage("El número que ingresó no es númerico.");
        }

        private void ValidateRepeatNumber(string textOfPhone)
        {
            if (system.GetAccounts().ToArray().Length > 0)
                if (!system.IsRepeatedNumber(textOfPhone))
                    AddAccount(textOfPhone);
                else
                    SetMessage("El número que ingresó ya está registrado.");
            else
                AddAccount(textOfPhone);
        }

        private void AddAccount(string textOfPhone)
        {
            Account newAccount = new Account(0, textOfPhone);
            system.AddAccount(newAccount);
            MessageAccountAdded();
        }

        private void MessageAccountAdded()
        {
            lblAnswer.ForeColor = Color.Green;
            SetMessage("La cuenta ha sido registrada correctamente.");
            txtNumberPhone.Clear();
        }

        private void SetMessage(string textToShow)
        {
            lblAnswer.Visible = true;
            lblAnswer.Text = textToShow;
            timerOfAnswer.Start();
        }

        private void TimerOfError_Tick(object sender, EventArgs e)
        {
            lblAnswer.Visible = false;
            timerOfAnswer.Enabled = false;
        }
    }
}
