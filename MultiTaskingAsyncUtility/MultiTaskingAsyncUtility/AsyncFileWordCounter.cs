// To check this code comment all code in ThreadedHorseRaceSimulation.cs

//static async Task<int> SearchWordInFileAsync(string word, string filePath)
//{
//    try
//    {
//        string content = await File.ReadAllTextAsync(filePath);
//        int occurrences = content.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Count(w => w.Equals(word, StringComparison.OrdinalIgnoreCase));
//        return occurrences;
//    }
//    catch (FileNotFoundException) { return -1; }
//}

//Console.Write("Word to search: ");
//string word = Console.ReadLine();

//Console.Write("Path to the file: ");
//string filePath = Console.ReadLine();

//int occurrences = await SearchWordInFileAsync(word, filePath);

//if (occurrences == -1) Console.WriteLine("File not found");
//else Console.WriteLine($"The word '{word}' occurs {occurrences} times");