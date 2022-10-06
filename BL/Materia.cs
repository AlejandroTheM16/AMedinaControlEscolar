using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {

        public static ML.Result GetAll() {

            ML.Result result = new ML.Result();

            try
            {

                using (DL_EF.AMedinaControlEscolarEntities1 context = new DL_EF.AMedinaControlEscolarEntities1()) {

                    var query = context.MateriaGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null) {

                        foreach (var obj in query) {

                            ML.Materia materia = new ML.Materia();

                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.costo = obj.Costo.Value;

                            result.Objects.Add(materia);    
                        
                        
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


        public static ML.Result Add(ML.Materia materia) {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.AMedinaControlEscolarEntities1 context = new DL_EF.AMedinaControlEscolarEntities1()) {

                    var query = context.MateriaAdd(materia.Nombre,materia.costo);

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

        public static ML.Result GetById(int IdMateria) {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.AMedinaControlEscolarEntities1 context = new DL_EF.AMedinaControlEscolarEntities1()) {

                    var query = context.MateriaGetById(IdMateria).AsEnumerable().FirstOrDefault();

                    if (query != null) {

                        ML.Materia materia = new ML.Materia();

                        materia.IdMateria = query.IdMateria;
                        materia.Nombre = query.Nombre;
                        materia.costo = query.Costo.Value;

                        result.Object = materia;

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

        public static ML.Result Update(ML.Materia materia) {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.AMedinaControlEscolarEntities1 context = new DL_EF.AMedinaControlEscolarEntities1()) {

                    var query = context.MateriaUpdate(materia.IdMateria,materia.Nombre,materia.costo);

                    if (query >= 1) {

                        result.Correct = true;
                    
                    }
                    else{

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

        public static ML.Result Delete(int IdMateria) {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.AMedinaControlEscolarEntities1 context = new DL_EF.AMedinaControlEscolarEntities1()) {

                    var query = context.MateriaDelete(IdMateria);

                    if (query >= 1) {

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
