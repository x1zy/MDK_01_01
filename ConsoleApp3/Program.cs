string dirName = "C:\\Program Files";
DirectoryInfo dirInfo = new DirectoryInfo(dirName);
Console.WriteLine("Название каталога: {0}", dirInfo.Name);
Console.WriteLine("Полное название каталога: {0}", dirInfo.FullName);
Console.WriteLine("Время создания каталога: {0}", dirInfo.CreationTime);
Console.WriteLine("Корневой каталог: {0}", dirInfo.Root);
