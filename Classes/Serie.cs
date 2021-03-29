using Dio.Series.Enum;
using System;

namespace Dio.Series.Classes
{
    public class Serie:EntidadeBase
    {
        public Genero Genero {get; set;}
        public string Titulo {get;set;}
        public string Descricao {get;set;}
        public int Ano {get;set;}
        public bool Excluido {get;set;}

        public Serie(int id,Genero genero,string titulo, string descricao,int ano){
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += "Id: "+this.Id+ Environment.NewLine;
            retorno += "Titulo: "+this.Titulo+ Environment.NewLine;
            retorno += "Genero: "+this.Genero+ Environment.NewLine;
            retorno += "Descrição: "+this.Descricao+ Environment.NewLine;
            retorno += "Ano: "+this.Ano+ Environment.NewLine;

            return retorno;
        }

        public int retornaId(){
            return this.Id;
        }
        
        public string retornaTitulo(){
            return this.Titulo;
        }

        public void excluir(){
            this.Excluido = true;
        }
    }
}