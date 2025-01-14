﻿using System;

namespace GeneralUpdate.Core.Events.MultiEventArgs
{
    public class MultiDownloadErrorEventArgs : EventArgs
    {
        public MultiDownloadErrorEventArgs(Exception exception, object version)
        {
            Exception = exception;
            Version = version;
        }

        public Exception Exception { get; set; }

        public object Version { get; set; }
    }
}