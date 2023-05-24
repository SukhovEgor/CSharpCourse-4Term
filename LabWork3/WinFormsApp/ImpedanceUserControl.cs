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
            double real = Convert.ToDouble(RealTextBox.Text);
            double imaginary = Convert.ToDouble(ImaginaryTextBox.Text);
            
            var newComplex = new Complex(real, imaginary);
            
            return newComplex;
        }
    }
}
