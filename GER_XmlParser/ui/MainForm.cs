using System.Data;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using GER_XmlParser.entities;
using GER_XmlParser.enums;
using GER_XmlParser.ui;
using GER_XmlParser.utils;

namespace GER_XmlParser
{
    public partial class MainForm : Form
    {
        #region FIELDS
        protected static Func<MyTreeNode<XmlNode>, TreeNode> TRANSLATE_TREENODES = delegate (MyTreeNode<XmlNode> myNode)
        {
            TreeNode newNode = new TreeNode();
            newNode.Text = myNode.DisplayText;
            newNode.Tag = myNode;
            return newNode;
        };
        protected static Func<MyTreeNode<string>, TreeNode> TRANSLATE_STRING_TREENODES = delegate (MyTreeNode<string> myNode)
        {
            TreeNode newNode = new TreeNode();
            newNode.Text = myNode.DisplayText;
            newNode.Tag = myNode;
            return newNode;
        };
        protected static Func<MyTreeNode<MappingBindingPair>, TreeNode> TRANSLATE_MAP_BINDING_TREENODES = delegate (MyTreeNode<MappingBindingPair> myNode)
        {
            TreeNode newNode = new TreeNode();
            newNode.Text = myNode.DisplayText;
            newNode.Tag = myNode;
            return newNode;
        };
        protected static Func<MyTreeNode<MappingDatasourcePair>, TreeNode> TRANSLATE_MAP_DATASOURCE_TREENODES = delegate (MyTreeNode<MappingDatasourcePair> myNode)
        {
            TreeNode newNode = new TreeNode();
            newNode.Text = myNode.DisplayText;
            newNode.Tag = myNode;
            return newNode;
        };
        #endregion
        #region PROPERTIES
        public XmlModelFileWrapper ModelWrapper { get; set; }
        public XmlModelFileWrapper ReferencedModelWrapper { get; set; }
        public XmlMappingWrapper MappingWrapper { get; set; }
        public XmlFormatFileWrapper FormatWrapper { get; set; }
        public XmlFormatFileWrapper ReferencedFormatWrapper { get; set; }
        protected static Color SUCCESS = Color.LightGreen;
        protected static Color WARNING = Color.LightYellow;
        protected static Color ERROR = Color.LightCoral;
        #endregion

        #region CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region METHODS

        #region Model
        protected void ImportModel()
        {
            try
            {
                this.ModelWrapper = new XmlModelFileWrapper(this.textBoxModelFile.Text);
            }
            catch (Exception e)
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
            this.textBoxModelIdentifier.Text = this.ModelWrapper.Identifier.Serial;
            this.textBoxModelExtensionLabels.Text = this.ModelWrapper.CountLabels.ToString();
            if (this.ModelWrapper.Extension)
            {
                this.textBoxModelIsExtension.Text = "Si";
                this.groupBoxModelExtension.Enabled = true;
                this.textBoxModelExtensionIdSerial.Text = this.ModelWrapper.ReferencedIdentifier.Serial;
                this.textBoxModelExtensionIdVersion.Text = this.ModelWrapper.ReferencedIdentifier.NumberString;
            }
            else
            {
                this.textBoxModelIsExtension.Text = "No";
                this.groupBoxModelExtension.Enabled = false;
                this.textBoxModelExtensionIdSerial.Text = "";
                this.textBoxModelExtensionIdVersion.Text = "";
            }

            MyTree<XmlNode> myTree = this.ModelWrapper.FindEntireModelContents();
            this.treeViewModelFindRef.Nodes.Clear();
            myTree.PopulateTreeViewControl(this.treeViewModelFindRef, TRANSLATE_TREENODES);
        }
        #endregion

        #region Mapping
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
            this.textBoxMapDescr.Text = this.MappingWrapper.Description;
            this.textBoxMapProvider.Text = this.MappingWrapper.Vendor;
            this.textBoxMapSerial.Text = this.MappingWrapper.Identifier.Serial;
            this.textBoxMapVers.Text = this.MappingWrapper.Identifier.NumberString;
            foreach (string idMapping in this.MappingWrapper.IdMappingVersions)
            {
                this.comboBoxMapVers.Items.Add(idMapping);
            }
            this.comboBoxMapVers.SelectedIndex = 0;

            if (this.MappingWrapper.IsBaseModelComputable)
            {
                this.textBoxMapBaseModelSerial.Text = this.MappingWrapper.BaseModelIdentifier.Serial;
                this.textBoxMapBaseModelVers.Text = this.MappingWrapper.BaseModelIdentifier.NumberString;
            }
            else
            {
                this.textBoxMapBaseModelSerial.Text = "???";
                this.textBoxMapBaseModelVers.Text = "???";
            }

            if (this.MappingWrapper.Extension)
            {
                this.textBoxMapExtension.Text = "Si";
                this.groupBoxMapExtension.Enabled = true;
                this.textBoxMapExtensionSerial.Text = this.MappingWrapper.BaseMappingIdentifier.Serial;
                this.textBoxMapExtensionVers.Text = this.MappingWrapper.BaseMappingIdentifier.NumberString;
            }
            else
            {
                this.textBoxMapExtension.Text = "No";
                this.groupBoxMapExtension.Enabled = false;
                this.textBoxMapExtensionSerial.Text = "";
                this.textBoxMapExtensionVers.Text = "";
            }
        }

        protected void UpdateMappingVersion()
        {
            string selectedIdMap = this.comboBoxMapVers.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedIdMap)) this.MappingWrapper.SetMappingVersion(selectedIdMap);
            this.textBoxMapModelMappingDefinition.Text = this.MappingWrapper.MappingDefinition;
            this.textBoxMapModelMappingName.Text = this.MappingWrapper.MappingName;
            this.textBoxMapModelMappingDescr.Text = this.MappingWrapper.MappingDescription;
            Dictionary<string, string> labels;
            if (this.ModelWrapper == null) labels = new Dictionary<string, string>();
            else labels = this.ModelWrapper.Labels;

            Tuple<MyTree<MappingDatasourcePair>, MyTree<MappingBindingPair>> tuple = this.MappingWrapper.FindEntireMappingContents(labels);
            MyTree<MappingDatasourcePair> myTreeDatasource = tuple.Item1;
            MyTree<MappingBindingPair> myTreeBinding = tuple.Item2;

            this.treeViewMapFindRefDatasource.Nodes.Clear();
            myTreeDatasource.PopulateTreeViewControl(this.treeViewMapFindRefDatasource, TRANSLATE_MAP_DATASOURCE_TREENODES);
            this.treeViewMapFindRefBinding.Nodes.Clear();
            myTreeBinding.PopulateTreeViewControl(this.treeViewMapFindRefBinding, TRANSLATE_MAP_BINDING_TREENODES);
        }

        protected void SetMappingFindReferencesArrowOrientation(ArrowOrientation orientation)
        {
            if (orientation == ArrowOrientation.NONE) this.pictureBoxMapFindRefBinding.Image = null;
            else if (orientation == ArrowOrientation.LEFT) this.pictureBoxMapFindRefBinding.Image = Properties.Resources.arrow_left;
            else if (orientation == ArrowOrientation.RIGHT) this.pictureBoxMapFindRefBinding.Image = Properties.Resources.arrow_right;
        }
        #endregion

        #region Format
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
            this.textBoxFormatSerial.Text = this.FormatWrapper.Identifier.Serial;
            this.textBoxFormatVers.Text = this.FormatWrapper.Identifier.NumberString;
            this.textBoxFormatLabels.Text = this.FormatWrapper.CountLabels.ToString();

            if (this.FormatWrapper.IsBaseModelComputable)
            {
                this.textBoxFormatBaseModelSerial.Text = this.FormatWrapper.BaseModelIdentifier.Serial;
                this.textBoxFormatBaseModelVers.Text = this.FormatWrapper.BaseModelIdentifier.NumberString;
            }
            else
            {
                this.textBoxFormatBaseModelSerial.Text = "???";
                this.textBoxFormatBaseModelVers.Text = "???";
            }

            if (this.FormatWrapper.Extension)
            {
                this.textBoxFormatBaseFormatExtension.Text = "Si";
                this.groupBoxFormatExtension.Enabled = true;
                this.textBoxFormatBaseFormatSerial.Text = this.FormatWrapper.BaseFormatIdentifier.Serial;
                this.textBoxFormatBaseFormatVers.Text = this.FormatWrapper.BaseFormatIdentifier.NumberString;
            }
            else
            {
                this.textBoxFormatBaseFormatExtension.Text = "No";
                this.groupBoxFormatExtension.Enabled = false;
                this.textBoxFormatBaseFormatSerial.Text = "";
                this.textBoxFormatBaseFormatVers.Text = "";
            }
        }
        #endregion

        #endregion

        #region EVENTS
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.groupBoxModel.Enabled = false;
            this.groupBoxFormat.Enabled = false;
            this.groupBoxMap.Enabled = false;
        }

        #region Model
        private void buttonModelBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = BrowseXmlFile();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.textBoxModelFile.Text = openFileDialog.FileName;
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

        private void treeViewModelFindRef_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            NodeDetailsForm ndf = new NodeDetailsForm(e.Node);
            ndf.ShowDialog();
        }

        private void buttonModelFindRefReset_Click(object sender, EventArgs e)
        {
            MyTree<XmlNode> myTree = this.ModelWrapper.FindEntireModelContents();
            this.treeViewModelFindRef.Nodes.Clear();
            myTree.PopulateTreeViewControl(this.treeViewModelFindRef, TRANSLATE_TREENODES);
            this.textBoxModelFindRef.Text = "";
        }

        private void buttonModelFindRefCollapse_Click(object sender, EventArgs e)
        {
            Action<TreeNode> action = delegate (TreeNode node)
            {
                node.Collapse();
            };
            foreach (TreeNode root in this.treeViewModelFindRef.Nodes)
            {
                TreeNodeUtils.Traverse(root, action);
            }
        }

        private void buttonModelFindRefExpand_Click(object sender, EventArgs e)
        {
            Action<TreeNode> action = delegate (TreeNode node)
            {
                node.Expand();
            };
            foreach (TreeNode root in this.treeViewModelFindRef.Nodes)
            {
                TreeNodeUtils.Traverse(root, action);
            }
        }

        private void buttonModelExtensionUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.ReferencedModelWrapper = new XmlModelFileWrapper(this.textBoxModelExtensionFilepath.Text);
            }
            catch (Exception)
            {
                AlertError("File .xml non valido per il model base");
                return;
            }
            this.textBoxModelImportedExtensionIdSerial.Text = this.ReferencedModelWrapper.Identifier.Serial;
            this.textBoxModelImportedExtensionIdVersion.Text = this.ReferencedModelWrapper.Identifier.NumberString;
            this.ModelWrapper.ParseLabelsFrom(this.ReferencedModelWrapper);

            if (this.ModelWrapper.ReferencedIdentifier.SameSerial(this.ReferencedModelWrapper.Identifier))
            {
                this.textBoxModelExtensionIdSerial.BackColor = SUCCESS;
                this.textBoxModelImportedExtensionIdSerial.BackColor = SUCCESS;
            }
            else
            {
                this.textBoxModelExtensionIdSerial.BackColor = ERROR;
                this.textBoxModelImportedExtensionIdSerial.BackColor = ERROR;
                AlertError("Discordanza tra seriali!");
            }
            if (this.ModelWrapper.ReferencedIdentifier.SameVersion(this.ReferencedModelWrapper.Identifier))
            {
                this.textBoxModelExtensionIdVersion.BackColor = SUCCESS;
                this.textBoxModelImportedExtensionIdVersion.BackColor = SUCCESS;

            }
            else
            {
                this.textBoxModelExtensionIdVersion.BackColor = WARNING;
                this.textBoxModelImportedExtensionIdVersion.BackColor = WARNING;
                AlertError("Discordanza tra versioni!");
            }

            this.textBoxModelExtensionLabels.Text = this.ReferencedModelWrapper.CountLabels.ToString();
        }

        private void buttonModelExtensionBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = BrowseXmlFile();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.textBoxModelExtensionFilepath.Text = openFileDialog.FileName;
            }
        }

        private void buttonModelExtensionReset_Click(object sender, EventArgs e)
        {
            this.textBoxModelExtensionFilepath.Text = "";
            this.ReferencedModelWrapper = null;
            this.textBoxModelExtensionLabels.Text = "";
            this.ModelWrapper.Labels.Clear();
            this.textBoxModelImportedExtensionIdSerial.Text = "";
            this.textBoxModelImportedExtensionIdVersion.Text = "";
            this.textBoxModelExtensionIdSerial.BackColor = Color.White;
            this.textBoxModelImportedExtensionIdSerial.BackColor = Color.White;
            this.textBoxModelExtensionIdVersion.BackColor = Color.White;
            this.textBoxModelImportedExtensionIdVersion.BackColor = Color.White;
        }
        #endregion

        #region Mapping
        private void buttonMapBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = BrowseXmlFile();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.textBoxMapFile.Text = openFileDialog.FileName;
            }
        }

        private void comboBoxMapVers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateMappingVersion();
        }

        private void buttonMapUpload_Click(object sender, EventArgs e)
        {
            this.ImportMapping();
        }

        private void treeViewMapFindRefDatasource_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MyTreeNode<MappingDatasourcePair> myTreeNode = e.Node.Tag as MyTreeNode<MappingDatasourcePair>;
            this.textBoxMapFindRefExpression.Text = myTreeNode.Content.Expression;
            this.textBoxMapFindRefBindings.Text = myTreeNode.Content.BindingPath;
            this.SetMappingFindReferencesArrowOrientation(ArrowOrientation.RIGHT);
        }

        private void treeViewMapFindRefBinding_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MyTreeNode<MappingBindingPair> myTreeNode = e.Node.Tag as MyTreeNode<MappingBindingPair>;
            this.textBoxMapFindRefExpression.Text = "";
            this.textBoxMapFindRefBindings.Text = myTreeNode.Content.DatasourcePath;
            this.SetMappingFindReferencesArrowOrientation(ArrowOrientation.LEFT);
        }

        private void buttonMapFindRefReset_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> labels;
            if (this.ModelWrapper == null) labels = new Dictionary<string, string>();
            else labels = this.ModelWrapper.Labels;

            Tuple<MyTree<MappingDatasourcePair>, MyTree<MappingBindingPair>> tuple = this.MappingWrapper.FindEntireMappingContents(labels);
            MyTree<MappingDatasourcePair> myTreeDatasource = tuple.Item1;
            MyTree<MappingBindingPair> myTreeBinding = tuple.Item2;
            this.treeViewMapFindRefBinding.Nodes.Clear();
            this.treeViewMapFindRefDatasource.Nodes.Clear();
            myTreeDatasource.PopulateTreeViewControl(this.treeViewMapFindRefDatasource, TRANSLATE_MAP_DATASOURCE_TREENODES);
            myTreeBinding.PopulateTreeViewControl(this.treeViewMapFindRefBinding, TRANSLATE_MAP_BINDING_TREENODES);
            this.textBoxMapFindRef.Text = "";
            this.SetMappingFindReferencesArrowOrientation(ArrowOrientation.NONE);
        }

        private void buttonMapFindRef_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> labels;
            if (this.ModelWrapper == null) labels = new Dictionary<string, string>();
            else labels = this.ModelWrapper.Labels;

            Tuple<MyTree<MappingDatasourcePair>, MyTree<MappingBindingPair>> tuple = this.MappingWrapper.FindReferences(this.textBoxMapFindRef.Text, labels);
            MyTree<MappingDatasourcePair> myTreeDatasource = tuple.Item1;
            MyTree<MappingBindingPair> myTreeBinding = tuple.Item2;

            this.treeViewMapFindRefDatasource.Nodes.Clear();
            myTreeDatasource.PopulateTreeViewControl(this.treeViewMapFindRefDatasource, TRANSLATE_MAP_DATASOURCE_TREENODES);
            this.treeViewMapFindRefBinding.Nodes.Clear();
            myTreeBinding.PopulateTreeViewControl(this.treeViewMapFindRefBinding, TRANSLATE_MAP_BINDING_TREENODES);
        }
        #endregion

        #region Format
        private void buttonFormatBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = BrowseXmlFile();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.textBoxFormat.Text = openFileDialog.FileName;
            }
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

        private void buttonFormatExtensionBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = BrowseXmlFile();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.textBoxFormatExtensionBrowse.Text = openFileDialog.FileName;
            }
        }
        private void buttonFormatExtensionReset_Click(object sender, EventArgs e)
        {
            this.textBoxFormatExtensionBrowse.Text = "";
            this.ReferencedFormatWrapper = null;
            this.textBoxFormatLabels.Text = "";
            this.FormatWrapper.Labels.Clear();
            this.textBoxFormatExtensionImportSerial.Text = "";
            this.textBoxFormatExtensionImportVers.Text = "";
            this.textBoxFormatExtensionImportSerial.BackColor = Color.White;
            this.textBoxFormatExtensionImportVers.BackColor = Color.White;
            this.textBoxFormatBaseFormatSerial.BackColor = Color.White;
            this.textBoxFormatBaseFormatVers.BackColor = Color.White;
        }
        private void buttonFormatExtensionImport_Click(object sender, EventArgs e)
        {
            try
            {
                this.ReferencedFormatWrapper = new XmlFormatFileWrapper(this.textBoxFormatExtensionBrowse.Text);
            }
            catch (Exception)
            {
                AlertError("File .xml non valido per il Format base");
                return;
            }
            this.textBoxFormatExtensionImportSerial.Text = this.ReferencedFormatWrapper.Identifier.Serial;
            this.textBoxFormatExtensionImportVers.Text = this.ReferencedFormatWrapper.Identifier.NumberString;
            this.FormatWrapper.ParseLabelsFrom(this.ReferencedFormatWrapper);

            if (this.FormatWrapper.BaseFormatIdentifier.SameSerial(this.ReferencedFormatWrapper.Identifier))
            {
                this.textBoxFormatExtensionImportSerial.BackColor = SUCCESS;
                this.textBoxFormatBaseFormatSerial.BackColor = SUCCESS;
            }
            else
            {
                this.textBoxFormatExtensionImportSerial.BackColor = ERROR;
                this.textBoxFormatBaseFormatSerial.BackColor = ERROR;
                AlertError("Discordanza tra seriali!");
            }
            if (this.FormatWrapper.BaseFormatIdentifier.SameVersion(this.ReferencedFormatWrapper.Identifier))
            {
                this.textBoxFormatExtensionImportVers.BackColor = SUCCESS;
                this.textBoxFormatBaseFormatVers.BackColor = SUCCESS;

            }
            else
            {
                this.textBoxFormatExtensionImportVers.BackColor = WARNING;
                this.textBoxFormatBaseFormatVers.BackColor = WARNING;
                AlertError("Discordanza tra versioni!");
            }

            this.textBoxFormatLabels.Text = this.ReferencedFormatWrapper.CountLabels.ToString();
        }
        #endregion

        #endregion

        #region STATIC METHODS
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
        #endregion

    }
}