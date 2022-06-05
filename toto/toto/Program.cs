using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toto
{
    public class Program
    {
        public static void Main()
        {
            int totalNumbers = 0;
            int[] numberOfRepetitions = new int[49];

            // индекс 0 - 2 последователни
            // индекс 1 - 3 последователни
            // индекс 2 - 4 последователни
            // индекс 3 - 5 последователни
            // индекс 4 - 6 последователни
            int[] numberOfConsecutives = new int[5];

            using (var f = new StreamReader("toto.txt"))
            {
                while(!f.EndOfStream)
                {
                    string line = f.ReadLine();
                    int[] numbers = Array.ConvertAll(line.Split(","), Convert.ToInt32);

                    foreach (var number in numbers)
                    {
                        numberOfRepetitions[number - 1]++; 
                        totalNumbers++;
                    }

                    int maxConsecutiveNumbers = 1; 
                    int consecutiveNumbers = 1;
                    for (int i = 1; i < numbers.Length; i++)
                    {
                        if ((numbers[i] - 1) == numbers[i - 1])
                        {
                            consecutiveNumbers++;
                        }
                        else
                        {
                            maxConsecutiveNumbers = Math.Max(maxConsecutiveNumbers, consecutiveNumbers);
                            consecutiveNumbers = 1;
                        }
                    }
                    maxConsecutiveNumbers = Math.Max(maxConsecutiveNumbers, consecutiveNumbers);

                    if (maxConsecutiveNumbers > 1)
                    {
                        numberOfConsecutives[maxConsecutiveNumbers - 2]++;
                    }
                }
            }

            Console.WriteLine("Процент за появяване на всяко от числата: \n");
            for (int i = 0; i < 49; i++)
            {
                double percentage = numberOfRepetitions[i] / (double)totalNumbers * 100;
                Console.WriteLine($"{i + 1} - {Math.Round(percentage, 2)}%");
            }

            for(int i = 0; i < numberOfConsecutives.Length; i++)
            {
                int count = numberOfConsecutives.Skip(i).Sum();
                Console.WriteLine($"\nТиражи с {i + 2} последователни числа: {count}");
            }
        }
    }
}
