using System;

class SieveOfEratosthenes
{
    public static void Main()
    {
        int N;
        Console.Write("Введите число N для поиска всех простых чисел до N: ");
        
        if (int.TryParse(Console.ReadLine(), out N) && N >= 2)
        {
            bool[] isPrime = new bool[N + 1];

            // Инициализируем массив как "все числа простые"
            for (int i = 2; i <= N; i++)
            {
                isPrime[i] = true;
            }

            // Применяем решето Эратосфена для поиска простых чисел
            for (int p = 2; p * p <= N; p++)
            {
                if (isPrime[p])
                {
                    for (int i = p * p; i <= N; i += p)
                    {
                        isPrime[i] = false;
                    }
                }
            }

            Console.WriteLine("Простые числа до " + N + ":");
            for (int i = 2; i <= N; i++)
            {
                if (isPrime[i])
                {
                    Console.Write(i + " ");
                }
            }
        }
        else
        {
            Console.WriteLine("Введите корректное значение N (N >= 2).");
        }
    }
}

