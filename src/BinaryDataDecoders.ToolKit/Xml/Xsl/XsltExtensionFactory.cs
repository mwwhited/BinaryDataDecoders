using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Xml.Serialization;

namespace BinaryDataDecoders.ToolKit.Xml.Xsl
{
    public class XsltExtensionFactory
    {
        public object BuildXsltExtension(object input)
        {
            var type = input.GetType();
            var extendedMethods = GetExtendableMethods(type);
            if (!extendedMethods.Any()) return input;

            var typeSignature = $"{type.Name}_{Guid.NewGuid()}";
            var assemblyName = new AssemblyName(typeSignature);
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");

            var typeBuilder = moduleBuilder.DefineType(typeSignature,
                    TypeAttributes.Public |
                    TypeAttributes.Class |
                    TypeAttributes.AutoClass |
                    TypeAttributes.AnsiClass |
                    TypeAttributes.BeforeFieldInit |
                    TypeAttributes.AutoLayout,
                    null);

            var xmlRootType = typeof(XmlRootAttribute);
            var xmlRootTypeCtor = xmlRootType.GetConstructor(Type.EmptyTypes);
            var xmlRootProp = new[] { xmlRootType.GetProperty(nameof(XmlRootAttribute.Namespace)) };
            foreach (var xmlRoot in type.GetCustomAttributes<XmlRootAttribute>())
            {
                typeBuilder.SetCustomAttribute(new CustomAttributeBuilder(xmlRootTypeCtor, new object[0], xmlRootProp, new object[] { xmlRoot.Namespace }));
            }

            var wrapped = typeBuilder.DefineField("_wrapped", type, FieldAttributes.Private | FieldAttributes.InitOnly);
            BuildConstructor(typeBuilder, wrapped);
            BuildMethods(typeBuilder, type, wrapped);

            var typeInfo = typeBuilder.CreateTypeInfo();
            var newType = typeInfo.AsType();
            var newInstance = Activator.CreateInstance(newType, input);

            return newInstance;
        }

        private void BuildMethods(TypeBuilder typeBuilder, Type type, FieldBuilder wrapped)
        {
            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!method.GetCustomAttributes<XsltFunctionAttribute>().Any(c => c.HideOriginalName))
                    BuildMethod(typeBuilder, wrapped, method, null);

                foreach (var extend in method.GetCustomAttributes<XsltFunctionAttribute>())
                {
                    BuildMethod(typeBuilder, wrapped, method, extend.Name);
                }
            }
        }

        private void BuildMethod(TypeBuilder typeBuilder, FieldBuilder wrapped, MethodInfo method, string? methodName)
        {
            var methodBuilder = typeBuilder.DefineMethod(methodName ?? method.Name, MethodAttributes.Public);

            var parameters = method.GetParameters().Select(t => t.ParameterType).ToArray();
            methodBuilder.SetParameters(parameters);
            methodBuilder.SetReturnType(method.ReturnType);

            var il = methodBuilder.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, wrapped);
            foreach (var i in Enumerable.Range(1, parameters.Length))
                EmitLoadArg(il, i);

            il.EmitCall(OpCodes.Callvirt, method, parameters);
            il.Emit(OpCodes.Ret);
        }

        private void BuildConstructor(TypeBuilder typeBuilder, FieldBuilder wrapped)
        {
            var ctorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new[] { wrapped.FieldType });
            var il = ctorBuilder.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Stfld, wrapped);
            il.Emit(OpCodes.Ret);
        }

        private static IEnumerable<(string name, MethodInfo method)> GetExtendableMethods(Type type) =>
            from method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
            from attribute in method.GetCustomAttributes<XsltFunctionAttribute>()
            select (attribute.Name, method);

        private static void EmitLoadArg(ILGenerator il, int index)
        {
            switch (index)
            {
                case 0:
                    il.Emit(OpCodes.Ldarg_0);
                    break;
                case 1:
                    il.Emit(OpCodes.Ldarg_1);
                    break;
                case 2:
                    il.Emit(OpCodes.Ldarg_2);
                    break;
                case 3:
                    il.Emit(OpCodes.Ldarg_3);
                    break;
                default:
                    if (index <= byte.MaxValue)
                    {
                        il.Emit(OpCodes.Ldarg_S, (byte)index);
                    }
                    else
                    {
                        il.Emit(OpCodes.Ldarg, index);
                    }
                    break;
            }
        }
    }
}
