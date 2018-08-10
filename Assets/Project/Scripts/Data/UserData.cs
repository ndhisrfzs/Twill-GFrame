using Logic;
using System;

namespace GFrame
{
    public class UserData: Singleton<UserData>
    {
        public Twill_User user;
        public DateTime server_time { get { return DateTime.Now + time_span; } }
        private TimeSpan time_span;
        private UserData() { }
        public void CorrectTime(DateTime server_time)
        {
            time_span = server_time - DateTime.Now;
        }
    }
}