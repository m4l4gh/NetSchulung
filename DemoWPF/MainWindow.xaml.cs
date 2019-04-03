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
        private readonly ConsoleApp1.LoggingService logger;

        public MainWindow()
        {
            InitializeComponent();
            logger = new ConsoleApp1.LoggingService();
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
                        logger.Log("Button 1 pressed");                        
                        break;

                    case "DeleteTempLog":
                        //logger.DeleteLine(2);
                        logger.DeleteLastLineFromCache();
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
