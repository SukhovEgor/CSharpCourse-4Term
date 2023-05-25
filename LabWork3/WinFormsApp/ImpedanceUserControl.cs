using System.Numerics;

namespace WinFormsApp
{
    /// <summary>
    /// Class ImpedanceUserControl.
    /// </summary>
    public partial class ImpedanceUserControl : UserControl
    {
        /// <summary>
        /// ImpedanceUserControl instance constructor.
        /// </summary>
        public ImpedanceUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get compex from textbox for filter.
        /// </summary>
        /// <returns>Complex.</returns>
        /// <exception cref="ArgumentException">
        /// Input string is empty.</exception>
        public Complex GetComplex()
        {
            if (string.IsNullOrEmpty(RealTextBox.Text) ||
                string.IsNullOrEmpty(ImaginaryTextBox.Text))
            {
                throw new ArgumentException("Input string is empty.");

            }
            else
            {
                double real = Convert.ToDouble
                    (RealTextBox.Text.DotToComma());

                double imaginary = Convert.ToDouble
                    (ImaginaryTextBox.Text.DotToComma());

                var newComplex = new Complex(real, imaginary);
                return newComplex;
            }
        }
    }
}
