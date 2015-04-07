using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using APP.Model;

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
        }
    }
}
