using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PMLAB_TestProject.Services
{
    public class HistoryService
    {
        string path;
        public HistoryService(string filepath = "History/history.txt") // for testing
        {
            path = filepath;
        }
        public async Task<bool> Append(string newLine)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                {
                    await sw.WriteLineAsync(newLine);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }        
        }
        public async Task<string> Search(string request)
        {
            try
            {
                StringBuilder result = new StringBuilder();
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    string line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        if (line.Contains(request))
                            result.AppendLine(line);
                    }
                }
                return result.ToString().Trim();                
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public async Task<string> GetAll()
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    return (await sr.ReadToEndAsync()).Trim();
                }
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        public async Task<bool> Clear()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
                {
                    await sw.WriteAsync(string.Empty);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
