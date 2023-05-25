using Model;

namespace WinFormsApp
{
    /// <summary>
    /// Class ElementEventArgs.
    /// </summary>
    public class ElementEventArgs : EventArgs
    {
        /// <summary>
        /// Gets PassiveElement.
        /// </summary>
        public PassiveElementBase PassiveElement { get; private set; }

        /// <summary>
        /// Constructor of event.
        /// </summary>
        /// <param name="passiveElement">PassiveElement.</param>
        public ElementEventArgs(PassiveElementBase passiveElement)
        {
            PassiveElement = passiveElement;
        }
    }
}
