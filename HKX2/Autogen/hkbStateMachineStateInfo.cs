using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace HKX2
{
    // hkbStateMachineStateInfo Signatire: 0xed7f9d0 size: 120 flags: FLAGS_NONE

    // listeners class: hkbStateListener Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 48 flags: FLAGS_NONE enum: 
    // enterNotify@events class: hkbStateMachine@eventPropertyArray Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 64 flags: FLAGS_NONE enum: 
    // exitNotify@events class: hkbStateMachine@eventPropertyArray Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 72 flags: FLAGS_NONE enum: 
    // transitions class: hkbStateMachineTransitionInfoArray Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 80 flags: FLAGS_NONE enum: 
    // generator class: hkbGenerator Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 88 flags: FLAGS_NONE enum: 
    // name class:  Type.TYPE_STRINGPTR Type.TYPE_VOID arrSize: 0 offset: 96 flags: FLAGS_NONE enum: 
    // stateId class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 104 flags: FLAGS_NONE enum: 
    // probability class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 108 flags: FLAGS_NONE enum: 
    // enable class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 112 flags: FLAGS_NONE enum: 
    public partial class hkbStateMachineStateInfo : hkbBindable, IEquatable<hkbStateMachineStateInfo?>
    {
        public IList<hkbStateListener> listeners { set; get; } = Array.Empty<hkbStateListener>();
        public hkbStateMachine@eventPropertyArray? enterNotify@events { set; get; }
        public hkbStateMachine@eventPropertyArray? exitNotify@events { set; get; }
        public hkbStateMachineTransitionInfoArray? transitions { set; get; }
        public hkbGenerator? generator { set; get; }
        public string name { set; get; } = "";
        public int stateId { set; get; }
        public float probability { set; get; }
        public bool enable { set; get; }

        public override uint Signature { set; get; } = 0xed7f9d0;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            listeners = des.ReadClassPointerArray<hkbStateListener>(br);
            enterNotify@events = des.ReadClassPointer<hkbStateMachine@eventPropertyArray>(br);
            exitNotify@events = des.ReadClassPointer<hkbStateMachine@eventPropertyArray>(br);
            transitions = des.ReadClassPointer<hkbStateMachineTransitionInfoArray>(br);
            generator = des.ReadClassPointer<hkbGenerator>(br);
            name = des.ReadStringPointer(br);
            stateId = br.ReadInt32();
            probability = br.ReadSingle();
            enable = br.ReadBoolean();
            br.Position += 7;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteClassPointerArray(bw, listeners);
            s.WriteClassPointer(bw, enterNotify@events);
            s.WriteClassPointer(bw, exitNotify@events);
            s.WriteClassPointer(bw, transitions);
            s.WriteClassPointer(bw, generator);
            s.WriteStringPointer(bw, name);
            bw.WriteInt32(stateId);
            bw.WriteSingle(probability);
            bw.WriteBoolean(enable);
            bw.Position += 7;
        }

        public override void ReadXml(IXmlReader xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            listeners = xd.ReadClassPointerArray<hkbStateListener>(xe, nameof(listeners));
            enterNotify@events = xd.ReadClassPointer<hkbStateMachine@eventPropertyArray>(xe, nameof(enterNotify@events));
            exitNotify@events = xd.ReadClassPointer<hkbStateMachine@eventPropertyArray>(xe, nameof(exitNotify@events));
            transitions = xd.ReadClassPointer<hkbStateMachineTransitionInfoArray>(xe, nameof(transitions));
            generator = xd.ReadClassPointer<hkbGenerator>(xe, nameof(generator));
            name = xd.ReadString(xe, nameof(name));
            stateId = xd.ReadInt32(xe, nameof(stateId));
            probability = xd.ReadSingle(xe, nameof(probability));
            enable = xd.ReadBoolean(xe, nameof(enable));
        }

        public override void WriteXml(IXmlWriter xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteClassPointerArray(xe, nameof(listeners), listeners);
            xs.WriteClassPointer(xe, nameof(enterNotify@events), enterNotify@events);
            xs.WriteClassPointer(xe, nameof(exitNotify@events), exitNotify@events);
            xs.WriteClassPointer(xe, nameof(transitions), transitions);
            xs.WriteClassPointer(xe, nameof(generator), generator);
            xs.WriteString(xe, nameof(name), name);
            xs.WriteNumber(xe, nameof(stateId), stateId);
            xs.WriteFloat(xe, nameof(probability), probability);
            xs.WriteBoolean(xe, nameof(enable), enable);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as hkbStateMachineStateInfo);
        }

        public bool Equals(hkbStateMachineStateInfo? other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   listeners.SequenceEqual(other.listeners) &&
                   ((enterNotify@events is null && other.enterNotify@events is null) || (enterNotify@events is not null && other.enterNotify@events is not null && enterNotify@events.Equals((IHavokObject)other.enterNotify@events))) &&
                   ((exitNotify@events is null && other.exitNotify@events is null) || (exitNotify@events is not null && other.exitNotify@events is not null && exitNotify@events.Equals((IHavokObject)other.exitNotify@events))) &&
                   ((transitions is null && other.transitions is null) || (transitions is not null && other.transitions is not null && transitions.Equals((IHavokObject)other.transitions))) &&
                   ((generator is null && other.generator is null) || (generator is not null && other.generator is not null && generator.Equals((IHavokObject)other.generator))) &&
                   (name is null && other.name is null || name == other.name || name is null && other.name == "" || name == "" && other.name is null) &&
                   stateId.Equals(other.stateId) &&
                   probability.Equals(other.probability) &&
                   enable.Equals(other.enable) &&
                   Signature == other.Signature; ;
        }

        public override int GetHashCode()
        {
            var hashcode = new HashCode();
            hashcode.Add(base.GetHashCode());
            hashcode.Add(listeners.Aggregate(0, (x, y) => x ^ y?.GetHashCode() ?? 0));
            hashcode.Add(enterNotify@events);
            hashcode.Add(exitNotify@events);
            hashcode.Add(transitions);
            hashcode.Add(generator);
            hashcode.Add(name);
            hashcode.Add(stateId);
            hashcode.Add(probability);
            hashcode.Add(enable);
            hashcode.Add(Signature);
            return hashcode.ToHashCode();
        }
    }
}

