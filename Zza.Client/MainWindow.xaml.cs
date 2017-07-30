using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Zza.Client.ZzaService;



namespace Zza.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Products();



        }

        private async void Products()
        {
            ZzaServiceClient proxy = new ZzaServiceClient("NetTcpBinding_IZzaService");
            // setting client credentials in the proxy.
            proxy.ClientCredentials.Windows.ClientCredential.UserName = "Bob";

            try
            {
               

                var Products = await proxy.GetProductsAsync();
                var Customer = await proxy.GetCustomersAsync();
           
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }

            finally 
            {
                proxy.Close();
            }
        }
    }
}
