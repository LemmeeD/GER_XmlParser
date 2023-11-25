using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using GER_XmlParser.entities;
using GER_XmlParser.utils;

namespace GER_XmlParser
{
    public partial class MainForm : Form
    {
        // FIELDS
        // PROPERTIES
        public XmlModelFileWrapper ModelWrapper { get; set; }
        public XmlMappingWrapper MappingWrapper { get; set; }
        public XmlFormatFileWrapper FormatWrapper { get; set; }
        protected static Func<MyTreeNode<XmlNode>, TreeNode> TRANSLATE_TREENODES = delegate (MyTreeNode<XmlNode> myNode)
        {
            TreeNode newNode = new TreeNode();
            newNode.Text = XmlNodeUtils.StringifyAsModel(myNode.Content);
            return newNode;
        };

        // CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();
        }

        // METHODS
        protected void ImportModel()
        {
            try
            {
                this.ModelWrapper = new XmlModelFileWrapper(this.textBoxModelFile.Text);
            }
            catch (Exception)
            {
                this.groupBoxModel.Enabled = false;
                AlertError("File .xml non valido per un model");
                return;
            }
            this.groupBoxModel.Enabled = true;
            this.textBoxModelName.Text = this.ModelWrapper.Name;
            this.textBoxModelDescr.Text = this.ModelWrapper.Description;
            this.textBoxModelVendor.Text = this.ModelWrapper.Vendor;
            this.textBoxModelPublicVersNum.Text = this.ModelWrapper.PublicVersionNumber;
        }

        protected void ImportMapping()
        {
            try
            {
                this.MappingWrapper = new XmlMappingWrapper(this.textBoxMapFile.Text);
            }
            catch (Exception)
            {
                this.groupBoxModel.Enabled = false;
                AlertError("File .xml non valido per un mapping");
                return;
            }
            this.groupBoxMap.Enabled = true;
            this.textBoxMapName.Text = this.MappingWrapper.Name;

            this.textBoxMapProvider.Text = this.MappingWrapper.Vendor;
            this.textBoxMapVers.Text = this.MappingWrapper.PublicVersionNumber;
            foreach (string idMapping in this.MappingWrapper.IdMappingVersions)
            {
                this.comboBoxMapVers.Items.Add(idMapping);
            }
            this.comboBoxMapVers.SelectedIndex = 0;
        }

        protected void ImportFormat()
        {
            try
            {
                this.FormatWrapper = new XmlFormatFileWrapper(this.textBoxFormat.Text);
            }
            catch (Exception)
            {
                this.groupBoxFormat.Enabled = false;
                AlertError("File .xml non valido per un format");
                return;
            }
            this.groupBoxFormat.Enabled = true;
            this.textBoxFormatName.Text = this.FormatWrapper.Name;
            this.textBoxFormatDescr.Text = this.FormatWrapper.Description;
            this.textBoxFormatProvider.Text = this.FormatWrapper.Vendor;
            this.textBoxFormatVers.Text = this.FormatWrapper.PublicVersionNumber;
        }

        // EVENTS
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.groupBoxModel.Enabled = false;
            this.groupBoxFormat.Enabled = false;
            this.groupBoxMap.Enabled = false;
        }

        private void buttonModelBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = BrowseXmlFile();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.textBoxModelFile.Text = openFileDialog.FileName;
            }
        }

        private void buttonMapBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = BrowseXmlFile();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.textBoxMapFile.Text = openFileDialog.FileName;
            }
        }

        private void buttonFormatBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = BrowseXmlFile();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.textBoxFormat.Text = openFileDialog.FileName;
            }
        }

        private void buttonModelFindRef_Click(object sender, EventArgs e)
        {
            if (this.textBoxModelFindRef.Text == "") return;
            MyTree<XmlNode> myTree = this.ModelWrapper.FindReferences(this.textBoxModelFindRef.Text);
            this.treeViewModelFindRef.Nodes.Clear();
            myTree.PopulateTreeViewControl(this.treeViewModelFindRef, TRANSLATE_TREENODES);
        }

        private void buttonModelUpload_Click(object sender, EventArgs e)
        {
            this.ImportModel();
        }

        private void buttonMapUpload_Click(object sender, EventArgs e)
        {
            this.ImportMapping();
        }

        private void comboBoxMapVers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedIdMap = this.comboBoxMapVers.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedIdMap)) this.MappingWrapper.SetMappingVersion(selectedIdMap);
            this.textBoxMapDescr.Text = this.MappingWrapper.Description;
        }

        private void buttonFormatUpload_Click(object sender, EventArgs e)
        {
            this.ImportFormat();
        }

        private void buttonFormatRebase_Click(object sender, EventArgs e)
        {
            int modifiedNodesCount = this.FormatWrapper.RemoveRevisionNumberAttributes();
            AlertSuccess(string.Format(@"Modificati {0} nodi", modifiedNodesCount));
        }

        // STATIC METHODS
        public static void AlertError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void AlertWarning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void AlertSuccess(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected static OpenFileDialog BrowseXmlFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "XML files (*.xml)|*.xml";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                return openFileDialog;
            }
        }
    }
}