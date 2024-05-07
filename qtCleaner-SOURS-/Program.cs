using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hi, do you want to clean your Windows? (1 - YES, 2 - NO)");
        string userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1":
                CleanTempFiles();
                break;
            case "2":
                Console.WriteLine("The program is closing.");
                break;
            default:
                Console.WriteLine("Invalid entry. Please enter 1 or 2.");
                break;
        }
    }

    static void CleanTempFiles()
    {
        Console.WriteLine("Debris cleanup begins...");

        string tempPath = Path.GetTempPath();
        DeleteFilesInDirectory(tempPath);

        string windowsTempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Temp");
        DeleteFilesInDirectory(windowsTempPath);

        Console.WriteLine("The cleanup is complete!");
    }

    static void DeleteFilesInDirectory(string path)
    {
        try
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {
                subDirectory.Delete(true);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Clearance Error: " + ex.Message);
        }
    }
}

// qcf  