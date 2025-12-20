using System.IO;
using System.Text;

namespace _03_Files
{
    class MyStream : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose called");
        }
    }

    internal class Program
    {
        // FileStream

        static void WriteToFile()
        {
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean nec semper purus, sit amet pharetra felis. In hac habitasse platea dictumst. Vivamus iaculis lorem eget dapibus venenatis. Aliquam erat volutpat. Fusce vitae ex sed lorem ornare vulputate. Aliquam fermentum pretium congue. Mauris eu ligula sagittis, imperdiet mauris eu, porta metus. Vestibulum sit amet fringilla ipsum. Mauris arcu purus, commodo nec bibendum a, sodales sit amet nulla. Vivamus laoreet posuere convallis. Nullam eget consectetur tellus, a consectetur dui. Sed eu odio iaculis, molestie neque quis, porttitor metus.";
            Stream stream = new FileStream("lorem.txt", FileMode.Create, FileAccess.Write);

            byte[] bytes = Encoding.UTF8.GetBytes(text);
            stream.Write(bytes);

            stream.Close();
        }

        static void ReadFromFile()
        {
            try
            {
                Stream stream = new FileStream("lorem.txt", FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[stream.Length];
                int l = stream.Read(buffer);

                string text = Encoding.UTF8.GetString(buffer, 0, l);
                Console.WriteLine(text);

                stream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CopyImage()
        {
            string imageName = "C# logo.png";

            var streamIn = new FileStream(imageName, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[streamIn.Length];
            int length = streamIn.Read(buffer);
            streamIn.Close();

            var streamOut = new FileStream("C# logo-copy.png", FileMode.Create, FileAccess.Write);
            streamOut.Write(buffer, 0, 5500);
            streamOut.Close();
        }

        static void StreamWriter()
        {
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean nec semper purus, sit amet pharetra felis. In hac habitasse platea dictumst. Vivamus iaculis lorem eget dapibus venenatis. Aliquam erat volutpat. Fusce vitae ex sed lorem ornare vulputate. Aliquam fermentum pretium congue. Mauris eu ligula sagittis, imperdiet mauris eu, porta metus. Vestibulum sit amet fringilla ipsum. Mauris arcu purus, commodo nec bibendum a, sodales sit amet nulla. Vivamus laoreet posuere convallis. Nullam eget consectetur tellus, a consectetur dui. Sed eu odio iaculis, molestie neque quis, porttitor metus.";

            var stream = new StreamWriter("lorem.txt");

            //stream.NewLine = "!";
            //Console.WriteLine(stream.NewLine);
            stream.WriteLine(text);

            stream.Close();
        }

        static void StreamReader()
        {
            var stream = new StreamReader("lorem.txt", Encoding.UTF8);

            string text = stream.ReadToEnd();
            Console.WriteLine(text);

            stream.Close();
        }

        static void MemoryStream()
        {
            byte[] bytes = [1, 3, 123, 255, 65, 24, 7, 100, 6];
            MemoryStream memStream = new MemoryStream(bytes);

            FileStream fileStream = new FileStream("bytes.bin", FileMode.Create, FileAccess.Write);

            memStream.CopyTo(fileStream);

            memStream.Close();
            fileStream.Close();
        }

        static void DisposeTmp()
        {
            // using працює тілкьи з класами які реалізувати IDisposable
            // using це try finally який у finally викликає метод Dispose

            try
            {
                using (Stream stream = new FileStream("lorem.txt", FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[stream.Length];
                    int l = stream.Read(buffer);

                    string text = Encoding.UTF8.GetString(buffer, 0, l);
                    Console.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DirectoryFileTmp()
        {
            // Directory

            string appPath = Directory.GetCurrentDirectory();

            string path = Path.Combine(appPath, "spr411");
            //var ext = Path.GetExtension("myfile.txt");
            //string newFile = "file" + ext;
            //Directory.CreateDirectory(path);
            // Directory.Delete(path);

            string[] files = Directory.GetFiles(appPath);
            //string[] dirs = Directory.GetDirectories("C:/");

            //Console.WriteLine(Directory.GetParent(path));

            // DirectoryInfo directory = new DirectoryInfo(appPath);


            // File
            using (var stream = File.Create("fileClass.bin"))
            {

            }


            // write
            File.WriteAllLines("files.txt", files);
            File.WriteAllText("alltext.txt", string.Join(", ", files));

            // read
            string text = File.ReadAllText("files.txt");
            Console.WriteLine(text);

            string filePath = @"C:\Users\traig\CalorieAppDB.mdf";
            //if(File.Exists(filePath))
            //{
            //    Console.WriteLine(File.ReadAllText(filePath));
            //}
            //byte[] bytes = File.ReadAllBytes(filePath);
            //foreach (var b in bytes)
            //{
            //    Console.Write(b + " ");
            //}

            //FileInfo fileInfo = new FileInfo(filePath);
            //Console.WriteLine(fileInfo.FullName);
            //Console.WriteLine(fileInfo.Name);
            //Console.WriteLine(fileInfo.Extension);
            //Console.WriteLine(fileInfo.Exists);
            //Console.WriteLine(fileInfo.Length);
            //Console.WriteLine(fileInfo.CreationTime);
            //Console.WriteLine(fileInfo.LastAccessTime);
            //Console.WriteLine(fileInfo.LastWriteTime);
        }

        static void Main(string[] args)
        {
            var fm = new FileManager();
            fm.Start();
        }
    }
}
