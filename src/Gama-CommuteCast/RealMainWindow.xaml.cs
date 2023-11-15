using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RestSharp;
using System.Diagnostics;

namespace Gama_CommuteCast
{
    /// <summary>
    /// Interaction logic for RealMainWindow.xaml
    /// </summary>
    public partial class RealMainWindow : Window
    {
        public RealMainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string apiUrl = "https://ibnux.github.io/BMKG-importer/cuaca/501187.json";
            try
            {
                var client = new RestClient(apiUrl);
                var request = new RestRequest();
                var response = client.Execute(request);
                var content = response.Content;
                var json = (JsonArray)JsonNode.Parse(content);
                Trace.WriteLine(json);
                foreach (var item in json)
                {
                    Trace.WriteLine(item);
                }
                lb0.Content = $"00:00, {json[0]["cuaca"]}, {json[0]["tempC"]}°";
                lb6.Content = $"06:00, {json[1]["cuaca"]}, {json[1]["tempC"]}°";
                lb12.Content = $"12:00, {json[2]["cuaca"]}, {json[2]["tempC"]}°";
                lb18.Content = $"18:00, {json[3]["cuaca"]}, {json[3]["tempC"]}°";
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
    }
}
