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

    public partial class AddCountries : Window
    {
        WorldDBDataSetTableAdapters.CountryTableAdapter AdptrContris;
        WorldDBDataSet.CountryDataTable ContsTable;

        WorldDBDataSetTableAdapters.ContinentTableAdapter AdptrCntints;
        WorldDBDataSet.ContinentDataTable ContinntsTabls;
        public AddCountries()
        {
            InitializeComponent();
            AdptrContris = new WorldDBDataSetTableAdapters.CountryTableAdapter();
            AdptrCntints = new WorldDBDataSetTableAdapters.ContinentTableAdapter();
        }

        public void FillCountry()
        {
            ContsTable = AdptrContris.GetCountries();
        }

        private void LoadedContinnt(object sender, RoutedEventArgs e)
        {
            ContinntsTabls = AdptrCntints.GetContinents();
            cntinntCmb.ItemsSource = ContinntsTabls;
            cntinntCmb.DisplayMemberPath = "ContinentName";
        }

        private void ClsBtn_ClickEvent(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void AddinBtn_ClickEvent(object sender, RoutedEventArgs e)
        {
            if (TxtCntry.Text.Equals(""))
            {
                cntrylabl.Content = "* This Field is required.";
            }
            else if (cntinntCmb.SelectedIndex == -1)
            {
                continnntlbl.Content = "* This Field is required.";
            }
            else
            {
                string cntrynme = TxtCntry.Text;
                string spknlanguage = txtLng.Text;
                string itsCrrncy = Currnctxt.Text;
                DataRowView DataRwVw = (DataRowView)cntinntCmb.SelectedItem;
                string x = DataRwVw["ContinentId"].ToString();
                AdptrContris.InsertQuery(cntrynme, 
                    spknlanguage, itsCrrncy, Convert.ToInt32(x));
                FillCountry();
                MessageBox.Show("New Country is Added", "Successfully Added", 
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
