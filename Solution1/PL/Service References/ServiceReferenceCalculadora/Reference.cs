//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.ServiceReferenceCalculadora {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceCalculadora.ICalculadora")]
    public interface ICalculadora {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculadora/Suma", ReplyAction="http://tempuri.org/ICalculadora/SumaResponse")]
        int Suma(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculadora/Suma", ReplyAction="http://tempuri.org/ICalculadora/SumaResponse")]
        System.Threading.Tasks.Task<int> SumaAsync(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculadora/Resta", ReplyAction="http://tempuri.org/ICalculadora/RestaResponse")]
        int Resta(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculadora/Resta", ReplyAction="http://tempuri.org/ICalculadora/RestaResponse")]
        System.Threading.Tasks.Task<int> RestaAsync(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculadora/Multiplicacion", ReplyAction="http://tempuri.org/ICalculadora/MultiplicacionResponse")]
        int Multiplicacion(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculadora/Multiplicacion", ReplyAction="http://tempuri.org/ICalculadora/MultiplicacionResponse")]
        System.Threading.Tasks.Task<int> MultiplicacionAsync(int a, int b);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalculadoraChannel : PL.ServiceReferenceCalculadora.ICalculadora, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculadoraClient : System.ServiceModel.ClientBase<PL.ServiceReferenceCalculadora.ICalculadora>, PL.ServiceReferenceCalculadora.ICalculadora {
        
        public CalculadoraClient() {
        }
        
        public CalculadoraClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalculadoraClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculadoraClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculadoraClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Suma(int a, int b) {
            return base.Channel.Suma(a, b);
        }
        
        public System.Threading.Tasks.Task<int> SumaAsync(int a, int b) {
            return base.Channel.SumaAsync(a, b);
        }
        
        public int Resta(int a, int b) {
            return base.Channel.Resta(a, b);
        }
        
        public System.Threading.Tasks.Task<int> RestaAsync(int a, int b) {
            return base.Channel.RestaAsync(a, b);
        }
        
        public int Multiplicacion(int a, int b) {
            return base.Channel.Multiplicacion(a, b);
        }
        
        public System.Threading.Tasks.Task<int> MultiplicacionAsync(int a, int b) {
            return base.Channel.MultiplicacionAsync(a, b);
        }
    }
}
