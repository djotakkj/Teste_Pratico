using System;

// esse código simula o cadastro de um orçamento para um cliente e veículo específicos
// validando os dados de entrada e calculando o valor total do orçamento com base nos itens listados.
class Program
{
    static void Main()
    {
        int clienteId = 10;
        int veiculoId = 25;

        // Lista de itens do orçamento
        OrcamentoItem[] itens =
        {
            new OrcamentoItem("Troca de óleo", 1, 120),
            new OrcamentoItem("Filtro de óleo", 1, 45)
        };

        // Valida o cliente
        if (clienteId <= 0)
        {
            Console.WriteLine("clienteId é obrigatório.");
            return;
        }

        // Valida o veículo
        if (veiculoId <= 0)
        {
            Console.WriteLine("veiculoId é obrigatório.");
            return;
        }

        // Verifica se há itens no orçamento
        if (itens.Length == 0)
        {
            Console.WriteLine("O orçamento deve possuir pelo menos 1 item.");
            return;
        }

        decimal valorTotal = 0;

        foreach (var item in itens)
        {  
            
            // Valida os campos de cada item
            if (string.IsNullOrWhiteSpace(item.Descricao))
            {
                Console.WriteLine("Descrição do item é obrigatória.");
                return;
            }

            if (item.Quantidade <= 0)
            {
                Console.WriteLine("Quantidade deve ser maior que zero.");
                return;
            }

            if (item.ValorUnitario <= 0)
            {
                Console.WriteLine("Valor unitário deve ser maior que zero.");
                return;
            }

            //Soma o valor total do orçamento
            valorTotal += item.Quantidade * item.ValorUnitario;
        }

        Console.WriteLine("Orçamento cadastrado com sucesso.");
        Console.WriteLine($"Valor total: R$ {valorTotal}");
    }
}

class OrcamentoItem
{
    public string Descricao;
    public int Quantidade;
    public decimal ValorUnitario;

    public OrcamentoItem(string descricao, int quantidade, decimal valorUnitario)
    {
        Descricao = descricao;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
    }
}