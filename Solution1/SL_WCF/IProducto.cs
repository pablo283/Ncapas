using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProducto" in both code and config file together.
    [ServiceContract]
    public interface IProducto
    {
        [OperationContract]
        SL_WCF.Result Add(ML.Producto prodcuto);
        [OperationContract]
        SL_WCF.Result Delete(ML.Producto producto);
        [OperationContract]
        SL_WCF.Result Update(ML.Producto producto);
    }
}
