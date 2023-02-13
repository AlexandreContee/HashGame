using JogoVelha.Enums;
using JogoVelha.Exceptions;
using JogoVelha.Jogabilidade;

namespace JogoVelha
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                bool continua = true;
                Jogo jogo = new Jogo();
                int jogadas = 0;
                Jogador jogador = Jogador.JOGADOR1;
                Tabuleiro tabuleiro = new Tabuleiro(3, 3);
                tabuleiro.PreencherTabuleiroInicial();
                bool fimDeJogo = true;

                while (continua)
                {
                    tabuleiro.PreencherTabuleiroInicial();
                    jogo.MostraMenu();
                    Jogador vencedor = Jogador.None;
                    int menuResposta = int.Parse(Console.ReadLine());

                    if (menuResposta == 0)
                    {
                        continua = true;
                        fimDeJogo = false;
                    }
                    else
                    {
                        continua = false;
                        fimDeJogo = true;
                    }
                    jogadas = 0;
                    while (!fimDeJogo && jogadas < 9)
                    {
                        jogadas = 0;
                        
                        vencedor = Jogador.None;
                        Console.Clear();
                        tabuleiro.ImprimeTabuleiro();
                        Console.WriteLine(jogador);
                        Console.Write("Digite o número da linha escolhida (1-3): ");
                        int linha = int.Parse(Console.ReadLine()) - 1;
                        Console.Write("Digite o número da coluna escolhida (1-3): ");
                        int coluna = int.Parse(Console.ReadLine()) - 1;

                        while (jogo.JogadaEhValida(linha, coluna, tabuleiro.Tab) == false)
                        {
                            Console.WriteLine("Jogada Inválida, a posição escolhida já está ocupada!");
                            Console.WriteLine(jogador);
                            Console.Write("Digite o número da linha escolhida (1-3): ");
                            linha = int.Parse(Console.ReadLine()) - 1;
                            Console.Write("Digite o número da coluna escolhida (1-3): ");
                            coluna = int.Parse(Console.ReadLine()) - 1;
                        }

                        if (jogador == Jogador.JOGADOR1)
                        {
                            tabuleiro.Jogador1Joga(linha, coluna);
                            jogadas++;
                            if (tabuleiro.VerificaGanhador(linha, coluna))
                            {
                                vencedor = Jogador.JOGADOR1;
                                fimDeJogo = true;
                                break;
                            }
                            else
                            {
                                jogador = Jogador.JOGADOR2;
                            }
                        }
                        else
                        {
                            tabuleiro.Jogador2Joga(linha, coluna);
                            jogadas++;
                            if (tabuleiro.VerificaGanhador(linha, coluna))
                            {
                                vencedor = Jogador.JOGADOR2;
                                fimDeJogo = true;
                                break;
                            }
                            else
                            {
                                jogador = Jogador.JOGADOR1;
                            }
                        }
                    }
                    Console.Clear();
                    
                    Console.WriteLine("Fim de jogo!");
                    if (vencedor == Jogador.None && jogadas > 0)
                    {
                        tabuleiro.ImprimeTabuleiro();
                        Console.WriteLine("Empatou!");
                    }
                    else if (vencedor != Jogador.None && jogadas > 0)
                    {
                        tabuleiro.ImprimeTabuleiro();
                        Console.WriteLine($"{vencedor} venceu!");
                    }
                }
            }
            catch (GameExceptions e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
