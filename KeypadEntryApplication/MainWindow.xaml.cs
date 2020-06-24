using System.Windows;
using System.Windows.Input;

namespace KeypadEntryApplication
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

        private void InputTextbox_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            KeypadEntry keypadEntryWindow = new KeypadEntry(this, InputTextbox.Text);
            if (keypadEntryWindow.ShowDialog() == true)
            {
                InputTextbox.Text = keypadEntryWindow.Result;
            }
        }
    }
}
