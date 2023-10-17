using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Пожалуйста, укажите команду, число1 и число2.");
            return;
        }

        string command = args[0];
        int number1 = int.Parse(args[1]);
        int number2 = int.Parse(args[2]);

        int result = 0;

        switch (command)
        {
            case "xor":
                result = number1 ^ number2;
                break;
            case "and":
                result = number1 & number2;
                break;
            case "or":
                result = number1 | number2;
                break;
            case "set1":
                result = number2 | (1 << number1);
                break;
            case "set0":
                result = number2 & ~(1 << number1);
                break;
            case "shl":
                result = number2 << number1;
                break;
            case "shr":
                result = number2 >> number1;
                break;
            case "rol":
                result = (number2 << number1) | (number2 >> (32 - number1));
                break;
            case "ror":
                result = (number2 >> number1) | (number2 << (32 - number1));
                break;
            case "mix":
                int[] bitOrder = new int[] { 7, 6, 5, 4, 3, 2, 1, 0 };
                int mixedNumber = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (((number2 >> bitOrder[i]) & 1) == 1)
                        mixedNumber |= (1 << i);
                }
                result = mixedNumber;
                break;
            default:
                Console.WriteLine("Неверная команда.");
                return;
        }

        Console.WriteLine($"Результат (десятичный): {result}");
        Console.WriteLine($"Результат (шестнадцатеричный): 0x{result:X}");
        Console.WriteLine($"Результат (бинарный): {Convert.ToString(result, 2).PadLeft(8, '0')}");
    }
}
