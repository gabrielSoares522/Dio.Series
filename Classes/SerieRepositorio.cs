using System.Collections.Generic;
using Dio.Series.Interface;

namespace Dio.Series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public bool Atualiza(int id, Serie entidade)
        {
            try{
                listaSerie[id] = entidade;
            }catch{
                return false;
            }
            return true;
        }

        public bool Excluir(int id)
        {
            try{
                listaSerie[id].excluir();
            }catch{
                return false;
            }
            return true;
        }

        public void Inserir(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            Serie serie;
            try{
                serie = listaSerie[id];
            }catch{
                return null;
            }
            return (!serie.Excluido)?serie:null;
        }
    }
}