using Model;

namespace WinFormsApp
{
    /// <summary>
    /// Class InductorCoilUserControl.
    /// </summary>
    public partial class InductorCoilUserControl : ElementBaseUserControl
    {
        /// <summary>
        /// InductorCoilUserControl instance constructor.
        /// </summary>
        public InductorCoilUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get passive element object.
        /// </summary>
        /// <returns>Passive Element.</returns>
        public override PassiveElementBase GetElement()
        {
            var newInductorCoil = new InductorCoil();

            var actions = new List<Action>()
            {
                () =>
                {
                    newInductorCoil.Inductance =
                    Convert.ToDouble(InductanceTextBox.Text.DotToComma());
                },
                () =>
                {
                    newInductorCoil.Frequency =
                    Convert.ToDouble(FrequencyTextBox.Text.DotToComma());
                }
            };

            InputParameters(actions);

            return newInductorCoil;
        }
    }
}
