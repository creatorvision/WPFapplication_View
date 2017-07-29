using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace userView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //Open the file              
            var stream = File.OpenText("..\\..\\..\\..\\userView.json");
            //Read the file              
            string st = stream.ReadToEnd();
            var Jresult = JArray.Parse(st);
            var tCount = Jresult.Count;

            for (int i=0;i<tCount;i++)
           {
                Userview uv = new Userview();

                uv = JsonConvert.DeserializeObject<Userview>(Jresult[i].ToString());

                StackPanel newpnl = new StackPanel();
                newpnl.Background = new SolidColorBrush(Colors.Lavender);
                newpnl.Margin = new Thickness(2, 4, 2, 4);

                //BROWSER
                Label lbrowser = new Label();
                lbrowser.Content = uv.browserName;

                ////URL
                //TextBlock turl = new TextBlock();
                //Hyperlink hurl = new Hyperlink();
                //hurl.NavigateUri = new Uri(uv.Url);
                //hurl.RequestNavigate += (sender, e) =>
                //{
                //    Process.Start(uv.browserName,e.Uri.ToString());
                //};
                //hurl.Inlines.Add("URL" + (i+1));
                //turl.Inlines.Add(hurl);

                //LOGO
                Label ll = new Label();
                ll.Content = uv.logo;
                Image llogo = new Image();
                llogo.Height = 90;
                llogo.Width = 300;
                BitmapImage myBitmapImage = new BitmapImage(new Uri(uv.logo));
                myBitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                llogo.Source = myBitmapImage;


                newpnl.Children.Add(llogo);
                newpnl.Children.Add(lbrowser);
                newpnl.Children.Add(ll);
                
                newpnl.PreviewMouseLeftButtonDown += (sender, e) =>
                {
                    Process.Start(uv.browserName, uv.Url);
                };

                StackPanel.Children.Add(newpnl);
               
           }
        }
    }
}
