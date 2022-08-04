using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using TicTacToe.Client.ViewModel;

namespace TicTacToe.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }

        public MainWindow()
        {
            ViewModel = new MainWindowViewModel();
            this.DataContext = ViewModel;
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Top_Left_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Top_Mid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Top_Right_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Mid_Left_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Mid_Mid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Mid_Right_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Bottom_Left_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bottom_Mid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bottom_Right_Click(object sender, RoutedEventArgs e)
        {

        }


        private static readonly Regex _regex = new("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
    }
}