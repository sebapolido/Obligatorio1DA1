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
        private Panel Panel;
        private IParkingRepository Repository;
        private ValidatorOfEnrollment ValidatorOfEnrollment;
        private ValidatorOfDate ValidatorOfDate;
        private CountryHandler CountryHandler;
        private int CostForMinutes;

        public ProcessPurchase(Panel PrincipalPanel, IParkingRepository ParkingRepository, CountryHandler ActualCountry)
        {
            InitializeComponent();
            Panel = PrincipalPanel;
            Repository = ParkingRepository;
            ValidatorOfEnrollment = new ValidatorOfEnrollment();
            ValidatorOfDate = new ValidatorOfDate();
            CostForMinutes = ActualCountry.CostForMinutes;
            CountryHandler = ActualCountry;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Panel.Visible = true;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            ValidateEmptyNumber();            
        }

        private void ValidateEmptyNumber()
        {
            lblAnswer.ForeColor = Color.Red;
            if (CountryHandler.ValidateIsEmptyByCountry(txtNumberPhone.Text))
                SetMessage("Debe ingresar un número de movil.");
            else
            {
                string TextOfPhone = txtNumberPhone.Text;
                TextOfPhone = TextOfPhone.Replace(" ", "");
                ValidateFormatNumber(TextOfPhone);
            }
        }

        private void ValidateFormatNumber(string TextOfPhone)
        {
            if (CountryHandler.ValidateFormatNumberByCountry(ref TextOfPhone))
                ValidateIsNumeric(TextOfPhone);
            else
                SetMessage("El número no coincide con el formato.");
        }

        private void ValidateIsNumeric(string TextOfPhone)
        {
            if (CountryHandler.ValidateIsNumericByCountry(TextOfPhone))
                ValidateRepeatNumber(TextOfPhone);
            else
                SetMessage("El número que ingresó no es númerico.");
        }

        private void ValidateRepeatNumber(string TextOfPhone)
        {
           if (Repository.IsRepeatedNumber(TextOfPhone))
                ValidateEmptyMessage();
           else
                SetMessage("El número que ingresó no está registrado.");
        }

        private void ValidateEmptyMessage()
        {
            if (!CountryHandler.ValidateIsEmptyByCountry(txtMessage.Text))
                ValidateLengthMessage();
            else
                SetMessage("Debe ingresar un mensaje.");
        }

        private void ValidateLengthMessage()
        {
            if (CountryHandler.IsLengthOfMessageCorrectByCountry(txtMessage.Text.Length))
                ValidateEnrollment();
            else
                SetMessage("El formato del mensaje no es correcto.");
        }

        private void ValidateEnrollment()
        {
            string[] LineOfMessage = txtMessage.Text.Split(' ');
            if (ValidatorOfEnrollment.IsCorrectSeparationOfEnrollmentMessageWithSpace(LineOfMessage))
                ValidateEnrollmentWithSpace(LineOfMessage);
            else
                ValidateEnrollmentWithoutSpace(LineOfMessage);
        }

        private void ValidateEnrollmentWithSpace(string [] LineOfMessage)
        {
            if (ValidatorOfEnrollment.ValidateFormatOfEnrollment(LineOfMessage[0] + LineOfMessage[1]))
                ValidateMessageData(txtMessage.Text.Substring(8));
            else
                SetMessage("El formato de la matrícula no es válido.");
        }

        private void ValidateEnrollmentWithoutSpace(string [] LineOfMessage)
        {
            if (ValidatorOfEnrollment.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(LineOfMessage))
                if (ValidatorOfEnrollment.ValidateFormatOfEnrollment(LineOfMessage[0]))
                    ValidateMessageData(txtMessage.Text.Substring(7));
                else
                    SetMessage("El formato de la matrícula no es válido.");
            else
                SetMessage("El formato de la matrícula no es válido.");
        }

        private void ValidateMessageData(string RestOfMessage)
        {
            if (CountryHandler.ValidateMessageDataByCountry(RestOfMessage))
                AssignValues(RestOfMessage);
            else
                SetMessage("El formato del mensaje no es correcto.");
        }

        private void AssignValues(string RestOfMessage)
        {
            string[] LineOfRestOfMessage = RestOfMessage.Split(' ');
            int HourOfPurchase = DateTime.Now.Hour;
            int MinutesOfPurchase = DateTime.Now.Minute;
            if (CountryHandler.WroteHourAndMinutesByCountry(LineOfRestOfMessage))
            {
                HourOfPurchase = CountryHandler.AssignHourByCountry(LineOfRestOfMessage);
                MinutesOfPurchase = CountryHandler.AssignMinutesByCountry(LineOfRestOfMessage);
            }
            int TimeOfPurchase = CountryHandler.AssignTimeByCountry(LineOfRestOfMessage);
            DateTime DateOfPurchase = AssignTimesToDate(HourOfPurchase, MinutesOfPurchase);
            ValidateTimeMultipleOf30(TimeOfPurchase, DateOfPurchase);
        }

        private DateTime AssignTimesToDate(int HourOfPurchase, int MinutesOfPurchase)
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 
                HourOfPurchase, MinutesOfPurchase, 0);
        }

        private void ValidateTimeMultipleOf30(int TimeOfPurchase, DateTime DateOfPurchase)
        {   
            if(CountryHandler.ValidateTimeOfPurchaseByCountry(TimeOfPurchase))
                ValidateDate(TimeOfPurchase, DateOfPurchase);
            else
                SetMessage("La cantidad de minutos debe ser múltiplo de 30.");
        }

        private void ValidateDate(int TimeOfPurchase, DateTime DateOfPurchase)
        {
            if (ValidatorOfDate.ValidateValidHour(DateOfPurchase))
            {
                int FinalTimeOfPurchase = CountryHandler.CalculateFinalTimeOfPurchaseByCountry(TimeOfPurchase, DateOfPurchase);
                CheckBalanceAccount(FinalTimeOfPurchase, DateOfPurchase);
            }
            else
                SetMessage("La hora es incorrecta o previa a la hora actual.");
        }

        private void CheckBalanceAccount(int FinalTimeOfPurchase, DateTime DateTimeOfPurchase)
        {
            Account Account = Repository.GetAnAccount(txtNumberPhone.Text.Replace(" ", ""));
            int FinalCostOfPurchase = FinalTimeOfPurchase * CostForMinutes;
            if (FinalCostOfPurchase <= Account.Balance)
            {
                SubtractBalance(Account, FinalCostOfPurchase);
                AddEnrollment(FinalTimeOfPurchase, DateTimeOfPurchase);
            }
            else
                SetMessage("El saldo de la cuenta es insuficiente.");
        }

        private void SubtractBalance(Account Account, int FinalCostOfPurchase)
        {
            Repository.SubstractBalanceToAccount(Account, FinalCostOfPurchase);
        }

        private void AddEnrollment(int FinalTimeOfPurchase, DateTime DateTime)
        {
            string NewEnrollment = txtMessage.Text.Replace(" ", "");
            Enrollment Enrollment = new Enrollment(NewEnrollment.Substring(0, 3),
            Int32.Parse(NewEnrollment.Substring(3, 4)));
            if (Repository.IsRepeatedEnrollment(Enrollment.LettersOfEnrollment, Enrollment.NumbersOfEnrollment))
                Enrollment = Repository.GetAnEnrollment(Enrollment.LettersOfEnrollment, Enrollment.NumbersOfEnrollment);
            else
                Repository.AddEnrollment(Enrollment);
            AddPurchase(FinalTimeOfPurchase, Enrollment, DateTime);
        }

        private void AddPurchase(int FinalTimeOfPurchase, Enrollment Enrollment, DateTime DateTime)
        {
            if (!Repository.ArePurchaseOnThatDate(DateTime, Enrollment))
            {
                Account Account = Repository.GetAnAccount(txtNumberPhone.Text.Replace(" ", ""));
                Purchase NewPurchase = new Purchase(Enrollment, FinalTimeOfPurchase, DateTime, Account);
                Repository.AddPurchase(NewPurchase);
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
        
        private void SetMessage(string TextToShow)
        {
            lblAnswer.Visible = true;
            lblAnswer.Text = TextToShow;
            timerOfAnswer.Start();
        }

        private void TimerOfAnswer_Tick(object sender, EventArgs e)
        {
            lblAnswer.Visible = false;
            timerOfAnswer.Enabled = false;
        }
    }
}
