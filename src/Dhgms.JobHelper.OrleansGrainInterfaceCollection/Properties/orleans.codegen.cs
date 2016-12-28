#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 414
#pragma warning disable 649
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998
[assembly: global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.3.0")]
[assembly: global::Orleans.CodeGeneration.OrleansCodeGenerationTargetAttribute("Dhgms.JobHelper.OrleansGrainInterfaceCollection, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
namespace Dhgms.JobHelper.OrleansGrainInterfaceCollection
{
    using global::Orleans.Async;
    using global::Orleans;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.3.0"), global::System.SerializableAttribute, global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute, global::Orleans.CodeGeneration.GrainReferenceAttribute(typeof (global::Dhgms.JobHelper.OrleansGrainInterfaceCollection.IGrain1))]
    internal class OrleansCodeGenGrain1Reference : global::Orleans.Runtime.GrainReference, global::Dhgms.JobHelper.OrleansGrainInterfaceCollection.IGrain1
    {
        protected @OrleansCodeGenGrain1Reference(global::Orleans.Runtime.GrainReference @other): base (@other)
        {
        }

        protected @OrleansCodeGenGrain1Reference(global::System.Runtime.Serialization.SerializationInfo @info, global::System.Runtime.Serialization.StreamingContext @context): base (@info, @context)
        {
        }

        protected override global::System.Int32 InterfaceId
        {
            get
            {
                return -1322876500;
            }
        }

        public override global::System.String InterfaceName
        {
            get
            {
                return "global::Dhgms.JobHelper.OrleansGrainInterfaceCollection.IGrain1";
            }
        }

        public override global::System.Boolean @IsCompatible(global::System.Int32 @interfaceId)
        {
            return @interfaceId == -1322876500;
        }

        protected override global::System.String @GetMethodName(global::System.Int32 @interfaceId, global::System.Int32 @methodId)
        {
            switch (@interfaceId)
            {
                case -1322876500:
                    switch (@methodId)
                    {
                        default:
                            throw new global::System.NotImplementedException("interfaceId=" + -1322876500 + ",methodId=" + @methodId);
                    }

                default:
                    throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
            }
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.1.3.0"), global::Orleans.CodeGeneration.MethodInvokerAttribute("global::Dhgms.JobHelper.OrleansGrainInterfaceCollection.IGrain1", -1322876500, typeof (global::Dhgms.JobHelper.OrleansGrainInterfaceCollection.IGrain1)), global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    internal class OrleansCodeGenGrain1MethodInvoker : global::Orleans.CodeGeneration.IGrainMethodInvoker
    {
        public global::System.Threading.Tasks.Task<global::System.Object> @Invoke(global::Orleans.Runtime.IAddressable @grain, global::System.Int32 @interfaceId, global::System.Int32 @methodId, global::System.Object[] @arguments)
        {
            try
            {
                if (@grain == null)
                    throw new global::System.ArgumentNullException("grain");
                switch (@interfaceId)
                {
                    case -1322876500:
                        switch (@methodId)
                        {
                            default:
                                throw new global::System.NotImplementedException("interfaceId=" + -1322876500 + ",methodId=" + @methodId);
                        }

                    default:
                        throw new global::System.NotImplementedException("interfaceId=" + @interfaceId);
                }
            }
            catch (global::System.Exception exception)
            {
                return global::Orleans.Async.TaskUtility.@Faulted(exception);
            }
        }

        public global::System.Int32 InterfaceId
        {
            get
            {
                return -1322876500;
            }
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 649
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif
