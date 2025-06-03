using System.Security.Cryptography;

Console.Clear();

Console.WriteLine("--- Pedra, Papel e Tesoura ---\n");
Console.WriteLine("Pedra = 0, Papel = 1, Tesoura = 2\n");

string[,] mensagens = {
    {"Empate.","Pedra é coberta pelo papel.","Pedra quebra tesoura."},
    {"Papel cobre pedra.","Empate.","Papel é cortado pela tesoura."},
    {"Tesoura é quebrada pela pedra.","Tesoura corta papel.","Empate."},
};

int[,] resultado = {
    {0, -1, 1},
    {1, 0, -1},
    {-1, 1, 0},
};

const int Pedra = 0;

string[] opcoes = { "Pedra", "Papel", "Tesoura" };

const int MaosParaVencer = 5;

int vitoriasJogador = 0, vitoriasCPU = 0;

int jogadaHumano = -1, jogadaCPU = -1;
int jogadaAnteriorHumano, jogadaAnteriorCPU;

string mensagemResultado = "";
ConsoleColor corResultado = ConsoleColor.White;

while (vitoriasJogador < MaosParaVencer && vitoriasCPU < MaosParaVencer)
{
    jogadaAnteriorHumano = jogadaHumano;
    jogadaAnteriorCPU = jogadaCPU;

    Console.Write("Sua mão: ");
    string entrada = Console.ReadLine()!.Trim();

    if (entrada != "0" && entrada != "1" && entrada != "2")
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Pedra = 0, Papel = 1, Tesoura = 2");
        Console.ResetColor();

        jogadaHumano = jogadaAnteriorHumano;
        continue;
    }
    jogadaHumano = Convert.ToInt32(entrada);

    if (jogadaHumano == Pedra && jogadaAnteriorHumano == Pedra)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Não pode jogar pedra duas vezes seguidas.");
        Console.ResetColor();

        continue;
    }

    jogadaCPU = EscolherJogadaCPU(jogadaAnteriorCPU != Pedra);

    if (resultado[jogadaHumano, jogadaCPU] == 1)
    {
        corResultado = ConsoleColor.Green;
        mensagemResultado = "Você ganhou!!";
        vitoriasJogador++;
    }
    else if (resultado[jogadaHumano, jogadaCPU] == -1)
    {
        corResultado = ConsoleColor.Red;
        mensagemResultado = "Você perdeu :(";
        vitoriasCPU++;
    }
    else
    {
        corResultado = ConsoleColor.White;
        mensagemResultado = "";
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"Humano => {opcoes[jogadaHumano]}");

    Console.ResetColor();
    Console.Write(", ");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\tCPU => {opcoes[jogadaCPU]}");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(mensagens[jogadaHumano, jogadaCPU]);

    Console.ForegroundColor = corResultado;
    Console.WriteLine($" {mensagemResultado}");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"Humano  = {vitoriasJogador}");

    Console.ResetColor();
    Console.Write(", ");

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\t\tCPU  = {vitoriasCPU}");

    Console.ResetColor();
    Console.WriteLine();
}

if (vitoriasJogador == MaosParaVencer)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Você ganhou a partida. Parabéns!");
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Você perdeu para a máquina. Boa sorte na próxima vez.");
}

Console.ResetColor();

int EscolherJogadaCPU(bool permitirPedra)
{
    if (permitirPedra) return RandomNumberGenerator.GetInt32(0, 3);
    return RandomNumberGenerator.GetInt32(1, 3);
}
