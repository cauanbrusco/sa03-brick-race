namespace BrickRace
{
    /// <summary>
    /// Constantes globais do jogo Brick Race.
    /// </summary>
    public static class Constantes
    {
        // Vida do jogador
        public const int VIDAS_INICIAIS = 3;

        // Velocidade (ms)
        public const int VELOCIDADE_INICIAL_MS = 200;
        public const int VELOCIDADE_MINIMA_MS = 50;
        public const int REDUCAO_VELOCIDADE_POR_NIVEL_MS = 20;

        // Pontuação
        public const int PONTOS_POR_DESVIO = 10;
        public const int PONTOS_PARA_SUBIR_NIVEL = 50;

        // Obstáculos
        public const int LINHA_COLISAO = 18;
        public const int MIN_OBSTACULOS_SIMULTANEOS = 2;
        public const int MAX_OBSTACULOS_SIMULTANEOS = 3;
        public const int MARGEM_SEGURANCA_GERACAO = 6;

        // Caminhos
        public const string CAMINHO_TRILHA_SONORA = "Final_Lap_Rush.mp3";
        public const string CAMINHO_SOM_PERDA_VIDA = "perdeu-vida.mp3";
        public const string CAMINHO_SOM_DERROTA = "som-perdeu-2.mp3";
        public const string CAMINHO_ARQUIVO_RECORDE = "recorde.txt";
        public const string CAMINHO_ARQUIVO_ULTIMO_RESULTADO = "ultimo_resultado.txt";

        // Dimensões da tela
        public const int ALTURA_TELA = 20;
        public const int LARGURA_TELA = 40;

        // Pistas do jogo
        public const int NUM_PISTAS = 2;
        public const int LARGURA_PISTA = 20;
        public static readonly int[] PISTA_X = new int[] { 6, 26 };
    }
}
