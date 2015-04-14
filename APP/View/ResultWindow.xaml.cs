using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using APP.Model;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace APP.View
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public ResultWindow(IEnumerable<Result> a , Bitmap bitmap)
        {

            InitializeComponent();

            ImageSource obj= System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                      bitmap.GetHbitmap(),
                      System.IntPtr.Zero,
                      Int32Rect.Empty,
                      BitmapSizeOptions.FromEmptyOptions());

            Image1.Source = obj;
            

           

           
            
        }
    }
}
