using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {

        public static ML.Result GetAll() {


            ML.Result result = new ML.Result();

            try
            {

                using (DL_EF.AMedinaControlEscolarEntities1 context = new DL_EF.AMedinaControlEscolarEntities1()) {

                    var query = context.AlumnoMateriaGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null) {

                        foreach (var obj in query) {

                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Alumno = new ML.Alumno();

                            alumnoMateria.IdAlumnoMateria = obj.IdAlumnoMateria;
                            alumnoMateria.Alumno.IdAlumno = obj.IdAlumno.Value;
                            alumnoMateria.Materia.IdMateria = obj.IdMateria.Value;

                            result.Objects.Add(alumnoMateria);  
                        
                        }

                        result.Correct = true;

                    
                    }
                }

            }
            catch (Exception Ex)
            {

                result.Correct= false;
                result.Message = Ex.Message;
                result.Ex = Ex;

            }

            return result;
        }

        public static ML.Result GetMateriaByIdAlumno(int? IdAlumno) { 

            ML.Result result = new ML.Result();

            try
            {

                using (DL_EF.AMedinaControlEscolarEntities1 context = new DL_EF.AMedinaControlEscolarEntities1()) {

                    var query = context.AlumnoMateriaGetById(IdAlumno).ToList();

                    result.Objects = new List<object>();

                    if (query != null) {

                        foreach (var obj in query) { 

                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Alumno = new ML.Alumno();

                            alumnoMateria.IdAlumnoMateria = obj.IdAlumnoMateria;
                            alumnoMateria.Alumno.IdAlumno = obj.IdAlumno.Value;
                            alumnoMateria.Materia.IdMateria = obj.IdMateria.Value;
                            alumnoMateria.Alumno.Nombre = obj.NombreAlumno;
                            alumnoMateria.Materia.Nombre = obj.NombreMateria;

                            result.Objects.Add(alumnoMateria);                        

                        }

                        result.Correct = true;
                    
                    }
                    
                }

            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.Message = Ex.Message;
                result.Ex = Ex;
            }

            return result;
        
        }


        public static ML.Result GetMateriasNoAsignadas(int? IdAlumno) {

            ML.Result result = new ML.Result();

            try
            {

                using (DL_EF.AMedinaControlEscolarEntities1 context = new DL_EF.AMedinaControlEscolarEntities1())
                {

                    var query = context.GetMateriasNoAsignadas(IdAlumno).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        foreach (var obj in query)
                        {

                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Alumno = new ML.Alumno();

                            alumnoMateria.Materia.IdMateria = obj.IdMateria;
                            alumnoMateria.Materia.Nombre = obj.Nombre;
                            alumnoMateria.Materia.costo = (decimal)obj.Costo;

                            result.Objects.Add(alumnoMateria);


                        }

                        result.Correct = true;


                    }

                }

            }
            catch (Exception Ex)
            {

                result.Correct = false;
                result.Message = Ex.Message;
                result.Ex = Ex;
            }

            return result;
        
        }

        public static ML.Result Add(ML.AlumnoMateria alumnoMateria) {

            ML.Result result = new ML.Result();

            try
            {

                using (DL_EF.AMedinaControlEscolarEntities1 context = new DL_EF.AMedinaControlEscolarEntities1()) {

                    var query = context.AlumnoMateriaAdd(alumnoMateria.Alumno.IdAlumno,alumnoMateria.Materia.IdMateria);

                    if (query >= 1)
                    {

                        result.Correct = true;

                    }
                    else {

                        result.Correct = false;
                    
                    }
                
                }

            }
            catch (Exception Ex)
            {

                result.Correct = false;
                result.Message = Ex.Message;
                result.Ex = Ex;
            }

            return result;
        
        
        }
    }
}
