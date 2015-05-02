using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Controls;
using System.IO;
using System.Collections.Generic;
using Microsoft.Win32;

using APP.Model;
using APP.Helpers;

namespace APP.View
{
    /// <summary>
    /// Interaction logic for CounturSelection.xaml
    /// </summary>
    public partial class CounturSelection : Window
    {
        private Brush brushColor;
        private Point? currentPoint = null;

        public CounturSelection( Contour a )
        {
            InitializeComponent();            
            
            // POTRZEBNA ZMIANA z klasy Pylek
            ListColors.ItemsSource = Pylki.getTypes();
            //ListColors.ItemsSource = Pylek.KolorPylkowList;
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

                CanvasContour.Width = bitmapImage.Width;
                CanvasContour.Height = bitmapImage.Height;
                CanvasContourBackground.ImageSource = bitmapImage;

                //Width = bitmapImage.Width + 100;
                //Height = bitmapImage.Height + 80;
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

                CanvasContour.Width = bitmapImage.Width;
                CanvasContour.Height = bitmapImage.Height;
                CanvasContourBackground.ImageSource = bitmapImage;

                //Width = bitmapImage.Width + 100;
                //Height = bitmapImage.Height + 80;
            }
        }

        private void TabelaKolorowShow_Click(object sender, RoutedEventArgs e)
        {
            if (ListColors.Visibility == Visibility.Hidden)
                ListColors.Visibility = Visibility.Visible;
            else
                ListColors.Visibility = Visibility.Hidden;
        }        

        private void CanvasContour_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (currentPoint != null)
            {
                if (brushColor == null) return;
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Line line = new Line();

                    line.Stroke = brushColor;
                    line.StrokeThickness = 1;
                    line.X1 = currentPoint.Value.X;
                    line.Y1 = currentPoint.Value.Y;
                    line.X2 = e.GetPosition(CanvasContour).X;
                    line.Y2 = e.GetPosition(CanvasContour).Y;
                    
                    line.HorizontalAlignment = HorizontalAlignment.Left;
                    line.VerticalAlignment = VerticalAlignment.Center;

                    line.SnapsToDevicePixels = true;
                    line.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);

                    currentPoint = e.GetPosition(CanvasContour);

                    CanvasContour.Visibility = Visibility.Visible;
                    CanvasContour.Children.Add(line);
                }
            }

        }

        private void CanvasContour_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(CanvasContour);
        }

        private void CanvasContour_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            currentPoint = null;
        }

        private void CanvasContour_MouseLeave(object sender, MouseEventArgs e)
        {
            currentPoint = null;            
        }

        private void CanvasContour_MouseEnter(object sender, MouseEventArgs e)
        {            
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                currentPoint = e.GetPosition(CanvasContour);
            }
        }

        private void SaveContours_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // Set filter options and filter index.
            saveFileDialog1.Filter = "Bitmapa (*.bmp)|*.bmp|Plik konturu (*.txt)|*.txt ";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.FileName = "Bitmapa";

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = saveFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                //CanvasContourBackground.ImageSource = null;
                CanvasContourBackground.Opacity = 0;

                string path = saveFileDialog1.FileName;

                FileStream fs = new FileStream(path, FileMode.Create);
                Rect prostokat = VisualTreeHelper.GetDescendantBounds(CanvasContour);

                RenderTargetBitmap bmp = new RenderTargetBitmap((int)prostokat.Width, (int)prostokat.Height, 96, 96, PixelFormats.Pbgra32);

                DrawingVisual dv = new DrawingVisual();

                using (DrawingContext dc = dv.RenderOpen())
                {
                    VisualBrush vb = new VisualBrush(CanvasContour);
                    dc.DrawRectangle(Brushes.White, null, new Rect(prostokat.Size));                    
                    dc.DrawRectangle(vb, null, new Rect(new System.Windows.Point(), prostokat.Size));                    
                }

                bmp.Render(dv);

                BitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(fs);
                fs.Close();

                CanvasContourBackground.Opacity = 1;
            }
        }

        private void SaveContourAndLoad1_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveContourAndLoad2_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ListViewTypes_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            Console.WriteLine(item);
            brushColor = (item as Pylki).Color;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();            
        }
    }


    public class Pylki
    {
        public string Name { get; set; }
        public string HexColor { get; set; }
        public Brush Color { get; set; }

        public override string ToString()
        {
            return Name + " -> " + HexColor + " -> " + Color.ToString();
        }

        public static List<Pylki> getTypes()
        {
            List<Pylki> types = new List<Pylki>();
            types.Add(new Pylki() { Name = "Rzepakowy", HexColor = "#00ff00", Color = Brushes.Green});
            types.Add(new Pylki() { Name = "Red", HexColor = "#ff0000", Color = Brushes.Red });
            types.Add(new Pylki() { Name = "Blue", HexColor = "#0000ff", Color = Brushes.Blue});

            return types;
        }
    }
}
