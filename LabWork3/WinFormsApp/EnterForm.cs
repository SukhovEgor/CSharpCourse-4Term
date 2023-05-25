using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class EnterForm : Form
    {
        private readonly Dictionary<string, UserControl> _comboBoxToUserControl;

        private EventHandler<ElementEventArgs> _elementEventHandler;

        public EventHandler<ElementEventArgs> ElementEventHandler { get; set; }

        public EnterForm()
        {
            InitializeComponent();
#if DEBUG
            AddRandomElementButton.Visible = true;
#endif
            
            string[] elementTypes = { "Resistor", "Capacitor", "InductorCoil" };
            _comboBoxToUserControl = new Dictionary<string, UserControl>()
            {
                {elementTypes[0], resistorUserControl1},
                {elementTypes[1], capacitorUserControl1},
                {elementTypes[2], inductorCoilUserControl1},
            };

            ElementTypesComboBox.Items.AddRange(elementTypes);

            ElementTypesComboBox.SelectedIndexChanged +=
                ElementTypesComboBox_SelectedIndexChanged;
        }

        private void ElementTypesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedElement = ElementTypesComboBox.SelectedItem.ToString();

            foreach (var (key, value) in _comboBoxToUserControl)
            {
                value.Visible = false;
                if (selectedElement == key)
                {
                    value.Visible = true;
                }
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ElementTypesComboBox.Text.ToString()))
            {
                Close();
            }
            else
            {
                try
                {
                    var selectedElement = ElementTypesComboBox.SelectedItem.ToString();
                    var selectedElementControl = _comboBoxToUserControl[selectedElement];
                    var eventArgs = new ElementEventArgs
                        (((ElementBaseUserControl)selectedElementControl).GetElement());
                    ElementEventHandler?.Invoke(this, eventArgs);
                }
                catch (Exception exception)
                {
                    if (exception.GetType() == typeof
                        (ArgumentOutOfRangeException) ||
                        exception.GetType() == typeof
                        (FormatException))
                    {
                        _ = MessageBox.Show
                            ($"Incorrect input parameters.\n" +
                            $"Error: {exception.Message}");
                    }
                    else
                    {
                        throw;
                    }
                }
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddRandomElementButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            var elementTypes = new Dictionary<int, PassiveElementType>
            {
                {0, PassiveElementType.Resistor },
                {1, PassiveElementType.Capacitor },
                {2, PassiveElementType.InductorCoil}
            };

            var randomType = random.Next(elementTypes.Count);
            var randomElement = 
                new RandomPassiveElement()
                .GetRandomParameters(elementTypes[randomType]);
            var eventArgs = new ElementEventArgs(randomElement);
            ElementEventHandler?.Invoke(this, eventArgs);
        }

        private void EnterForm_Load(object sender, EventArgs e)
        {
            OKButton.Focus();
            resistorUserControl1.Visible = false;
            capacitorUserControl1.Visible = false;
            inductorCoilUserControl1.Visible = false;
        }
    }
}
