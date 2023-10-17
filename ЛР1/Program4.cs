using System;

class Program
{
    static void Main()
    {
        ulong a = 365;    // Первое число
        ulong b = 1514;   // Второе число
        ulong M = 69665;  // Модуль M

        // Сложение
        ulong sum = AddGF2(a, b, M);
        Console.WriteLine("a + b mod M = " + sum);

        // Вычитание
        ulong diff = SubtractGF2(a, b, M);
        Console.WriteLine("a - b mod M = " + diff);

        // Умножение
        ulong product = MultiplyGF2(a, b, M);
        Console.WriteLine("a * b mod M = " + product);

        // Поиск обратного элемента
        ulong inverse = FindInverseGF2(a, M);
        Console.WriteLine("2^(-1) mod M = " + inverse);
    }

    // Функция сложения в поле GF(2,n)
    static ulong AddGF2(ulong a, ulong b, ulong M)
    {
        return (a ^ b) % M;
    }

    // Функция вычитания в поле GF(2,n)
    static ulong SubtractGF2(ulong a, ulong b, ulong M)
    {
        return (a ^ b) % M;
    }

    // Функция умножения в поле GF(2,n)
    static ulong MultiplyGF2(ulong a, ulong b, ulong M)
    {
        ulong result = 0;
        while (b > 0)
        {
            if ((b & 1) == 1)
            {
                result = (result + a) % M;
            }
            a = (a << 1) % M;
            b >>= 1;
        }
        return result;
    }

    // Функция поиска обратного элемента в поле GF(2,n)
    static ulong FindInverseGF2(ulong a, ulong M)
    {
        ulong x, y;
        ExtendedEuclidean(a, M, out x, out y);
        if (x < 0)
        {
            x += M;
        }
        return x;
    }

    // Расширенный алгоритм Евклида для нахождения обратного элемента
    static void ExtendedEuclidean(ulong a, ulong b, out ulong x, out ulong y)
    {
        if (a == 0)
        {
            x = 0;
            y = 1;
        }
        else
        {
            ExtendedEuclidean(b % a, a, out x, out y);
            ulong temp = x;
            x = y - (b / a) * x;
            y = temp;
        }
    }
}
