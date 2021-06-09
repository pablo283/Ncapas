using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


    namespace SL_WCF
    {
        [ServiceContract]
        public interface IDepartamento
        {
            [OperationContract]
            SL_WCF.Result Add(ML.Departamento departamento);
           [OperationContract]
            SL_WCF.Result Delete(ML.Departamento departamento);
            [OperationContract]
            SL_WCF.Result Update(ML.Departamento departamento);
        }
    }

