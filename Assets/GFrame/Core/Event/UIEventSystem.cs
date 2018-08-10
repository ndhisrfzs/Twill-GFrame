using System;
using System.Collections.Generic;

namespace GFrame
{
    public delegate void OnEvent(IMsg msg);
    public class UIEventSystem : Singleton<UIEventSystem>
    {
        private UIEventSystem() { }
        private Dictionary<ushort, ListenerWarp> m_listeners = new Dictionary<ushort, ListenerWarp>();

        public class ListenerWarp
        {
            private LinkedList<OnEvent> m_Events;
            public bool Execute(IMsg msg)
            {
                if(m_Events == null)
                {
                    return false;
                }

                LinkedListNode<OnEvent> next = m_Events.First;
                OnEvent call = null;
                while(next != null)
                {
                    call = next.Value;
                    call(msg);

                    next = next.Next;
                }
                return true;
            }

            public bool Add(OnEvent listener)
            {
                if(m_Events == null)
                {
                    m_Events = new LinkedList<OnEvent>();
                }

                if (m_Events.Contains(listener))
                {
                    return false;
                }

                m_Events.AddLast(listener);
                return true;
            }

            public void Remove(OnEvent listener)
            {
                if(m_Events == null)
                {
                    return;
                }

                m_Events.Remove(listener);
            }
        }

        public bool Register<T>(T msg_id, OnEvent fun)
            where T : IConvertible
        {
            ushort kv = msg_id.ToUInt16(null);
            ListenerWarp warp;
            if(!m_listeners.TryGetValue(kv, out warp))
            {
                warp = new ListenerWarp();
                m_listeners.Add(kv, warp);
            }

            if (warp.Add(fun))
            {
                return true;
            }

            return false;
        }

        public void UnRegister<T>(T msg_id, OnEvent fun) 
            where T : IConvertible
        {
            ListenerWarp warp;
            if(m_listeners.TryGetValue(msg_id.ToUInt16(null), out warp))
            {
                warp.Remove(fun);
            }
        }

        public bool Send(IMsg msg)
        {
            ListenerWarp warp;
            if(m_listeners.TryGetValue(msg.msg_id, out warp))
            {
                return warp.Execute(msg);
            }

            return false;
        }
    }
}
