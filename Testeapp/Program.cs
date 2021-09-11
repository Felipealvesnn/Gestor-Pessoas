using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Testeapp
{
    class Program
    {
        static List<ISalvar> salvarpessoas = new List<ISalvar>();
        static void Main(string[] args)
        {
            int opcao;
            bool menu = false;
            Carregar();
            while (!menu)
            {
                Console.WriteLine("===== Menu =====");
                Console.WriteLine("digite\n1-cadastrar pessoa\n2-para Alterar pessoa\n3-Consultar pessoa\n4-Remover pessoa\n5-para sair");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    if (opcao >= 1 && opcao <= 5)
                    {
                        switch (opcao)
                        {
                            case 1:
                                Cadastrar();
                                break;
                            case 2:
                                Alterar();
                                Console.ReadKey();
                                break;
                            case 3:
                                Consultar();
                                Console.ReadKey();
                                break;
                            case 4:
                                Remover();
                                break;
                            case 5:
                                menu = true;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("opcao invalida");
                        Console.ReadKey();
                    }
                }
                catch
                {
                   Console.WriteLine("digitou errado, irmão");
                   Console.ReadKey();
                }
                Console.Clear();
            }

                void Cadastrar()
                {
                Console.Clear();
                Console.WriteLine("Digite o nome da pessoa");
                string nome=Console.ReadLine();
                Console.WriteLine("digite o telefone da people");
                int telefone = int.Parse(Console.ReadLine());
                Pessoa pf = new Pessoa(nome,telefone);
              
                salvarpessoas.Add(pf);
                  Salvar();
                 }

                 void Alterar()
                     {
                    Consultar();
                    Console.WriteLine("digite o id da pessoa q vc quer alterar");
                    int id=int.Parse(Console.ReadLine());
                    salvarpessoas[id].Adicionarpessoa();
                    salvarpessoas[id].Adicionartelefone();
                    }

            void Consultar()
            {
                Console.Clear();
                int id = 0;
                foreach (ISalvar pessoa in salvarpessoas)
                {
                    Console.WriteLine($"id da pessoa: {id}");
                    pessoa.Exibir();
                }
            }
            void Remover()
            {
                Console.Clear();
                Consultar();
                Console.WriteLine("Digite o id que voce quer excluir");
                int id = int.Parse(Console.ReadLine());
                salvarpessoas.RemoveAt(id);
                Salvar();
            }
            void Salvar()
            {
                FileStream stream = new FileStream("ListaPessoas.dat", FileMode.OpenOrCreate);
                BinaryFormatter enoncer = new BinaryFormatter();
                enoncer.Serialize(stream,salvarpessoas);
                stream.Close();

            }
             void Carregar()
            {
                FileStream stream = new FileStream("ListaPessoas.dat", FileMode.OpenOrCreate);
                BinaryFormatter enconder = new BinaryFormatter();
                try
                {
                    salvarpessoas = (List<ISalvar>)enconder.Deserialize(stream);
                    if (salvarpessoas == null)
                    {
                        salvarpessoas = new List<ISalvar>();
                    }
                }
                catch
                {
                    salvarpessoas = new List<ISalvar>();
                }
                stream.Close();
            }



        }
    }
}
