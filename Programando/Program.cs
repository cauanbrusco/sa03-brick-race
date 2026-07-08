using System;

namespace BrickRace
{
    // Esta é a classe principal do programa.
    // É aqui que o jogo começa a rodar.
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Configura o console para mostrar acentos e caracteres especiais corretamente
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Essa variável controla se o programa deve continuar rodando ou não
            // 0 significa "continuar rodando" e 1 significa "sair do programa"
            int sairDoPrograma = 0;

            // Enquanto sairDoPrograma for igual a 0, o menu continua aparecendo
            while (sairDoPrograma == 0)
            {
                // Busca o recorde salvo para mostrar no menu
                int recorde = Persistencia.CarregarRecorde();

                // Mostra o menu na tela
                Tela.MostrarMenu(recorde);

                // Lê o que o jogador digitou
                string entrada = Console.ReadLine();

                // Verifica qual opção o jogador escolheu, uma por uma
                if (entrada == "1")
                {
                    // Cria um novo jogo
                    Jogo jogo = new Jogo();

                    // Inicia o jogo e guarda o resultado
                    ResultadoPartida resultado = jogo.Iniciar();

                    // Mostra o resultado final na tela
                    Tela.MostrarFimDeJogo(resultado);
                }
                else if (entrada == "2")
                {
                    // Mostra as instruções do jogo
                    Tela.MostrarInstrucoes();
                }
                else if (entrada == "3")
                {
                    // Carrega o último resultado salvo
                    ResultadoPartida ultimoResultado = Persistencia.CarregarUltimoResultado();

                    // Mostra esse último resultado na tela
                    Tela.MostrarUltimoResultado(ultimoResultado);
                }
                else if (entrada == "0")
                {
                    // O jogador escolheu sair, então muda o valor para 1
                    sairDoPrograma = 1;
                }
                else
                {
                    // Se o jogador digitar qualquer outra coisa, avisa que é inválido
                    Tela.MostrarOpcaoInvalidaMenu();
                }
            }

            // Quando o loop termina, limpa a tela e mostra mensagem de despedida
            Console.Clear();
            Console.WriteLine("Obrigado por jogar Brick Race!");
        }
    }
}

