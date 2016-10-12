using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace SendSMS {
    class Program {
        public static string SendSMS(string msisdn, string username, string password, string output) {
            StringBuilder sb  = new StringBuilder();
            byte[]        buf = new byte[1024];
            string url = "http://smsc.txtnation.com:5002/checkHLR?" + "msisdn=" + msisdn + "&username=" + username + "&password=" + password + "&output=" + output;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            string tempString = null;
            int count = 0;
            do {
                count = resStream.Read(buf, 0, buf.Length);
                if (count != 0) {
                    tempString = Encoding.ASCII.GetString(buf, 0, count);
                    sb.Append(tempString);
                }
            }
            while (count > 0);
            return sb.ToString();
        }
        static void Main(string[] args) {
            string respXML = SendSMS("msisdn", "username", "password", "xml|json");
            Console.WriteLine(respXML);
       }
    }
}
