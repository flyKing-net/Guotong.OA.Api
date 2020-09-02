using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Guotong.Api.Common.Helper
{
    public class UploadImage
    {
        public static bool UploadFile(string fileName, string imageIO, string fileUrl)
        {
            string message = "";
            byte[] pFileContent = Convert.FromBase64String(imageIO);
            if (pFileContent.Length <= 0)
            {
                return false;
            }
            //string mFilePath =Server.MapPath(fileUrl);
            string mFilePath = Path.GetDirectoryName(fileUrl);
            if (!Directory.Exists(mFilePath))
            {
                Directory.CreateDirectory(mFilePath);
            }
            message = mFilePath;
            try
            {
                string mFileName = Path.Combine(mFilePath, fileName);
                using (FileStream mStream = File.Open(mFileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    mStream.Write(pFileContent, 0, pFileContent.Length);
                    mStream.Flush();
                    mStream.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
