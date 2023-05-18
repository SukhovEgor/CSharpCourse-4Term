using Model;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

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

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _elementList.Clear();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ElementDataGridView.SelectedCells.Count != 0)
            {
                foreach (DataGridViewRow row in ElementDataGridView.SelectedRows)
                {
                    _elementList.Remove(row.DataBoundItem as PassiveElementBase);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileBrowser = new SaveFileDialog
            {
                Filter = "PassiveElement (*.pelmt)|*.pelmt"
            };

            fileBrowser.ShowDialog();
            var path = fileBrowser.FileName;

            var xmlSerializer = new XmlSerializer(typeof(BindingList<PassiveElementBase>));
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            using (var file = File.Create(path))
            {
                xmlSerializer.Serialize(file, ElementDataGridView.DataSource);
                file.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileBrowser = new OpenFileDialog
            {
                Filter = "PassiveElement (*.pelmt)|*.pelmt"
            };

            fileBrowser.ShowDialog();
            var path = fileBrowser.FileName;

            
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            var xmlSerializer = new XmlSerializer(typeof(BindingList<PassiveElementBase>));

            using (var file = new StreamReader(path))
            {
                _elementList = (BindingList<PassiveElementBase>)xmlSerializer.Deserialize(file);
            }

            ElementDataGridView.DataSource = _elementList;
        }

    }
}