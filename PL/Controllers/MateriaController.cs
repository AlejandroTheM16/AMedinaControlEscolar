using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        //public ActionResult GetAll()
        //{
        //    ML.Materia materia = new ML.Materia();

        //    ML.Result result = BL.Materia.GetAll();

        //    if (result.Correct)
        //    {

        //        materia.Materias = result.Objects;

        //    }
        //    else {

        //    }

        //    return View(materia);
        //}

        [HttpGet]
        public ActionResult Form(int? IdMateria) {

            ML.Materia materia = new ML.Materia();

            if (IdMateria == null)
            {

                return View(materia);

            }
            else {

                ML.Result result = BL.Materia.GetById(IdMateria.Value);

                if (result.Correct) {

                    materia = (ML.Materia)result.Object;
                    return View(materia);

                }
                else {

                    ViewBag.Mensaje = ("ocurrio un erro al traer los datos" + result.Message);
                    return View("Modal");

                }

            }

        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia) {

            if (materia.IdMateria == 0)
            {

                ML.Result result = BL.Materia.Add(materia);

                if (result.Correct)
                {

                    ViewBag.Mensaje = ("Materia agregada correctamente");
                    return View("Modal");

                }
                else
                {

                    ViewBag.Mensaje = ("Ocurrio un error al agregar" + result.Message);
                    return View("Modal");
                }
            }
            else {

                ML.Result result = BL.Materia.Update(materia);

                if (result.Correct)
                {

                    ViewBag.Mensaje = ("Materia actualizada correctamente");
                    return View("Modal");

                }
                else
                {

                    ViewBag.Mensaje = ("ocurrio un error al actualizar" + result.Message);
                    return View("Modal");
                }

            }

        }

        public ActionResult Delete(int? IdMateria) {

            if (IdMateria != null)
            {

                ML.Result result = BL.Materia.Delete(IdMateria.Value);

                if (result.Correct)
                {

                    ViewBag.Mensaje = ("Materia eliminada correctamente");
                    return View("Modal");

                }
                else
                {

                    ViewBag.Mensaje = ("ocurrio un error al eliminar la materia " + result.Message);
                    return View("Modal");

                }

            }
            else {

                ViewBag.Mensaje = ("ocurrio un error");
                return View("Modal");
            }
        
        }
    }
}