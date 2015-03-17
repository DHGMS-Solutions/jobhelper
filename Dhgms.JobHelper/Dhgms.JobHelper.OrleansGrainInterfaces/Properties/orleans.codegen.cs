//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998

namespace Dhgms.JobHelper.OrleansGrainInterfaces
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    using System.Collections.Generic;
    using Orleans;
    using Orleans.Runtime;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public class Grain1Factory
    {
        

                        public static Dhgms.JobHelper.OrleansGrainInterfaces.IJobGrain GetGrain(long primaryKey)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(Dhgms.JobHelper.OrleansGrainInterfaces.IJobGrain), -280256842, primaryKey));
                        }

                        public static Dhgms.JobHelper.OrleansGrainInterfaces.IJobGrain GetGrain(long primaryKey, string grainClassNamePrefix)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(Dhgms.JobHelper.OrleansGrainInterfaces.IJobGrain), -280256842, primaryKey, grainClassNamePrefix));
                        }

                        public static Dhgms.JobHelper.OrleansGrainInterfaces.IJobGrain GetGrain(System.Guid primaryKey)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(Dhgms.JobHelper.OrleansGrainInterfaces.IJobGrain), -280256842, primaryKey));
                        }

                        public static Dhgms.JobHelper.OrleansGrainInterfaces.IJobGrain GetGrain(System.Guid primaryKey, string grainClassNamePrefix)
                        {
                            return Cast(global::Orleans.CodeGeneration.GrainFactoryBase.MakeGrainReferenceInternal(typeof(Dhgms.JobHelper.OrleansGrainInterfaces.IJobGrain), -280256842, primaryKey, grainClassNamePrefix));
                        }

            public static Dhgms.JobHelper.OrleansGrainInterfaces.IJobGrain Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return Grain1Reference.Cast(grainRef);
            }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
        [System.SerializableAttribute()]
        [global::Orleans.CodeGeneration.GrainReferenceAttribute("Dhgms.JobHelper.OrleansGrainInterfaces.Dhgms.JobHelper.OrleansGrainInterfaces.IGr" +
            "ain1")]
        internal class Grain1Reference : global::Orleans.Runtime.GrainReference, global::Orleans.Runtime.IAddressable, Dhgms.JobHelper.OrleansGrainInterfaces.IJobGrain
        {
            

            public static Dhgms.JobHelper.OrleansGrainInterfaces.IJobGrain Cast(global::Orleans.Runtime.IAddressable grainRef)
            {
                
                return (Dhgms.JobHelper.OrleansGrainInterfaces.IJobGrain) global::Orleans.Runtime.GrainReference.CastInternal(typeof(Dhgms.JobHelper.OrleansGrainInterfaces.IJobGrain), (global::Orleans.Runtime.GrainReference gr) => { return new Grain1Reference(gr);}, grainRef, -280256842);
            }
            
            protected internal Grain1Reference(global::Orleans.Runtime.GrainReference reference) : 
                    base(reference)
            {
            }
            
            protected internal Grain1Reference(SerializationInfo info, StreamingContext context) : 
                    base(info, context)
            {
            }
            
            protected override int InterfaceId
            {
                get
                {
                    return -280256842;
                }
            }
            
            protected override string InterfaceName
            {
                get
                {
                    return "Dhgms.JobHelper.OrleansGrainInterfaces.Dhgms.JobHelper.OrleansGrainInterfaces.IGr" +
                        "ain1";
                }
            }
            
            [global::Orleans.CodeGeneration.CopierMethodAttribute()]
            public static object _Copier(object original)
            {
                Grain1Reference input = ((Grain1Reference)(original));
                return ((Grain1Reference)(global::Orleans.Runtime.GrainReference.CopyGrainReference(input)));
            }
            
            [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
            public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
            {
                Grain1Reference input = ((Grain1Reference)(original));
                global::Orleans.Runtime.GrainReference.SerializeGrainReference(input, stream, expected);
            }
            
            [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
            public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
            {
                return Grain1Reference.Cast(((global::Orleans.Runtime.GrainReference)(global::Orleans.Runtime.GrainReference.DeserializeGrainReference(expected, stream))));
            }
            
            public override bool IsCompatible(int interfaceId)
            {
                return (interfaceId == this.InterfaceId);
            }
            
            protected override string GetMethodName(int interfaceId, int methodId)
            {
                return Grain1MethodInvoker.GetMethodName(interfaceId, methodId);
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [global::Orleans.CodeGeneration.MethodInvokerAttribute("Dhgms.JobHelper.OrleansGrainInterfaces.Dhgms.JobHelper.OrleansGrainInterfaces.IGr" +
        "ain1", -280256842)]
    internal class Grain1MethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        
        int global::Orleans.CodeGeneration.IGrainMethodInvoker.InterfaceId
        {
            get
            {
                return -280256842;
            }
        }
        
        global::System.Threading.Tasks.Task<object> global::Orleans.CodeGeneration.IGrainMethodInvoker.Invoke(global::Orleans.Runtime.IAddressable grain, int interfaceId, int methodId, object[] arguments)
        {

            try
            {                    if (grain == null) throw new System.ArgumentNullException("grain");
                switch (interfaceId)
                {
                    case -280256842:  // IGrain1
                        switch (methodId)
                        {
                            default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                        }
                    default:
                        throw new System.InvalidCastException("interfaceId="+interfaceId);
                }
            }
            catch(Exception ex)
            {
                var t = new System.Threading.Tasks.TaskCompletionSource<object>();
                t.SetException(ex);
                return t.Task;
            }
        }
        
        public static string GetMethodName(int interfaceId, int methodId)
        {

            switch (interfaceId)
            {
                
                case -280256842:  // IGrain1
                    switch (methodId)
                    {
                        
                        default: 
                            throw new NotImplementedException("interfaceId="+interfaceId+",methodId="+methodId);
                    }

                default:
                    throw new System.InvalidCastException("interfaceId="+interfaceId);
            }
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif
