using System;
using System.Windows;
using APP.Model;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;
using System.IO;

namespace APP.View
{
    /// <summary>
    /// Interaction logic for CounturSelection.xaml
    /// </summary>
    public partial class CounturSelection : Window
    {
        public CounturSelection( Contour a )
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            // sprawdzić czy zapisano zmiany
            this.Close();
        }

        private void LoadContours_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Bitmapa (*.bmp)|*.bmp|Plik konturu (*.txt)|*.txt ";
            openFileDialog1.FilterIndex = 1;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(openFileDialog1.FileName));

                myCanvas.Width = bitmapImage.Width;
                myCanvas.Height = bitmapImage.Height;
                CanvasImage.ImageSource = bitmapImage;

                Width = bitmapImage.Width + 100;
                Height = bitmapImage.Height + 80;
            }
        }

        private void LoadBackground_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Obrazy (*.jpeg;*.jpg;*.bmp;*.png)|*.jpeg;*.jpg;*.bmp;*.png";
            openFileDialog1.FilterIndex = 1;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(openFileDialog1.FileName));

                myCanvas.Width = bitmapImage.Width;
                myCanvas.Height = bitmapImage.Height;
                CanvasImage.ImageSource = bitmapImage;

                Width = bitmapImage.Width + 100;
                Height = bitmapImage.Height + 80;
            }
        }

        private void TabelaKolorowShow_Click(object sender, RoutedEventArgs e)
        {
            if (ListaKolorów.Visibility == Visibility.Hidden)
                ListaKolorów.Visibility = Visibility.Visible;
            else
                ListaKolorów.Visibility = Visibility.Hidden;
        }

        System.Windows.Point? currentPoint = null;

        private void NewContourImage_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (currentPoint != null)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Line line = new Line();

                    line.Stroke = System.Windows.SystemColors.WindowFrameBrush;
                    line.X1 = currentPoint.Value.X;
                    line.Y1 = currentPoint.Value.Y;
                    line.X2 = e.GetPosition(myCanvas).X;
                    line.Y2 = e.GetPosition(myCanvas).Y;

                    line.HorizontalAlignment = HorizontalAlignment.Left;
                    line.VerticalAlignment = VerticalAlignment.Center;

                    currentPoint = e.GetPosition(myCanvas);

                    myCanvas.Visibility = Visibility.Visible;
                    myCanvas.Children.Add(line);
                }
            }

        }

        private void NewContourImage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(myCanvas);
        }

        private void NewContourImage_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            currentPoint = null;
        }

        private void SaveContours_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // Set filter options and filter index.
            saveFileDialog1.Filter = "Bitmapa (*.bmp)|*.bmp|Plik konturu (*.txt)|*.txt ";
            saveFileDialog1.FilterIndex = 1;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = saveFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                //CanvasImage.ImageSource = null;
                CanvasImage.Opacity = 0;

                string path = saveFileDialog1.FileName;

                FileStream fs = new FileStream(path, FileMode.Create);
                Rect prostokat = VisualTreeHelper.GetDescendantBounds(myCanvas);

                RenderTargetBitmap bmp = new RenderTargetBitmap((int)prostokat.Width, (int)prostokat.Height, 96, 96, PixelFormats.Pbgra32);

                DrawingVisual dv = new DrawingVisual();

                using (DrawingContext dc = dv.RenderOpen())
                {
                    VisualBrush vb = new VisualBrush(myCanvas);
                    dc.DrawRectangle(vb, null, new Rect(new System.Windows.Point(), prostokat.Size));
                }

                bmp.Render(dv);

                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(fs);
                fs.Close();

                CanvasImage.Opacity = 1;
            }



        }
    }
}
