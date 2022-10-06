using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        // GET: AlumnoMateria
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();

            ML.Result result = BL.Alumno.GetAll();

            if (result.Correct) {

                alumno.Alumnos = result.Objects;

            }
            else {

                ViewBag.Mensaje = ("Error al traer la informacion");

            }

            return View(alumno);
        }

        [HttpGet]
        public ActionResult MateriaGetByIdAlumno(int? IdAlumno) {

            if (IdAlumno == null) {

                IdAlumno = (int)Session["IdAlumno"];

            }

            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Materia = new ML.Materia();

            ML.Result result = BL.AlumnoMateria.GetMateriaByIdAlumno(IdAlumno);

            Session["IdAlumno"] = IdAlumno;


            if (result.Correct)
            {

                alumnoMateria.AlumnoMaterias = result.Objects;
            }
            else {

                ViewBag.Mensaje = ("Error al traer la informacion");

            }

            return View(alumnoMateria);

        }

        [HttpGet]
        public ActionResult GetMateriasNoAsignadas(int? IdAlumno) {
            

            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Materia = new ML.Materia();

            if (IdAlumno == 0)
            {

                IdAlumno = (int)Session["IdAlumno"];

            }

            ML.Result result = BL.AlumnoMateria.GetMateriasNoAsignadas(IdAlumno);

            Session["IdAlumno"] = IdAlumno;

            if (result.Correct)
            {

                alumnoMateria.AlumnoMaterias = result.Objects;

            }
            else {

                ViewBag.Mensaje = ("Error al traer la informacion");

            }

            return View(alumnoMateria);
        }


        [HttpPost]
        public ActionResult Form(ML.AlumnoMateria alumnoMateria) {

            Session["IdAlumno"] = alumnoMateria.Alumno.IdAlumno;

            if (alumnoMateria.IdAlumnoMateria != 0)
            {

                return View(alumnoMateria);

            }
            else {

                ML.Result result = BL.AlumnoMateria.Add(alumnoMateria);

                if (result.Correct)
                {

                    ViewBag.Mensaje = ("Se asignaron las materias al alumno");

                }
                else {

                    ViewBag.Mensaje = ("Error al traer la informacion");

                }
            
            
            }

            return View(alumnoMateria);


        
        }
    }
}