using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace えいようちゃん
{
    /// <summary>
    /// ファイルのjsonシリアライズ・デシリアライズを行う
    /// </summary>
    static public class Json
    {
        /// <summary>
        /// MainFormのFileをJsonにシリアライズして出力
        /// </summary>
        /// <param name="path"></param>
        static public void ExportFile(string path)
        {
            if(MainForm.File==null)
            {
                throw new Exception("ファイルがありません");
            }

            var op = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            string jsonStr = JsonSerializer.Serialize(MainForm.File, op);

            try
            {
                using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
                using (var sw = new StreamWriter(stream))
                {
                    sw.Write(jsonStr);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// jsonファイルをファイルとして読み込む
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static public File InportFile(string path)
        {
            File rtn = new File();

            try
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (var sr = new StreamReader(stream))
                {
                    var jsonText = sr.ReadToEnd();
                    if (!jsonText.Contains("SetDishes"))//このアプリと無関係のJsonFileをはじく
                    {
                        throw new Exception("えいようちゃんのファイルではありません");
                    }
                    rtn = JsonSerializer.Deserialize<File>(jsonText);//エラー処理！
                }
            }
            catch
            {
                throw;
            }
            return rtn;
        }
    }
}
