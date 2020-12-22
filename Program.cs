using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {

            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                            aluno.Nota = nota;

                        else
                            throw new ArgumentException("O valor da nota deve ser decimal");

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        
                        for (int i = 0; i < indiceAluno; i++)
                            notaTotal = notaTotal + alunos[i].Nota;

                        var mediaGeral = notaTotal / indiceAluno;

                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                            conceitoGeral = Conceito.E;

                        else if (mediaGeral < 4)
                            conceitoGeral = Conceito.D;
                        
                        else if (mediaGeral < 6)
                            conceitoGeral = Conceito.C;
                        
                        else if (mediaGeral < 8)
                            conceitoGeral = Conceito.B;

                        else
                            conceitoGeral = Conceito.A;

                        Console.WriteLine($"Média Geral: {mediaGeral} - Conceito Geral: {conceitoGeral}");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = obterOpcaoUsuario();
            }
        }
        
        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
