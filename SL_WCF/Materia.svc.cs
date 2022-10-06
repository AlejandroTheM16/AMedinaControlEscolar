using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Materia" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Materia.svc or Materia.svc.cs at the Solution Explorer and start debugging.
    public class Materia : IMateria
    {
        public void DoWork()
        {
        }

        public SL_WCF.Result GetAll()
        {

            ML.Result resultBusiness = BL.Alumno.GetAll();

            return new SL_WCF.Result
            {

                Correct = resultBusiness.Correct,
                Ex = resultBusiness.Ex,
                ErrorMessage = resultBusiness.Message,
                Object = resultBusiness.Object,
                Objects = resultBusiness.Objects

            };
        }

        public SL_WCF.Result GetById(int IdAlumno)
        {

            ML.Result resultBusiness = BL.Alumno.GetById(IdAlumno);

            return new SL_WCF.Result
            {

                Correct = resultBusiness.Correct,
                Ex = resultBusiness.Ex,
                ErrorMessage = resultBusiness.Message,
                Object = resultBusiness.Object,
                Objects = resultBusiness.Objects

            };

        }

        public SL_WCF.Result Add(ML.Alumno alumno)
        {

            ML.Result resultBusiness = BL.Alumno.Add(alumno);

            return new SL_WCF.Result
            {

                Correct = resultBusiness.Correct,
                Ex = resultBusiness.Ex,
                ErrorMessage = resultBusiness.Message


            };
        }

        public SL_WCF.Result Update(ML.Alumno alumno)
        {

            ML.Result resultBusiness = BL.Alumno.Update(alumno);

            return new SL_WCF.Result
            {

                Correct = resultBusiness.Correct,
                Ex = resultBusiness.Ex,
                ErrorMessage = resultBusiness.Message

            };

        }

    }
}
