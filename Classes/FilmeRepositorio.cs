using AppCadastro.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCadastro.Classes
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        public List<Filme> listaFilme = new List<Filme>();


        public void Atualizar(int id, Filme elemento)
        {
            listaFilme[id] = elemento;

        }

        public void Excluir(int id)
        {
            listaFilme[id].Excluir();
        }

        public void Inserir(Filme elemento)
        {
            listaFilme.Add[elemento];
        }

        public List<Filme> Lista()
        {
            return listaFilme;
        }

        public int ProximoId()
        {
            return listaFilme.Count;
        }

        public Filme RetornarPorId(int id)
        {
            return listaFilme[id];
        }
    }
}
