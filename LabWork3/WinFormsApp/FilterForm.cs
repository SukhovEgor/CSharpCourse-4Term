using System.ComponentModel;
using Model;

namespace WinFormsApp
{
    /// <summary>
    /// Class FilterForm.
    /// </summary>
    public partial class FilterForm : Form
    {
        /// <summary>
        /// Dictionary of elementTypes.
        /// </summary>
        private readonly Dictionary<string, Type> _elementTypes = new()
        {
            {nameof(Resistor), typeof(Resistor)},
            {nameof(Capacitor), typeof(Capacitor)},
            {nameof(InductorCoil), typeof(InductorCoil)}
        };

        /// <summary>
        /// Dictionary of ElementType names.
        /// </summary>
        private readonly Dictionary<string, string> _listBoxToElementType;

        /// <summary>
        /// Gets or sets EventHandler _elementListFiltered field's property.
        /// </summary>
        public EventHandler<ElementEventArgsList> ElementListFiltered
        { get; set; }

        /// <summary>
        /// Gets or sets BindingList for linh to MainForm _elementList.
        /// </summary>
        public BindingList<PassiveElementBase> ElementList { get; set; }

        /// <summary>
        /// Filter form instance constructor.
        /// </summary>
        public FilterForm()
        {
            InitializeComponent();

            _listBoxToElementType = new Dictionary<string, string>()
            {
                {"Resistor", nameof(Resistor)},
                {"Capacitor", nameof(Capacitor)},
                {"InductorCoil", nameof(InductorCoil)}
            };
            ElementCheckedListBox.Items.AddRange
                (_listBoxToElementType.Keys.ToArray());
            OKButton.Enabled = false;
        }

        /// <summary>
        /// Click event to filter information in DataGrid.
        /// </summary>
        /// <param name="sender">OKButton.</param>
        /// <param name="e">Event argument.</param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            //TODO: refactor
            try
            {
                var valueFilteredList = new BindingList<PassiveElementBase>();
                var typeFilteredList = new BindingList<PassiveElementBase>();

                var searchValue = ImpedanceUserControl.GetComplex();

                var action = new List<Action<BindingList<PassiveElementBase>>>
                {
                    typeFilteredList =>
                    {
                        foreach (var element in ElementList)
                        {
                            foreach (var checkedElement in
                                     ElementCheckedListBox.CheckedItems)
                            {
                                if (element.GetType() ==
                                    _elementTypes[_listBoxToElementType
                                    [checkedElement.ToString()]])
                                {

                                    typeFilteredList.Add(element);
                                }
                            }
                        }
                    },

                    typeFilteredList =>
                    {
                        foreach (var element in typeFilteredList)
                        {
                            if (element.FilterImpedance == searchValue)
                            {
                                valueFilteredList.Add(element);
                            }
                        }
                    }
                };

                if (string.IsNullOrEmpty(ImpedanceUserControl.RealTextBox.Text) &&
                    string.IsNullOrEmpty(ImpedanceUserControl.ImaginaryTextBox.Text))
                {
                    action[0].Invoke(typeFilteredList);

                    var eventArgs = new ElementEventArgsList(typeFilteredList);
                    ElementListFiltered?.Invoke(this, eventArgs);

                }

                else
                {
                    if (ElementCheckedListBox.SelectedItems.Count == 0)
                    {
                        typeFilteredList = ElementList;
                        action[1].Invoke(typeFilteredList);
                    }
                    else
                    {
                        action[0].Invoke(typeFilteredList);
                        action[1].Invoke(typeFilteredList);
                    }

                    var eventArgs = new ElementEventArgsList
                        (valueFilteredList);
                    ElementListFiltered?.Invoke(this, eventArgs);
                }

            }
            catch (Exception exception)
            {
                if (exception.GetType() == typeof(ArgumentOutOfRangeException)
                    || exception.GetType() == typeof(FormatException)
                    || exception.GetType() == typeof(ArgumentException))
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

        /// <summary>
        /// Click event to cancel information in DataGrid to initial values.
        /// </summary>
        /// <param name="sender">CancelButton.</param>
        /// <param name="e">Event argument.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            var eventArgs = new ElementEventArgsList(ElementList);
            ElementListFiltered?.Invoke(this, eventArgs);
            if (!string.IsNullOrEmpty(ImpedanceUserControl.RealTextBox.Text) ||
                !string.IsNullOrEmpty(ImpedanceUserControl.ImaginaryTextBox.Text))
            {
                ImpedanceUserControl.RealTextBox.Clear();
                ImpedanceUserControl.ImaginaryTextBox.Clear();
            }
        }
        //TODO: XML
        private void ElementCheckedListBox_SelectedIndexChanged
            (object sender, EventArgs e)
        {
            OKButton.Enabled = true;
        }
    }
}
