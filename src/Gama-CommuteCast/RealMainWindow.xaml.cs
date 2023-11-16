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

        // Window Drag
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void BtnMinimize_OnClick(object sender, RoutedEventArgs e)
        {
            /*Minimize the window*/
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            /*Close the Application*/
            Application.Current.Shutdown();
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

        private void btnIQA_Click(object sender, RoutedEventArgs e)
        {
            string apiKey = "44b26895-4bb4-4058-8abb-f41c19f22505";
            string apiUrl = $"http://api.airvisual.com/v2/city?city=sleman&state=yogyakarta&country=indonesia&key={apiKey}";

            try
            {
                var client = new RestClient(apiUrl);
                var request = new RestRequest();
                var response = client.Execute(request);
                var content = response.Content;
                var json = (JsonObject)JsonNode.Parse(content);
                Trace.WriteLine(json["data"]["current"]["pollution"]["aqius"]);
                lbIQA.Content = "IQA: " + json["data"]["current"]["pollution"]["aqius"];
            } catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
    }
}
