using CandidateTesting.JaderMartins.Exceptions;
using CandidateTesting.JaderMartins.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.JaderMartins.Services
{
    public class MinhaCdn : IProvider, IHttpMethod, IStatusCode, IUriPath, ITimeTaken, IResponseSize, ICacheStatus, IFile
    {
        public List<string> GetLines(string url)
        {
            List<string> lines = new List<string>();
            using (WebClient fileGetter = new WebClient())
            {
                var text = System.Text.Encoding.UTF8.GetString(fileGetter.DownloadData(url));

                using (StringReader sr = new StringReader(text))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }

                return lines.ToList();
            }
        }

        public string GetProvider(List<string> columns)
        {
            return "\"MINHA CDN\"";
        }

        public string GetStatusCode(List<string> columns)
        {
            try
            {
                return columns[1];
            }
            catch (Exception)
            {
                throw new ExceptionInvalidFormat("status-code");
            }
        }

        public List<string> GetColuns(string line)
        {
            try
            {
                return line.Split('|').ToList<string>();
            }
            catch (Exception)
            {
                throw new ExceptionInvalidFormat();
            }
        }

        public string GetHttpMethod(List<string> columns)
        {
            try
            {
                return columns[3].Split('"')[1].Split(' ')[0];
            }
            catch (Exception)
            {
                throw new ExceptionInvalidFormat("http-method");
            }
            
        }

        public string GetUriPath(List<string> columns)
        {
            try
            {
                return columns[3].Split(' ')[1];
            }
            catch (Exception)
            {
                throw new ExceptionInvalidFormat("uri-path");
            }
        }

        public string GetTimeTaken(List<string> columns)
        {
            try
            {
                return Math.Round(decimal.Parse(columns[4], new NumberFormatInfo() { NumberDecimalSeparator = "." })).ToString();
            }
            catch (Exception)
            {
                throw new ExceptionInvalidFormat("time-taken");
            }
            
        }

        public string GetResponseSize(List<string> columns)
        {
            try
            {
                return columns[0];
            }
            catch (Exception)
            {
                throw new ExceptionInvalidFormat("response-size");
            }   
        }

        public string GetCacheStatus(List<string> columns)
        {
            try
            {
                if (columns[2].ToUpper() == "INVALIDATE")
                    return "REFRESH_HIT";
                else
                    return columns[2];
            }
            catch (Exception)
            {
                throw new ExceptionInvalidFormat("cache-status");
            }
        }
    }
}
