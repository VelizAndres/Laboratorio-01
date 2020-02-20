using System;
using System.Collections.Generic;
using Laboratorio_01.Models;
using LibrayArtesana.Estructuras;

namespace Laboratorio_01.Herramienta
{
    public class CajaArtesano
    {
        private static CajaArtesano _instance = null;

        public static CajaArtesano Instance
        {
            get
            {
                if (_instance == null) _instance = new CajaArtesano();
                return _instance;
            }
        }
        public ListaDoble<mJugArtesano> JugadorListArte = new ListaDoble<mJugArtesano>();
    }
}