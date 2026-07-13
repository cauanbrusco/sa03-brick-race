namespace BrickRace
{
    /// <summary>
    /// Agrupa exemplos de funções recursivas usadas para manipular a lista
    /// de obstáculos do Brick Race.
    /// </summary>
    public static class Recursividade
    {
        public static int ContarObstaculosAtivos(List<Obstaculo> obstaculos, int indice = 0)
        {
            if (obstaculos is null || indice >= obstaculos.Count)
            {
                return 0;
            }

            int atual = obstaculos[indice].Ativo ? 1 : 0;
            return atual + ContarObstaculosAtivos(obstaculos, indice + 1);
        }

        public static bool ExisteConflito(List<Obstaculo> obstaculos, int indice, int pistaNova, int linhaNova)
        {
            if (obstaculos is null || indice >= obstaculos.Count)
            {
                return false;
            }

            var atual = obstaculos[indice];
            bool mesmaAlturaAproximada = Math.Abs(atual.Linha - linhaNova) <= Constantes.MARGEM_SEGURANCA_GERACAO;

            if (atual.Ativo && atual.Pista != pistaNova && mesmaAlturaAproximada)
            {
                return true;
            }

            return ExisteConflito(obstaculos, indice + 1, pistaNova, linhaNova);
        }
    }
}
