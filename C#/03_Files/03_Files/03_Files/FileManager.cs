namespace _03_Files
{
    public class FileManager
    {
        string rootPath;
        string currentPath;
        int currentPos;
        
        public FileManager()
        {
            rootPath = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
            currentPath = rootPath;
            currentPos = 0;
        }

        public void ShowItems()
        {
            var dirs = GetDirectories();
            var files = GetFiles();

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < dirs.Count; i++)
            {
                var dir = dirs[i];
                var symbol = (i == currentPos) ? "-> " : "   ";
                Console.WriteLine($"{symbol}{dir.Name}");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                var symbol = (i + dirs.Count == currentPos) ? "-> " : "   ";
                Console.WriteLine($"{symbol}{file.Name}");
            }
            Console.ResetColor();
        }

        private void Update()
        {
            Console.Clear();
            ShowItems();
        }

        public void Start()
        {
            ShowItems();
            ConsoleKey key = ConsoleKey.Escape;
            do
            {
                key = Console.ReadKey(true).Key;
                var total = GetDirectories().Count + GetFiles().Count;

                if (key == ConsoleKey.UpArrow && currentPos > 0)
                {
                    currentPos--;
                }
                else if (key == ConsoleKey.DownArrow && currentPos < total - 1)
                {
                    currentPos++;
                }
                else if (key == ConsoleKey.Enter)
                {
                    Open();
                }
                Update();

            } while (key != ConsoleKey.Escape);
               
        }

        void Open()
        {
            var dir = GetDirectories()[currentPos];
            currentPath = dir.FullName;
            currentPos = 0;
            Update();
        }

        public List<DirectoryInfo> GetDirectories()
        {
            var res = new List<DirectoryInfo>();
            var dirs = Directory.GetDirectories(currentPath);
            foreach (var dir in dirs)
            {
                res.Add(new DirectoryInfo(dir));
            }
            return res;
        }

        public List<FileInfo> GetFiles()
        {
            var res = new List<FileInfo>();
            var files = Directory.GetFiles(currentPath);
            foreach (var file in files)
            {
                res.Add(new FileInfo(file));
            }
            return res;
        }
    }
}
