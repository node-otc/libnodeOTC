using System;
using System.Collections.Generic;

namespace Benadetta.Collections {

    [Serializable]
    public class GenericListEntry<T> {
        public string Name { get; set; }
        public T RawEntry { get; set; }

        public GenericListEntry (ListNode<T> root) : this (root.Name, root.Entry) { }
        public GenericListEntry (string name, T data) {
            Name = name;
            RawEntry = data;
        }

        public static implicit operator GenericListEntry<T> (ListNode<T> node) {
            return new GenericListEntry<T> (node.Name, node.Entry);
        }

    }

    public class ListNode<T> : Node<T, ListNode<T>>, IEnumerable<T>, IList<GenericListEntry<T>> {
        //[NoSerializable]
        public override ListNode<T> Root {
            get {
                if (Prev == null)
                    return this;
                else
                    return Prev.Root;
            }
            protected set {
                Prev = value;
            }
        }
        public ListNode<T> Last {
            get {
                if (Next == null)
                    return this;
                else
                    return Next.Last;
            }
        }
        public GenericListEntry<T> this [int index] {
            get {
                ListNode<T> root = Root;

                do {
                    if (root.Index == index)
                        return new GenericListEntry<T> (root);

                    root = root.Next;
                } while (root != null);
                return null;
            }
            set {
                ListNode<T> root = Root;
                if (root.Index == index)
                    root.Entry = value.RawEntry;

                do {
                    if (root.Index == index)
                        root.Entry = value.RawEntry;

                    root = root.Next;
                } while (root != null);
            }
        }
        public int Count {
            get {
                ListNode<T> root = this;
                int count = 0;

                do {
                    count++;

                    root = root.Next;
                } while (root != null);
                return count;
            }
        }
        public int Index {
            get {
                ListNode<T> root = Root;
                if (root.Name == Name)
                    return 0;

                int index = 0;

                do {
                    index++;

                    if (root.Name == Name)
                        return index;

                    root = root.Next;
                } while (root != null);
                return -1;
            }
        }
        public bool IsReadOnly {
            get {
                return false;
            }
        }
        public ListNode<T> Next {
            get { return m_nodes[1]; }
            set { m_nodes[1] = value; }
        }
        public ListNode<T> Prev {
            get { return m_nodes[0]; }
            set { m_nodes[0] = value; }
        }

        public ListNode (string name) : base (name, 2) { }
        public ListNode (string name, T data) : base (name, data, 2) {

        }
        public override ListNode<T> getNode (string name) {
            if (this.Name == name)
                return this;

            if (Next != null)
                return Next.getNode (name);
            if (Prev != null)
                return Prev.getNode (name);

            return null;
        }
        public override void OnSetNode (Node<T, ListNode<T>> node) {
            Console.WriteLine ("[{0}] Set Node Next: {1}", Entry, Next.Entry);
        }
        public override ListNode<T> setNode (ListNode<T> node) {
            if (Next == null) {
                node.Prev = this;
                Next = node;
                OnSetNode (node);
            } else {
                Next.setNode (node);
            }
            return this;
        }

        public override ListNode<T> removeNode (ListNode<T> node, ref bool removed) {
            removed = false;

            if (node == null)
                return this;

            if (node.Prev != null && node.Next != null) {
                node.Prev = node.Next;
                removed = true;
            } else if (node.Prev != null && node.Next == null) {
                node.Prev.Next = null;
                removed = true;
            } else if (node.Prev == null && node.Next != null) {
                node.Next.Prev = null;
                removed = true;
            }
            if (removed) OnRemoveNode (node);

            return this;
        }

        public override ListNode<T> removeNode (string name, ref bool removed) {
            return removeNode (getNode (name), ref removed);
        }

        public override void Travers (TraversOrder order, ListNode<T> Root) {
            if (Root != null && order == TraversOrder.ListOrder) {
                Console.Write (Root.Entry + " ");
                Travers (order, Root.Next);
            }
        }

        public override void Travers (TraversOrder order, funcTravers travers, ListNode<T> root) {
            if (root != null && order == TraversOrder.ListOrder) {
                travers (root.Next);
                Travers (order, travers, root.Next);
            }
            if (root != null && order == TraversOrder.ReservListOrder) {
                travers (root.Next);
                Travers (order, travers, root.Prev);
            }
        }
        public override List<T> ToList () {
            ListNode<T> root = Root;
            List<T> list = new List<T> ();

            do {
                list.Add (root.Entry);

                root = root.Next;
            } while (root != null);

            return list;
        }

        #region IEnumerable implementation
        public System.Collections.IEnumerator GetEnumerator () {
            return GetEnumerator ();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator () {
            ListNode<T> root = Root;

            do {
                yield return root.Entry;

                root = root.Next;
            } while (root != null);
        }
        #endregion

        #region ICollection implementation
        public void Add (GenericListEntry<T> item) {
            setNode (new ListNode<T> (item.Name, item.RawEntry));
        }

        public void Clear () {
            this.Dispose (true);
        }

        public bool Contains (GenericListEntry<T> item) {
            return getNode (item.Name) != null;
        }

        public void CopyTo (GenericListEntry<T>[] array, int arrayIndex) {
            throw new System.NotImplementedException ();
        }

        public virtual bool Remove (GenericListEntry<T> item) {
            if (getNode (item.Name) == null)
                return false;

            bool removed = false;
            removeNode (item.Name, ref removed);
            return removed;
        }

        #endregion

        #region IList implementation
        public int IndexOf (GenericListEntry<T> item) {
            throw new System.NotImplementedException ();
        }

        public void Insert (int index, GenericListEntry<T> item) {
            throw new System.NotImplementedException ();
        }

        public void RemoveAt (int index) {
            throw new System.NotImplementedException ();
        }

        #endregion        

        IEnumerator<GenericListEntry<T>> IEnumerable<GenericListEntry<T>>.GetEnumerator () {
            ListNode<T> root = Root;

            do {
                yield return new GenericListEntry<T> (root.Name, root.Entry);

                root = root.Next;
            } while (root != null);
        }

        protected override void Dispose (bool disposing) {
            base.Dispose (disposing);

            if (disposing) {
                if (Next != null)
                    Next.Dispose (disposing);
            }
        }

    }
    public class ListNode : ListNode<Object> {
        public ListNode (string name, Object data) : base (name, data) { }

    }
}