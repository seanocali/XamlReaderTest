using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace XamlReaderTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.Loaded += MainPage_Loaded;
            this.InitializeComponent();
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var xamlStr = File.ReadAllText("TestView.xaml");
            try
            {
                var runtimeXaml = XamlReader.Load(xamlStr) as UserControl;
                this.Content = runtimeXaml;
            }
            catch (Exception ex)
            {
                var messageDialog = new MessageDialog(ex.Message);
                await messageDialog.ShowAsync();
            }
        }
    }
}
