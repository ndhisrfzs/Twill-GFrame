namespace GFrame
{
    using UnityEngine;
    public abstract class BaseMonoBehaviour : MonoBehaviour
    {
        public bool alwaysShow = false;
        public void Process(IMsg msg)
        {
            if (gameObject.activeInHierarchy)
            {
                ProcessMessage(msg);
            }
        }
        protected virtual void ProcessMessage(IMsg msg) { }
        public void Show()
        {
            gameObject.SetActive(true);
            OnShow();
        }
        protected virtual void OnShow() { }

        public void Hide()
        {
            OnHide();
            if(!alwaysShow)
                gameObject.SetActive(false);
        }
        protected virtual void OnHide() { }

        protected virtual void OnDestroy()
        {
            OnBeforeDestory();
            if (!Application.isPlaying)
            {
                UnRegisterAllEvent();
            }
        }

        protected virtual void OnBeforeDestory() { }
        protected virtual void UnRegisterAllEvent() { }
    }
}
