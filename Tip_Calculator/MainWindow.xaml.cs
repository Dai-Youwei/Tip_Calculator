using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Tip_Calculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Tip tip;

        public MainWindow()
        {
            tip = new Tip();
            InitializeComponent();

        }

        private void AmountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            billAmountTextBox.Text = tip.BillAmount;
            
        }

        private void BillAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            PerformCalculation();
        }

        private void AmountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            PerformCalculation();
        }

        private void PerformCalculation()
        {
            var selectedRadio = myStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
            tip.CalculateTip(billAmountTextBox.Text, double.Parse(selectedRadio.Tag.ToString()));
            amountToTipTextBlock.Text = tip.TipAmount;
            totalTextBlock.Text = tip.TotalAmount;
        }

    }
}
