using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result Add(ML.Alumno alumno) {
            
            ML.Result result = new ML.Result();

            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.Get())) {

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "AlumnoAdd";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection = context;

                    SqlParameter[] collection = new SqlParameter[3];
                    collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[0].Value = alumno.Nombre;
                    collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = alumno.ApellidoPaterno;
                    collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = alumno.ApellidoMaterno;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (rowAffected >= 1)
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


        public static ML.Result GetAll() {

            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get())) {

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "AlumnoGetAll";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = context;

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (dt.Columns.Count > 0) {

                        result.Objects = new List<object>();

                        foreach (DataRow dr in dt.Rows)
                        {

                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = int.Parse(dr[0].ToString());
                            alumno.Nombre = dr[1].ToString();
                            alumno.ApellidoPaterno = dr[2].ToString();
                            alumno.ApellidoMaterno = dr[3].ToString();

                            result.Objects.Add(alumno);

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

        public static ML.Result GetById(int IdAlumno) {

            ML.Result result = new ML.Result();

            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.Get())) {

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "AlumnoGetById";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = context;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                    collection[0].Value = IdAlumno;
                    cmd.Parameters.AddRange(collection); 

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0) { 

                        DataRow dr = dt.Rows[0];
                        ML.Alumno alumno = new ML.Alumno();

                        alumno.IdAlumno = int.Parse(dr[0].ToString());
                        alumno.Nombre = dr[1].ToString();
                        alumno.ApellidoPaterno = dr[2].ToString();
                        alumno.ApellidoMaterno = dr[3].ToString();

                        result.Object = alumno;

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

        public static ML.Result Update(ML.Alumno alumno) {

            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get())) {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "AlumnoUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection = context;

                    SqlParameter[] collection = new SqlParameter[4];

                    collection[0] = new SqlParameter("IdAlumno",SqlDbType.Int);
                    collection[0].Value = alumno.IdAlumno;
                    collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[1].Value = alumno.Nombre;
                    collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = alumno.ApellidoPaterno;
                    collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = alumno.ApellidoMaterno;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int rowAffected = cmd.ExecuteNonQuery();

                    if (rowAffected > 0)
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
