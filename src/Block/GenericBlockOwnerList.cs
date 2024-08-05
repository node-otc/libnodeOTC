using System;
using System.IO;
using System.Collections.Generic;

namespace Benadetta.Block {
    [Serializable]
    public class GenericBlockOwnerListEntry {
        public Guid Owner { get; private set; }
        public double Date { get; private set; }
        public String Hash { get; private set; }
        public String LastHash { get; private set; }

        public String Name { get; internal set; }

        private static int index = 0;

        public GenericBlockOwnerListEntry(String baseHash, Guid owner, double date) {
            Owner = owner;
            Date = date;
            LastHash = "";
            Name = String.Format("TC:{0}:{1}", baseHash, index++);
            Hash = BlockUtils.GenSHA512(String.Format("{0}:{1}:{2}:{3}", owner, date, LastHash, Name));
        }
        public GenericBlockOwnerListEntry(String baseHash, Guid owner, double date, String preHash) {
            Owner = owner;
            Date = date;
            LastHash = preHash;
            Name = String.Format("TC:{0}:{1}", baseHash, index++);
            Hash = BlockUtils.GenSHA512(String.Format("{0}:{1}:{2}:{3}", owner, date, LastHash, Name));
        }
        public virtual string ToJson() {
            string frmt = "\t{";

            frmt += String.Format ("\n\t\"Name\": \"{0}\",", Name);
            frmt += String.Format ("\n\t\"Owner\": \"{0}\",\n\t\"TimeStamp\": \"{1}\",\n\t\"Hash\": \"{2}\",", 
                Owner, Date, Hash);

            frmt += String.Format ("\n\t\"LastHash\": \"{0}\"",  LastHash);
            frmt += "\n\t}";

            return frmt;
        }
    }

    [Serializable]
    public class GenericBlockOwnerList : ListNode<GenericBlockOwnerListEntry> {
        
        public GenericBlockOwnerList (string name, GenericBlockOwnerListEntry data) 
            : base (data.Name, data) { 
                
            }

        public void setNode(GenericBlockOwnerListEntry entry) {
            GenericBlockOwnerList node = new GenericBlockOwnerList(entry.Name, entry);

            setNode(node);
        }
        public override string ToString() {
            ListNode<GenericBlockOwnerListEntry> root = Root;
            StringBuilder builder = new StringBuilder();

            
            builder.AppendLine("[");
            do {
                builder.Append(root.Entry.ToJson());
                if(root.Next != null) builder.AppendLine(",");
                root = root.Next;
            } while (root != null);
            builder.AppendLine("]");
            
            return builder.ToString();
        }
        public override void OnSetNode (Node<GenericBlockOwnerListEntry, ListNode<GenericBlockOwnerListEntry>> node) { }
        public override ListNode<GenericBlockOwnerListEntry> removeNode (ListNode<GenericBlockOwnerListEntry> node, ref bool removed) { removed = false; return null; }
        public override bool Remove (GenericListEntry<GenericBlockOwnerListEntry> item) { return false; }
    }
}