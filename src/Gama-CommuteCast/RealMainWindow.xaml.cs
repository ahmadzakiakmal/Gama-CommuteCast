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
                lb0.Content = $"00:00, {json[0]["cuaca"]}, temp: {json[0]["tempC"]}C°, hum: {json[0]["humidity"]}%";
                lb6.Content = $"06:00, {json[1]["cuaca"]}, temp: {json[1]["tempC"]}C°, hum: {json[1]["humidity"]}%";
                lb12.Content = $"12:00, {json[2]["cuaca"]}, temp: {json[2]["tempC"]}C°, hum: {json[2]["humidity"]}%";
                lb18.Content = $"18:00, {json[3]["cuaca"]}, temp: {json[3]["tempC"]}C°, hum: {json[3]["humidity"]}%";
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
                int aqi = (int)json["data"]["current"]["pollution"]["aqius"];
                int humidity = (int)json["data"]["current"]["weather"]["hu"];

                lbIQA.Content = $"aqi: {aqi}, current-humidity: {humidity}";
            } catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
    }
}
