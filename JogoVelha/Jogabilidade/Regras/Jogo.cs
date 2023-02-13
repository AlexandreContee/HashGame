namespace JogoVelha.Jogabilidade
{
    internal class Jogo
    {
        public Jogo() { }

        public void MostraMenu()
        {
            Console.WriteLine("Jogo da Velha");
            Console.WriteLine("0 - Novo Jogo");
            Console.WriteLine("1 - Sair");
        }

        public bool JogadaEhValida(int linhaEscolhida, int colunaEscolhida, char[,] tabuleiro)
        {
            if (tabuleiro[linhaEscolhida, colunaEscolhida] == ' ')
            {
                return true;
            }
            return false;
        }
    }
}
