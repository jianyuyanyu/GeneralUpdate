﻿using GeneralUpdate.Core.CustomAwaiter;
using GeneralUpdate.Core.Events.MultiEventArgs;
using GeneralUpdate.Core.Exceptions.CustomArgs;
using GeneralUpdate.Core.Exceptions.CustomException;
using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralUpdate.Core.Download
{
    /// <summary>
    /// Download task class.
    /// </summary>
    /// <typeparam name="TVersion">'T' is the version information that needs to be downloaded.</typeparam>
    public sealed class DownloadTask<TVersion> : AbstractTask<TVersion>, IAwaiter<DownloadTask<TVersion>>
    {
        #region Private Members

        private Exception _exception;
        private DownloadManager<TVersion> _manager;
        private const int DEFAULT_DELTA = 1048576;//1024*1024
        private TVersion _version;

        #endregion Private Members

        #region Constructors

        public DownloadTask(DownloadManager<TVersion> manger, TVersion version)
        {
            _manager = manger;
            _version = version;
        }

        #endregion Constructors

        #region Public Properties

        public bool IsCompleted { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Launch the current download task.
        /// </summary>
        /// <returns></returns>
        public async Task Launch()
        {
            try
            {
                var url = GetPropertyValue<string>(_version, "Url");
                var name = GetPropertyValue<string>(_version, "Name");
                InitTimeOut(_manager.TimeOut);
                InitStatisticsEvent();
                InitProgressEvent();
                InitCompletedEvent();
                var installPath = $"{_manager.Path}{name}{_manager.Format}";
                DownloadFileRange(url, installPath, null);
                await this;
            }
            catch (Exception ex)
            {
                _manager.OnMultiDownloadError(this, new MultiDownloadErrorEventArgs(ex, _version));
                _exception = new GeneralUpdateException<ExceptionArgs>("'download task' The executes abnormally !", ex);
            }
        }

        public DownloadTask<TVersion> GetResult()
        {
            if (_exception != null) ExceptionDispatchInfo.Capture(_exception).Throw();
            return this;
        }

        public void OnCompleted(Action continuation)
        {
            if (IsCompleted) continuation?.Invoke();
        }

        public DownloadTask<TVersion> GetAwaiter() => this;

        public async Task AsTask(DownloadTask<TVersion> awaiter) => await awaiter;

        #endregion Public Methods

        #region Private Methods

        private void InitStatisticsEvent()
        {
            if (SpeedTimer != null) return;

            SpeedTimer = new Timer(_ =>
            {
                try
                {
                    var interval = DateTime.Now - StartTime;
                    var downLoadSpeed = interval.Seconds < 1
                        ? ToUnit(ReceivedBytes - BeforBytes)
                        : ToUnit(ReceivedBytes - BeforBytes / interval.Seconds);
                    var size = (TotalBytes - ReceivedBytes) / DEFAULT_DELTA;
                    var remainingTime = new DateTime().AddSeconds(Convert.ToDouble(size));
                    _manager.OnMultiDownloadStatistics(this, new MultiDownloadStatisticsEventArgs(_version, remainingTime, downLoadSpeed));
                    StartTime = DateTime.Now;
                    BeforBytes = ReceivedBytes;
                }
                catch (Exception exception)
                {
                    _manager.OnMultiDownloadError(this, new MultiDownloadErrorEventArgs(exception, _version));
                }
            }, null, 0, 1000);
        }

        private void InitProgressEvent()
        {
            MultiDownloadProgressChanged += ((sender, e) =>
            {
                try
                {
                    ReceivedBytes = e.BytesReceived;
                    TotalBytes = e.TotalBytesToReceive;

                    var eventArgs = new MultiDownloadProgressChangedEventArgs(_version,
                        e.BytesReceived / DEFAULT_DELTA,
                        e.TotalBytesToReceive / DEFAULT_DELTA,
                        e.ProgressPercentage,
                        e.UserState);

                    _manager.OnMultiDownloadProgressChanged(this, eventArgs);
                }
                catch (Exception exception)
                {
                    _manager.OnMultiDownloadError(this, new MultiDownloadErrorEventArgs(exception, _version));
                }
            });
        }

        private void InitCompletedEvent()
        {
            MultiDownloadFileCompleted += ((sender, e) =>
            {
                try
                {
                    if (SpeedTimer != null)
                    {
                        SpeedTimer.Dispose();
                        SpeedTimer = null;
                    }
                    var eventArgs = new MultiDownloadCompletedEventArgs(_version, e.Error, e.Cancelled, e.UserState);
                    _manager.OnMultiAsyncCompleted(this, eventArgs);
                    Dispose();
                }
                catch (Exception exception)
                {
                    _manager.FailedVersions.Add(new ValueTuple<object, string> { });
                    _manager.OnMultiDownloadError(this, new MultiDownloadErrorEventArgs(exception, _version));
                }
                finally
                {
                    IsCompleted = true;
                }
            });
        }

        private TResult GetPropertyValue<TResult>(TVersion entity, string propertyName)
        {
            TResult result = default(TResult);
            Type entityType = typeof(TVersion);
            try
            {
                PropertyInfo info = entityType.GetProperty(propertyName);
                result = (TResult)info.GetValue(entity);
            }
            catch (ArgumentNullException ex)
            {
                throw _exception = new ArgumentNullException("'GetPropertyValue' The method executes abnormally !", ex);
            }
            catch (AmbiguousMatchException ex)
            {
                throw _exception = new AmbiguousMatchException("'GetPropertyValue' The method executes abnormally !", ex);
            }
            catch (Exception ex)
            {
                throw new GeneralUpdateException<ExceptionArgs>($"Download task GetPropertyValue error : {ex.Message}", ex.InnerException);
            }
            return result;
        }

        private string ToUnit(long byteSize)
        {
            string result;
            var tempSize = Convert.ToSingle(byteSize) / 1024;
            if (tempSize > 1)
            {
                var tempMbyte = tempSize / 1024;
                if (tempMbyte > 1)
                {
                    result = $"{tempMbyte.ToString("##0.00", CultureInfo.InvariantCulture)}MB/S";
                }
                else
                {
                    result = $"{tempSize.ToString("##0.00", CultureInfo.InvariantCulture)}KB/S";
                }
            }
            else
            {
                result = $"{byteSize.ToString(CultureInfo.InvariantCulture)}B/S";
            }
            return result;
        }

        #endregion Private Methods
    }
}