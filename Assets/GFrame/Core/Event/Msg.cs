using System;

namespace GFrame
{
    public interface IMsg
    {
        ushort msg_id { get; set; }
    }

    public class EventMsg : IMsg
    {
        public ushort msg_id { get; set; }
        public EventMsg() { }
        public EventMsg(ushort msg_id)
        {
            this.msg_id = msg_id;
        }
    }

    public class EventMsgWithValue<T> : EventMsg
    {
        public T value;
        public EventMsgWithValue(ushort msg_id, T value) 
            : base(msg_id)
        {
            this.value = value;
        }
    }
}
