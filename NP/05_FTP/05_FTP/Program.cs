using FluentFTP;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace _05_FTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "";
            string userName = "";
            string password = "";

            // Read list
            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            //request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            //request.Credentials = new NetworkCredential(userName, password);
            //var response = (FtpWebResponse)request.GetResponse();   

            //using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            //{
            //    string data = stream.ReadToEnd();
            //    Console.WriteLine(data);
            //}


            //Upload
            //url = "";
            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            //request.Method = WebRequestMethods.Ftp.UploadFile;
            //request.Credentials = new NetworkCredential(userName, password);

            //var bytes = File.ReadAllBytes("forest.webp");

            //using (Stream stream = request.GetRequestStream())
            //{
            //    stream.Write(bytes);
            //}


            //Download
            //url = "";

            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            //request.Method = WebRequestMethods.Ftp.DownloadFile;
            //request.Credentials = new NetworkCredential(userName, password);

            //var response = (FtpWebResponse)request.GetResponse();

            //using (Stream stream = response.GetResponseStream())
            //{
            //    using (Stream file = File.OpenWrite(@"C:\Users\traig\Downloads\download.json"))
            //    {
            //        stream.CopyTo(file);
            //    }
            //}





            // FluentFTP
            url = "";
            string root = "";

            using (var client = new FtpClient(url, userName, password))
            {
                client.Connect();

                // Скачати файл
                //client.DownloadFile(@"C:\Users\traig\Downloads\test.webp", $"/{root}/image.webp");

                // Список файлів і папок
                //var items = client.GetListing($"/{root}");

                //foreach(var item in items)
                //{
                //    if(item.Type == FtpObjectType.Directory)
                //    {
                //        Console.WriteLine(item.Name);
                //    }
                //    else
                //    {
                //        client.DeleteFile(item.FullName);
                //    }
                //}

                // Завантажити файл
                client.UploadFile(@"C:\Users\traig\Downloads\tommy-cash-espresso-macchiato.mp3", $"/{root}/files/audio.mp3");
            }
        }
    }
}
