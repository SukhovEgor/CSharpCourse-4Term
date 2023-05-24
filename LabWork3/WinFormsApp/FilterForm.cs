using System.ComponentModel;
using Model;

namespace WinFormsApp
{
    public partial class FilterForm : Form
    {
        private readonly Dictionary<string, Type> _elementTypes = new()
        {
            {nameof(Resistor), typeof(Resistor)},
            {nameof(Capacitor), typeof(Capacitor)},
            {nameof(InductorCoil), typeof(InductorCoil)}
        };

        private readonly Dictionary<string, string> _listBoxToElementType;

        public EventHandler<ElementEventArgsList> ElementListFiltered { get; set; }

        public BindingList<PassiveElementBase> ElementList { get; set; }


        public FilterForm()
        {
            InitializeComponent();

            _listBoxToElementType = new Dictionary<string, string>()
            {
                {"Resistor", nameof(Resistor)},
                {"Capacitor", nameof(Capacitor)},
                {"InductorCoil", nameof(InductorCoil)}
            };
            ElementCheckedListBox.Items.AddRange(_listBoxToElementType.Keys.ToArray());
        }

        private void OKButton_Click(object sender, EventArgs e)
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
                                _elementTypes[_listBoxToElementType[checkedElement.ToString()]])
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
            action[0].Invoke(typeFilteredList);
            action[1].Invoke(typeFilteredList);
            var eventArgs = new ElementEventArgsList
                (valueFilteredList);
            ElementListFiltered?.Invoke(this, eventArgs);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var eventArgs = new ElementEventArgsList(ElementList);
            ElementListFiltered?.Invoke(this, eventArgs);
        }
    }
}
