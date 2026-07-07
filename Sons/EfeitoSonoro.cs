using NAudio.Wave;

namespace BrickRace
{
    /// <summary>
    /// Efeitos sonoros do jogo, incluindo áudio MP3 para eventos importantes.
    /// </summary>
    public static class EfeitosSonoros
    {
        public static void TocarColisao()
        {
            TocarArquivoSemBloquear(Constantes.CAMINHO_SOM_PERDA_VIDA);
        }

        public static void TocarSubidaDeNivel()
        {
            TocarSemBloquear(() =>
            {
                Console.Beep(523, 90);  // C5
                Console.Beep(659, 90);  // E5
                Console.Beep(784, 140); // G5
            });
        }

        public static void TocarDerrota()
        {
            TocarArquivoSemBloquear(Constantes.CAMINHO_SOM_DERROTA);
        }

        private static void TocarSemBloquear(Action efeito)
        {
            Task.Run(() =>
            {
                efeito();
            });
        }

        private static void TocarArquivoSemBloquear(string caminho)
        {
            Task.Run(() =>
            {
                if (string.IsNullOrWhiteSpace(caminho))
                {
                    return;
                }

                string caminhoBase = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, caminho));
                if (!File.Exists(caminhoBase))
                {
                    return;
                }

                using AudioFileReader reader = new AudioFileReader(caminhoBase);
                using WaveOutEvent output = new WaveOutEvent();
                output.Init(reader);
                output.Play();

                while (output.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
            });
        }
    }
}
