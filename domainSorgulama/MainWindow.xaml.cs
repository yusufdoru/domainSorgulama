using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Threading;


namespace domainSorgulama
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        WebClient wClient;
        string sourceUrl = "";
        string source = "";
        string desen = "alÄ±nmamÄ±ÅŸ.";

        public MainWindow()
        {
            InitializeComponent();
            wClient = new WebClient();
            wClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wClient_DownloadStringCompleted);
        }

        void wClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                source = e.Result;
                bool varmi = Regex.IsMatch(source, desen);
                if (varmi)
                    lblSonuc.Content = "Daha önce alınmamış.";
                else
                    lblSonuc.Content = "Daha önce alınmış.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sourceUrl = "http://kimindir.com/" + txtDomain.Text;
                wClient.DownloadStringAsync(new Uri(sourceUrl));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }
    }
}
