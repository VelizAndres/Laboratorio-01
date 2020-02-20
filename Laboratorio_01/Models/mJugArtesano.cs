using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laboratorio_01.Herramienta;

namespace Laboratorio_01.Models
{
    public class mJugArtesano
    {
        //Constructor
        public mJugArtesano()
        {

        }
        private string name;
        private string apellido;
        private string posicion;
        private double salario;
        private string club;
         private int llave;

        public string Name { get => name; set => name = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Posicion { get => posicion; set => posicion = value; }
        public double Salario { get => salario; set => salario = value; }
        public string Club { get => club; set => club = value; }
        public int Llave { get => llave; set => llave = value; }

    

    }
}