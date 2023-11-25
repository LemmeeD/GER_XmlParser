using System.Data;
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
                Alert("File .xml non valido per un model");
                return;
            }
            this.groupBoxModel.Enabled = true;
            this.textBoxModelName.Text = this.ModelWrapper.Name;
            this.textBoxModelDescr.Text = this.ModelWrapper.Description;
            this.textBoxModelVendor.Text = this.ModelWrapper.Vendor;
            this.textBoxModelPublicVersNum.Text = this.ModelWrapper.PublicVersionNumber;
        }

        // EVENTS
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "xml files (*.xml)|*.xml";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                return openFileDialog;
            }
        }

        private void buttonModelUpload_Click(object sender, EventArgs e)
        {
            this.ImportModel();
        }

        // STATIC METHODS
        public static void Alert(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void buttonModelFindRef_Click(object sender, EventArgs e)
        {
            if (this.textBoxModelFindRef.Text == "") return;
            MyTree<XmlNode> myTree = this.ModelWrapper.FindReferences(this.textBoxModelFindRef.Text);
            this.treeViewModelFindRef.Nodes.Clear();
            myTree.PopulateTreeViewControl(this.treeViewModelFindRef, TRANSLATE_TREENODES);
        }
    }
}