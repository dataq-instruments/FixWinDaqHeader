using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the path to the binary file as a command-line argument.");
            return;
        }

        string filePath = args[0];

        if (!File.Exists(filePath))
        {
            Console.WriteLine("The specified file does not exist.");
            return;
        }

        try
        {
            // Read the binary file into a byte array
            byte[] fileBytes = File.ReadAllBytes(filePath);

            if (fileBytes.Length < 18)
            {
                Console.WriteLine("File is too small to contain the required header.");
                return;
            }

            // Read header size (byte 6 and 7) in little endian format
            ushort headerSize = BitConverter.ToUInt16(fileBytes, 6);

            // Calculate new value for bytes 8 to 11 (file size - header size)
            uint newLongWordValue = (uint)(fileBytes.Length - headerSize);

            // Change the unsigned long word at bytes 8 to 11
            BitConverter.GetBytes(newLongWordValue).CopyTo(fileBytes, 8);

            // Change bytes 12 to 17 to 0
            for (int i = 12; i <= 17; i++)
            {
                fileBytes[i] = 0;
            }

            // Generate a new file name
            string newFileName = Path.GetFileNameWithoutExtension(filePath) + "_modified" + Path.GetExtension(filePath);
            string newFilePath = Path.Combine(Path.GetDirectoryName(filePath), newFileName);

            // Save the modified file
            File.WriteAllBytes(newFilePath, fileBytes);

            Console.WriteLine($"File successfully modified and saved as {newFileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
