using Model;
using System.ComponentModel;
using System.Xml.Serialization;

namespace WinFormsApp
{
    /// <summary>
    /// class MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// List of passive element.
        /// </summary>
        private BindingList<PassiveElementBase> _elementList = new();

        /// <summary>
        /// Filtered List of passive element.
        /// </summary>
        private BindingList<PassiveElementBase> _filteredList = new();

        /// <summary>
        /// Main form instance constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            var source = new BindingSource(_elementList, null);
            ElementDataGridView.DataSource = source;
        }

        /// <summary>
        /// Click event to save elemnt list to file.
        /// </summary>
        /// <param name="sender">SaveToolStripMenuItem.</param>
        /// <param name="e">Event argument.</param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileBrowser = new SaveFileDialog
            {
                Filter = "PassiveElement (*.elmt)|*.elmt"
            };

            _ = fileBrowser.ShowDialog();
            var path = fileBrowser.FileName;

            var xmlSerializer =
                new XmlSerializer(typeof(BindingList<PassiveElementBase>));

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

        /// <summary>
        ///  Click event to open elemnt list from file.
        /// </summary>
        /// <param name="sender">OpenToolStripMenuItem.</param>
        /// <param name="e">Event argument.</param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileBrowser = new OpenFileDialog
            {
                Filter = "PassiveElement (*.elmt)|*.elmt"
            };

            _ = fileBrowser.ShowDialog();
            var path = fileBrowser.FileName;

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            var xmlSerializer =
                new XmlSerializer(typeof(BindingList<PassiveElementBase>));

            try
            {
                using (var file = new StreamReader(path))
                {
                    _elementList = (BindingList<PassiveElementBase>)
                        xmlSerializer.Deserialize(file);
                }

                ElementDataGridView.DataSource = _elementList;
            }
            catch (Exception)
            {
                _ = MessageBox.Show("The file could not be open.\n",
                    "The file is corrupted or does not match the format.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Click event to add an PassiveElement object to the list.
        /// </summary>
        /// <param name="sender">AddButton.</param>
        /// <param name="e">Event argument.</param>
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

        /// <summary>
        /// Click event to remove an PassiveElement object from the list.
        /// </summary>
        /// <param name="sender">RemoveButton.</param>
        /// <param name="e">Event argument.</param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (ElementDataGridView.SelectedCells.Count != 0)
            {
                foreach (DataGridViewRow row in
                    ElementDataGridView.SelectedRows)
                {
                    _ = _elementList.Remove
                        (row.DataBoundItem as PassiveElementBase);

                    _ = _filteredList.Remove
                        (row.DataBoundItem as PassiveElementBase);
                }
            }
        }

        /// <summary>
        /// Click event to clear elementlist.
        /// </summary>
        /// <param name="sender">ClearButton.</param>
        /// <param name="e">Event argument.</param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            _elementList.Clear();
            _filteredList.Clear();
        }

        /// <summary>
        /// Click event to open filter form.
        /// </summary>
        /// <param name="sender">FilterButton.</param>
        /// <param name="e">Event argument.</param>
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
