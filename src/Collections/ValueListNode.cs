using System;
using System.Collections.Generic;

namespace Benadetta.Collections {

    [Serializable]
    public class ValueListNode<D> : ListNode, IComparable, IConvertible, IFormattable, IComparable<D>, IEquatable<D>
        where D : IComparable, IConvertible, IFormattable, IComparable<D>, IEquatable<D> {
            public ValueListNode (string name, Object data = null) : base (name, data) { }

            public override string ToString () {
                StringBuilder st = new StringBuilder (string.Format ("[{0}:{1}] ", Name, Entry));
                if (m_nodes[1] != null)
                    st.Append (string.Format ("Next: {0} ", m_nodes[1]));
                if (m_nodes[0] != null)
                    st.Append (string.Format ("Prev: {0} ", m_nodes[0]));

                return st.ToString ();
            }
            #region IComparable implementation
            public virtual int CompareTo (object obj) {
                return ((IComparable) Entry).CompareTo (obj);
            }
            #endregion       

            #region IConvertible implementation
            public virtual TypeCode GetTypeCode () {
                return ((IConvertible) Entry).GetTypeCode ();
            }

            public virtual bool ToBoolean (IFormatProvider provider) {
                return ((IConvertible) Entry).ToBoolean (provider);
            }

            public virtual byte ToByte (IFormatProvider provider) {
                return ((IConvertible) Entry).ToByte (provider);
            }

            public virtual char ToChar (IFormatProvider provider) {
                return ((IConvertible) Entry).ToChar (provider);
            }

            public virtual DateTime ToDateTime (IFormatProvider provider) {
                return ((IConvertible) Entry).ToDateTime (provider);
            }

            public virtual decimal ToDecimal (IFormatProvider provider) {
                return ((IConvertible) Entry).ToDecimal (provider);
            }

            public virtual double ToDouble (IFormatProvider provider) {
                return ((IConvertible) Entry).ToDouble (provider);
            }

            public virtual short ToInt16 (IFormatProvider provider) {
                return ((IConvertible) Entry).ToInt16 (provider);
            }

            public virtual int ToInt32 (IFormatProvider provider) {
                return ((IConvertible) Entry).ToInt32 (provider);
            }

            public virtual long ToInt64 (IFormatProvider provider) {
                return ((IConvertible) Entry).ToInt64 (provider);
            }

            public virtual sbyte ToSByte (IFormatProvider provider) {
                return ((IConvertible) Entry).ToSByte (provider);
            }

            public virtual float ToSingle (IFormatProvider provider) {
                return ((IConvertible) Entry).ToSingle (provider);
            }

            public virtual string ToString (IFormatProvider provider) {
                return ((IConvertible) Entry).ToString (provider);
            }

            public virtual object ToType (Type conversionType, IFormatProvider provider) {
                return ((IConvertible) Entry).ToType (conversionType, provider);
            }

            public virtual ushort ToUInt16 (IFormatProvider provider) {
                return ((IConvertible) Entry).ToUInt16 (provider);
            }

            public virtual uint ToUInt32 (IFormatProvider provider) {
                return ((IConvertible) Entry).ToUInt32 (provider);
            }

            public virtual ulong ToUInt64 (IFormatProvider provider) {
                return ((IConvertible) Entry).ToUInt64 (provider);
            }
            #endregion        

            #region IFormattable implementation
            public virtual string ToString (string format, IFormatProvider formatProvider) {
                return ((IFormattable) Entry).ToString (format, formatProvider);
            }
            #endregion  

            #region IComparable implementation
            public virtual int CompareTo (D other) {
                return ((IComparable<D>) Entry).CompareTo (other);
            }
            #endregion        
            #region IEquatable implementation
            public virtual bool Equals (D other) {
                return ((IEquatable<D>) Entry).Equals (other);
            }
            #endregion
        }

    [Serializable]
    public class ByteListNode : ValueListNode<byte> { public ByteListNode (string name, byte value) : base (name, value) { } }

    [Serializable]
    public class Int16ListNode : ValueListNode<short> { public Int16ListNode (string name, short value) : base (name, value) { } }

    [Serializable]
    public class Int32ListNode : ValueListNode<int> { public Int32ListNode (string name, int value) : base (name, value) { } }

    [Serializable]
    public class Int64ListNode : ValueListNode<long> { public Int64ListNode (string name, long value) : base (name, value) { } }

    [Serializable]
    public class SByteListNode : ValueListNode<sbyte> { public SByteListNode (string name, sbyte value) : base (name, value) { } }

    [Serializable]
    public class UInt16ListNode : ValueListNode<ushort> { public UInt16ListNode (string name, ushort value) : base (name, value) { } }

    [Serializable]
    public class UInt32ListNode : ValueListNode<uint> { public UInt32ListNode (string name, uint value) : base (name, value) { } }

    [Serializable]
    public class UInt64ListNode : ValueListNode<ulong> { public UInt64ListNode (string name, ulong value) : base (name, value) { } }

    [Serializable]
    public class DecimalListNode : ValueListNode<decimal> { public DecimalListNode (string name, decimal value) : base (name, value) { } }

    [Serializable]
    public class DoubleListNode : ValueListNode<double> { public DoubleListNode (string name, double value) : base (name, value) { } }

    [Serializable]
    public class SingleListNode : ValueListNode<float> { public SingleListNode (string name, float value) : base (name, value) { } }
}