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
            ElementDataGridView.DataSource = _elementList;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newEnterForm = new EnterForm(_elementList);

            newEnterForm.Show();

            newEnterForm.Closed += (_, _) =>
            {
                addToolStripMenuItem.Enabled = true;
            };

            addToolStripMenuItem.Enabled = false;
        }
    }
}