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
        private Panel panel;
        private SystemController system;
        private ValidatorOfEnrollment validatorOfEnrollment;
        private ValidatorOfPhone validatorOfPhone;
        private ValidatorOfMessage validatorOfMessage;
        private ValidatorOfDate validatorOfDate;
        private int costForMinutes;

        public ProcessPurchase(Panel principalPanel, SystemController systemController, int actualCostForMinutes)
        {
            InitializeComponent();
            panel = principalPanel;
            system = systemController;
            validatorOfEnrollment = new ValidatorOfEnrollment();
            validatorOfPhone = new ValidatorOfPhone();
            validatorOfMessage = new ValidatorOfMessage();
            validatorOfDate = new ValidatorOfDate();
            costForMinutes = actualCostForMinutes;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            panel.Visible = true;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            ValidateEmptyNumber();            
        }

        private void ValidateEmptyNumber()
        {
            lblAnswer.ForeColor = Color.Red;
            if (validatorOfPhone.IsEmpty(txtNumberPhone.Text))
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
            if (validatorOfPhone.ValidateFormatNumber(ref textOfPhone))
                ValidateIsNumeric(textOfPhone);
            else
                SetMessage("El número no coincide con el formato.");
        }

        private void ValidateIsNumeric(string textOfPhone)
        {
            if (validatorOfPhone.ValidateIsNumeric(textOfPhone))
                ValidateRepeatNumber(textOfPhone);
            else
                SetMessage("El número que ingresó no es númerico.");
        }

        private void ValidateRepeatNumber(string textOfPhone)
        {
           if (system.IsRepeatedNumber(textOfPhone))
                ValidateEmptyMessage();
           else
                SetMessage("El número que ingresó no está registrado.");
        }

        private void ValidateEmptyMessage()
        {
            if (!validatorOfMessage.IsEmpty(txtMessage.Text))
                ValidateMessage();
            else
                SetMessage("Debe ingresar un mensaje.");
        }

        private void ValidateMessage()
        {
            if (validatorOfMessage.IsLengthOfMessageCorrect(txtMessage.Text.Length))
                ValidateEnrollment();
            else
                SetMessage("El formato del mensaje no es correcto.");
        }

        private void ValidateEnrollment()
        {
            string[] lineOfMessage = txtMessage.Text.Split(' ');
            if (validatorOfEnrollment.IsCorrectSeparationOfEnrollmentMessageWithSpace(lineOfMessage))
                ValidateEnrollmentWithSpace(lineOfMessage);
            else
                ValidateEnrollmentWithoutSpace(lineOfMessage);
        }

        private void ValidateEnrollmentWithSpace(string [] lineOfMessage)
        {
            if (validatorOfEnrollment.ValidateFormatOfEnrollment(lineOfMessage[0] + lineOfMessage[1]))
                ValidateEmptyTime(txtMessage.Text.Substring(8));
            else
                SetMessage("El formato de la matrícula no es valido.");
        }

        private void ValidateEnrollmentWithoutSpace(string [] lineOfMessage)
        {
            if (validatorOfEnrollment.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(lineOfMessage))
                if (validatorOfEnrollment.ValidateFormatOfEnrollment(lineOfMessage[0]))
                    ValidateEmptyTime(txtMessage.Text.Substring(7));
                else
                    SetMessage("El formato de la matrícula no es valido.");
            else
                SetMessage("El formato de la matrícula no es valido.");
        }

        private void ValidateEmptyTime(string restOfMessage)
        {
            string[] lineOfRestOfMessage = restOfMessage.Split(' ');
            if (validatorOfMessage.IsCorrectSeparationOfRestOfMessage(lineOfRestOfMessage))
            {
                string hour = "";
                string minutes = "";
                if (validatorOfMessage.WroteTime(lineOfRestOfMessage))
                {
                    hour = lineOfRestOfMessage[2].Split(':')[0];
                    minutes = lineOfRestOfMessage[2].Split(':')[1];
                }
                string time = lineOfRestOfMessage[1];
                if (validatorOfMessage.ValidateMinutes(restOfMessage))
                    ValidateTime(time, hour, minutes);
                else
                    SetMessage("El formato del mensaje no es correcto.");

            }else
                SetMessage("El formato del mensaje no es correcto.");
        }

        private void ValidateTime(string time, string hour, string minutes)
        {
            if (Entrytime(hour, minutes)){
                if (validatorOfMessage.ValidateIsNumeric(time))
                    AssignTime(time, "" + DateTime.Now.Hour,"" + DateTime.Now.Minute);
                else
                    SetMessage("El formato del tiempo no es valido.");
            }
            else
            {
                if (validatorOfMessage.ValidateIsNumeric(time) && validatorOfMessage.ValidateIsNumeric(hour) 
                    && validatorOfMessage.ValidateIsNumeric(minutes))
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
            if(validatorOfMessage.ValideTimeOfPurchase(timeOfPurchase))
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
            if (validatorOfDate.ValidateValidHour(dateTime))
            {
                int finalTimeOfPurchase = validatorOfMessage.CalculateFinalTimeOfPurchase(timeOfPurchase, hourOfPurchase, minsOfPurchase);
                CheckBalanceAccount(finalTimeOfPurchase, dateTime);
            }
            else
                SetMessage("La hora es incorrecta o previa a la hora actual.");
        }

        private void CheckBalanceAccount(int finalTimeOfPurchase, DateTime dateTime)
        {
            Account account = system.GetAnAccount(txtNumberPhone.Text.Replace(" ", ""));
            int finalCostOfPurchase = finalTimeOfPurchase * costForMinutes;
            if (finalCostOfPurchase < account.balance)
            {
                SubtractBalance(account, finalCostOfPurchase);
                AddEnrollment(finalTimeOfPurchase, dateTime);
            }
            else
                SetMessage("El saldo de la cuenta es insuficiente.");
        }

        private void SubtractBalance(Account account, int finalCostOfPurchase)
        {
            account.SubstractBalance(finalCostOfPurchase);
        }

        private void AddEnrollment(int finalTimeOfPurchase, DateTime dateTime)
        {
            string aEnrollment = txtMessage.Text.Replace(" ", "");
            Enrollment enrollment = new Enrollment(aEnrollment.Substring(0, 3),
            Int32.Parse(aEnrollment.Substring(3, 4)));
            system.AddEnrollment(enrollment);
            AddPurchase(finalTimeOfPurchase, enrollment, dateTime);
        }

        private void AddPurchase(int finalTimeOfPurchase, Enrollment enrollment, DateTime dateTime)
        {
            if (!system.ArePurchaseOnThatDate(dateTime, enrollment))
            {
                Purchase newPurchase = new Purchase(enrollment, finalTimeOfPurchase, dateTime);
                system.AddPurchase(newPurchase);
                MessagePurchaseAdded();
            }
            else
                SetMessage("Ya hay una compra activa en ese horario.");
        }

        private void MessagePurchaseAdded()
        {
            lblAnswer.ForeColor = Color.Green;
            SetMessage("Compra realizada correctamente.");
            RestartInputData();
        }

        private void RestartInputData()
        {
            txtNumberPhone.Clear();
            txtMessage.Clear();
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
    }
}
