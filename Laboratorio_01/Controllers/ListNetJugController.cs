using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio_01.Herramienta;
using Laboratorio_01.Models;
using System.IO;


namespace Laboratorio_01.Controllers
{
    public class ListNetJugController : Controller
    {
        // GET: ListNetJug
        public ActionResult InicioNet()
        {
            return View(CajaNet.Instance.JugadorListNet);
        }

  

        // GET: ListNetJug/Create
        public ActionResult Create()
        {
            return View("CreateListNet");
        }


        public ActionResult Busqueda(string Texto)
        {
            if (Texto == "Hello") { 
             return View("CreateListNet");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult CargaArch(string Archivo)
        {
            try
            {
                string auxJug = "";
                StreamReader lector = new StreamReader(@Archivo);
                auxJug = lector.ReadLine();
                while ((auxJug = lector.ReadLine()) != null)
                {
                    Guardar_Jugadores_Lista(auxJug);
                }

                return View("InicioNet", CajaNet.Instance.JugadorListNet);
            }
            catch
            {
                return View("Error","Shared");
            }
        }

        public void Guardar_Jugadores_Lista(string linecomplete)
        {
           string[] data= linecomplete.Split(Convert.ToChar(";"));
            var Jugador = new mJugador
            {
                Club = data[0],
                Apellido = data[1],
                Name = data[2],
                Posicion = data[3],
                Salario = double.Parse(data[4]),
                Llave =  Convert.ToInt32(data[2][0]) * Convert.ToInt32(data[1][0]) *Convert.ToInt32(double.Parse(data[4]))
            };
            Jugador.Save();

        }


        // POST: ListNetJug/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var Jugador = new mJugador
                {
                    Name = collection["Name"],
                    Apellido = collection["Apellido"],
                    Posicion = collection["Posicion"],
                    Salario = double.Parse(collection["Salario"]),
                    Club = collection["Club"],
                    Llave = Convert.ToInt32(collection["Name"][0]) * Convert.ToInt32(collection["Apellido"][0]) * Convert.ToInt32(double.Parse(collection["Salario"]))
                };
                if (Jugador.Save())
                {
                    return RedirectToAction("InicioNet");
                }
                else
                {
                    return View(Jugador);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ListNetJug/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListNetJug/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ListNetJug/Delete/5
     public ActionResult Delete(int id)
        {

            mJugador Jug = new mJugador();
            foreach (var item in CajaNet.Instance.JugadorListNet)
            {
                if(item.Llave==id)
                {
                    Jug = item;
                }
            }
            CajaNet.Instance.JugadorListNet.Remove(Jug);
            return View("InicioNet", CajaNet.Instance.JugadorListNet);
        }

        // POST: ListNetJug/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
           
                return RedirectToAction("InicioNet");
            }
            catch
            {
                return View("CreateLisNet");
            }
        }
    }
}
