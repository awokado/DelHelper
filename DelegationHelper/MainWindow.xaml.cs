using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Xml;

namespace DelegationHelper
{
    

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private XmlReader xmlReader = null;

        public MainWindow()
        {
            InitializeComponent();
            LoadXMLfromWeb("http://www.nbp.pl/kursy/xml/LastA.xml");
            //Console.WriteLine("The version of the currently executing assembly is: {0}",typeof(MainWindow).Assembly.GetName().Version);
            Console.WriteLine("The version of mscorlib.dll is: {0}", typeof(String).Assembly.GetName().Version);
        }


        private void LoadXMLfromWeb(string URL)
        {
            try
            {
                xmlReader = XmlReader.Create(URL);
                //Thread.Sleep(3000);

            }
            catch (Exception e)
            {
                string info = "Exception caught: " + e.Message + "\nSource: "  + e.Source;
                MessageBox.Show(info, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            finally
            {
                if (xmlReader != null) { Console.WriteLine("sukces"); }
                else { Console.WriteLine("porażka"); }
            }

        }
    }
}
