using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BinaryDataDecoders.CodeAnalysis.Tests.CSharp
{
    //line comment
    [Serializable]
    class SampleClass_NoVisibility
    {
        /// <summary>
        /// xml comment
        /// </summary>
        [Obsolete]
        public SampleClass_NoVisibility()
        {
        }
        /* block
         * comment */
        public SampleClass_NoVisibility([In] int value)
        {
        }

        static SampleClass_NoVisibility()
        {
        }

        ~SampleClass_NoVisibility()
        {
        }

        public string PropertyGetterOnlyArrow => null;
        public string PropertyGetterOnly { get; }
        public string PropertySetterOnly { set { } }
        public int this[int index]
        {
            get { return index; }
            set { index = value; }
        }
        protected int ProtectedProperty { get; set; }
        public static int PropertyStaticPublic { get; set; }
        private static int PropertyStaticPrivate { get; set; }
        internal static int PropertyStaticInternal { get; set; }

        public readonly SampleClass_Public _public;
        public SampleClass_Public _public2;
        private static readonly SampleClass_Public _static;

        public void MethodVoid()
        {
        }

        public static void MethodStaticVoid()
        {
        }
        public void MethodInput(string input1, string input2)
        {
        }
        public void MethodInput<T>(string input1, T input2)
        {
        }

        [return: ReturnAttrib]
        public int MethodIntReturn()
        {
            return 0;
        }
    }
    public class ReturnAttribAttribute : Attribute { }

    public class SampleClass_Public
    {
    }

    public interface SampleInterface
    {
         int Property{ get; set; }
    }

    public class SampleClass_Generic<T>
    {
        T Property { get; set; }
    }
    internal class SampleClass_Internal
    {
    }
    public sealed class SampleClass_PublicSealed
    {
    }
    public abstract class SampleClass_PublicAbstract
    {
        internal class Nested
        {
        }
    }
    public static class SampleClass_PublicStatic
    {
    }
    public struct SampleStruct
    {
    }
    public enum SampleEnum
    {
        V1,
        V2,
    }
    public enum SampleByteEnum : byte
    {
        V1,
        V2,
    }
}
