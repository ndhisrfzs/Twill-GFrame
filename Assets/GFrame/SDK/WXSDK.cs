using System;
using UnityEngine;

namespace GFrame
{
    [MonoSingletonPath("Tools/WXSDK")]
    public class WXSDK : MonoSingleton<WXSDK>
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        static AndroidJavaClass JC;
#endif
        public static string AppID = "wx80b7f7e0e8f01445";
        public static Action<string> actionFunc;

        public void Init()
        {
            InitWXApi("WXSDK", "Callback");
        }

        public static bool InitWXApi(string u3dObject, string u3dCallback)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            string javaClass = Application.identifier + ".wxapi.WXSDKFunction";
            try
            {
                JC = new AndroidJavaClass(javaClass);

                return JC.CallStatic<bool>("InitWXApi", AppID, u3dObject, u3dCallback);
            }
            catch(System.Exception e)
            {

            }
#endif
            return false;
        }

        public static void ShareUrl(string url, string urlTitle, string urlDesc, byte[] thumbImage, WXShareType shareType, Action<string> action)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            try
            {
                actionFunc = action;
                JC.CallStatic("ShareUrl", url, urlTitle, urlDesc, thumbImage, (int)shareType);
            }
            catch (System.Exception e)
            {
                
            }
#endif
        }

        public static void ShareImage(byte[] imageData, byte[] thumbImageData, WXShareType shareType)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            try
            {
                JC.CallStatic("ShareImage", imageData, thumbImageData, (int)shareType);
            }
            catch (System.Exception e)
            {
            }
#endif
        }

        public void Callback(string value)
        {
            if (actionFunc != null)
            {
                actionFunc(value);
                actionFunc = null;
            }
        }
    }

    public enum WXShareType : int
    {
        /// <summary>
        /// 发送到聊天界面
        /// </summary>
        WXSceneSession = 0,

        /// <summary>
        /// 发送到朋友圈
        /// </summary>
        WXSceneTimeline = 1,

        /// <summary>
        /// 添加到微信收藏
        /// </summary>
        WXSceneFavorite = 2,
    }
}
