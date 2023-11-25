using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GER_XmlParser.entities
{
    public class MyTreeNode<T> where T : class
    {
        // FIELDS
        // PROPERTIES
        public T Content { get; }
        public MyTreeNode<T> Parent { get; set; }
        public List<MyTreeNode<T>> Children { get; set; }
        public bool IsRoot { get { return (this.Parent == null); } }
        public bool IsLeaf { get { return (this.Children.Count == 0); } }

        // CONSTRUCTORS
        public MyTreeNode(T content)
        {
            this.Content = content;
            this.Parent = null;
            this.Children = new List<MyTreeNode<T>>();
        }

        public MyTreeNode(MyTreeNode<T> parent, T content)
        {
            this.Content = content;
            this.Parent = parent;
            this.Children = new List<MyTreeNode<T>>();
        }

        // METHODS
        public MyTreeNode<T> AddChild(T newContent)
        {
            if (newContent == null) throw new ApplicationException("Contenuto nullo");
            MyTreeNode<T> alreadyExisting = null;
            foreach (MyTreeNode<T> child in this.Children)
            {
                if (child.Content.Equals(newContent))
                {
                    alreadyExisting = child;
                    break;
                }
            }
            if (alreadyExisting == null)
            {
                MyTreeNode<T> newChild = new MyTreeNode<T>(this, newContent);
                this.Children.Add(newChild);
                return newChild;
            }
            else return alreadyExisting;
        }

        public MyTreeNode<T> AddChild(MyTreeNode<T> newChild)
        {
            MyTreeNode<T> alreadyExisting = null;
            foreach (MyTreeNode<T> child in this.Children)
            {
                if (child.Equals(newChild))
                {
                    alreadyExisting = child;
                    break;
                }
            }
            if (alreadyExisting == null)
            {
                this.Children.Add(newChild);
                return newChild;
            }
            else return alreadyExisting;
        }

        public void Traverse(Action<T> action)
        {
            action(this.Content);
            foreach (MyTreeNode<T> child in this.Children)
            {
                child.Traverse(action);
            }
        }

        /// <summary>
        /// Ritorna null in caso di ricerca con esito negativo
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="func"></param>
        /// <param name="pred"></param>
        /// <returns></returns>
        public R Traverse<R>(Func<MyTreeNode<T>, R> func, Func<MyTreeNode<T>, bool> pred) where R : class
        {
            if (pred(this)) return func(this);
            else
            {
                foreach (MyTreeNode<T> child in this.Children)
                {
                    R childResult = child.Traverse(func, pred);
                    if (childResult != null) return childResult;
                }
                return null;
            };
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            else if (obj is MyTreeNode<T>)
            {
                MyTreeNode<T> that = obj as MyTreeNode<T>;
                return (this.Content.Equals(that.Content));
            }
            else return false;
        }

        public override string ToString()
        {
            return this.Content.ToString();
        }
    }
}
