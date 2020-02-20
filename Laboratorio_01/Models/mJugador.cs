using Laboratorio_01.Herramienta;

namespace Laboratorio_01.Models
{
    public class mJugador
    {

        //Constructor
        public mJugador()
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

        public bool Save()
        {
            try
            {
                CajaNet.Instance.JugadorListNet.AddFirst(this);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}