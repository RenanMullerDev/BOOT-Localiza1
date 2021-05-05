using System;
using System.Collections.Generic;
using DIO.Discos.Interfaces;


namespace DIO.Disco
{
	public class DiscoRepositorio : IRepositorio<Disco>
	{
        private List<Disco> listaDisco = new List<Disco>();
		public void Atualiza(int id, Disco objeto)
		{
			listaDisco[id] = objeto;
		}

        public void Exclui(int id)
		{
			listaDisco[id].Excluir();
		}

		public void Insere(Disco objeto)
		{
			listaDisco.Add(objeto);
		}

		public List<Disco> Lista()
		{
			return listaDisco;
		}

		public int ProximoId()
		{
			return listaDisco.Count;
		}

		public Disco RetornaPorId(int id)
		{
			return listaDisco[id];
		}

        internal void Insere(object novoDisco)
        {
            throw new NotImplementedException();
        }
    }
}