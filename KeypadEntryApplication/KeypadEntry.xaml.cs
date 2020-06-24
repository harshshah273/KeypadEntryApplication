using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace KeypadEntryApplication
{
    /// <summary>
    /// Interaction logic for KeypadEntry.xaml
    /// </summary>
    public partial class KeypadEntry : Window, INotifyPropertyChanged
    {
        private string _result;
        private readonly int minNumber = 5;
        private readonly int maxNumber = 10000;

        public string Result
        {
            get { return _result; }
            private set { _result = value; OnPropertyChanged("Result"); }
        }

        public KeypadEntry(Window owner, string entry)
        {
            InitializeComponent();
            Result = entry;
            Owner = owner;
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs args)
        {
            Button button = sender as Button;
            switch (button.CommandParameter.ToString())
            {
                case "Return":
                    if(ValidateEntry(Result))
                    DialogResult = true;
                    break;
                case "Backspace":
                    if (Result?.Length > 0)
                        Result = Result.Remove(Result.Length - 1);
                    break;
                case "Clear":
                    Result = string.Empty;
                    break;
                case "Decimal":
                    if (Result != null && !Result.Contains("."))
                        Result += button.Content.ToString();
                    break;
                default:
                    Result += button.Content.ToString();
                    break;
            }
        }

        private bool ValidateEntry(string entry)
        {
            if (!decimal.TryParse(entry, out decimal number))
            {
                MessageBox.Show("Not a valid number, please try again.");
                return false;
            }
            if (number < minNumber || number > maxNumber)
            {
                MessageBox.Show("The number is not in a valid range, please enter number between " + minNumber + " and " + maxNumber + ".");
                return false;
            }
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
