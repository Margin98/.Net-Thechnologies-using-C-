using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace A2MarginPatel
{
    public partial class AddCities : Window
    {
        WorldDBDataSetTableAdapters.CityTableAdapter AdptrCities;
        WorldDBDataSet.CityDataTable CitiesTabls;

        WorldDBDataSetTableAdapters.CountryTableAdapter AdptrContris;
        WorldDBDataSet.CountryDataTable ContsTable;
        public AddCities()
        {
            InitializeComponent();
            AdptrCities = new WorldDBDataSetTableAdapters.CityTableAdapter();
            AdptrContris = new WorldDBDataSetTableAdapters.CountryTableAdapter();
        }

        public void FillingCity()
        {
            CitiesTabls = AdptrCities.GetCities();
        }

        private void Loaded_Contry(object sender, RoutedEventArgs e)
        {
            ContsTable = AdptrContris.GetCountries();
            cmbCntry.ItemsSource = ContsTable;
            cmbCntry.DisplayMemberPath = "CountryName";
        }

        private void AddinBtn_ClickEvent(object sender, RoutedEventArgs e)
        {
            if (txtCty.Text.Equals(""))
            {
                lblCity.Content = "* This Field is required.";
               
            }
            else if (cmbCntry.SelectedIndex == -1)
            {
                cntrylabl.Content = "* This Field is required.";
            }
            else
            {
                string NmeCty = txtCty.Text;
                bool isCapital = (bool)chckCaps.IsChecked;
                string population = Ppltiontxt.Text;
                DataRowView DataRwVw = (DataRowView)cmbCntry.SelectedItem;
                string x = DataRwVw["CountryId"].ToString();

                AdptrCities.InsertQuery(NmeCty, isCapital, population, Convert.ToInt32(x));

                FillingCity();

                MessageBox.Show("New Country is Added", 
                    "Successfully Added", MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            }
        }

        private void ClsBtn_ClickEvent(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
