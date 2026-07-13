namespace BrickRace
{
    public class Carro
    {
        public int Pista { get; private set; }

        public Carro(int pistaInicial)
        {
            Pista = pistaInicial;
        }

        public void MoverParaEsquerda()
        {
            Pista = Math.Max(0, Pista - 1);
        }

        public void MoverParaDireita()
        {
            Pista = Math.Min(1, Pista + 1);
        }
    }

    public class Obstaculo
    {
        public int Linha { get; private set; }
        public int Pista { get; private set; }
        public int Tipo { get; }
        public bool Ativo { get; set; }
        public bool JaContabilizado { get; set; }

        public Obstaculo(int linhaInicial, int pista, int tipo)
        {
            Linha = linhaInicial;
            Pista = pista;
            Tipo = tipo;
            Ativo = true;
        }

        public void Descer(int quantidade = 1)
        {
            Linha += Math.Max(1, quantidade);
        }

        public bool ForaDaTela()
        {
            return Linha > 25;
        }
    }

    public class Colisao
    {
        public bool Ocorreu(Carro carro, Obstaculo obstaculo)
        {
            return obstaculo.Ativo && obstaculo.Pista == carro.Pista;
        }
    }

    public class ResultadoPartida
    {
        public int Pontuacao { get; set; }
        public int Nivel { get; set; }
        public int ObstaculosDesviados { get; set; }

        public static ResultadoPartida? DeTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return null;
            }

            string[] partes = texto.Split('|');
            if (partes.Length < 3)
            {
                return null;
            }

            return new ResultadoPartida
            {
                Pontuacao = int.Parse(partes[0]),
                Nivel = int.Parse(partes[1]),
                ObstaculosDesviados = int.Parse(partes[2])
            };
        }

        public override string ToString()
        {
            return $"{Pontuacao}|{Nivel}|{ObstaculosDesviados}";
        }
    }
}
