using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace HKX2
{
    // hkbIntVariableSequencedData Signatire: 0x7bfc518a size: 40 flags: FLAGS_NONE

    // samples class: hkbIntVariableSequencedDataSample Type.TYPE_ARRAY Type.TYPE_STRUCT arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    // variableIndex class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 32 flags: FLAGS_NONE enum: 
    public partial class hkbIntVariableSequencedData : hkbSequencedData, IEquatable<hkbIntVariableSequencedData?>
    {
        public IList<hkbIntVariableSequencedDataSample> samples { set; get; } = Array.Empty<hkbIntVariableSequencedDataSample>();
        public int variableIndex { set; get; }

        public override uint Signature { set; get; } = 0x7bfc518a;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            samples = des.ReadClassArray<hkbIntVariableSequencedDataSample>(br);
            variableIndex = br.ReadInt32();
            br.Position += 4;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteClassArray(bw, samples);
            bw.WriteInt32(variableIndex);
            bw.Position += 4;
        }

        public override void ReadXml(IXmlReader xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            samples = xd.ReadClassArray<hkbIntVariableSequencedDataSample>(xe, nameof(samples));
            variableIndex = xd.ReadInt32(xe, nameof(variableIndex));
        }

        public override void WriteXml(IXmlWriter xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteClassArray(xe, nameof(samples), samples);
            xs.WriteNumber(xe, nameof(variableIndex), variableIndex);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as hkbIntVariableSequencedData);
        }

        public bool Equals(hkbIntVariableSequencedData? other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   samples.SequenceEqual(other.samples) &&
                   variableIndex.Equals(other.variableIndex) &&
                   Signature == other.Signature; ;
        }

        public override int GetHashCode()
        {
            var hashcode = new HashCode();
            hashcode.Add(base.GetHashCode());
            hashcode.Add(samples.Aggregate(0, (x, y) => x ^ y?.GetHashCode() ?? 0));
            hashcode.Add(variableIndex);
            hashcode.Add(Signature);
            return hashcode.ToHashCode();
        }
    }
}

