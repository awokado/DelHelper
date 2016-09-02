using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
/// <summary>
/// DAL data access layer
/// </summary>
namespace DelegationHelper.Model
{
    static class  NBPTableDownloader
    {
        private static XmlReader xmlReader;


        public static CurrencyTable getNBPCurrencyTable()
        {
            xmlReader = LoadXMLfromWeb("http://www.nbp.pl/kursy/xml/LastA.xml");
            Console.WriteLine("--2--------------------------------------------------------------");

            CurrencyTable currencyTable = new CurrencyTable();
            Currency currency;


                Console.Write(new string(' ', xmlReader.Depth * 2)); // Write indentation
                Console.WriteLine(xmlReader.NodeType);
                //xmlReader.ReadStartElement("tabela_kursow");

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
                            }
                            break;


                        case XmlNodeType.EndElement: break;
                        case XmlNodeType.Text:
                        case XmlNodeType.CDATA:
                        case XmlNodeType.Comment:
                        case XmlNodeType.XmlDeclaration: break;
                        case XmlNodeType.DocumentType: break;
                        default: break;
                    }
                }
                
            
            Console.WriteLine(currencyTable == null);
            return currencyTable;
        }



        private static XmlReader LoadXMLfromWeb(string URL)
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
                string info = "Exception caught: " + e.Message + "\nSource: " + e.Source;
                MessageBox.Show(info, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                //for test only!
                if (reader != null) { Console.WriteLine("sukces"); }
                else { Console.WriteLine("porażka"); }
            }

            return reader;
        }
    }
}
