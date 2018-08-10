using UnityEngine;

public static class ScreenShot
{
    /// <summary>
    /// 获取屏幕截图
    /// </summary>
    /// <param name="maxPixel">最大像素大小</param>
    /// <param name="quality">0:png  1-100:jpg</param>
    /// <returns></returns>
    public static byte[] GetScreenShot(int maxPixel, int quality)
    {
        int width = Screen.width;
        int height = Screen.height;


        int totalWH = width * height;
        //调整分辨率
        if (totalWH > maxPixel)
        {
            double rate = (double)maxPixel / totalWH;
            rate = System.Math.Sqrt(rate);

            width = (int)(width * rate);
            height = (int)(height * rate);
        }

        RenderTexture rt = new RenderTexture(width, height, 0);

        Camera.main.targetTexture = rt;
        Camera.main.Render();

        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D(width, height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(new Rect(0, 0, width, height), 0, 0);// 注：这个时候，它是从RenderTexture.active中读取像素  
        screenShot.Apply();

        Camera.main.targetTexture = null;
        RenderTexture.active = null;
        GameObject.Destroy(rt);

        byte[] retV = null;

        if (quality <= 0)
        {
            retV = screenShot.EncodeToPNG();
        }
        else if (quality >= 100)
        {
            retV = screenShot.EncodeToJPG(100);
        }
        else
        {
            retV = screenShot.EncodeToJPG(quality);
        }

        return retV;
    }
}
