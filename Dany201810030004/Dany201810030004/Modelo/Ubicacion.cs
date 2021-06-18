using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Dany201810030004.Modelo
{
    public class Ubicacion
    {
        [PrimaryKey]
        public int IdUbicacion { get; }
        public double Latitud { set; get; }
        public double Longitud { set; get; }
        [MaxLength(30)]

        public String DescripcionCorta { set; get; }
        [MaxLength(60)]
        public String DescripcionLarga { set; get; }


    }
}