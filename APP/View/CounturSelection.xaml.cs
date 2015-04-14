using System;
using System.Windows;
using APP.Model;

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


    }
}
