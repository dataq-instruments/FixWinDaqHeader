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


            // Read header size (byte 6 and 7) in little endian format
            ushort headerSize = BitConverter.ToUInt16(fileBytes, 6);

            if (fileBytes.Length <= headerSize)
            {
                Console.WriteLine("File is too small to contain the required header.");
                return;
            }

            // Calculate new value for bytes 8 to 11 (file size - header size)
            uint newLongWordValue = (uint)(fileBytes.Length - headerSize);

            // Change the unsigned long word at bytes 8 to 11
            BitConverter.GetBytes(newLongWordValue).CopyTo(fileBytes, 8);

            // Change bytes 12 to 17 to 0
            for (int i = 12; i <= 17; i++)
            {
                fileBytes[i] = 0;
            }

            // Check the double-precision number at bytes 28 to 35
            double doubleValue = BitConverter.ToDouble(fileBytes, 28);

            // If the value is zero or less, prompt the user to enter a new number
            if (doubleValue <= 0)
            {
                Console.WriteLine("The time interval stored at bytes 28 to 35 is zero or negative.");
                Console.Write("Please enter a new positive time interval: ");
                double newValue;
                while (!double.TryParse(Console.ReadLine(), out newValue) || newValue <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid positive number.");
                }

                // Place the new value in bytes 28 to 35
                BitConverter.GetBytes(newValue).CopyTo(fileBytes, 28);
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
