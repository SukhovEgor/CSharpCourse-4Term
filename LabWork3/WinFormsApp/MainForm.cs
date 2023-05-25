using Model;
using System.ComponentModel;
using System.Xml.Serialization;


namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private BindingList<PassiveElementBase> _elementList = new();
        
        private BindingList<PassiveElementBase> _filteredList = new();

        public MainForm()
        {
            InitializeComponent();

            var source = new BindingSource(_elementList, null);
            ElementDataGridView.DataSource = source;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileBrowser = new SaveFileDialog
            {
                Filter = "PassiveElement (*.elmt)|*.elmt"
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
                Filter = "PassiveElement (*.elmt)|*.elmt"
            };

            fileBrowser.ShowDialog();
            var path = fileBrowser.FileName;

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            var xmlSerializer = new XmlSerializer(typeof(BindingList<PassiveElementBase>));
            try
            {
                using (var file = new StreamReader(path))
                {
                    _elementList = (BindingList<PassiveElementBase>)xmlSerializer.Deserialize(file);
                }
                ElementDataGridView.DataSource = _elementList;
            }
            catch (Exception exception)
            {
                MessageBox.Show("The file could not be uploaded.\n",
                    "The file is corrupted or does not match the format.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
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
                AddButton.Enabled = true;
            };

            AddButton.Enabled = false;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (ElementDataGridView.SelectedCells.Count != 0)
            {
                foreach (DataGridViewRow row in ElementDataGridView.SelectedRows)
                {
                    _elementList.Remove(row.DataBoundItem as PassiveElementBase);
                    _filteredList.Remove(row.DataBoundItem as PassiveElementBase);
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _elementList.Clear();
            _filteredList.Clear();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            var newFilterForm = new FilterForm();

            newFilterForm.ElementList = _elementList;

            newFilterForm.Show();

            newFilterForm.ElementListFiltered += (_, args) =>
            {
                ElementDataGridView.DataSource = args.ElementListFiltered;
                _elementList = args.ElementListFiltered;
            };

            newFilterForm.Closed += (_, _) =>
            {
                FilterButton.Enabled = true;
            };

            FilterButton.Enabled = false;
        }
    }
}