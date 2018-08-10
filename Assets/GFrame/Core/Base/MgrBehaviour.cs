using System;
using System.Collections.Generic;
using System.Linq;

namespace GFrame
{
    public abstract class MgrBehaviour : BaseMonoBehaviour
    {
        private Dictionary<ushort, OnEvent> m_Events = new Dictionary<ushort, OnEvent>();

        public void RegisterEvent<T>(T msg_id, OnEvent fun) 
            where T : IConvertible
        {
            var kv = msg_id.ToUInt16(null);
            if (!m_Events.ContainsKey(kv))
            {
                m_Events.Add(kv, fun);
            }
            UIEventSystem.Instance.Register(msg_id, Process);
        }

        public void RegisterEvents<T>(List<T> msg_ids, OnEvent fun)
            where T : IConvertible
        {
            foreach (var msg_id in msg_ids)
            {
                RegisterEvent(msg_id, fun);
            }
        }

        public void UnRegisterEvent<T>(T msg_id, OnEvent fun)
            where T : IConvertible
        {
            m_Events.Remove(msg_id.ToUInt16(null));
            UIEventSystem.Instance.UnRegister(msg_id, Process);
        }

        public void UnRegisterEvents<T>(List<T> msg_ids, OnEvent fun)
           where T : IConvertible
        {
            foreach (var msg_id in msg_ids)
            {
                UnRegisterEvent(msg_id, fun);
            }
        }

        protected override void UnRegisterAllEvent()
        {
            UnRegisterEvents(m_Events.Keys.ToList(), Process);
            m_Events.Clear();
        }

        protected override void ProcessMessage(IMsg msg)
        {
            OnEvent call;
            if (m_Events.TryGetValue(msg.msg_id, out call))
            {
                call(msg);
            }
        }

        public void SendMsg<T>(T msg_id)
            where T : IConvertible
        {
            UIEventSystem.Instance.Send(new EventMsg(msg_id.ToUInt16(null)));
        }
        public void SendMsg<T, V>(T msg_id, V value)
            where T : IConvertible
        {
            UIEventSystem.Instance.Send(new EventMsgWithValue<V>(msg_id.ToUInt16(null), value));
        }
    }
}
