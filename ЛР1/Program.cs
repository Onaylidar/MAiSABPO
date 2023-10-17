using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Использование: 1.exe <формат> <путь к файлу>");
            return;
        }

        string format = args[0].ToLower();
        string filePath = args[1];

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Указанный файл не существует.");
            return;
        }

        byte[] fileBytes = File.ReadAllBytes(filePath);

        switch (format)
        {
            case "hex8":
                Console.WriteLine(BitConverter.ToString(fileBytes).Replace("-", " "));
                break;
            case "dec8":
                foreach (byte b in fileBytes)
                {
                    Console.Write(b.ToString("D3") + " ");
                }
                Console.WriteLine();
                break;
            case "hex16":
                for (int i = 0; i < fileBytes.Length; i += 2)
                {
                    ushort value = BitConverter.ToUInt16(fileBytes, i);
                    Console.Write(value.ToString("X4") + " ");
                }
                Console.WriteLine();
                break;
            case "dec16":
                for (int i = 0; i < fileBytes.Length; i += 2)
                {
                    ushort value = BitConverter.ToUInt16(fileBytes, i);
                    Console.Write(value.ToString("D5") + " ");
                }
                Console.WriteLine();
                break;
            case "hex32":
                for (int i = 0; i < fileBytes.Length; i += 4)
                {
                    uint value = BitConverter.ToUInt32(fileBytes, i);
                    Console.Write(value.ToString("X8") + " ");
                }
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("Неподдерживаемый формат.");
                break;
        }
    }
}
