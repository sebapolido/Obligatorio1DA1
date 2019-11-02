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
        private Panel panel;
        private Validator validator;
        private IParkingRepository parkingRepository;
        public CountryHandler country { get; set; }

        public Settings(Panel principalPanel, IParkingRepository parking, CountryHandler actualCountry)
        {
            InitializeComponent();
            panel = principalPanel;
            parkingRepository = parking;
            validator = new Validator();
            country = actualCountry;
            AgregateItemsToComboBoxs();
            SetActualData();
        }

        private void AgregateItemsToComboBoxs()
        {
             if (cboCountry.Items.Count == 0)
                for (int i = 0; i < parkingRepository.GetCountries().ToArray().Length; i++)
                    cboCountry.Items.Add(parkingRepository.GetCountries().ElementAt(i).NameOfCountry);
        }

        private void SetActualData()
        {
            lblActualCostForMinutes.Text = "El costo por minuto actual es de: " + country.CostForMinutes;
            lblActualCountry.Text = "El país actual es: " + country.NameOfCountry;
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
            if (validator.ValidateIsEmpty(txtCostForMinutes.Text) && cboCountry.Text.Equals(""))
                SetMessage("Debe ingresar un país o un costo.");
            else
                ValidateOnlyCountrySelected();
        }

        private void ValidateOnlyCountrySelected()
        {
            if (!cboCountry.Text.Equals("") && validator.ValidateIsEmpty(txtCostForMinutes.Text))
                ActualizationMessage("El país ha sido actualizado.");
            else
                ValidateOnlyCostSelected();
        }

        private void ValidateOnlyCostSelected()
        {
            if (validator.ValidateIsNumeric(txtCostForMinutes.Text) && cboCountry.Text.Equals(""))
                ActualizationMessage("El costo por minuto ha sido actualizado.");
            else
                ValidateCorrectCountryAndCost();
        }

        private void ValidateCorrectCountryAndCost()
        {
            if (validator.ValidateIsNumeric(txtCostForMinutes.Text))
                ActualizationMessage("El costo por minuto ha sido actualizado.");
            else
                SetMessage("Debe ingresar un número.");
        }

        private void ActualizationMessage(string message)
        {
            if(!cboCountry.Text.Equals(""))
                country = parkingRepository.GetACountry(cboCountry.Text);
            if(validator.ValidateIsNumeric(txtCostForMinutes.Text))
                country.CostForMinutes = int.Parse(txtCostForMinutes.Text);
            lblAnswer.ForeColor = Color.Green;
            SetActualData();
            SetMessage(message);
            RestartInputData();
        }

        private void RestartInputData()
        {
            txtCostForMinutes.Clear();
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            panel.Visible = true;
        }
    }
}
