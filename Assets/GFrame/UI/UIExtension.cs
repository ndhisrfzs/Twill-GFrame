namespace GFrame
{
    public static class UIExtension
    {
        public static T OpenUI<T>(this UILevel level)
            where T : UIBehaviour
        {
            return UIManager.Instance.OpenUI<T>(level);
        }
    }
}
