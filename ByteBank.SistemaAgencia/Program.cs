using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 1),
                new ContaCorrente(342, 999),
                null,
                new ContaCorrente(340, 4),
                new ContaCorrente(340, 456),
                new ContaCorrente(340, 10),
                null,
                null,
                new ContaCorrente(290, 123)
            };

            //contas.Sort(new ComparadorContaCorrentePorAgencia());

            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
                if(conta != null)
                { 
                    Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
                }
            }

            Console.ReadLine();
        }

        static void TestaSort()
        {
            var nomes = new List<string>()
            {
                "Wellington",
                "Guilherme",
                "Luana",
                "Ana"
            };

            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }

            var idades = new List<int>();

            idades.Add(1);
            idades.Add(5);
            idades.Add(14);
            idades.Add(25);
            idades.Add(38);
            idades.Add(61);

            idades.AdicionarVarios(45, 89, 12);

            idades.AdicionarVarios(99, -1);


            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }
        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(4);
            listaDeIdades.Adicionar("um texto qualquer");
            listaDeIdades.AdicionarVarios(16, 23, 60);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Idade no indice {i}: {idade}");
            }
        }

        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach (int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }


        static void TestaListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaDoGui = new ContaCorrente(11111, 1111111);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679754)
            };

            lista.AdicionarVarios(contas);

            lista.AdicionarVarios(
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787)
            );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }
        }

        static void TesteArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 4456668),
                new ContaCorrente(874, 7781438),
            };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Numero}");
            }

            Console.ReadLine();
        }

        static void TestaArrayInt()
        {
            // ARRAY de inteiros, com 5 posições!
            int[] idades = null;
            idades = new int[3];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            //idades[3] = 50;
            //idades[4] = 28;
            //idades[5] = 60;

            Console.WriteLine(idades.Length);

            int acumulador = 0;
            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acessando o array idades no índice {indice}");
                Console.WriteLine($"Valor de idades[{indice}] = {idade}");

                acumulador += idade;
            }

            int media = acumulador / idades.Length;
            Console.WriteLine($"Média de idades = {media}");

            Console.ReadLine();
        }
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Olá, mundo!");
        //    Console.WriteLine(123);
        //    Console.WriteLine(10.5);
        //    Console.WriteLine(true);

        //    object conta = new ContaCorrente(456, 687876);
        //    object desenvolvedor = new Desenvolvedor("4564654");

        //    string contaToString = conta.ToString();

        //    Console.WriteLine("Resultado " + contaToString);
        //    Console.WriteLine(conta);

        //    Cliente carlos_1 = new Cliente();
        //    carlos_1.Nome = "Carlos";
        //    carlos_1.CPF = "458.623.120-03";
        //    carlos_1.Profissao = "Designer";

        //    Cliente carlos_2 = new Cliente();
        //    carlos_2.Nome = "Carlos";
        //    carlos_2.CPF = "458.623.120-03";
        //    carlos_2.Profissao = "Designer";

        //    if (carlos_1.Equals(carlos_2))
        //    {
        //        Console.WriteLine("São iguais!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Não são iguais!");
        //    }

        //    Console.ReadLine();
        //}

        //static void TestaString()
        //{
        //    // Olá, meu nome é Guilherme e você pode entrar em contato comigo
        //    // através do número 8457-4456!

        //    // Meu nome é Guilherme, me ligue em 4784-4546

        //    // string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
        //    // string padrao = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
        //    // string padrao = "[0-9]{4,5}[-][0-9]{4}";
        //    // string padrao = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
        //    // string padrao = "[0-9]{4,5}-{0,1}[0-9]{4}";
        //    string padrao = "[0-9]{4,5}-?[0-9]{4}";
        //    string textoDeTeste = "ajgdjgjagsygaugsa 99871-5456 aygsygsygua auyakjskjs";

        //    Match resultado = Regex.Match(textoDeTeste, padrao);

        //    Console.WriteLine(resultado.Value);
        //    Console.ReadLine();

        //    string urlTeste = "https://www.bytebank.com/cambio";
        //    int indiceByteBank = urlTeste.IndexOf("https://www.bytebank.com");

        //    Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com"));
        //    Console.WriteLine(urlTeste.EndsWith("cambio/"));

        //    Console.WriteLine(urlTeste.Contains("ByteBank"));


        //    Console.ReadLine();
        //    // pagina?argumentos
        //    // 012345678


        //    //moedaOrigem=real&moedaDestino=dolar
        //    //
        //    //             ----------------´


        //    string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
        //    ExtratorValorDeArgumentosURL extratorDeValores = new ExtratorValorDeArgumentosURL(urlParametros);

        //    string valor = extratorDeValores.GetValor("moedaDestino");
        //    Console.WriteLine("Valor de moedaDestino: " + valor);

        //    string valorMoedaOrigem = extratorDeValores.GetValor("moedaOrigem");
        //    Console.WriteLine("Valor de moedaOrigem: " + valorMoedaOrigem);

        //    Console.WriteLine(extratorDeValores.GetValor("VALOR"));

        //    Console.ReadLine();

        //    // Testando o método Remove
        //    string testeRemocao = "primeiraParte&123456789";
        //    int indiceEComercial = testeRemocao.IndexOf('&');
        //    Console.WriteLine(testeRemocao.Remove(indiceEComercial, 4));
        //    Console.ReadLine();

        //    // <nome>=<valor>
        //    string palavra = "moedaOrigem=moedaDestino&moedaDestino=dolar";
        //    string nomeArgumento = "moedaDestino=";

        //    int indice = palavra.IndexOf(nomeArgumento);
        //    Console.WriteLine(indice);

        //    Console.WriteLine("Tamanho da string nomeArgumento: " + nomeArgumento.Length);

        //    Console.WriteLine(palavra);
        //    Console.WriteLine(palavra.Substring(indice));
        //    Console.WriteLine(palavra.Substring(indice + nomeArgumento.Length));
        //    Console.ReadLine();

        //    // Testando o IsNullOrEmpty
        //    string textoVazio = "";
        //    string textoNulo = null;
        //    string textoQualquer = "kjhfsdjhgsdfjksdf";


        //    Console.WriteLine(String.IsNullOrEmpty(textoVazio));
        //    Console.WriteLine(String.IsNullOrEmpty(textoNulo));
        //    Console.WriteLine(String.IsNullOrEmpty(textoQualquer));
        //    Console.ReadLine();






        //    ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL("");

        //    string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

        //    int indiceInterrogacao = url.IndexOf('?');

        //    Console.WriteLine(indiceInterrogacao);

        //    Console.WriteLine(url);
        //    string argumentos = url.Substring(indiceInterrogacao + 1);
        //    Console.WriteLine(argumentos);
        //}
    }


}
