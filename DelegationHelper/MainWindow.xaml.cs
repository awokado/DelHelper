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

        XmlReader xmlReader = null;
        public string lbCurrencyTabTxt { get; set; } = "uruchamiam";

        public MainWindow()
        {
            InitializeComponent();
            lbCurrencyTab.DataContext = this;
            
            //Console.WriteLine("The version of the currently executing assembly is: {0}",typeof(MainWindow).Assembly.GetName().Version);
            //Console.WriteLine("The version of mscorlib.dll is: {0}", typeof(String).Assembly.GetName().Version);
        }


        private  XmlReader LoadXMLfromWeb(string URL)
        {
            XmlReader reader = null;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;

            try
            {
                 reader = XmlReader.Create(URL, settings);
                //Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                string info = "Exception caught: " + e.Message + "\nSource: "  + e.Source;
                MessageBox.Show(info, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (reader != null) { Console.WriteLine("sukces"); }
                else { Console.WriteLine("porażka"); }
            }
           
            return reader;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            xmlReader = LoadXMLfromWeb("http://www.nbp.pl/kursy/xml/LastA.xml");
            while (xmlReader.Read())
            {

                Console.Write(new string(' ', xmlReader.Depth * 2)); // Write indentation
                Console.WriteLine(xmlReader.NodeType);
                //xmlReader.ReadStartElement("tabela_kursow");
               

                CurrencyTable currencyTable = new CurrencyTable();
                Currency currency;
                string number;
                string date;
                while (xmlReader.Read())
                {


                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            switch (xmlReader.Name)
                            {
                                case "numer_tabeli":
                                    {
                                        xmlReader.Read();
                                        number = xmlReader.Value;
                                        currencyTable.number = number;
                                        break;
                                    }
                                case "data_publikacji":
                                    {
                                        xmlReader.Read();
                                        date = xmlReader.Value;
                                        currencyTable.date = date;
                                        break;
                                    }
                                case "pozycja":
                                    {
                                        currency = new Currency();
                                        xmlReader.ReadStartElement("pozycja");
                                        currency.Name = xmlReader.ReadElementContentAsString("nazwa_waluty", "");
                                        currency.Converter = xmlReader.ReadElementContentAsString("przelicznik", "");
                                        currency.Code = xmlReader.ReadElementContentAsString("kod_waluty", "");
                                        currency.ExchangeRate = xmlReader.ReadElementContentAsString("kurs_sredni", "");
                                        xmlReader.ReadEndElement();
                                        currencyTable.items.Add(currency);
                                        break;
                                    }
                                default: break;
                            }break;


                        case XmlNodeType.EndElement: break;
                        case XmlNodeType.Text:
                        case XmlNodeType.CDATA:
                        case XmlNodeType.Comment:
                        case XmlNodeType.XmlDeclaration: break;
                        case XmlNodeType.DocumentType: break;
                        default: break;
                    }
                }

                
                lvCurrency.ItemsSource = currencyTable.items;


            }
        }
    }
}
