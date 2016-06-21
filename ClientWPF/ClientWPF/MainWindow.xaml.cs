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

//Zusätzliche Namespaces
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Discovery;

namespace ClientWPF
{

    [ServiceContract]
    public interface IFlug
    {
        [OperationContract]
        string getFlug(DateTime tDatetime, string tStartStadt, string tZielStadt);
    }

    [ServiceContract]
    public interface IHotel
    {
        [OperationContract]
        string getHotel(DateTime tDate, string tDestination);
    }


    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Control.ClientController CC = new Control.ClientController();
        }

        private void button_Suche_Click(object sender, RoutedEventArgs e)
        {
            Control.ClientController CC = new Control.ClientController();

            if (string.IsNullOrWhiteSpace(tb_Von.Text) && string.IsNullOrWhiteSpace(tb_Nach.Text))
            {
                MessageBox.Show("Bitte Zielort eingeben.");
            }

            else
            {
                if (dp_Date.SelectedDate == null)
                {
                    MessageBox.Show("Bitte Datum eingeben.");
                }

                else
                {
                    FillFlugFields(CC.Feriensuche(dp_Date.SelectedDate.Value, tb_Von.Text, tb_Nach.Text));
                    FillHotelFields(CC.Hotelsuche(dp_Date.SelectedDate.Value, tb_Nach.Text));
                }
            }
        }

        private void FillFlugFields(string tResult)
        {
            if (tResult == "NULL")
            {
                tb_Ausgabe.Text = "Sorry, keine Resultate";
            }

            else
            {
                string[] res = tResult.Split(';');

                tb_Gesellschaft.Text = res[0];
                tb_Flugpreis.Text = res[1];
            }
        }

        private void FillHotelFields(string tResult)
        {
            if (tResult == "NULL")
            {
                tb_Ausgabe.Text = "Sorry, keine Resultate";
            }

            else
            {
                string[] res = tResult.Split(';');

                tb_Hotel.Text = res[0];
                tb_Hotelpreis.Text = res[1];
            }
        }

        private void button_FlugBuchung_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_Gesellschaft.Text) || string.IsNullOrWhiteSpace(tb_Flugpreis.Text))
            {
                MessageBox.Show("Zuerst Suchen.");
            }

            else
            {
                Control.ClientController CC = new Control.ClientController();
                if(CC.FlugBuchung(dp_Date.SelectedDate.Value, tb_Von.Text, tb_Nach.Text, double.Parse(tb_Flugpreis.Text), tb_Gesellschaft.Text))
                {
                    tb_Ausgabe.Text = "Danke. Ihr Flug ist gebucht.";
                }

                else
                {
                    tb_Ausgabe.Text = "Whoops, ERROR.";
                }
            }
        }
    }
}
