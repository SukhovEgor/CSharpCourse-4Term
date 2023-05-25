using System.ComponentModel;
using Model;

namespace WinFormsApp
{
    /// <summary>
    /// class ElementEventArgsList.
    /// </summary>
    public class ElementEventArgsList : EventArgs
    {
        /// <summary>
        /// Gets filtered element list.
        /// </summary>
        public BindingList<PassiveElementBase> ElementListFiltered
        { get; private set; }

        /// <summary>
        /// Constructor of event.
        /// </summary>
        /// <param name="elementListFiltered">elementListFiltered.</param>
        public ElementEventArgsList
            (BindingList<PassiveElementBase> elementListFiltered)
        {
            ElementListFiltered = elementListFiltered;
        }
    }
}
