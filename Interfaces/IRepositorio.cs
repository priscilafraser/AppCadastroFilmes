using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCadastro.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornarPorId(int id);
        void Inserir(T elemento);
        void Excluir(int id);
        void Atualizar(int id, T elemento);
        int ProximoId();

    }
}


