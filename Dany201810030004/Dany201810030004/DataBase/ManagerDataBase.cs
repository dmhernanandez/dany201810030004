using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using Dany201810030004.Modelo;
using System.Threading.Tasks;

namespace Dany201810030004.DataBase
{
    public class ManagerDataBase
    {
       

        readonly SQLiteAsyncConnection ConexionAsync;
        public ManagerDataBase(string path)
        {
            ConexionAsync = new SQLiteAsyncConnection(path);
            ConexionAsync.CreateTableAsync<Ubicacion>();
        }

        public Task<int> SaveUbicationAsync(Ubicacion ubicacion)
        {
            return ConexionAsync.InsertAsync(ubicacion);
        }
        public Task<int> DeleteUbication(Ubicacion ubicacion)
        {
            return  ConexionAsync.DeleteAsync(ubicacion);
        }
        /*Retorna todos las ubicaciones*/
        public Task<List<Ubicacion>> GetAllUbications()
        {
            return ConexionAsync.Table<Ubicacion>().ToListAsync();
        }
        public Task<int> GetCount()
        {
            return ConexionAsync.Table<Ubicacion>().CountAsync();
        }
    }
}
