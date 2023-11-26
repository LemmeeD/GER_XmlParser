using GER_XmlParser.utils;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using GER_XmlParser.entities;

namespace GER_XmlParser.ui
{
    public partial class NodeDetailsForm : Form
    {
        // FIELDS
        protected TreeNode _treeNode;
        // PROPERTIES
        public TreeNode TreeNode { get { return this._treeNode; } }

        // CONSTRUCTORS

        // METHODS
        public NodeDetailsForm(TreeNode treeNode)
        {
            InitializeComponent();
            this._treeNode = treeNode;
        }

        private void NodeDetailsForm_Load(object sender, EventArgs e)
        {
            List<TreeNode> parentsChain = TreeNodeUtils.ParentsChainReverse(this.TreeNode);
            this.labelNodePath.Text = CollectionUtils.Stringify(parentsChain, (TreeNode tn) => { return tn.Text; }, "/");
            PopulateDataGridView(this.dataGridView1, this.TreeNode);
        }

        protected static void PopulateDataGridView(DataGridView dataGridView, TreeNode treeNode)
        {
            MyTreeNode<XmlNode> myTreeNode = treeNode.Tag as MyTreeNode<XmlNode>;
            dataGridView.Rows.Clear();
            foreach (XmlAttribute attr in myTreeNode.Content.Attributes)
            {
                dataGridView.Rows.Add(new string[] { attr.Name, attr.Value });
            }
        }
    }
}
