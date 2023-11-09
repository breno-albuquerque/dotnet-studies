var currentDirectory = Directory.GetCurrentDirectory();

Console.WriteLine("Current Directory: " + currentDirectory);

var filesDirectory = Path.Combine(currentDirectory, "Files");

SetupDirectory(filesDirectory);

using (StreamWriter sw = File.CreateText(Path.Combine(filesDirectory, "Example_1.txt")))
{
    sw.WriteLine("Line 1");
    sw.WriteLine("Line 2");
}

using (StreamWriter sw = File.CreateText(Path.Combine(filesDirectory, "Example_2.cs")))
{
    sw.WriteLine("using test;");
}

File.WriteAllLines(Path.Combine(filesDirectory, "Example_3.txt"),  CreateStringList());

//  Help Methods
IEnumerable<string> CreateStringList()
{
    var list = new List<string>();
    
    var random = new Random();
    
    for (var i = 0; i < 30; i += 1)
        list.Add($"Numero {random.Next(0, 10)}");

    return list;
}

void SetupDirectory(string directoryPath)
{
    if (!Directory.Exists(directoryPath));
        Directory.CreateDirectory(directoryPath);
    
    var files = Directory.EnumerateFiles(directoryPath);
        
    if (files.Any())
    {
        foreach (var file in files)
            File.Delete(file);
    }
}










