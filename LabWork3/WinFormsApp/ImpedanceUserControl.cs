using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using Model;

namespace WinFormsApp
{
    public partial class ImpedanceUserControl : UserControl
    {
        public ImpedanceUserControl()
        {
            InitializeComponent();
        }

        public Complex GetComplex()
        {
            if (string.IsNullOrEmpty(RealTextBox.Text) || string.IsNullOrEmpty(ImaginaryTextBox.Text))
            {
                throw new ArgumentException("Input string is empty.");

            }
            else
            {
                double real = Convert.ToDouble(RealTextBox.Text.DotToComma());
                double imaginary = Convert.ToDouble(ImaginaryTextBox.Text.DotToComma());

                var newComplex = new Complex(real, imaginary);
                return newComplex;
            }
        }
    }
}
