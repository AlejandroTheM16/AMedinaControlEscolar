using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMateria" in both code and config file together.
    [ServiceContract]
    public interface IMateria
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        SL_WCF.Result Add(ML.Alumno alumno);

        [OperationContract]
        SL_WCF.Result Update(ML.Alumno alumno);

        //[OperationContract]
        //SL_WCF.Result Delete(int IdAlumno);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SL_WCF.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SL_WCF.Result GetById(int IdAlumno);

    }
}
