using GER_XmlParser.entities.wrappers.data;
using GER_XmlParser.utils;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GER_XmlParser.entities
{
    /// <summary>
    /// Implementazione custom di un albero che può prevedere multiple radici
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyTree<T> where T : class
    {
        // FIELDS
        // PROPERTIES
        public List<MyTreeNode<T>> Roots { get; }

        // CONSTRUCTORS
        public MyTree()
        {
            this.Roots = new List<MyTreeNode<T>>();
        }

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
                Func<MyTreeNode<T>, MyTreeNode<T>> func = delegate (MyTreeNode<T> node)
                {
                    return node;
                };
                result = root.Traverse(func, pred);
                if (result != null) return result;
            }
            return null;
        }

        public void Traverse(Action<MyTreeNode<T>> action)
        {
            foreach (MyTreeNode<T> root in this.Roots)
            {
                root.Traverse(action);
            }
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
            Comparison<MyTreeNode<T>> comparison = delegate (MyTreeNode<T> node1, MyTreeNode<T> node2)
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

        public MyTree<T> DeepCopy()
        {
            List<MyTreeNode<T>> deepCopyRoots = new List<MyTreeNode<T>>();
            foreach (MyTreeNode<T> root in this.Roots)
            {
                deepCopyRoots.Add(root.DeepCopy());
            }
            MyTree<T> deepCopy = new MyTree<T>(deepCopyRoots);

            Action<MyTreeNode<T>> action = delegate (MyTreeNode<T> node)
            {
                List<MyTreeNode<T>> deepCopiedChildren = new List<MyTreeNode<T>>();
                foreach (MyTreeNode<T> child in node.Children)
                {
                    deepCopiedChildren.Add(child.DeepCopy());
                }
                node.Children.Clear();
                node.Children.AddRange(deepCopiedChildren);
            };

            foreach (MyTreeNode<T> root in this.Roots)
            {
                root.Traverse(action);
            }
            return deepCopy;
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

        protected static MyTreeNode<MappingDatasourcePair> PopulateSingleRootDatasourceTreeFromStringPath(
            char separator,
            MyTree<MappingDatasourcePair> tree,
            MyTreeNode<MappingDatasourcePair> root,
            string datasourcePath,
            string bindingPath,
            XmlNode nodeExpression)
        {
            List<string> cumulativeStringsBinding = StringUtils.cumulativeSplit(datasourcePath, separator);
            string[] stringsBinding = datasourcePath.Split(separator);
            string expression = null;
            if (nodeExpression != null)
            {
                XmlAttribute expressionAttr = nodeExpression.Attributes["ExpressionAsString"];
                if (expressionAttr != null)
                {
                    expression = expressionAttr.Value;
                }
            }
            string cursorBindingPath;
            MyTreeNode<MappingDatasourcePair> temp = null;
            MyTreeNode<MappingDatasourcePair> cursor = root;
            for (int i = 0; i < cumulativeStringsBinding.Count; i++)
            {
                if (i == cumulativeStringsBinding.Count - 1) cursorBindingPath = bindingPath;
                else cursorBindingPath = "";
                string currentString = stringsBinding[i];
                string currentCumulativeString = cumulativeStringsBinding[i];
                temp = tree.Find(new MappingDatasourcePair(currentCumulativeString, cursorBindingPath));
                if (temp == null) cursor = cursor.AddChild(new MappingDatasourcePair(currentCumulativeString, cursorBindingPath, expression), currentString);
                else cursor = temp;
            }
            return cursor;  //leaf
        }

        protected static MyTreeNode<MappingBindingPair> PopulateSingleRootBindingTreeFromStringPath(
            char separator, MyTree<MappingBindingPair> tree,
            MyTreeNode<MappingBindingPair> root,
            string bindingPath,
            string datasourcePath,
            Dictionary<string, string> labels)
        {
            List<string> cumulativeStringsBinding = StringUtils.cumulativeSplit(bindingPath, separator);
            string[] stringsBinding = bindingPath.Split(separator);
            MyTreeNode<MappingBindingPair> temp = null;
            MyTreeNode<MappingBindingPair> cursor = root;
            string cursorDatasourcePath;
            for (int i = 0; i < cumulativeStringsBinding.Count; i++)
            {
                if (i == cumulativeStringsBinding.Count - 1) cursorDatasourcePath = datasourcePath;
                else cursorDatasourcePath = "";
                string currentString = stringsBinding[i];
                currentString = StringUtils.StringifyAsMapping(currentString, labels);
                string currentCumulativeString = cumulativeStringsBinding[i];
                temp = tree.Find(new MappingBindingPair(currentCumulativeString, cursorDatasourcePath));
                if (temp == null) cursor = cursor.AddChild(new MappingBindingPair(currentCumulativeString, cursorDatasourcePath), currentString);
                else cursor = temp;
            }
            return cursor;  //leaf
        }

        public static MyTree<XmlNode> ComputeFromModelFindRef(List<XmlNode> nodesFound, XmlNode nodeRootToBeExcluded, Dictionary<string, string> labels)
        {
            // radice unica temporanea che corrisponde al nodo 'Contents.'
            MyTreeNode<XmlNode> myRoot = new MyTreeNode<XmlNode>(nodeRootToBeExcluded, XmlNodeUtils.StringifyAsModel(nodeRootToBeExcluded, labels));
            MyTree<XmlNode> myTree = new MyTree<XmlNode>(myRoot);
            foreach (XmlNode node in nodesFound)
            {
                List<XmlNode> parentsChainUntilNodeTobeExcluded = XmlNodeUtils.ParentsChainUntilReverse(node, nodeRootToBeExcluded, new HashSet<string>() { "Contents." });
                XmlNode first = parentsChainUntilNodeTobeExcluded[0];
                MyTreeNode<XmlNode> myCursor;
                MyTreeNode<XmlNode> firstOfChain = myTree.Find(first);
                if (firstOfChain == null) firstOfChain = myRoot.AddChild(first, XmlNodeUtils.StringifyAsModel(first, labels));
                myCursor = firstOfChain;
                foreach (XmlNode cursor in parentsChainUntilNodeTobeExcluded.Skip(1))
                {
                    // aggiunta del figlio controllare se esiste già
                    MyTreeNode<XmlNode> newMyCursor = myCursor.AddChild(cursor, XmlNodeUtils.StringifyAsModel(cursor, labels));
                    myCursor = newMyCursor;
                }
            }
            myTree.RemoveRoot(myRoot);
            myTree.Sort();
            return myTree;
        }

        public static Tuple<MyTree<MappingDatasourcePair>, MyTree<MappingBindingPair>> ComputeFromMappingFindRef(
            List<XmlNode> nodesDatasourceFound,
            XmlNode nodeRootDatasourceToBeExcluded,
            List<XmlNode> nodesBindingFound,
            XmlNode nodeRootBindingToBeExcluded,
            Dictionary<string, string> labels)
        {
            Dictionary<string, string> pathMemoization = new Dictionary<string, string>();

            // radice unica temporanea di Content 'root'
            string rootContent = "root";

            MyTreeNode<MappingDatasourcePair> myRootDatasource = new MyTreeNode<MappingDatasourcePair>(new MappingDatasourcePair(rootContent, "/"), rootContent);
            MyTree<MappingDatasourcePair> myTreeDatasource = new MyTree<MappingDatasourcePair>(myRootDatasource);
            foreach (XmlNode node in nodesDatasourceFound)
            {
                string datasourcePath = "";
                string name = node.Attributes["Name"].Value;
                XmlNode nodeModelItemDefinition = node.ParentNode.ParentNode;
                XmlAttribute parentPathAttr = nodeModelItemDefinition.Attributes["ParentPath"];
                if (parentPathAttr != null)
                {
                    datasourcePath = (parentPathAttr.Value + "/");
                }
                datasourcePath += name;
                XmlNode nodeExpression = node.SelectSingleNode("./ValueSource/ERModelExpressionItem");

                PopulateSingleRootDatasourceTreeFromStringPath('/', myTreeDatasource, myRootDatasource, datasourcePath, "", nodeExpression);
            }
            myTreeDatasource.RemoveRoot(myRootDatasource);
            myTreeDatasource.Sort();

            MyTreeNode<MappingBindingPair> myRootBinding = new MyTreeNode<MappingBindingPair>(new MappingBindingPair(rootContent, "/"), rootContent);
            MyTree<MappingBindingPair> myTreeBinding = new MyTree<MappingBindingPair>(myRootBinding);
            foreach (XmlNode node in nodesBindingFound)
            {
                string datasourcePath = node.Attributes["ItemPath"].Value;
                XmlNode dataContainerPathBinding = node.ParentNode.ParentNode;
                string bindingPath = dataContainerPathBinding.Attributes["Path"].Value;
                pathMemoization.Add(bindingPath, datasourcePath);

                PopulateSingleRootDatasourceTreeFromStringPath('/', myTreeDatasource, myRootDatasource, datasourcePath, bindingPath, null);
                PopulateSingleRootBindingTreeFromStringPath('/', myTreeBinding, myRootBinding, bindingPath, datasourcePath, labels);
            }
            Action<MyTreeNode<MappingDatasourcePair>> updateAction = delegate(MyTreeNode<MappingDatasourcePair> node) { 
                if (node.Content.BindingPath != "") { return; }

                try
                {
                    node.Content.BindingPath = DictionaryUtils.GetFirstKeyFromValue(pathMemoization, node.Content.Path);
                } catch (KeyNotFoundException)
                {

                }
            };
            myTreeDatasource.Traverse(updateAction);
            myTreeBinding.RemoveRoot(myRootBinding);
            myTreeBinding.Sort();
            return Tuple.Create<MyTree<MappingDatasourcePair>, MyTree<MappingBindingPair>>(myTreeDatasource, myTreeBinding);
        }

        public static MyTree<FormatPair> ComputeFromFormatFindRef(List<XmlNode> nodesFound, XmlNode nodeRootToBeExcluded, List<XmlNode> nodeBindingsFound, Dictionary<string, string> labels)
        {
            // radice unica temporanea che corrisponde al nodo 'Contents.'
            MyTreeNode<FormatPair> myRoot = new MyTreeNode<FormatPair>(new FormatPair(nodeRootToBeExcluded), XmlNodeUtils.StringifyAsFormat(nodeRootToBeExcluded, labels));
            MyTree<FormatPair> myTree = new MyTree<FormatPair>(myRoot);
            foreach (XmlNode node in nodesFound)
            {
                XmlNode bindingNode;
                try
                {
                    bindingNode = nodeBindingsFound.Where((n) =>
                    {
                        XmlAttribute attr = n.Attributes["Component"];
                        if (attr != null) return node["ID."].Value == attr.Value;
                        else return false;
                    }).First();
                } catch (InvalidOperationException)
                {
                    bindingNode = null;
                }

                List<XmlNode> parentsChainUntilNodeTobeExcluded = XmlNodeUtils.ParentsChainUntilReverse(node, nodeRootToBeExcluded, new HashSet<string>() { "Contents." });
                XmlNode first = parentsChainUntilNodeTobeExcluded[0];
                MyTreeNode<FormatPair> myCursor;
                MyTreeNode<FormatPair> firstOfChain = myTree.Find(new FormatPair(first, bindingNode));
                if (firstOfChain == null) firstOfChain = myRoot.AddChild(new FormatPair(first, bindingNode), XmlNodeUtils.StringifyAsFormat(first, labels));
                myCursor = firstOfChain;
                foreach (XmlNode cursor in parentsChainUntilNodeTobeExcluded.Skip(1))
                {
                    // aggiunta del figlio controllare se esiste già
                    MyTreeNode<FormatPair> newMyCursor = myCursor.AddChild(new FormatPair(cursor, bindingNode), XmlNodeUtils.StringifyAsFormat(cursor, labels));
                    myCursor = newMyCursor;
                }
            }
            myTree.RemoveRoot(myRoot);
            myTree.Sort();
            return myTree;
        }
    }
}
