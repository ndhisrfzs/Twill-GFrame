﻿using System.Collections.Generic;
using System.IO;

namespace GFrame
{
    public class IOUtil 
    {
        /// <summary>
		/// 创建新的文件夹,如果存在则不创建
		/// </summary>
		public static string CreateDirIfNotExists(string dirFullPath)
        {
            if (!Directory.Exists(dirFullPath))
            {
                Directory.CreateDirectory(dirFullPath);
            }
            return dirFullPath;
        }

        /// <summary>
        /// 删除文件夹，如果存在
        /// </summary>
        public static void DeleteDirIfExists(string dirFullPath)
        {
            if (Directory.Exists(dirFullPath))
            {
                Directory.Delete(dirFullPath, true);
            }
        }

        public static List<string> GetDirSubFilePathList(string dirABSPath, bool isRecursive = true, string suffix = "")
        {
            List<string> pathList = new List<string>();
            DirectoryInfo di = new DirectoryInfo(dirABSPath);

            if (!di.Exists)
            {
                return pathList;
            }

            FileInfo[] files = di.GetFiles();
            foreach (FileInfo fi in files)
            {
                if (!string.IsNullOrEmpty(suffix))
                {
                    if (!fi.FullName.EndsWith(suffix, System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }
                }
                pathList.Add(fi.FullName);
            }

            if (isRecursive)
            {
                DirectoryInfo[] dirs = di.GetDirectories();
                foreach (DirectoryInfo d in dirs)
                {
                    pathList.AddRange(GetDirSubFilePathList(d.FullName, isRecursive, suffix));
                }
            }

            return pathList;
        }

        public static List<string> GetDirSubDirNameList(string dirABSPath)
        {
            List<string> nameList = new List<string>();
            DirectoryInfo di = new DirectoryInfo(dirABSPath);

            DirectoryInfo[] dirs = di.GetDirectories();
            foreach (DirectoryInfo d in dirs)
            {
                nameList.Add(d.Name);
            }

            return nameList;
        }

        public static string GetFileName(string absOrAssetsPath)
        {
            string name = absOrAssetsPath.Replace("\\", "/");
            int lastIndex = name.LastIndexOf("/");

            if (lastIndex >= 0)
            {
                return name.Substring(lastIndex + 1);
            }
            else
            {
                return name;
            }
        }

        public static string GetFileNameWithoutExtend(string absOrAssetsPath)
        {
            string fileName = GetFileName(absOrAssetsPath);
            int lastIndex = fileName.LastIndexOf(".");

            if (lastIndex >= 0)
            {
                return fileName.Substring(0, lastIndex);
            }
            else
            {
                return fileName;
            }
        }

        public static string GetFileExtendName(string absOrAssetsPath)
        {
            int lastIndex = absOrAssetsPath.LastIndexOf(".");

            if (lastIndex >= 0)
            {
                return absOrAssetsPath.Substring(lastIndex);
            }

            return string.Empty;
        }

        public static string GetDirPath(string absOrAssetsPath)
        {
            string name = absOrAssetsPath.Replace("\\", "/");
            int lastIndex = name.LastIndexOf("/");
            return name.Substring(0, lastIndex + 1);
        }

        public static string GetResourcePath(string absOrAssetsPath)
        {
            string name = absOrAssetsPath.Replace("\\", "/");
            int index = name.IndexOf("Resources/");
            if(index <= -1)
            {
                throw new System.Exception("Not A Resources Folder");
            }
            else
            {
                name = name.Substring(index + 10);
            }
            int lastIndex = name.LastIndexOf(".");
            if (lastIndex >= 0)
            {
                return name.Substring(0, lastIndex);
            }

            return name;
        }
    }
}
