namespace BrickRace
{
    /// <summary>
    /// Efeitos sonoros do jogo usando beeps simples para evitar dependências externas.
    /// </summary>
    public static class EfeitosSonoros
    {
        public static void TocarColisao()
        {
            TocarSemBloquear(() => Console.Beep(440, 120));
        }

        public static void TocarSubidaDeNivel()
        {
            TocarSemBloquear(() =>
            {
                Console.Beep(523, 90);
                Console.Beep(659, 90);
                Console.Beep(784, 140);
            });
        }

        public static void TocarDerrota()
        {
            TocarSemBloquear(() => Console.Beep(220, 300));
        }

        private static void TocarSemBloquear(Action efeito)
        {
            Task.Run(() =>
            {
                efeito();
            });
        }
    }
}
