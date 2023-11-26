using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GER_XmlParser.utils
{
    internal class TreeNodeUtils
    {
        // FIELDS
        // PROPERTIES

        // CONSTRUCTORS

        // METHODS
        public static List<TreeNode> ParentsChain(TreeNode node)
        {
            List<TreeNode> chains = new List<TreeNode>();
            chains.Add(node);
            return InnerParentsChain(node, chains);
        }

        public static List<TreeNode> ParentsChainReverse(TreeNode node)
        {
            List<TreeNode> result = ParentsChain(node);
            result.Reverse();
            return result;
        }

        protected static List<TreeNode> InnerParentsChain(TreeNode node, List<TreeNode> parents)
        {
            TreeNode parentNode = node.Parent;
            if (parentNode != null)
            {
                parents.Add(parentNode);
                return InnerParentsChain(parentNode, parents);
            }
            else
            {
                return parents;
            }
        }

        public static void Traverse(TreeNode node, Action<TreeNode> action)
        {
            action(node);
            foreach (TreeNode child in node.Nodes)
            {
                Traverse(child, action);
            }
        }
    }
}
