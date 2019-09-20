﻿using System;
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
    public partial class ProcessPurchase : UserControl
    {
        Panel panel;
        SystemController system;

        public ProcessPurchase(Panel principalPanel, SystemController systemController)
        {
            InitializeComponent();
            panel = principalPanel;
            system = systemController;
            this.txtMessage.Leave += new System.EventHandler(this.txtMessage_Leave);
            this.txtMessage.Enter += new System.EventHandler(this.txtMessage_Enter);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            panel.Visible = true;
        }

        private void TxtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ValidateEmptyNumber();
            }

        }

        private void TxtNumberPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                ValidateEmptyNumber();
            }

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ValidateEmptyNumber();            
        }

        private void ValidateEmptyNumber()
        {
            lblAnswer.ForeColor = Color.Red;
            if (txtNumberPhone.Text.Length == 0)
                SetMessage("Debe ingresar un número de movil.");
            else
            {
                string text = txtNumberPhone.Text;
                text = text.Replace(" ", "");
                if (system.ValidateLengthNumber(text))
                {
                    ValidateNumberFormat(text);
                }
                else
                    SetMessage("El número no coincide con el formato.");
            }
        }
        
        private void ValidateNumberFormat(string text)
        {
            if (system.ValidateIsNumeric(text))
                ValidateRepeatNumber(text);
            else
                SetMessage("El número que ingresó no es númerico.");
        }

        private void ValidateRepeatNumber(string text)
        {
            if (system.GetAccounts().ToArray().Length > 0)
            {
                if (system.ValidateRepeatNumber(text))
                    ValidateMessage(system.getAnAccount(text));
                else
                    SetMessage("El número que ingresó no está registrado.");
            }
        }

        private void ValidateMessage(Account account)
        {
            if (txtMessage.Text.Length > 8 && txtMessage.Text.Length < 20)
            {
                string text = txtMessage.Text.Substring(0, 8);
                if (system.ValidateFormatOfEnrollment(text))
                   ValidateMinutes(txtMessage.Text.Substring(7), account);
                else
                   SetMessage("El formato de la matricula no es valido.");      
            }

            else
                SetMessage("Debe ingresar un mensaje.");
        }

        private void ValidateMinutes(String restOfMessage, Account account)
        {
            string hour = "";
            string minutes = "";
            string time = "";
            if (system.ValidateMinutes(restOfMessage, hour, minutes, time) == 0)
            {
                ValidateTime(time, hour, minutes, account);
            }
            else
                SetMessage("El formato del mensaje no es correcto.");
            
           
        }

        private void ValidateTime(string time, string hour, string minutes, Account account)
        {
            if (hour.Equals("") && minutes.Equals("")){
                if (IsConvertStringToNumber(time))
                    validateTimeMultipleOf30(time, account);
                else
                    SetMessage("El formato del tiempo no es valido.");
            }
            else
            {
                if (IsConvertStringToNumber(time, hour, minutes))
                {

                }
                else
                    SetMessage("El formato de la hora es valido.");
            }
           /* if ((int)time % 30 == 0)
            {

            }*/
            
        }

        private void validateTimeMultipleOf30(string time, Account account)
        {            
            Int32.TryParse(time, out int timeOfParking);
            if(timeOfParking % 30 == 0)
            {
                if (account.balance >= timeOfParking)
                {

                }
                else
                    SetMessage("El saldo de la cuenta es insuficiente.");
            }
            else
                SetMessage("La cantidad de minutos debe ser múltiplo de 30.");
        }

        private bool IsConvertStringToNumber(string time)
        {
            int isNumeric = 0;
            if (Int32.TryParse(time, out isNumeric))
                return true;
            else
                return false;
        }

        private bool IsConvertStringToNumber(string time, string hour, string minutes)
        {
            int isNumeric = 0;
            if (Int32.TryParse(time, out isNumeric) && Int32.TryParse(hour, out isNumeric) && Int32.TryParse(minutes, out isNumeric))
                return true;
            else
                return false;
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

        private void txtMessage_Leave(object sender, EventArgs e)
        {
            if (txtMessage.Text.Length == 0)
            {
                txtMessage.Text = "Ej: ABC 1234 60 11:00";
                txtMessage.ForeColor = SystemColors.ControlDark;
            }
        }

        private void txtMessage_Enter(object sender, EventArgs e)
        {
            txtMessage.ForeColor = Color.Black;
            txtMessage.Text = "";
        }


        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
