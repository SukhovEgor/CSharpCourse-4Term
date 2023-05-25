using Model;

namespace WinFormsApp
{
    /// <summary>
    /// class ResistorUserControl.
    /// </summary>
    public partial class ResistorUserControl : ElementBaseUserControl
    {
        /// <summary>
        /// ResistorUserControl instance constructor.
        /// </summary>
        public ResistorUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get passive element object.
        /// </summary>
        /// <returns>Passive Element.</returns>
        public override PassiveElementBase GetElement()
        {
            var newResistor = new Resistor();

            var actions = new List<Action>()
            {
                () =>
                {
                    newResistor.Resistance =
                    Convert.ToDouble(ResistanceTextBox.Text.DotToComma());
                }
            };

            InputParameters(actions);

            return newResistor;
        }
    }
}
