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

        private readonly Dictionary<string, Func<PassiveElementBase>> _comboBoxToElement;

        private BindingList<PassiveElementBase> _elementListAdding;

        public EnterForm(BindingList<PassiveElementBase> elementList)
        {
            InitializeComponent();

            _elementListAdding = elementList;

#if DEBUG
            AddRandomElementButton.Visible = true;
#endif
            /*
            string[] elementTypes = { "Resistor", "Capacitor", "InductorCoil" };
            _comboBoxToUserControl = new Dictionary<string, UserControl>()
            {
                {elementTypes[0], resistorUserControl1},
                {elementTypes[1], capacitorUserControl1},
                {elementTypes[2], inductorCoilUserControl1},
            };

            ElementTypesComboBox.Items.AddRange(elementTypes);

            _comboBoxToElement = new Dictionary<string, Func<PassiveElementBase>>()
            {
                {elementTypes[0], resistorUserControl1.GetElement},
                {elementTypes[1], capacitorUserControl1.GetElement},
                {elementTypes[2], inductorCoilUserControl1.GetElement},
            };

            ElementTypesComboBox.SelectedIndexChanged +=
                ElementTypesComboBox_SelectedIndexChanged;*/
            //string[] elementTypes = { "Resistor", "Capacitor", "InductorCoil" };
            _comboBoxToUserControl = new Dictionary<string, UserControl>()
            {
                {"Resistor", resistorUserControl1},
                {"Capacitor", capacitorUserControl1},
                {"InductorCoil", inductorCoilUserControl1},
            };

            ElementTypesComboBox.Items.AddRange(_comboBoxToUserControl.Keys.
                ToArray());

            _comboBoxToElement = new Dictionary<string, Func<PassiveElementBase>>()
            {
                {"Resistor", resistorUserControl1.GetElement},
                {"Capacitor", capacitorUserControl1.GetElement},
                {"InductorCoil", inductorCoilUserControl1.GetElement},
            };

            ElementTypesComboBox.SelectedIndexChanged +=
                ElementTypesComboBox_SelectedIndexChanged;
        }

        private void ElementTypesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedElement = ElementTypesComboBox.SelectedItem.ToString();

            foreach (var (elementType, userControl) in _comboBoxToUserControl)
            {
                userControl.Visible = false;
                if (selectedElement == elementType)
                {
                    userControl.Visible = true;
                }
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ElementTypesComboBox.SelectedItem.ToString()))
            {
                Close();
            }
            else
            {
                foreach (var (key, value) in _comboBoxToElement)
                {
                    if (ElementTypesComboBox.SelectedItem.ToString() == key)
                    {
                        _elementListAdding.Add(value.Invoke());
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

            ElementTypesComboBox.SelectedIndex = random.Next(0, 3);

            foreach (TextBox textbox in Controls.OfType<TextBox>())
            {
                if (textbox.Visible && String.IsNullOrEmpty(textbox.Text))
                {
                    textbox.Focus();
                    textbox.Text = random.Next(1, 100).ToString();
                }
            }
        }

        private void EnterForm_Load(object sender, EventArgs e)
        {
            resistorUserControl1.Visible = false;
            capacitorUserControl1.Visible = false;
            inductorCoilUserControl1.Visible = false;
        }
    }
}
