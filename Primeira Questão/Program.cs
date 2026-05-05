using System;

// Fiz esse código que quando executado, ele pede para o usuário digitar uma palavra ou frase e verifica se é um palíndromo.
// Ou seja, se a palavra ou frase é a mesma quando lida de trás para frente, ignorando espaços e diferenças entre maiúsculas e minúsculas.
// O programa utiliza um loop para comparar os caracteres do início e do fim da string.
// Avançando em direção ao centro até que uma diferença seja encontrada ou até que todos os caracteres sejam verificados.
//Se for encontrado um par de caracteres diferentes, o programa conclui que não é um palíndromo; caso contrário.
// se todos os caracteres forem iguais, o programa conclui que é um palíndromo.
class Program
{
    static void Main()
    {
        Console.WriteLine("Digite uma palavra ou frase:");
        string palavra = Console.ReadLine();
        string texto = palavra.Replace(" ", "").ToLower();
        bool palindromo = true;
        int inicio = 0;
        int fim = texto.Length - 1;
        while (inicio < fim)
        {
            if (texto[inicio] != texto[fim])
            {
                palindromo = false;
                break;
            }
            inicio++;
            fim--;
        }
        if (palindromo)
        {
            Console.WriteLine("É um palíndromo!");
        }
        else
        {
            Console.WriteLine("Não é um palíndromo!");
        }
    }
}