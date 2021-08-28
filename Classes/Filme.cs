    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCadastro
{
    public class Filme : UnicaClasse
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public int Ano { get; set; }

        public string AtoresPrincipais { get; set; }

        public string Diretor { get; set; }

        public bool Excluido { get; set; }


        public Filme(int id, string titulo, string descricao, string atoresPrincipais, string diretor, int ano)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.AtoresPrincipais = atoresPrincipais;
            this.Diretor = diretor;
            this.Ano = ano;
            this.Excluido = false;
        }


        public override string ToString()
        {
            string retorno = "";
            retorno += $"Título: {this.Titulo} {Environment.NewLine}";
            retorno += $"Descrição: {this.Descricao} {Environment.NewLine}";
            retorno += $"Ano de lançamento: {this.Ano} {Environment.NewLine}";
            retorno += $"Atores principais: {this.AtoresPrincipais} {Environment.NewLine}";
            retorno += $"Diretor: {this.Diretor} {Environment.NewLine}";
            retorno += "Excluido: " + this.Excluido;

            return retorno;

        }

        public string RetornarTitulo()
        {
            return this.Titulo;
        }

        public string RetornarId()
        {
            return Convert.ToString(Id);
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }


        public void Excluir()
        {
            this.Excluido = true;
        }

        
    }


    
}
