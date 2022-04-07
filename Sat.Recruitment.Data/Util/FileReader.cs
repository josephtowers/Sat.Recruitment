using System.IO;

namespace Sat.Recruitment.Data.Util
{
    public static class FileReader
    {
        public static StreamReader ReadFile(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
    }
}
