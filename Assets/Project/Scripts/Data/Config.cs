namespace GFrame
{
    public class Config : Singleton<Config>
    {
        private Config() { }

        public short GameID = 1;
        public ulong[] KeyWithLogin;
        public ulong[] KeyWithGame;
        public string Version;
        public string LoginIp;
        public int LoginPort;
    }
}
