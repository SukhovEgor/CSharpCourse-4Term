using Model;

namespace WinFormsApp
{
    /// <summary>
    /// Class ElementBaseUserControl.
    /// </summary>
    public abstract partial class ElementBaseUserControl : UserControl
    {
        /// <summary>
        /// Abstract method for getting passive element.
        /// </summary>
        /// <returns>Passive Element.</returns>
        public abstract PassiveElementBase GetElement();

        /// <summary>
        /// Input parameters in instance.
        /// </summary>
        /// <param name="actions">List of actions.</param>
        public void InputParameters(List<Action> actions)
        {
            foreach (var action in actions)
            {
                action.Invoke();
            }
        }
    }
}
