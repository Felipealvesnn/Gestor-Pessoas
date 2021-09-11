using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testeapp
{
    [System.Serializable]
    class Pessoa: ISalvar
    {
        string nome;
        int telefone;

        public Pessoa(string nome, int telefone)
        {
            this.nome = nome;
            this.telefone = telefone;
        }

        public void Exibir()
        {
            Console.WriteLine($"nome da pessoa {nome}");
            Console.WriteLine($"Telefone da pessoa {telefone}");
            Console.WriteLine("============================");
        }
        public void Adicionarpessoa()
        {
            Console.WriteLine("adicionar nome");
            string nome=Console.ReadLine();
            
           
        }
        public void Adicionartelefone()
        {
            Console.WriteLine("adicionar telefone");
            int telefone = int.Parse(Console.ReadLine());
            
        }

       
    }
}
