using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    public class ElementEventArgs : EventArgs
    {
        public PassiveElementBase PassiveElement { get; private set; }

        public ElementEventArgs(PassiveElementBase passiveElement)
        {
            PassiveElement = passiveElement;
        } 
        
        
    }
}
