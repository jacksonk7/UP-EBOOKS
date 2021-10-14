using System;
using System.Collections.Generic;
using UP.Ebooks.Interfaces;

namespace UP.Ebooks
{ 
	public class EbookRepositorio : IRepositorio<Ebook>
	{
        private List<Ebook> listaEbook = new List<Ebook>();
		public void Atualiza(int id, Ebook objeto)
		{
			listaEbook[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaEbook[id].Excluir();
		}

		public void Insere(Ebook objeto)
		{
			listaEbook.Add(objeto);
		}

		public List<Ebook> Lista()
		{
			return listaEbook;
		}

		public int ProximoId()
		{
			return listaEbook.Count;
		}

		public Ebook RetornaPorId(int id)
		{
			return listaEbook[id];
		}
	}
}