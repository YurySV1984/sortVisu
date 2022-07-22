using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    public class TreeSort<T> : BaseClass<T> where T: IComparable<T> 
    {
        public TreeSort(int n) : base(n) { }
        public event EventHandler<int> OnSwop;
        public event EventHandler OnFinish;

        public void Sort()
        {
            var tree = new Tree<T>();
            foreach (var item in collection)
            {
                tree.Add(item);
            }
            collection = tree.Infix().ToArray();
            OnFinish?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Tree <T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; } 
        public void Add(T meaning)
        {
            if (Root == null)
            {
                Root = new Node<T>(meaning);
                Count = 1;
                return;
            }
            else
            {
                Root.Add(meaning);
                Count++;
            }
        }

        public List<T> Prefix(Node<T> node)
        {
            var result = new List<T>();
            if (node != null)
            {
                result.Add(node.Meaning);
                if (node.Left != null)
                {
                    result.AddRange(Prefix(node.Left));
                }

                if (node.Right != null)
                {
                    result.AddRange(Prefix(node.Right));
                }
            }
            return result;
        }

        public List<T> Infix(Node<T> node)
        {
            var result = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    result.AddRange(Infix(node.Left));
                }
                result.Add(node.Meaning);
                if (node.Right != null)
                {
                    result.AddRange(Infix(node.Right));
                }
            }
            return result;
        }

        public List<T> Postfix(Node<T> node)
        {
            var result = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    result.AddRange(Postfix(node.Left));
                }

                if (node.Right != null)
                {
                    result.AddRange(Postfix(node.Right));
                }
                result.Add(node.Meaning);
            }
            return result;
        }



        public List<T> Prefix()
        {
            var result = new List<T>();
            if (Root == null)
            {
                return result; 
            }
            result = Prefix(Root);
            return result;
        }
        public List<T> Infix()
        {
            var result = new List<T>();
            if (Root == null)
            {
                return result;
            }
            result = Infix(Root);
            return result;
        }
        public List<T> Postfix()
        {
            var result = new List<T>();
            if (Root == null)
            {
                return result;
            }
            result = Postfix(Root);
            return result;
        }

    }






    public class  Node <T> where T : IComparable<T>
    {
        public T Meaning { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node(T meaning)
        {
            Meaning = meaning;            
        }
        public Node(T meaning, Node<T> left, Node<T> right) : this(meaning)
        {
            Left = left;
            Right = right;
        }
        public void Add(T meaning)
        {
            var node = new Node<T>(meaning);
            if (node.Meaning.CompareTo(Meaning) < 0)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(meaning);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(meaning);
                }
            }
        }

        
    }
}
