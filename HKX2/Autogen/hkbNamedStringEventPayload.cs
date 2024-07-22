using System;
using System.Xml.Linq;

namespace HKX2
{
    // hkbNamedString@eventPayload Signatire: 0x6caa9113 size: 32 flags: FLAGS_NONE

    // data class:  Type.TYPE_STRINGPTR Type.TYPE_VOID arrSize: 0 offset: 24 flags: FLAGS_NONE enum: 
    public partial class hkbNamedString@eventPayload : hkbNamed@eventPayload, IEquatable<hkbNamedString@eventPayload?>
    {
        public string data { set; get; } = "";

        public override uint Signature { set; get; } = 0x6caa9113;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            data = des.ReadStringPointer(br);
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteStringPointer(bw, data);
        }

        public override void ReadXml(IXmlReader xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            data = xd.ReadString(xe, nameof(data));
        }

        public override void WriteXml(IXmlWriter xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteString(xe, nameof(data), data);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as hkbNamedString@eventPayload);
        }

        public bool Equals(hkbNamedString@eventPayload? other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   (data is null && other.data is null || data == other.data || data is null && other.data == "" || data == "" && other.data is null) &&
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

