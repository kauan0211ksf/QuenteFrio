﻿Console.Clear();

Random random = new Random();
int numeroSorteado = random.Next(1, 101);
int numeroTentativas = 0;
bool acertou = false;

Console.WriteLine("--- Jogo de Adivinhação ---\n");
Console.WriteLine("Tente adivinhar o número secreto entre 1 e 100.\n");
Console.WriteLine("Você tem no máximo 7 tentativas.\n");

while (numeroTentativas < 7 && !acertou)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Digite o seu palpite: ");
    Console.ResetColor();
    int palpite;

    if (!int.TryParse(Console.ReadLine(), out palpite)){
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Entrada inválida. Tente novamente.\n");
        Console.ResetColor();
        continue;
    }

    numeroTentativas++;

    if (palpite == numeroSorteado){
        acertou = true;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nParabéns! Você acertou o número secreto!");
        Console.ResetColor();
        Console.WriteLine($"Número de tentativas:"); 
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"{numeroTentativas}\n");
        Console.ResetColor();
    }
    else {
    string dica;
    int diferenca = Math.Abs(palpite - numeroSorteado);

    if (diferenca <= 3){
        dica = "Está pelando!";
    }
    else if (diferenca <= 10){
        dica = "Está quente!";
    }
    else if (diferenca >= 30){
        dica = "Está congelando!";
    }
    else{
        dica = "Está frio!";
    }

        Console.WriteLine($"{dica} O número secreto é {(palpite < numeroSorteado ? "maior" : "menor")} do que o palpite.\n");
    }
}

if (!acertou)
{
    Console.WriteLine("\nVocê excedeu o número máximo de tentativas. Você perdeu o jogo!");
    Console.WriteLine($"O número secreto era: {numeroSorteado}\n");
}

Console.WriteLine("Fim do jogo. Obrigado por jogar!\n");

Console.ResetColor();