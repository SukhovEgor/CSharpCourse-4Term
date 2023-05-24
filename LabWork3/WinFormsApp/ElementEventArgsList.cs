using System.ComponentModel;
using Model;

namespace WinFormsApp
{
    public class ElementEventArgsList : EventArgs
    {
        public BindingList<PassiveElementBase> ElementListFiltered { get; private set; }

        public ElementEventArgsList (BindingList<PassiveElementBase> elementListFiltered)
        {
            ElementListFiltered = elementListFiltered;
        }
    }
}
