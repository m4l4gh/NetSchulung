﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTypes
{
    public class LogLineModel
    {
        public int RowIndex { get; set; }
        public DateTime LoggingTime { get; set; }
        public string Message { get; set; }

        /*public LogLineModel(string Message)
        {
            LoggingTime = DateTime.Now;
            RowIndex = 0;
        }*/
    }

    public class LogLineModelList :List<LogLineModel>
    {

    }
}
