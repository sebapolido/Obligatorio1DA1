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
        ISystemController system;

        public ProcessPurchase(Panel principalPanel, ISystemController systemController)
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
                string textOfPhone = txtNumberPhone.Text;
                textOfPhone = textOfPhone.Replace(" ", "");
                ValidateFormatNumber(textOfPhone);
            }
        }

        private void ValidateFormatNumber(string textOfPhone)
        {
            if (system.ValidateFormatNumber(ref textOfPhone))
            {
                ValidateIsNumeric(textOfPhone);
            }
            else
                SetMessage("El número no coincide con el formato.");
        }

        private void ValidateIsNumeric(string textOfPhone)
        {
            if (system.ValidateIsNumeric(textOfPhone))
                ValidateRepeatNumber(textOfPhone);
            else
                SetMessage("El número que ingresó no es númerico.");
        }

        private void ValidateRepeatNumber(string textOfPhone)
        {
            if (system.GetAccounts().ToArray().Length > 0)
            {
                if (system.ValidateRepeatNumber(textOfPhone))
                    ValidateMessage();
                else
                    SetMessage("El número que ingresó no está registrado.");
            }
        }

        private void ValidateMessage()
        {
            if (IsLengthOfMessageCorrect())
            {
                string[] lineOfMessage = txtMessage.Text.Split(' ');
                if (IsCorrectSeparationOfMessage(lineOfMessage))
                {
                    if (system.ValidateFormatOfEnrollment(lineOfMessage[0] + lineOfMessage[1]))
                        ValidateEmptyTime(txtMessage.Text.Substring(8));
                    else
                        SetMessage("El formato de la matrícula no es valido.");
                }
                else
                    if (lineOfMessage[0].Length == 7) {
                        if (system.ValidateFormatOfEnrollment(lineOfMessage[0]))
                            ValidateEmptyTime(txtMessage.Text.Substring(7));
                        else
                            SetMessage("El formato de la matrícula no es valido.");
                    }else
                        SetMessage("El formato de la matrícula no es valido.");
            }
            else
                SetMessage("Debe ingresar un mensaje.");
        }

        private bool IsCorrectSeparationOfMessage(string[] lineOfMessage)
        {
            return lineOfMessage[0].Length == 3 && lineOfMessage.Length > 1 && lineOfMessage[1].Length == 4;
        }

        private bool IsLengthOfMessageCorrect()
        {
            return txtMessage.Text.Length > 8 && txtMessage.Text.Length < 20;
        }

        private void ValidateEmptyTime(string restOfMessage)
        {
            string[] lineOfRestOfMessage = restOfMessage.Split(' ');
            if (IsCorrectSeparationOfRestOfMessage(lineOfRestOfMessage))
            {
                string hour = "";
                string minutes = "";
                if (WroteTimeAndMinute(lineOfRestOfMessage))
                {
                    hour = lineOfRestOfMessage[2].Split(':')[0];
                    minutes = lineOfRestOfMessage[2].Split(':')[1];
                }
                string time = lineOfRestOfMessage[1];
                if (system.ValidateMinutes(restOfMessage))
                {
                    ValidateTime(time, hour, minutes);
                }
                else
                    SetMessage("El formato del mensaje no es correcto.");

            }else
                SetMessage("El formato del mensaje no es correcto.");
        }

        private bool WroteTimeAndMinute(string[] line)
        {
            return line.Length == 3 && line[2].Contains(':');
        }

        public bool IsCorrectSeparationOfRestOfMessage(string [] line)
        {
            return line.Length >= 2 && line.Length <= 3;
        }

        private void ValidateTime(string time, string hour, string minutes)
        {
            if (Entrytime(hour, minutes)){
                if (IsConvertStringToNumber(time))
                    AssignTime(time, "" + DateTime.Now.Hour,"" + DateTime.Now.Minute);
                else
                    SetMessage("El formato del tiempo no es valido.");
            }
            else
            {
                if (IsConvertStringToNumber(time, hour, minutes))
                    AssignTime(time, hour, minutes);
                else
                    SetMessage("El formato de la hora es valido.");
            }           
        }

        private void AssignTime(string time, string hour, string minutes)
        {
            int timeOfPurchase = Int32.Parse(time);
            int hourOfPurchase = Int32.Parse(hour);
            int minsOfPurchase = Int32.Parse(minutes);
            ValidateTimeMultipleOf30(timeOfPurchase, hourOfPurchase, minsOfPurchase);
        }

        private bool Entrytime(string hour, string minutes)
        {
            return hour.Equals("") && minutes.Equals("");
        }

        private void ValidateTimeMultipleOf30(int timeOfPurchase, int hourOfPurchase, int minsOfPurchase)
        {   
            if(system.ValideTimeOfPurchase(timeOfPurchase))
            {
                if(minsOfPurchase >= 0 && minsOfPurchase < 60) 
                    ValidateDate(timeOfPurchase, hourOfPurchase, minsOfPurchase);
                else
                    SetMessage("El formato de la hora no es correcto");
            }
            else
                SetMessage("La cantidad de minutos debe ser múltiplo de 30.");
        }

        private void ValidateDate(int timeOfPurchase, int hourOfPurchase, int minsOfPurchase)
        {
            DateTime dateTime = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, hourOfPurchase,
                        minsOfPurchase, 0);
            if (system.ValidateValidHour(dateTime))
            {
                int finalTimeOfPurchase = system.CalculateFinalTimeOfPurchase(timeOfPurchase, hourOfPurchase, minsOfPurchase);
                CheckBalanceAccount(finalTimeOfPurchase, dateTime);
            }
            else
                SetMessage("El formato de la hora no es correcto");
        }

        private void CheckBalanceAccount(int finalTimeOfPurchase, DateTime dateTime)
        {
            IAccount account = system.GetAnAccount(txtNumberPhone.Text.Replace(" ", ""));
            int costForMinut = 1;
            int finalCostOfPurchase = finalTimeOfPurchase * costForMinut;
            if (finalCostOfPurchase < account.balance) //ARREGLARRRR
            {
                SubtractBalance(account, finalCostOfPurchase);
                AddEnrollment(finalTimeOfPurchase, dateTime);
            }
            else
                SetMessage("El saldo de la cuenta es insuficiente.");
        }

        private void SubtractBalance(IAccount account, int finalCostOfPurchase)
        {
            account.SubstractBalance(finalCostOfPurchase);
        }


        private void AddEnrollment(int finalTimeOfPurchase, DateTime dateTime)
        {
            string aEnrollment = txtMessage.Text.Replace(" ", "");
            IEnrollment enrollment = new Enrollment(aEnrollment.Substring(0, 3),
            Int32.Parse(aEnrollment.Substring(3, 4)));
            system.AddEnrollment(enrollment);
            AddPurchase(finalTimeOfPurchase, enrollment, dateTime);
        }

        private void AddPurchase(int finalTimeOfPurchase, IEnrollment enrollment, DateTime dateTime)
        {
            if (!system.ArePurchaseOnThatDate(dateTime, enrollment))
            {
                IPurchase newPurchase = new Purchase(enrollment, finalTimeOfPurchase, dateTime);
                system.AddPurchase(newPurchase);
                lblAnswer.ForeColor = Color.Green;
                SetMessage("Compra realizada correctamente.");
            }
            else
                SetMessage("Ya hay una compra activa en ese horario.");
        }

        private bool IsConvertStringToNumber(string time)
        {
            return system.IsConvertStringToNumber(time);
        }

        private bool IsConvertStringToNumber(string time, string hour, string minutes)
        {
            return system.IsConvertStringToNumber(time) && system.IsConvertStringToNumber(hour)
                && system.IsConvertStringToNumber(minutes);
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
