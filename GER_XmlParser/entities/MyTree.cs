using GER_XmlParser.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GER_XmlParser.entities
{
    public class MyTree<T> where T : class
    {
        // FIELDS
        // PROPERTIES
        public List<MyTreeNode<T>> Roots { get; }

        // CONSTRUCTORS
        public MyTree(List<MyTreeNode<T>> roots)
        {
            this.Roots = roots;
        }

        public MyTree(params MyTreeNode<T>[] roots)
        {
            this.Roots = roots.ToList();
        }

        // METHODS
        public MyTreeNode<T> Find(T targetContent)
        {
            MyTreeNode<T> result;
            foreach (MyTreeNode<T> root in this.Roots)
            {
                Func<MyTreeNode<T>, bool> pred = delegate (MyTreeNode<T> node)
                {
                    return (node.Content.Equals(targetContent));
                };
                Func<MyTreeNode<T>, MyTreeNode<T>> func = delegate(MyTreeNode<T> node)
                {
                    return node;
                };
                result = root.Traverse(func, pred);
                if (result != null) return result;
            }
            return null;
        }

        public void RemoveRoot(MyTreeNode<T> rootToBeRemoved)
        {
            if (!this.Roots.Contains(rootToBeRemoved)) return;

            foreach (MyTreeNode<T> root in this.Roots)
            {
                if (root.Equals(rootToBeRemoved))
                {
                    foreach (MyTreeNode<T> rootChild in root.Children)
                    {
                        this.Roots.Add(rootChild);
                    }
                    break;
                }
            }
            this.Roots.Remove(rootToBeRemoved);
        }

        public void Sort()
        {
            Comparison<MyTreeNode<T>> comparison = delegate(MyTreeNode<T> node1, MyTreeNode<T> node2)
            {
                return node1.DisplayText.CompareTo(node2.DisplayText);
            };
            this.Sort(comparison);
        }

        public void Sort(Comparison<MyTreeNode<T>> comparison)
        {
            Action<MyTreeNode<T>> sortAction = delegate (MyTreeNode<T> node)
            {
                node.Children.Sort(comparison);
            };
            this.Roots.Sort(comparison);
            foreach (MyTreeNode<T> root in this.Roots)
            {
                root.Traverse(sortAction);
            }
        }

        public void PopulateTreeViewControl(TreeView treeView, Func<MyTreeNode<T>, TreeNode> translateFunc)
        {
            foreach (MyTreeNode<T> root in this.Roots)
            {
                TreeNode newRootTreeNode = translateFunc(root);
                treeView.Nodes.Add(newRootTreeNode);
                TranslateRecursivelyMyTreeNodes(root, translateFunc, newRootTreeNode);
            }
        }

        protected static void TranslateRecursivelyMyTreeNodes(MyTreeNode<T> myTreeNode, Func<MyTreeNode<T>, TreeNode> translateFunc, TreeNode treeNode)
        {
            foreach (MyTreeNode<T> child in myTreeNode.Children)
            {
                TreeNode newChildTreeNode = translateFunc(child);
                treeNode.Nodes.Add(newChildTreeNode);
                TranslateRecursivelyMyTreeNodes(child, translateFunc, newChildTreeNode);
            }
        }

        public static MyTree<XmlNode> ComputeFromModelFindRef(List<XmlNode> nodesFound, XmlNode nodeRootToBeExcluded)
        {
            MyTreeNode<XmlNode> myRoot = new MyTreeNode<XmlNode>(nodeRootToBeExcluded, XmlNodeUtils.StringifyAsModel(nodeRootToBeExcluded));
            MyTree<XmlNode> myTree = new MyTree<XmlNode>(myRoot);
            foreach (XmlNode node in nodesFound)
            {
                List<XmlNode> parentsChainUntilNodeTobeExcluded = XmlNodeUtils.ParentsChainUntilReserve(node, nodeRootToBeExcluded, new HashSet<string>() { "Contents." });
                XmlNode first = parentsChainUntilNodeTobeExcluded[0];
                MyTreeNode<XmlNode> myCursor;
                MyTreeNode<XmlNode> firstOfChain = myTree.Find(first);
                if (firstOfChain == null) firstOfChain = myRoot.AddChild(first, XmlNodeUtils.StringifyAsModel(first));
                myCursor = firstOfChain;
                foreach (XmlNode cursor in parentsChainUntilNodeTobeExcluded.Skip(1))
                {
                    MyTreeNode<XmlNode> newMyCursor = myCursor.AddChild(cursor, XmlNodeUtils.StringifyAsModel(cursor));
                    myCursor = newMyCursor;
                }
            }
            myTree.RemoveRoot(myRoot);
            myTree.Sort();
            return myTree;
        }
    }
}
