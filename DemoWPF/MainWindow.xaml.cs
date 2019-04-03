using System;
using System.Collections.Generic;
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

namespace DemoWPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ConsoleApp1.ILoggingService _logger;
        private readonly ConsoleApp1.IInitLogging _initService;

        public MainWindow()
        {
            InitializeComponent();
            var service = new ConsoleApp1.LoggingService();            
            _initService = service;
            _logger = service;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var name = sender.GetType().Name;
            //if ((sender!=null)&&(sender.GetType() == typeof(Button)))
            var btn = sender as Control; // Basisklasse - d.h. funktioniert für alle Elemente
            if (btn != null)
            {
                btn.Background = Brushes.Azure;
            }

            //oder:
            if (sender is Button)              
            {
                ((Button)sender).Background = Brushes.Azure;
            }

            var color = btn?.Background;

            try
            {
                var tag = (string)btn.Tag;
                switch (tag)
                {
                    case "Log":
                        _initService.Init();
                        _logger.Log("Button 1 pressed");                        
                        break;

                    case "DeleteTempLog":
                        _initService.Init();
                        _logger.DeleteLine(2);
                        //logger.DeleteLastLineFromCache();
                        break;
                    default:
                        break;

                }
            }
            catch (InvalidCastException ice)
            {
                //TODO
            }
            
            e.Handled = true;
        }
    }
}
