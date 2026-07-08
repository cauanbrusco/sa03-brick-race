namespace BrickRace
{
    public class Menu
    {
        public void Mostrar(int recorde)
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

        public void MostrarInstrucoes()
        {
            Console.Clear();
            Console.WriteLine("=== Instruções ===");
            Console.WriteLine("Use A/D ou as setas para se mover entre 2 pistas.");
            Console.WriteLine("Desvie dos obstáculos.");
            Console.WriteLine("Se bater, perde uma vida.");
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para voltar.");
            Console.ReadLine();
        }

        public void MostrarOpcaoInvalida()
        {
            Console.WriteLine();
            Console.WriteLine("Opção inválida. Tente novamente.");
            Console.WriteLine("Pressione ENTER para continuar.");
            Console.ReadLine();
        }
    }
}
