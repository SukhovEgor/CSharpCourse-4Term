using Model;
using System.ComponentModel;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        public static BindingList<PassiveElementBase> _elementList = new();
        public MainForm()
        {
            InitializeComponent();

            var source = new BindingSource(_elementList, null);
            ElementDataGridView.DataSource = source;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newEnterForm = new EnterForm();

            newEnterForm.Show();

            newEnterForm.ElementEventHandler += (_, args) =>
            {
                _elementList.Add(args.PassiveElement);
                ElementDataGridView.DataSource = _elementList;
            };

            newEnterForm.Closed += (_, _) =>
            {
                addToolStripMenuItem.Enabled = true;
            };

            addToolStripMenuItem.Enabled = false;
        }
    }
}