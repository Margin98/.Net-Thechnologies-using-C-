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

namespace A2MarginPatel
{
    
    public partial class AddContinents : Window
    {
        WorldDBDataSetTableAdapters.ContinentTableAdapter AdptrCntints;


        WorldDBDataSet.ContinentDataTable ContinntsTabls;
        public AddContinents()
        {
            InitializeComponent();
            AdptrCntints = new WorldDBDataSetTableAdapters.ContinentTableAdapter();
            ContinntsTabls = new WorldDBDataSet.ContinentDataTable();
        }

        public void FillingContinent()
        {
            ContinntsTabls = AdptrCntints.GetContinents();
        }

        private void AddinBtn_ClickEvent(object sender, RoutedEventArgs e)
        {
            if (txtContinet.Text.Equals(""))
            {
                Error_lbl.Content = " * This field is required";
            }
            else
            {

                FillingContinent();

                String contName = txtContinet.Text;

                AdptrCntints.Insert(contName);

                FillingContinent();


                MessageBox.Show("New Continent is Added", "Successfully Added", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ClsBtn_ClickEvent(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
