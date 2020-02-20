using Laboratorio_01.Models;
using System.Collections.Generic;


namespace Laboratorio_01.Herramienta
{
    public class CajaNet
    {
        private static CajaNet _instance = null;

        public static CajaNet Instance
        {
            get
            {
                if (_instance == null) _instance = new CajaNet();
                return _instance;
            }
        }
        public LinkedList<mJugador> JugadorListNet = new LinkedList<mJugador>();
    }
}