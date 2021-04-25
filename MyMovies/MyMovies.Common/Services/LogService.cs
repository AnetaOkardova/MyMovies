using Microsoft.Extensions.Configuration;
using MyMovies.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyMovies.Common.Services
{
    public class LogService : ILogService
    {
        private readonly string _filePath;

        public LogService(IConfiguration configuration)
        {
            if(configuration["LogFilePath"] == null)
            {
                _filePath = "Logs.txt";
            }
            else
            {
                _filePath = configuration["LogFilePath"];
            }
            //same as:
            //_filePath = configuration["LogFilePath"] ?? "Logs.txt";
            //null check proverka
        }
        public void Log(LogData logData)
        {
            switch (logData.Type)
            {
                case LogType.Info:
                    File.AppendAllLines($"./Logs/Info_{_filePath}", new List<string>() { JsonConvert.SerializeObject(logData) });
                    break;
                case LogType.Warning:
                    File.AppendAllLines($"./Logs/Warning_{_filePath}", new List<string>() { JsonConvert.SerializeObject(logData) });
                    break;
                case LogType.Error:
                    File.AppendAllLines($"./Logs/Error_{DateTime.Now.ToString("yyyy_MM_dd")}_{_filePath}", new List<string>() { JsonConvert.SerializeObject(logData) });
                    break;
                default:
                    break;
            }
        }
    }
}
