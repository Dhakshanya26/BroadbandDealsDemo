using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BroadbandDeals.Service.Helper
{
    public static class LogManager
    {
        public static log4net.ILog Log { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        static LogManager()
        {
            Log = log4net.LogManager.GetLogger(typeof(LogManager));
        }

        /// <summary>
        /// Error only with message
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(object msg)
        {
            Log.Error(msg);
        }
        /// <summary>
        /// Error with message & exception
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public static void Error(object msg, Exception ex)
        {
            Log.Error(msg, ex);
        }
        /// <summary>
        ///  Error with exception
        /// </summary>
        /// <param name="ex"></param>
        public static void Error(Exception ex)
        {
            Log.Error(ex);
        }
        /// <summary>
        /// Log Information
        /// </summary>
        /// <param name="msg"></param>
        public static void Info(object msg)
        {
            Log.Info(msg);
        }
    }
}