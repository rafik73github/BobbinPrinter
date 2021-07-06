using System.Text.RegularExpressions;
using System.Windows.Input;
namespace BobbinPrinter.Tools
{
    class Validate
    {

        public static void NoSpaceTextbox(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        public static void NumberValidatInTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9,]+");

            e.Handled = regex.IsMatch(e.Text);

        }

        public static void OnlyNumberValidatInTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);

        }

        public static void LetterValidatInTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^a-z-]+");

            e.Handled = regex.IsMatch(e.Text);

        }


    }
}
