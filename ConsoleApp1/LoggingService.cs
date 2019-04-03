using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LoggingService
    {

        List<string> log = new List<string>();
        private string _logFile = String.Empty;
        private int _currentRowIndex = -1;

        /// <summary>
        /// Soll einen Eintrag in die log.txt anhängen.
        /// </summary>
        /// <param name="tolog"></param>
        /// 

        public int FilePath { get; }

        public void Init()
        {

            var path = (string)Environment.GetEnvironmentVariables()["APPDATA"];
            var folder = Path.Combine(path, "myapp");
            Directory.CreateDirectory(folder);
            _logFile = Path.Combine(folder, "log.txt");

        }
        public void LogNew(string tolog)
        {

            log.Add(DateTime.Now.ToString() + ":" + tolog);
        
        /*    var path = (string)Environment.GetEnvironmentVariables()["APPDATA"];
            var folder = Path.Combine(path, "myapp");
            Directory.CreateDirectory(folder);
            var logfile = Path.Combine(folder, "log.txt");
            using (var sw = new StreamWriter(logfile, append))
            {
                sw.WriteLine(DateTime.Now.ToString() +":"+ tolog);
            }
        */
        }

        public void Log(string tolog)
        {            
            using (var sw = new StreamWriter(_logFile, append:true))
            {
                _currentRowIndex++;
                sw.WriteLine($"{_currentRowIndex} | {tolog}");
            }
            
        }

        public void Flush()
        {           
            using (var sw = new StreamWriter (_logFile, append:true))
            {
                foreach (var line in log)
                {
                    sw.WriteLine(DateTime.Now.ToString() + ":" + line);
                }
            }
        }

        public void DeleteLastLineFromCache(int numlines = 1)
        {
            if (log.Count >= numlines)
            {
                log.RemoveRange(log.Count - numlines, numlines);
            }
            
        }

        public void DeleteLineNew(int linenumber) { 
      
            var path = (string)Environment.GetEnvironmentVariables()["APPDATA"];
            var folder = Path.Combine(path, "myapp");
            Directory.CreateDirectory(folder);           
            var newlogfile = Path.Combine(folder, "log_new.txt");
            string line = String.Empty;
            if (!File.Exists(_logFile)) return;

            
            using (var sr = new StreamReader(_logFile))
            {
                using (var sw = new StreamWriter(newlogfile))
                {
                    var counter = 0;
                    while (!sr.EndOfStream)
                    {
                        counter++;
                        line = sr.ReadLine();
                        if (counter != linenumber)
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
           
            File.Copy(newlogfile, _logFile, true);
            File.Delete(newlogfile);
        }

        public void ClearLog()
        {
            if (File.Exists(_logFile))    
            File.Delete(_logFile);
        }

        public void DeleteLine(int rowIndex)
        {
            var list = new List<string>();
            using (var sr = new StreamReader(_logFile))
            {
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                }

                for (int i=0;i<list.Count;i++)
                {
                    var isLineToDelete = list[i].StartsWith(rowIndex.ToString());
                    if (isLineToDelete)
                    {
                        list.RemoveAt(i);
                        break;
                    }
                }
            }

            using (var sw = new StreamWriter(_logFile))
            {
                foreach(var line in list)
                {
                    sw.WriteLine(line);
                }
            }
        }

    }
}
