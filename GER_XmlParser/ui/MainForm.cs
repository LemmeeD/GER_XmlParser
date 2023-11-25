using System.Data;
using System.Windows.Forms;

using GER_XmlParser.entities;

namespace GER_XmlParser
{
    public partial class MainForm : Form
    {
        // FIELDS
        // PROPERTIES
        public XmlModelFileWrapper ModelWrapper { get; set; }

        // CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();
        }

        // METHODS
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.groupBoxModel.Enabled = false;
        }

        private void buttonModelBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = BrowseXmlFile();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.textBoxModelFile.Text = openFileDialog.FileName;
            }
            else
            {
                // 
            }
        }

        protected static OpenFileDialog BrowseXmlFile()
        {
            string result;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "xml files (*.xml)|*.xml";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                return openFileDialog;
            }
        }

        public static void Alert(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void buttonModelUpload_Click(object sender, EventArgs e)
        {
            try
            {
                new XmlModelFileWrapper(this.textBoxModelFile.Text);
                this.groupBoxModel.Enabled = true;
                this.ImportModel();
            }
            catch (Exception)
            {
                this.groupBoxModel.Enabled = false;
                Alert("File .xml non valido per un model");
            }
        }

        /// <summary>
        /// Si aspetta di trovare il percorso di un file .xml valido nella TextBox di riferimento
        /// </summary>
        protected void ImportModel()
        {
            try
            {
                this.ModelWrapper = new XmlModelFileWrapper(this.textBoxModelFile.Text);
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
            this.textBoxModelName.Text = this.ModelWrapper.Name;
            this.textBoxModelDescr.Text = this.ModelWrapper.Description;
        }
    }
}