using System.Collections.Generic;
using Dio.Series.Interface;
using System.IO;
using System.Xml.Serialization;

namespace Dio.Series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        const string arquivo = "listaSeries.txt";
        private List<Serie> listaSerie = new List<Serie>();

        public bool Atualiza(int id, Serie entidade)
        {
            try{
                listaSerie[id] = entidade;
            }catch{
                return false;
            }

            Salvar();
            return true;
        }

        public bool Excluir(int id)
        {
            try{
                listaSerie[id].excluir();
            }catch{
                return false;
            }

            Salvar();
            return true;
        }

        public void Inserir(Serie entidade)
        {
            listaSerie.Add(entidade);

            Salvar();
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

        public void Salvar()
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Serie>));
            FileStream file = File.Create(arquivo);

            writer.Serialize(file, listaSerie);
            file.Close();
        }
        
        public void Carregar()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Serie>));
            StreamReader file = new StreamReader(arquivo);
            
            try{
                listaSerie = (List<Serie>)reader.Deserialize(file);
            }catch{}
            
            file.Close();
        }
    }
}