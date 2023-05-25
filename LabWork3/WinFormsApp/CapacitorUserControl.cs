using Model;

namespace WinFormsApp
{
    /// <summary>
    /// UserControl for Capacitor.
    /// </summary>
    public partial class CapacitorUserControl : ElementBaseUserControl
    {
        /// <summary>
        /// CapacitorUserControl instance constructor.
        /// </summary>
        public CapacitorUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get passive element object.
        /// </summary>
        /// <returns>Passive Element.</returns>
        public override PassiveElementBase GetElement()
        {
            var newCapacitor = new Capacitor();

            var actions = new List<Action>()
            {
                () =>
                {
                    newCapacitor.Capacity = Convert.ToDouble
                    (CapacityTextBox.Text.DotToComma());
                },
                () =>
                {
                    newCapacitor.Frequency = Convert.ToDouble
                    (FrequencyTextBox.Text.DotToComma());
                }
            };

            InputParameters(actions);

            return newCapacitor;
        }
    }
}
