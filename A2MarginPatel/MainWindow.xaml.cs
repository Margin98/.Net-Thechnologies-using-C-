using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace A2MarginPatel
{

    public partial class MainWindow : Window
    {
        WorldDBDataSetTableAdapters.CityTableAdapter AdptrCities;
        WorldDBDataSetTableAdapters.ContinentTableAdapter AdptrCntints;
        WorldDBDataSetTableAdapters.CountryTableAdapter AdptrContris;


        WorldDBDataSet.CityDataTable CitiesTabls;
        WorldDBDataSet.ContinentDataTable ContinntsTabls;
        WorldDBDataSet.CountryDataTable ContsTable;

        public MainWindow()
        {
            InitializeComponent();
            AdptrCities = new WorldDBDataSetTableAdapters.CityTableAdapter();
            AdptrCntints = new WorldDBDataSetTableAdapters.ContinentTableAdapter();
            AdptrContris = new WorldDBDataSetTableAdapters.CountryTableAdapter();
        }

        public void GettingContinnt()
        {

            ContinntsTabls = AdptrCntints.GetContinents();
            cmbConti.ItemsSource = ContinntsTabls;

        }

        public void Gettingcntry()
        {
            ContsTable = AdptrContris.GetCountries();

        }

        public void Gettingcty()
        {
            CitiesTabls = AdptrCities.GetCities();
        }

        private void LoadedCntinntCmb(object sender, RoutedEventArgs e)
        {
            GettingContinnt();
            cmbConti.DisplayMemberPath = "ContinentName";
        }

        private void ContinntSelctinCmbChange(object sender, SelectionChangedEventArgs e)
        {

            int id = cmbConti.SelectedIndex + 1;

            ContsTable = AdptrContris.GetById(id);

            if (ContsTable.Count > 0)
            {
                cntrylist.ItemsSource = ContsTable;
                cntrylist.DisplayMemberPath = "CountryName";
            }
        }

        private void ListCntrsSelctChang(object sender, SelectionChangedEventArgs e)
        {

            String cntrynme = "";

            int z = cntrylist.SelectedIndex;

            if (z != -1)
            {
                DataRowView DataRwVw = (DataRowView)cntrylist.SelectedItem;

                cntrynme = DataRwVw["CountryId"].ToString();

                int countryId = Convert.ToInt32(cntrynme);

                CitiesTabls = AdptrCities.GetByCityName(countryId);

                if (CitiesTabls.Count > 0)
                {
                    cts.ItemsSource = CitiesTabls;
                    ContsTable = AdptrContris.GetCountries();
                    var row = ContsTable[countryId - 1];
                    LangLabl.Content = row.Language.ToString();
                    Currncylabl.Content = row.Currency.ToString();
                }
            }
            else
            {
                ContinntSelctinCmbChange(sender, e);
            }
        }

        private void AddBtnCnttntsClickEvent(object sender, RoutedEventArgs e)
        {
            AddContinents continent = new AddContinents();
            continent.Closed += new EventHandler(ListRfrsh);
            continent.Show();
        }

        private void ListRfrsh(object sender, EventArgs e)
        {
            GettingContinnt();
            cmbConti.DisplayMemberPath = "ContinentName";
        }

        private void AddBtnCntryclickEvent(object sender, RoutedEventArgs e)
        {
            AddCountries country = new AddCountries();
            country.Closed += new EventHandler(List2frsh);
            country.Show();
        }

        private void List2frsh(object sender, EventArgs e)
        {
            Gettingcntry();
        }

        private void AddBtnCtyclickEvent(object sender, RoutedEventArgs e)
        {
            AddCities TCty = new AddCities();
            TCty.Closed += new EventHandler(Listctyrfrsh);
            TCty.Show();
        }

        private void Listctyrfrsh(object sender, EventArgs e)
        {
            Gettingcty();
        }
    }
}
