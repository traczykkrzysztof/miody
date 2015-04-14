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
using APP.View;
using System.IO;
using Microsoft.Win32;
using APP.Helpers.FileHandling;
using APP.Model;
using System.Drawing;


namespace APP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Button2_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                OpenFileDialog obj = new OpenFileDialog();
                Nullable<bool> result = obj.ShowDialog();
                if (result==true)
                {
                    string file = obj.FileName;

                    ContourLoader obj1 = new ContourLoader();
                    Contour obj2 = obj1.LoadContour(file);

                    Bitmap bit = obj2.Bitmap;

                    ResultWindow resultWindow = new ResultWindow(new List<Result>() { new Result()}, bit); //nie do konca wiem co to jest to D w klasie Result, wiec nie wsadzam nic 

                    resultWindow.Show();



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            
          

        }

        
    }
}
