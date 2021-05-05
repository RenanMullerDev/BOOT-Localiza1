using System;
using DIO.Discos;

namespace DIO.Disco
{
    public class Disco : EntidadeBase
    {
        // Atributos
		private Estilo Estilo { get; set; }
		private string Titulo { get; set; }
		private string Faixas { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Disco(int id, Estilo estilo, string titulo, string faixas, int ano)
		{
			this.Id = id;
			this.Estilo = estilo;
			this.Titulo = titulo;
			this.Faixas = faixas;
			this.Ano = ano;
            this.Excluido = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Estilo: " + this.Estilo + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Faixas: " + this.Faixas + Environment.NewLine;
            retorno += "Ano do Álbum: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}