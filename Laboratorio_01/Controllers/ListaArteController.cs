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
    public class ListaArteController : Controller
    {
        // GET: ListaArte
        public ActionResult InicioArtesana()
        {
            return View(CajaArtesano.Instance.JugadorListArte);
        }

 
        // GET: ListaArte/Create
        public ActionResult Create()
        {
            return View("CreateListArte");
        }

        // POST: ListaArte/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var Jugador = new mJugArtesano
                {
                    Name = collection["Name"],
                    Apellido = collection["Apellido"],
                    Posicion = collection["Posicion"],
                    Salario = double.Parse(collection["Salario"]),
                    Club = collection["Club"],
                    Llave = Convert.ToInt32(collection["Name"][0]) * Convert.ToInt32(collection["Apellido"][0]) * Convert.ToInt32(double.Parse(collection["Salario"]))
                };
                CajaArtesano.Instance.JugadorListArte.Agregar(Jugador);
                    return RedirectToAction("InicioArtesana");
               
            }
            catch
            {
                return View("CreateListArte");
            }
        }

        // GET: ListaArte/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListaArte/Edit/5
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

        // GET: ListaArte/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListaArte/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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

                return View("InicioNet", CajaArtesano.Instance.JugadorListArte);
            }
            catch
            {
                return View("Error", "Shared");
            }
        }

        public void Guardar_Jugadores_Lista(string linecomplete)
        {
            string[] data = linecomplete.Split(Convert.ToChar(";"));
            var Jugador = new mJugArtesano
            {
                Club = data[0],
                Apellido = data[1],
                Name = data[2],
                Posicion = data[3],
                Salario = double.Parse(data[4]),
                Llave = Convert.ToInt32(data[2][0]) * Convert.ToInt32(data[1][0]) * Convert.ToInt32(double.Parse(data[4]))
            };
           

        }


    }

}
