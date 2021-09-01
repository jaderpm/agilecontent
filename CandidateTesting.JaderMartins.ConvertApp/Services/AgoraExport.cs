using CandidateTesting.JaderMartins.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.JaderMartins.Services
{
    public class AgoraExport: IOutFormat, IHeader, IVersion, IFields, IDate
    {
        private IHttpMethod HttpMethod_ { get; set; }
        private IProvider Provider_ { get; set; }
        private IStatusCode Statuscode_ { get; set; }
        private IUriPath UriPath_ { get; set; }
        private ITimeTaken TimeTaken_ { get; set; }
        private IResponseSize ResponseSize_ { get; set; }
        private ICacheStatus CacheStatus_ { get; set; }
        private IFile File_ { get; set; }

        public AgoraExport(IProvider provider, IHttpMethod httpMethod, IStatusCode statuscode, IUriPath uriPath, ITimeTaken timeTaken, IResponseSize responseSize,ICacheStatus cacheStatus, IFile file)
        {
            Provider_ = provider;
            Statuscode_ = statuscode;
            HttpMethod_ = httpMethod;
            UriPath_ = uriPath;
            TimeTaken_ = timeTaken;
            ResponseSize_ = responseSize;
            CacheStatus_ = cacheStatus;
            File_ = file;
        }

        public string GetStringFormattedFromUrl(string url)
        {
            var outputText = new StringBuilder();
            outputText.Append(GetHeader());
            foreach (var item in File_.GetLines(url))
            {
                var columns = File_.GetColuns(item);
                var formatted = Provider_.GetProvider(columns) + " " + HttpMethod_.GetHttpMethod(columns) + " " + Statuscode_.GetStatusCode(columns) + " " + UriPath_.GetUriPath(columns) + " " + TimeTaken_.GetTimeTaken(columns) + " " + ResponseSize_.GetResponseSize(columns) + " " + CacheStatus_.GetCacheStatus(columns);
                outputText.AppendLine(formatted);
            }
            return outputText.ToString();
        }

        public string GetHeader()
        {
            return @$"#Version: {GetVersion()}
#Date: {GetDate()}
#Fields: {GetFields()}
";
        }

        public string GetVersion()
        {
            return "1.0";
        }

        public string GetFields()
        {
            return "provider http-method status-code uri-path time-taken response-size cache-status";
        }

        public DateTime GetDate()
        {
            return DateTime.Now;
        }

        public void ExportFileFromUrl(string url, string outPath)
        {
            var directoryName = Path.GetDirectoryName(outPath);
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
            File.WriteAllText(outPath, GetStringFormattedFromUrl(url));
        }
    }
}
