using System;
using System.Xml.Linq;

namespace HKX2
{
    // hkpHingeLimitsDataAtoms Signatire: 0x555876ff size: 144 flags: FLAGS_NONE

    // rotations class: hkpSetLocalRotationsConstraintAtom Type.TYPE_STRUCT Type.TYPE_VOID arrSize: 0 offset: 0 flags: FLAGS_NONE enum: 
    // angLimit class: hkpAngLimitConstraintAtom Type.TYPE_STRUCT Type.TYPE_VOID arrSize: 0 offset: 112 flags: FLAGS_NONE enum: 
    // 2dAng class: hkp2dAngConstraintAtom Type.TYPE_STRUCT Type.TYPE_VOID arrSize: 0 offset: 128 flags: FLAGS_NONE enum: 
    public partial class hkpHingeLimitsDataAtoms : IHavokObject, IEquatable<hkpHingeLimitsDataAtoms?>
    {
        public hkpSetLocalRotationsConstraintAtom rotations { set; get; } = new();
        public hkpAngLimitConstraintAtom angLimit { set; get; } = new();
        public hkp2dAngConstraintAtom 2dAng { set; get; } = new();

        public virtual uint Signature { set; get; } = 0x555876ff;

        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            rotations.Read(des, br);
            angLimit.Read(des, br);
            2dAng.Read(des, br);
            br.Position += 12;
        }

        public virtual void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            rotations.Write(s, bw);
            angLimit.Write(s, bw);
            2dAng.Write(s, bw);
            bw.Position += 12;
        }

        public virtual void ReadXml(IXmlReader xd, XElement xe)
        {
            rotations = xd.ReadClass<hkpSetLocalRotationsConstraintAtom>(xe, nameof(rotations));
            angLimit = xd.ReadClass<hkpAngLimitConstraintAtom>(xe, nameof(angLimit));
            2dAng = xd.ReadClass<hkp2dAngConstraintAtom>(xe, nameof(2dAng));
        }

        public virtual void WriteXml(IXmlWriter xs, XElement xe)
        {
            xs.WriteClass<hkpSetLocalRotationsConstraintAtom>(xe, nameof(rotations), rotations);
            xs.WriteClass<hkpAngLimitConstraintAtom>(xe, nameof(angLimit), angLimit);
            xs.WriteClass<hkp2dAngConstraintAtom>(xe, nameof(2dAng), 2dAng);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as hkpHingeLimitsDataAtoms);
        }

        public bool Equals(hkpHingeLimitsDataAtoms? other)
        {
            return other is not null &&
                   ((rotations is null && other.rotations is null) || (rotations is not null && other.rotations is not null && rotations.Equals((IHavokObject)other.rotations))) &&
                   ((angLimit is null && other.angLimit is null) || (angLimit is not null && other.angLimit is not null && angLimit.Equals((IHavokObject)other.angLimit))) &&
                   ((2dAng is null && other.2dAng is null) || (2dAng is not null && other.2dAng is not null && 2dAng.Equals((IHavokObject)other.2dAng))) &&
                   Signature == other.Signature; ;
        }

        public override int GetHashCode()
        {
            var hashcode = new HashCode();
            hashcode.Add(rotations);
            hashcode.Add(angLimit);
            hashcode.Add(2dAng);
            hashcode.Add(Signature);
            return hashcode.ToHashCode();
        }
    }
}

