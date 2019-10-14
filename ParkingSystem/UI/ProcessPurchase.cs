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
        private IParkingRepository repository;
        private ValidatorOfEnrollment validatorOfEnrollment;
        private ValidatorOfPhone validatorOfPhone;
        private ValidatorOfMessage validatorOfMessage;
        private ValidatorOfDate validatorOfDate;
        private int costForMinutes;

        public ProcessPurchase(Panel principalPanel, IParkingRepository parkingRepository, int actualCostForMinutes)
        {
            InitializeComponent();
            panel = principalPanel;
            repository = parkingRepository;
            validatorOfEnrollment = new ValidatorOfEnrollment();
            validatorOfPhone = new ValidatorOfPhone();
            validatorOfMessage = new ValidatorOfMessage();
            validatorOfDate = new ValidatorOfDate();
            costForMinutes = actualCostForMinutes;
            this.txtMessage.Leave += new System.EventHandler(this.TxtMessage_Leave);
            this.txtMessage.Enter += new System.EventHandler(this.TxtMessage_Enter);
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
            if (validatorOfPhone.ValidateIsEmpty(txtNumberPhone.Text))
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
           if (repository.IsRepeatedNumber(textOfPhone))
                ValidateEmptyMessage();
           else
                SetMessage("El número que ingresó no está registrado.");
        }

        private void ValidateEmptyMessage()
        {
            if (!validatorOfMessage.ValidateIsEmpty(txtMessage.Text))
                ValidateLengthMessage();
            else
                SetMessage("Debe ingresar un mensaje.");
        }

        private void ValidateLengthMessage()
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
                ValidateMessageData(txtMessage.Text.Substring(8));
            else
                SetMessage("El formato de la matrícula no es válido.");
        }

        private void ValidateEnrollmentWithoutSpace(string [] lineOfMessage)
        {
            if (validatorOfEnrollment.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(lineOfMessage))
                if (validatorOfEnrollment.ValidateFormatOfEnrollment(lineOfMessage[0]))
                    ValidateMessageData(txtMessage.Text.Substring(7));
                else
                    SetMessage("El formato de la matrícula no es válido.");
            else
                SetMessage("El formato de la matrícula no es válido.");
        }

        private void ValidateMessageData(string restOfMessage)
        {
            if (validatorOfMessage.ValidateMessageData(restOfMessage))
                AssignValues(restOfMessage);
            else
                SetMessage("El formato del mensaje no es correcto.");
        }

        private void AssignValues(string restOfMessage)
        {
            string[] lineOfRestOfMessage = restOfMessage.Split(' ');
            int hour = DateTime.Now.Hour;
            int minutes = DateTime.Now.Minute;
            if (validatorOfMessage.WroteHourAndMinutes(lineOfRestOfMessage))
            {
                hour = int.Parse(lineOfRestOfMessage[2].Split(':')[0]);
                minutes = int.Parse(lineOfRestOfMessage[2].Split(':')[1]);
            }
            int time = int.Parse(lineOfRestOfMessage[1]);
            AssignTimesToDate(time, hour, minutes);
        }

        private void AssignTimesToDate(int timeOfPurchase, int hourOfPurchase, int minutesOfPurchase)
        {
            DateTime dateOfPurchse = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, hourOfPurchase,
                        minutesOfPurchase, 0);
            ValidateTimeMultipleOf30(timeOfPurchase, dateOfPurchse);
        }

        private void ValidateTimeMultipleOf30(int timeOfPurchase, DateTime dateOfPurchse)
        {   
            if(validatorOfMessage.ValideTimeOfPurchase(timeOfPurchase))
                ValidateDate(timeOfPurchase, dateOfPurchse);
            else
                SetMessage("La cantidad de minutos debe ser múltiplo de 30.");
        }

        private void ValidateDate(int timeOfPurchase, DateTime dateOfPurchse)
        {
            if (validatorOfDate.ValidateValidHour(dateOfPurchse))
            {
                int finalTimeOfPurchase = validatorOfMessage.CalculateFinalTimeOfPurchase(timeOfPurchase, dateOfPurchse);
                CheckBalanceAccount(finalTimeOfPurchase, dateOfPurchse);
            }
            else
                SetMessage("La hora es incorrecta o previa a la hora actual.");
        }

        private void CheckBalanceAccount(int finalTimeOfPurchase, DateTime dateTimeOfPurchase)
        {
            Account account = repository.GetAnAccount(txtNumberPhone.Text.Replace(" ", ""));
            int finalCostOfPurchase = finalTimeOfPurchase * costForMinutes;
            if (finalCostOfPurchase <= account.balance)
            {
                SubtractBalance(account, finalCostOfPurchase);
                AddEnrollment(finalTimeOfPurchase, dateTimeOfPurchase);
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
            repository.AddEnrollment(enrollment);
            AddPurchase(finalTimeOfPurchase, enrollment, dateTime);
        }

        private void AddPurchase(int finalTimeOfPurchase, Enrollment enrollment, DateTime dateTime)
        {
            if (!repository.ArePurchaseOnThatDate(dateTime, enrollment))
            {
                Purchase newPurchase = new Purchase(enrollment, finalTimeOfPurchase, dateTime);
                repository.AddPurchase(newPurchase);
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

        private void TxtMessage_Leave(object sender, EventArgs e)
        {
            if (txtMessage.Text.Length == 0)
            {
                txtMessage.Text = "Ej: ABC 1234 60 11:00";
                txtMessage.ForeColor = Color.DarkGray;
            }
        }

        private void TxtMessage_Enter(object sender, EventArgs e)
        {
            if (txtMessage.Text == "Ej: ABC 1234 60 11:00")
            {
                txtMessage.Text = "";
                txtMessage.ForeColor = Color.Black;
            }
        }
    }
}
