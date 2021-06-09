using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

 namespace SL_WCF
    {
        public class Departamento : IDepartamento  /* TODO: put your data source class name here */
        {
            
            public SL_WCF.Result Add(ML.Departamento departamento)
            {
                ML.Result result = BL.Departamento.AddEF(departamento);

                return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
            }

            public SL_WCF.Result Delete(ML.Departamento departamento)
            {

                ML.Result result = BL.Departamento.DeleteEF(departamento);
                return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };       
            }
           public SL_WCF.Result Update(ML.Departamento departamento)
            {

                ML.Result result = BL.Departamento.UpdateEF(departamento);
                return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
            }
        }
    }

