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
                string[] line = txtMessage.Text.Split(' ');
                if (line[0].Length == 3 && line.Length > 1 && line[1].Length == 4)
                {
                    if (system.ValidateFormatOfEnrollment(line[0] + line[1]))
                        ValidateEmptyTime(txtMessage.Text.Substring(8), account);
                    else
                        SetMessage("El formato de la matricula no es valido.");
                }
                else
                    if (line[0].Length == 7) {
                        if (system.ValidateFormatOfEnrollment(line[0]))
                            ValidateEmptyTime(txtMessage.Text.Substring(7), account);
                        else
                            SetMessage("El formato de la matricula no es valido.");
                    }else
                        SetMessage("El formato de la matricula no es valido.");
            }
            else
                SetMessage("Debe ingresar un mensaje.");
        }

        private void ValidateEmptyTime(String restOfMessage, Account account)
        {
            string[] line = restOfMessage.Split(' ');
            if (line.Length >= 2 && line.Length<=3)
            {
                string hour = "";
                string minutes = "";
                if (line.Length == 3 && line[2].Contains(':'))
                {
                    hour = line[2].Split(':')[0];
                    minutes = line[2].Split(':')[1];
                }
                string time = line[1];
                if (system.ValidateMinutes(restOfMessage))
                {
                    ValidateTime(time, hour, minutes, account);
                }
                else
                    SetMessage("El formato del mensaje no es correcto.");

            }else
                SetMessage("El formato del mensaje no es correcto.");
        }

        private void ValidateTime(string time, string hour, string minutes, Account account)
        {
            if (hour.Equals("") && minutes.Equals("")){
                if (IsConvertStringToNumber(time))
                {
                    int timeOfPurchase = Int32.Parse(time);
                    ValidateTimeMultipleOf30(timeOfPurchase, DateTime.Now.Hour,
                        DateTime.Now.Hour, account);
                }
                else
                    SetMessage("El formato del tiempo no es valido.");
            }
            else
            {
                if (IsConvertStringToNumber(time, hour, minutes))
                {
                    int timeOfPurchase = Int32.Parse(time);
                    int hourOfPurchase = Int32.Parse(hour);
                    int minsOfPurchase = Int32.Parse(minutes);
                    ValidateTimeMultipleOf30(timeOfPurchase, hourOfPurchase, minsOfPurchase, account);
                }
                else
                    SetMessage("El formato de la hora es valido.");
            }           
        }

        private void ValidateTimeMultipleOf30(int timeOfPurchase, int hourOfPurchase, int minsOfPurchase, Account account)
        {   
            if(system.ValideTimeOfPurchase(timeOfPurchase))
            {
                ValidateDate(timeOfPurchase, hourOfPurchase, minsOfPurchase, account);
            }
            else
                SetMessage("La cantidad de minutos debe ser múltiplo de 30.");
        }

        private void ValidateDate(int timeOfPurchase, int hourOfPurchase, int minsOfPurchase, Account account)
        {
            DateTime dateTime = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, hourOfPurchase,
                        minsOfPurchase, 0);
            if (system.ValidateValidHour(dateTime))
            {

            }
            else
                SetMessage("El formato de la hora no es correcto");
        }

        private bool IsConvertStringToNumber(string time)
        {
            return system.IsConvertTimeStringToNumber(time);
        }

        private bool IsConvertStringToNumber(string time, string hour, string minutes)
        {
            return system.IsConvertTimeHourAndMinutesStringToNumber(time, hour, minutes);
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
