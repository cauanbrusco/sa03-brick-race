using NAudio.Wave;

namespace BrickRace
{
    /// <summary>
    /// Efeitos sonoros do jogo usando os arquivos MP3 do projeto.
    /// </summary>
    public static class EfeitosSonoros
    {
        public static void TocarColisao()
        {
            ReproduzirArquivo(Constantes.CAMINHO_SOM_PERDA_VIDA);
        }

        public static void TocarSubidaDeNivel()
        {
            // Evita sobreposição com a trilha principal do jogo.
        }

        public static void TocarDerrota()
        {
            MusicaDeFundo.Parar();
            ReproduzirArquivo(Constantes.CAMINHO_SOM_DERROTA);
        }

        private static void ReproduzirArquivo(string caminho)
        {
            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            var caminhoResolvido = ResolverCaminho(caminho);
            if (string.IsNullOrWhiteSpace(caminhoResolvido))
            {
                return;
            }

            try
            {
                using var reader = new AudioFileReader(caminhoResolvido);
                using var player = new WaveOutEvent();
                player.Init(reader);
                player.Play();
                while (player.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(50);
                }
            }
            catch
            {
            }
        }

        private static string? ResolverCaminho(string caminho)
        {
            if (string.IsNullOrWhiteSpace(caminho))
            {
                return null;
            }

            var locais = new List<string>
            {
                Path.Combine(Directory.GetCurrentDirectory(), caminho),
                Path.Combine(AppContext.BaseDirectory, caminho),
                Path.Combine(Directory.GetCurrentDirectory(), "Sons", caminho),
                Path.Combine(AppContext.BaseDirectory, "Sons", caminho)
            };

            foreach (var local in locais)
            {
                if (File.Exists(local))
                {
                    return local;
                }
            }

            return null;
        }
    }
}
