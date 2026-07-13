namespace BrickRace
{
    public class Painel
    {
        public void Mostrar(int pontuacao, int recorde, int nivel, int vidas, int velocidadeMs)
        {
            Console.SetCursorPosition(0, Constantes.ALTURA_TELA + 1);
            Console.WriteLine($"Pontos: {pontuacao} | Recorde: {recorde} | Nível: {nivel} | Vidas: {vidas} | Velocidade: {velocidadeMs}ms");
            Console.WriteLine("Use A/D ou setas para mover entre as 2 pistas. ESC para sair.");
        }
    }
}
