using Model;

namespace WinFormsApp
{
    /// <summary>
    /// Class EnterForm.
    /// </summary>
    public partial class EnterForm : Form
    {
        /// <summary>
        /// Dictionary of UserControls.
        /// </summary>
        private readonly Dictionary<string,
            UserControl> _comboBoxToUserControl;

        /// <summary>
        /// Gets or sets EventHandler _elementEventHandler field's property.
        /// </summary>
        public EventHandler<ElementEventArgs> ElementEventHandler { get; set; }

        /// <summary>
        /// EnterForm.
        /// </summary>
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

            OKButton.Enabled = false;
        }

        /// <summary>
        /// Click event to check changes in ComboBox.
        /// </summary>
        /// <param name="sender">ElementTypesComboBox.</param>
        /// <param name="e">Event argument.</param>
        private void ElementTypesComboBox_SelectedIndexChanged
            (object sender, EventArgs e)
        {
            string selectedElement =
                ElementTypesComboBox.SelectedItem.ToString();

            OKButton.Enabled = true;

            foreach (var (key, value) in _comboBoxToUserControl)
            {
                value.Visible = false;
                if (selectedElement == key)
                {
                    value.Visible = true;
                }
            }
        }

        /// <summary>
        /// Click event to add a new passive element.
        /// </summary>
        /// <param name="sender">OKButton.</param>
        /// <param name="e">Event argument.</param>
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
                    var selectedElement =
                        ElementTypesComboBox.SelectedItem.ToString();

                    var selectedElementControl =
                        _comboBoxToUserControl[selectedElement];

                    var eventArgs = new ElementEventArgs
                        (((ElementBaseUserControl)
                        selectedElementControl).GetElement());

                    ElementEventHandler?.Invoke(this, eventArgs);
                }
                catch (Exception exception)
                {
                    if (exception.GetType() == typeof
                        (ArgumentOutOfRangeException) ||
                        exception.GetType() == typeof
                        (FormatException) ||
                        exception.GetType() == typeof
                        (ArgumentException))
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

        /// <summary>
        /// Click event to close the form.
        /// </summary>
        /// <param name="sender">CancelButton.</param>
        /// <param name="e">Event argument.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Click event to add random element.
        /// </summary>
        /// <param name="sender">AddRandomElementButton.</param>
        /// <param name="e">Event argument.</param>
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

        /// <summary>
        /// Event of load form.
        /// </summary>
        /// <param name="sender">EnterForm.</param>
        /// <param name="e">Event argument.</param>
        private void EnterForm_Load(object sender, EventArgs e)
        {
            resistorUserControl1.Visible = false;
            capacitorUserControl1.Visible = false;
            inductorCoilUserControl1.Visible = false;
        }
    }
}
