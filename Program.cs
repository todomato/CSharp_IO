using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
    

namespace CSharp_IO
{
    class Program
    {
        static void Main(string[] args)
        {

            //取得Bin資料夾
            var bin = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Replace("file:///", "");
            var path = Path.Combine(Path.GetDirectoryName(bin),"Demo");
            //判斷資料夾位置
            if (!Directory.Exists(path))
            {
                //建立資料夾
                Directory.CreateDirectory(path);
            }

            #region 文件相關
            Console.WriteLine(Path.GetDirectoryName(path));     //取得資料夾稱, D:\TestDir
            Console.WriteLine(Path.Combine(new string[] { @"D:\", "BaseDir", "SubDir", "TestFile.txt" })); //產生路徑
            #endregion

            //判斷檔案位置
            var filename = "test.txt";

            //結合路徑
            var filePath = Path.Combine(path, filename);

            //判斷資料夾位置
            if (!File.Exists(filePath))
            {
                //建立檔案
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    AddText(fs, "This is some text");
                    AddText(fs, "This is some more text,");
                    AddText(fs, "\r\nand this is on a new line");
                    AddText(fs, "\r\n\r\nThe following is a subset of characters:\r\n");
                }
            }

            #region 檔案相關
            Console.WriteLine(Path.GetFileName(path));          //取得檔名 TestFile.txt
            Console.WriteLine(Path.GetFileNameWithoutExtension(path)); //檔案無副檔名 TestFile
            Console.WriteLine(Path.GetFullPath(path));          //全部路徑 D:\TestDir\TestFile.txt
            Console.WriteLine(Path.GetPathRoot(path));           //取得跟目錄
            Console.WriteLine(Path.ChangeExtension(path, ".jpg"));//改變副檔名 D:\TestDir\TestFile.jpg
            #endregion

            #region 目錄讀取資料相關
            Console.WriteLine(Directory.GetFiles(path));
            Console.WriteLine(Directory.GetFiles(path, "*.pdf")); //指搜尋.pdf副檔名
            Console.WriteLine(Directory.GetFiles(path, "*.pdf", SearchOption.AllDirectories)); //指搜尋.pdf副檔名,含子資料夾
            #endregion

            //刪除檔案
            File.Delete(filePath);
            Directory.Delete(path);
        }

        //寫入檔案
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }   
}
