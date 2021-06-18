using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Dany201810030004.Modelo
{
    public class Ubicacion
    {
        [PrimaryKey,AutoIncrement]
        public int IdUbicacion { get; set; }
        public double Latitud { set; get; }
        public double Longitud { set; get; }
        [MaxLength(30)]

        public String DescripcionCorta { set; get; }
        [MaxLength(60)]
        public String DescripcionLarga { set; get; }


    }
}