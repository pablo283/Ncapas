//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.ServiceReferenceProducto {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/SL_WCF")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Exception))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Producto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Departamento))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Area))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Proveedor))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.VentaProducto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Venta))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Cliente))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.MetodoPago))]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool CorrectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Exception ExField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ObjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] ObjectsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Correct {
            get {
                return this.CorrectField;
            }
            set {
                if ((this.CorrectField.Equals(value) != true)) {
                    this.CorrectField = value;
                    this.RaisePropertyChanged("Correct");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Exception Ex {
            get {
                return this.ExField;
            }
            set {
                if ((object.ReferenceEquals(this.ExField, value) != true)) {
                    this.ExField = value;
                    this.RaisePropertyChanged("Ex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Object {
            get {
                return this.ObjectField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectField, value) != true)) {
                    this.ObjectField = value;
                    this.RaisePropertyChanged("Object");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] Objects {
            get {
                return this.ObjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectsField, value) != true)) {
                    this.ObjectsField = value;
                    this.RaisePropertyChanged("Objects");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceProducto.IProducto")]
    public interface IProducto {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/Add", ReplyAction="http://tempuri.org/IProducto/AddResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL.ServiceReferenceProducto.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Proveedor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.VentaProducto))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Venta))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Cliente))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.MetodoPago))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        PL.ServiceReferenceProducto.Result Add(ML.Producto prodcuto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/Add", ReplyAction="http://tempuri.org/IProducto/AddResponse")]
        System.Threading.Tasks.Task<PL.ServiceReferenceProducto.Result> AddAsync(ML.Producto prodcuto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/Delete", ReplyAction="http://tempuri.org/IProducto/DeleteResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL.ServiceReferenceProducto.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Proveedor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.VentaProducto))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Venta))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Cliente))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.MetodoPago))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        PL.ServiceReferenceProducto.Result Delete(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/Delete", ReplyAction="http://tempuri.org/IProducto/DeleteResponse")]
        System.Threading.Tasks.Task<PL.ServiceReferenceProducto.Result> DeleteAsync(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/Update", ReplyAction="http://tempuri.org/IProducto/UpdateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL.ServiceReferenceProducto.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Proveedor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.VentaProducto))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Venta))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Cliente))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.MetodoPago))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Area))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Departamento))]
        PL.ServiceReferenceProducto.Result Update(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/Update", ReplyAction="http://tempuri.org/IProducto/UpdateResponse")]
        System.Threading.Tasks.Task<PL.ServiceReferenceProducto.Result> UpdateAsync(ML.Producto producto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductoChannel : PL.ServiceReferenceProducto.IProducto, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductoClient : System.ServiceModel.ClientBase<PL.ServiceReferenceProducto.IProducto>, PL.ServiceReferenceProducto.IProducto {
        
        public ProductoClient() {
        }
        
        public ProductoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PL.ServiceReferenceProducto.Result Add(ML.Producto prodcuto) {
            return base.Channel.Add(prodcuto);
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReferenceProducto.Result> AddAsync(ML.Producto prodcuto) {
            return base.Channel.AddAsync(prodcuto);
        }
        
        public PL.ServiceReferenceProducto.Result Delete(ML.Producto producto) {
            return base.Channel.Delete(producto);
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReferenceProducto.Result> DeleteAsync(ML.Producto producto) {
            return base.Channel.DeleteAsync(producto);
        }
        
        public PL.ServiceReferenceProducto.Result Update(ML.Producto producto) {
            return base.Channel.Update(producto);
        }
        
        public System.Threading.Tasks.Task<PL.ServiceReferenceProducto.Result> UpdateAsync(ML.Producto producto) {
            return base.Channel.UpdateAsync(producto);
        }
    }
}
