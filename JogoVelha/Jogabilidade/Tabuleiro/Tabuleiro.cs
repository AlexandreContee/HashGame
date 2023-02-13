namespace JogoVelha.Jogabilidade;

class Tabuleiro
{
    public char[,] Tab { get; set; }

    public Tabuleiro(int linhas, int colunas)
    {
        Tab = new char[linhas, colunas];
    }

    public void ImprimeTabuleiro()
    {
        Console.WriteLine();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Tab[i, j] == ' ')
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(Tab[i, j]);
                }
                if (j != 2)
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            if (i != 2)
            {
                Console.WriteLine("-----");
            }
        }
    }

    public void PreencherTabuleiroInicial()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Tab[i, j] = ' ';
            }
        }
    }

    public void Jogador1Joga(int linhaEscolhida, int colunaEscolhida)
    {
        Tab[linhaEscolhida, colunaEscolhida] = 'X';
    }

    public void Jogador2Joga(int linhaEscolhida, int colunaEscolhida)
    {
        Tab[linhaEscolhida, colunaEscolhida] = 'O';
    }

    public bool VerificaGanhador(int linha, int coluna)
    {
        // verificar linhas
        for (int j = 0; j < 3; j++)
        {
            if (Tab[linha, j] != Tab[linha, coluna])
            {
                break;
            }
            if (j == 2)
            {
                return true;
            }
        }

        // verificar colunas
        for (int i = 0; i < 3; i++)
        {
            if (Tab[i, coluna] != Tab[linha, coluna])
            {
                break;
            }
            if (i == 2)
            {
                return true;
            }
        }

        // verificar a diagonal principal
        for (int cont = 0; cont < 3; cont++)
        {
            if (Tab[cont, cont] != Tab[linha, coluna])
            {
                break;
            }
            if (cont == 2)
            {
                return true;
            }
        }

        // verificar a diagonal secundária
        if (linha + coluna == 2)
        {
            for (int cont = 0; cont < 3; cont++)
            {
                if (Tab[cont, 2 - cont] != Tab[linha, coluna])
                {
                    break;
                }
                if (cont == 2)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
