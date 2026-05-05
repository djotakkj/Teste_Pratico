using System;

// Fiz esse código que quando executado, ele pergunta ao usuário quantos elementos da sequência de Fibonacci deseja gerar.
// em seguida, gera a sequência de Fibonacci até a quantidade especificada.
class Program
{
    static void Main()
    {
        Console.WriteLine("Quantos elementos da sequência de Fibonacci deseja gerar?");
        int quantidade = Convert.ToInt32(Console.ReadLine());
        int primeiro = 0;
        int segundo = 1;
        Console.Write("Sequência: ");
        for (int i = 0; i < quantidade; i++)
        {
            Console.Write(primeiro);
            if (i < quantidade - 1)
            {
                Console.Write(", ");
            }
            int proximo = primeiro + segundo;
            primeiro = segundo;
            segundo = proximo;
        }
    }
}