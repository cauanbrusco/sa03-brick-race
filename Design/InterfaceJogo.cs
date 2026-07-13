namespace BrickRace
{
    public static class Tela
    {
        public static void MostrarMenu(int recorde)
        {
            Console.Clear();
            Console.WriteLine("=== Brick Race ===");
            Console.WriteLine($"Recorde atual: {recorde}");
            Console.WriteLine();
            Console.WriteLine("1 - Jogar");
            Console.WriteLine("2 - Instruções");
            Console.WriteLine("3 - Último resultado");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
        }

        public static void MostrarInstrucoes()
        {
            Console.Clear();
            Console.WriteLine("=== Instruções ===");
            Console.WriteLine("Use A/D ou as setas para se mover entre as pistas.");
            Console.WriteLine("Desvie dos obstáculos e sobreviva o maior tempo possível.");
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para voltar.");
            Console.ReadLine();
        }

        public static void MostrarFimDeJogo(ResultadoPartida resultado)
        {
            Console.Clear();
            Console.WriteLine("=== Fim de jogo ===");
            Console.WriteLine($"Pontuação: {resultado.Pontuacao}");
            Console.WriteLine($"Nível: {resultado.Nivel}");
            Console.WriteLine($"Obstáculos desviados: {resultado.ObstaculosDesviados}");
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para continuar.");
            Console.ReadLine();
        }

        public static void MostrarUltimoResultado(ResultadoPartida? resultado)
        {
            Console.Clear();
            Console.WriteLine("=== Último resultado ===");
            if (resultado is null)
            {
                Console.WriteLine("Nenhum resultado salvo ainda.");
            }
            else
            {
                Console.WriteLine($"Pontuação: {resultado.Pontuacao}");
                Console.WriteLine($"Nível: {resultado.Nivel}");
                Console.WriteLine($"Obstáculos desviados: {resultado.ObstaculosDesviados}");
            }

            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para voltar.");
            Console.ReadLine();
        }

        public static void MostrarOpcaoInvalidaMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Opção inválida. Tente novamente.");
            Console.WriteLine("Pressione ENTER para continuar.");
            Console.ReadLine();
        }

        public static void DesenharPartida(Carro carro, List<Obstaculo> obstaculos, int pontuacao, int recorde, int nivel, int vidas, int velocidadeMs)
        {
            Console.Clear();
            Console.WriteLine($"Brick Race | Pontuação: {pontuacao} | Recorde: {recorde}");
            Console.WriteLine($"Nível: {nivel} | Vidas: {vidas} | Velocidade: {velocidadeMs}ms");
            Console.WriteLine(new string('-', 40));

            for (int linha = 0; linha < Constantes.ALTURA_TELA; linha++)
            {
                string pistaEsquerda = obstaculos.Any(o => o.Ativo && o.Pista == 0 && o.Linha == linha) ? "X" : " ";
                string pistaDireita = obstaculos.Any(o => o.Ativo && o.Pista == 1 && o.Linha == linha) ? "X" : " ";
                string carroNaLinha = linha == Constantes.ALTURA_TELA - 1 && carro.Pista == 0 ? "C" : " ";
                string carroNaLinhaDireita = linha == Constantes.ALTURA_TELA - 1 && carro.Pista == 1 ? "C" : " ";

                Console.WriteLine($"|{pistaEsquerda}{carroNaLinha}|{pistaDireita}{carroNaLinhaDireita}|");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}
