﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using NLog;


namespace LoggerService
{
    public class LoggerManager: ILoggerManager
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();


        public LoggerManager()
        {
        }

        public void LogInfo(string message)=> _logger.Debug(message);
        public void LogWarning(string message) => _logger.Warn(message);
        public void LogDebug(string message) => _logger.Debug(message);
        public void LogError(string message)=> _logger.Error(message);



    }
}
