using GN;
using System.Collections;
using System.Threading;
using UnityEngine;

namespace GFrame
{
    public class App : MonoBehaviour
    {
        //public TextAsset KP;
        public string version = "0.0.1";
        public string LoginIp = "127.0.0.1";
        public int LoginPort = 7777;
        IEnumerator Start()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            Config.Instance.Version = version;
            Config.Instance.LoginIp = LoginIp;
            Config.Instance.LoginPort = LoginPort;
            //Config.Instance.KeyWithLogin = CalcBytes.ConvertToUlongs(KP.bytes);
            //Config.Instance.KeyWithGame = CalcBytes.ConvertToUlongs2(KP.bytes);

            SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);

            Game.EventSystem.Add(DLLType.Model, typeof(App).Assembly);

            Game.Scene.AddComponent<OpcodeTypeComponent>();
            Game.Scene.AddComponent<MessageDispatherComponent, AppType>(AppType.Client);
            Game.Scene.AddComponent<NetClientComponent>();
            Game.Scene.AddComponent<SessionComponent>();

            SceneManager.Instance.OpenScene(Scene.Login);

            AudioManager.Instance.SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume", 0.8f));
            AudioManager.Instance.SetEffectVolume(PlayerPrefs.GetFloat("EffectVolume", 0.8f));
            AudioManager.Instance.PlayMusic("Sound/BACK_GROUND");

            WXSDK.Instance.Init();

            yield return null;
        }

        private void Update()
        {
            OneThreadSynchronizationContext.Instance.Update();
            Game.EventSystem.Update();
        }
    }
}
