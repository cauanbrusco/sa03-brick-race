using NAudio.Wave;

namespace BrickRace
{
    /// <summary>
    /// Responsável por tocar a trilha de fundo do jogo.
    /// Usa um arquivo MP3 quando ele existir na pasta do projeto.
    /// </summary>
    public static class MusicaDeFundo
    {
        private static Task? _tarefa;
        private static CancellationTokenSource? _tokenSource;

        public static void Tocar(string caminho)
        {
            if (_tarefa is { IsCompleted: false })
            {
                return;
            }

            _tokenSource?.Dispose();
            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;

            _tarefa = Task.Run(() => Reproduzir(caminho, token), token);
        }

        public static void Parar()
        {
            if (_tokenSource == null)
            {
                return;
            }

            _tokenSource.Cancel();
            _tokenSource.Dispose();
            _tokenSource = null;
            _tarefa = null;
        }

        private static void Reproduzir(string caminho, CancellationToken token)
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

            if (!OperatingSystem.IsWindows())
            {
                return;
            }

            while (!token.IsCancellationRequested)
            {
                using AudioFileReader reader = new AudioFileReader(caminhoBase);
                using WaveOutEvent output = new WaveOutEvent();
                output.Init(reader);
                output.Play();

                while (!token.IsCancellationRequested && output.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }

                output.Stop();
            }
        }
    }
}
