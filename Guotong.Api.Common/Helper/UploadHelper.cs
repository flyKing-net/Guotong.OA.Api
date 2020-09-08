using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace Guotong.Api.Common.Helper
{
    public class UploadHelper
    {
        public static bool UploadFile(string fileName, string imageIO)
        {

            byte[] pFileContent = Convert.FromBase64String(imageIO);
            if (pFileContent.Length <= 0)return false;
            string mFilePath = "D://wwwroot//Api//wwwroot//upload//videoRecord//";
            if (!Directory.Exists(mFilePath))
            {
                Directory.CreateDirectory(mFilePath);
            }
            try
            {
                string mFileName = Path.Combine(mFilePath, fileName);
                using (FileStream mStream = new FileStream(mFileName,FileMode.CreateNew))
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
