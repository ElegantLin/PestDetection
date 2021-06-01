using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections;

namespace quarantine_app
{
    class HttpUtils
    {
        public static string Get(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }

            return retString;
        }

        public static string DoPost(string url, Hashtable paramsOfUrl)
        {
            if (url == null)
            {
                throw new Exception("WebService地址为空");
            }
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            byte[] data = GetJointBOfParams(paramsOfUrl);

            request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();
            reader.Close();
            return result;
        }

        private static String GetJointSOfParams(System.Collections.Hashtable paramsOfUrl)
        {
            if (paramsOfUrl == null || paramsOfUrl.Count == 0) return String.Empty;
            StringBuilder sbuilder = new StringBuilder();
            int i = 0;
            foreach (DictionaryEntry de in paramsOfUrl)
            {
                string value = ToHttpChar(de.Value.ToString());
                if (i == 0)
                {
                    sbuilder.Append(de.Key + "=" + value);
                }
                else
                {
                    sbuilder.Append("&" + de.Key + "=" + value);
                }
                i++;
            }
            return sbuilder.ToString();
        }

        private static byte[] GetJointBOfParams(Hashtable paramsOfUrl)
        {
            String stringJointOfParams = GetJointSOfParams(paramsOfUrl);
            byte[] data = Encoding.UTF8.GetBytes(stringJointOfParams);
            return data;
        }

        private static string ToHttpChar(string value)
        {
            value = value.ToString().Replace("+", "%2B");
            value = value.ToString().Replace(" ", "%20");
            value = value.ToString().Replace("/", "%2F");
            value = value.ToString().Replace("?", "%3F");
            value = value.ToString().Replace("%", "%25");
            value = value.ToString().Replace("#", "%23");
            value = value.ToString().Replace("&", "%26");
            value = value.ToString().Replace("=", "%3D");
            value = value.ToString().Replace(@"\", "%5C");
            value = value.ToString().Replace(".", "%2E");
            value = value.ToString().Replace(":", "%3A");
            return value;
        }
 
        public static string HttpApi(string url, string jsonstr, string type)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);  
            request.Accept = "text/html,application/xhtml+xml,*/*";
            request.ContentType = "application/json";
            request.Method = type.ToUpper().ToString(); 
            byte[] buffer = encoding.GetBytes(jsonstr);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public static string BuildQuery(Dictionary<string, string> dic) {
            string res = "";
            List<string> test = new List<string>(dic.Keys);
            for (int i = 0; i < dic.Count; i++)
            {
                res += test[i];
                res += "=";
                res += dic[test[i]];
                if (i != dic.Count - 1) {
                    res += "&";
                }
            }
            Console.WriteLine(res);
            return res;
        }

        public static string UploadImage(string uploadUrl, string imgPath, Dictionary<string, string> dic)
        {
            string[] urls = imgPath.Split('~');
            int img_count = urls.Length;
            for(int i = 0; i < urls.Length; i++)
            {
                if (urls[i].Contains("111.198.4.119")) urls[i] = "";
            }

            var postData = BuildQuery(dic);
            var postUrl = string.Format("{0}?{1}", uploadUrl, postData);
            Console.WriteLine(postUrl);
            HttpWebRequest request = WebRequest.Create(postUrl) as HttpWebRequest;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            request.KeepAlive = true;
            request.Credentials = CredentialCache.DefaultCredentials;

            string boundary = DateTime.Now.Ticks.ToString("X"); 
            request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
            byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

            Stream postStream = request.GetRequestStream();
            string sbHeaderTemplate = "Content-Disposition:form-data;name=\"file\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n";
            byte[] buffer = new byte[6 * 1024 * 1024];
            foreach (string url in urls)
            {
                if (url != "")
                {
                    postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                    int pos = url.LastIndexOf("\\");
                    string fileName = url.Substring(pos + 1);
                    string header = string.Format(sbHeaderTemplate, fileName);
                    byte[] postHeaderBytes = Encoding.UTF8.GetBytes(header);
                    postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                    using (FileStream fs = new FileStream(url, FileMode.Open, FileAccess.Read))
                    {
                        int r = fs.Read(buffer, 0, buffer.Length);
                        postStream.Write(buffer, 0, r);
                    }
                }  
            }
            postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            postStream.Close();

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream instream = response.GetResponseStream();
            StreamReader sr = new StreamReader(instream, Encoding.UTF8);
            string content = sr.ReadToEnd();
            return content;
        }

        public static string downloadFile(string download_url, string file_type)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(download_url);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream responseStream = response.GetResponseStream();
            Random random = new Random();
            string fileName = "file" + random.Next().ToString() + "." + file_type;
            Stream stream = new FileStream(fileName, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            return fileName;
        }
    }
}
