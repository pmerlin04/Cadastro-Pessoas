using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastramento
{
    internal class Cadastro
    {
        private int Id { get; set; }
        private string Nome { get; set; }
        private string Endereco { get; set; }
        private string Sexo { get; set; }
        private string EstadoCivil { get; set; }

        private bool opcao = true;

       private char opcaoRegistro;

        List<Cadastro> pessoas = new List<Cadastro>();

        public Cadastro()
        {
        }

        public Cadastro(int id, string nome, string endereco, string sexo, string estadoCivil)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
        }

        /*
            public void CadastroPessoas()
            {
                while (opcao == true)
                {
                    Console.WriteLine("Nome:");
                    Console.WriteLine("Endereço:");
                    Console.WriteLine("Sexo: ");
                    Console.WriteLine("estado: ");
                    Pessoa = Console.ReadLine().Split(' ');
                    cont++;

                    Console.WriteLine("Deseja continuar? ");
                    n1 = char.Parse(Console.ReadLine());
                    if (n1 == 'n')
                    {
                        opcao = false;
                    }
                }
                foreach (var p in Pessoa)
                {
                    Console.WriteLine(p);
                }
            }*/

        public void Menu()
        {
            int opcaoMenu = 0;
            Console.WriteLine("Digite a opção de Menu: ");
            Console.WriteLine("1 - Cadastro\n" 
                + "2 - Deletar Cadastro\n" 
                + "3 - Alterar Cadastro\n"
                + "4 - Mostrar Cadastro\n"
                + "5 - Sair");
            opcaoMenu = int.Parse(Console.ReadLine());
            switch (opcaoMenu)
            {
                case 1:
                    CadastroPessoas();
                break;

                case 2:
                    DeletarPessoas();
                break;

                case 3:
                    ModificarPessoas();
                break;

                case 4:
                    MostrarPessoas();
                    if (pessoas.Count == 0)
                    {
                        Console.WriteLine("Você não cadastrou nenhum registro");
                        Console.WriteLine("Deseja cadastrar? ");
                        opcaoRegistro = char.Parse(Console.ReadLine());
                        if(opcaoRegistro == 's')
                        CadastroPessoas();
                    }
                break;

                case 5:
                    Console.WriteLine("Fim do programa");
                break;

                default:
                    Menu();
                break;
            }
        }

        public void MostrarPessoas()
        {
            int n1 = 0;
            //mostrar o resultado
            foreach (var p in pessoas)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Deseja continuar? ");
            n1 = char.Parse(Console.ReadLine());
            if (n1 == 's')
            {
                Menu();//voltar para menu principal
            }else
                Console.WriteLine("Fim do programa");
        }

        //Cadastrar Pessoa
        public void CadastroPessoas()
        {
            string nome;
            string endereco;
            string sexo;
            string estado;
            char n1;
            int cont = 0;
            while (opcao == true)
            {
                //a variavel cont serve como uma chave primaria
                //identifica a pessoa cadastrada
                cont++;
                Console.WriteLine("Nome: ");
                nome = Console.ReadLine();
                Console.WriteLine("Endereço: ");
                endereco = Console.ReadLine();
                Console.WriteLine("Sexo: ");
                sexo = Console.ReadLine();
                Console.WriteLine("Estado civil: ");
                estado = Console.ReadLine();

                //atribui o valor das variaveis nos parametros dos atributos da classe
                pessoas.Add(new Cadastro(cont, nome, endereco, sexo, estado));


                Console.WriteLine("Deseja continuar cadastrando? ");
                n1 = char.Parse(Console.ReadLine());
                if (n1 == 'n')
                {
                    opcao = false;
                    Menu();//voltar para menu principal
                }
                else
                    CadastroPessoas();


            }

        }//Final do CadastroPessoas

        //Remover Pessoa
        public void DeletarPessoas()
        {
            int id = 0;
            int n1 = 0;
            Console.WriteLine("Digite o Id que deseja remover");
            id = int.Parse(Console.ReadLine());

            Cadastro cad = pessoas.Find(x => x.Id == id);
            if (cad != null)
            {
                pessoas.Remove(cad);
                Console.WriteLine($"O id {id} foi deletado com sucesso");
            }
            else
                Console.WriteLine($"O id {id} não existe");

            Console.WriteLine("Deseja continuar deletando? ");
            n1 = char.Parse(Console.ReadLine());
            if (n1 == 's')
            {
                DeletarPessoas();//voltar para menu principal
            }
            else
                Menu();


        }//final do DeletarPessoas

        //Modificar Pessoa
        public void ModificarPessoas()
        {
            int id = 0;
            int n1 = 0;
            Console.WriteLine("Insira o Id para atualizar: ");
            id = int.Parse(Console.ReadLine());

            Cadastro pessoa = pessoas.FirstOrDefault(x => x.Id == id);
            if (pessoa != null)
            {
                Console.WriteLine("Nome: ");
                pessoa.Nome = Console.ReadLine();
                Console.WriteLine("Endereco: ");
                pessoa.Endereco = Console.ReadLine();
                Console.WriteLine("Sexo: ");
                pessoa.Sexo = Console.ReadLine();
                Console.WriteLine("Estado Civil: ");
                pessoa.EstadoCivil = Console.ReadLine();

                Console.WriteLine(pessoa);

                Console.WriteLine("Deseja continuar? ");
                n1 = char.Parse(Console.ReadLine());
                if (n1 == 'n')
                {
                    opcao = false;
                    Menu();//voltar para menu principal
                }


            }
        }


        public override string ToString()
        {
            return Id 
                 + ": "
                 + Nome
                 + ",  "
                 + Endereco
                 + ", "
                 + Sexo
                 + ", "
                 + EstadoCivil;
        }









    }
}
