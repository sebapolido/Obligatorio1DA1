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
        private Panel Panel;
        private IParkingRepository ParkingRepository;
        public CountryHandler Country { get; set; }

        public Settings(Panel PrincipalPanel, IParkingRepository Parking, CountryHandler ActualCountry)
        {
            InitializeComponent();
            Panel = PrincipalPanel;
            ParkingRepository = Parking;
            Country = ActualCountry;
            AgregateItemsToComboBoxs();
            SetActualData();
        }

        private void AgregateItemsToComboBoxs()
        {
             if (cboCountry.Items.Count == 0)
                for (int i = 0; i < ParkingRepository.GetCountries().ToArray().Length; i++)
                    cboCountry.Items.Add(ParkingRepository.GetCountries().ElementAt(i).NameOfCountry);
        }

        private void SetActualData()
        {
            lblActualCostForMinutes.Text = "El costo por minuto actual es de: " + Country.CostForMinutes;
            lblActualCountry.Text = "El país actual es: " + Country.NameOfCountry;
        }

        private void TxtCostForMinutes_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            lblAnswer.ForeColor = Color.Red;
            ValidateEmptyData();
        }

        private void ValidateEmptyData()
        {
            if (Country.ValidateIsEmptyByCountry(txtCostForMinutes.Text) && cboCountry.Text.Equals(""))
                SetMessage("Debe ingresar un país o un costo.");
            else
                ValidateOnlyCountrySelected();
        }

        private void ValidateOnlyCountrySelected()
        {
            if (!cboCountry.Text.Equals("") && Country.ValidateIsEmptyByCountry(txtCostForMinutes.Text))
                ActualizationMessage("El país ha sido actualizado.");
            else
                ValidateOnlyCostSelected();
        }

        private void ValidateOnlyCostSelected()
        {
            if (Country.ValidateIsNumericByCountry(txtCostForMinutes.Text) && cboCountry.Text.Equals(""))
                ActualizationMessage("El costo por minuto ha sido actualizado.");
            else
                ValidateCorrectCountryAndCost();
        }

        private void ValidateCorrectCountryAndCost()
        {
            if (Country.ValidateIsNumericByCountry(txtCostForMinutes.Text))
                ActualizationMessage("El costo por minuto ha sido actualizado.");
            else
                SetMessage("Debe ingresar un número.");
        }

        private void ActualizationMessage(string message)
        {
            UpdateData();
            lblAnswer.ForeColor = Color.Green;
            SetActualData();
            SetMessage(message);
            RestartInputData();
        }

        private void UpdateData()
        {
            if (!cboCountry.Text.Equals(""))
                Country = ParkingRepository.GetACountry(cboCountry.Text);
            if (Country.ValidateIsNumericByCountry(txtCostForMinutes.Text))
            {
                int NewCostOfMinutes = int.Parse(txtCostForMinutes.Text);
                Country.CostForMinutes = NewCostOfMinutes;
                ParkingRepository.UpdateCostForMinutes(Country);
            }
        }

        private void RestartInputData()
        {
            txtCostForMinutes.Clear();
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Panel.Visible = true;
        }
    }
}
