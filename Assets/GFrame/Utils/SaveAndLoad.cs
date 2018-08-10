/* 创建者: 王弈博
 * 用途: 用于U3D的数据保存和读取
 * 设计思想: 
 * 遗留问题:
 * 使用注意:
 * 版本号:
*/


namespace GFrame
{
    using System.IO;


    /// <summary>
    /// 读取或者保存文件
    /// </summary>
    public static class SaveAndLoad
    {

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="data">数据</param>
        public static void SaveData(this string fileName, byte[] data)
        {
            //string fileFullName = FilePath + fileName;
            string path = fileName.Substring(0, fileName.LastIndexOf('/'));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                fs.Write(data, 0, data.Length);
                fs.Flush();
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="data">数据</param>
        /// <param name="len">保存长度</param>
        public static void SaveData(this string fileName, byte[] data, int len)
        {
            //string fileFullName = FilePath + fileName;
            string path = fileName.Substring(0, fileName.LastIndexOf('/'));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                fs.Write(data, 0, len);
                fs.Flush();
            }
        }



        public static void SaveObject(this string fileName, object obj)
        {
            byte[] objBytes = null;
            int len = GN.Serialization.SerializeTo(obj, ref objBytes, 0);

            SaveData(fileName, objBytes, len);
        }


        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>数据，如果文件不存在，返回Null</returns>
        public static byte[] LoadData(this string fileName)
        {
            //string fileFullName = FilePath + fileName ;

            if (!File.Exists(fileName))
            {
                return null;
            }
            //ResourcesX.Load("XML/" + fileName) as FileStream;
            //using (FileStream fs = new FileStream(fileFullName, FileMode.Open, FileAccess.Read))
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                int byteLength = (int)fs.Length;
                byte[] bytes = new byte[byteLength];
                fs.Read(bytes, 0, byteLength);

                //string xmlString = System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                return bytes;
            }
        }


        public static bool LoadObject<T>(this string fileName, out T obj)
        {
            byte[] fileData = LoadData(fileName);

            if (fileData == null)
            {
                obj = default(T);
                return false;
            }
            else
            {
                try
                {
                    int readLen = 0;
                    obj = GN.Serialization.DeserializeFrom<T>(fileData, 0, out readLen);
                    return true;
                }
                catch
                {
                    obj = default(T);
                    return false;
                }
            }
        }


        public static string[] Exists(string path)
        {
            if (Directory.Exists(path))
            {
                return Directory.GetFiles(path);
            }
            return null;
        }

        public static void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch
                { }
            }
        }

        public static void DeletePath(string filePath)
        {
            if (Directory.Exists(filePath))
            {
                Directory.Delete(filePath, true);
            }
        }


        public static bool TryDeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);

                    return true;
                }
                catch
                { }
            }

            return false;
        }
    }
}