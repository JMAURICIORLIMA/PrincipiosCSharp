using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("INFORME O NOME DO ALUNO: ");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        
                        Console.WriteLine("INFORME A NOTA DO ALUNO: ");
                        if (decimal.TryParse(Console.ReadLine(), out var nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArithmeticException("VALOR DA NOTA DE SER DECIMAL");
                        }
                        
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach (var alu in alunos)
                        {
                            if (!string.IsNullOrEmpty(alu.Nome))
                            {
                            Console.WriteLine($"ALUNO: {alu.Nome}\n NOTA: {alu.Nota}\n");
                            Console.WriteLine("-------------------------------");                            
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        ConceitoEnum conceitoGeral;

                        if(mediaGeral < 2)
                        {
                            conceitoGeral = ConceitoEnum.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = ConceitoEnum.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = ConceitoEnum.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = ConceitoEnum.B;
                        }
                        else
                        {
                            conceitoGeral = ConceitoEnum.A;
                        }


                        Console.WriteLine($"MEDIA GERAL: {mediaGeral}\n CONCEITO: {conceitoGeral}");
                        Console.WriteLine("-------------------------------");


                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\n-------------------------------");
            Console.WriteLine("   INFORME A OPÇÃO DESEJADA: ");
            Console.WriteLine("1- INSERIR ALUNO");
            Console.WriteLine("2- LISTAR ALUNOS");
            Console.WriteLine("3- CALCULAR MÉDIA GERAL");
            Console.WriteLine("X- SAIR");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
