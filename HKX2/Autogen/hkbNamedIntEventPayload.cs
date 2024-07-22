using System;
using System.Xml.Linq;

namespace HKX2
{
    // hkbNamedInt@eventPayload Signatire: 0x3c99bda4 size: 32 flags: FLAGS_NONE

    // data class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 24 flags: FLAGS_NONE enum: 
    public partial class hkbNamedInt@eventPayload : hkbNamed@eventPayload, IEquatable<hkbNamedInt@eventPayload?>
    {
        public int data { set; get; }

        public override uint Signature { set; get; } = 0x3c99bda4;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            data = br.ReadInt32();
            br.Position += 4;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.WriteInt32(data);
            bw.Position += 4;
        }

        public override void ReadXml(IXmlReader xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            data = xd.ReadInt32(xe, nameof(data));
        }

        public override void WriteXml(IXmlWriter xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteNumber(xe, nameof(data), data);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as hkbNamedInt@eventPayload);
        }

        public bool Equals(hkbNamedInt@eventPayload? other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   data.Equals(other.data) &&
                   Signature == other.Signature; ;
        }

        public override int GetHashCode()
        {
            var hashcode = new HashCode();
            hashcode.Add(base.GetHashCode());
            hashcode.Add(data);
            hashcode.Add(Signature);
            return hashcode.ToHashCode();
        }
    }
}

