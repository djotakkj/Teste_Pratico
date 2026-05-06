using System;

// Quando esse código é executado, ele pede para o usuário digitar um texto gritado
// ou seja, um texto que pode conter múltiplos pontos de interrogação e exclamação consecutivos.
// O programa então normaliza o texto, reduzindo múltiplos pontos de interrogação
// a um único ponto de interrogação e múltiplos pontos de exclamação a um único ponto de exclamação.
class Program
{
    static void Main()
    {
        Console.WriteLine("Digite o texto gritado:");
        string texto = Console.ReadLine();
        string resultado = "";
        int i = 0;
        while (i < texto.Length)
        {
            char caractere = texto[i];
            if (caractere == '?' || caractere == '!')
            {
                bool temInterrogacao = false;
                bool temExclamacao = false;
                while (i < texto.Length && (texto[i] == '?' || texto[i] == '!'))
                {
                    if (texto[i] == '?')
                    {
                        temInterrogacao = true;
                    }
                    else if (texto[i] == '!')
                    {
                        temExclamacao = true;
                    }
                    i++;
                }
                if (temInterrogacao)
                {
                    resultado += "?";
                }
                if (temExclamacao)
                {
                    resultado += "!";
                }
            }
            else
            {
                resultado += caractere;
                i++;
            }
        }
        Console.WriteLine("Texto normalizado:");
        Console.WriteLine(resultado);
    }
}