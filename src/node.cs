using System;
using System.Collections.Generic;

namespace Benadetta {
    [Serializable]
    public enum TraversOrder {
        Preorder,
        Inorder,
        Postorder,
        ListOrder,
        ReservListOrder
    }

    [Serializable]
    public abstract class Node<T, D> 
    //where T : class
    {
        public delegate void funcTravers (D node);

        protected D[]? m_nodes;

        public string? Name {
            get;
            set;
        }
        public T? Entry {
            get;
            set;
        }
        internal Node () { 

        }

        protected Node (string name, int nodes) {
            Name = name;
            m_nodes = new D[nodes];
        }
        protected Node (string name, T data, int nodes) {
            Name = name;
            Entry = data;
            m_nodes = new D[nodes];
        }

        public abstract D Root { get; protected set; }

        public abstract D getNode (string name);
        public abstract D setNode (D node);
        public abstract D removeNode (D node, ref bool removed);
        public abstract D removeNode (string name, ref bool removed);

        public abstract void Travers (TraversOrder order, D Root);
        public abstract void Travers (TraversOrder order, funcTravers travers, D Root);
        public abstract List<T> ToList ();

        public override string ToString () {
            return string.Format ("[Node: Name={0}, Data={1}, Root={2}]", Name, Entry, Root);
        }
  
        //protected abstract D setParent(D node);
        public virtual void OnSetNode (Node<T, D> node) { }
        public virtual void OnRemoveNode (Node<T, D> node) { }
    }

}