# BinaryDataDecoders.ToolKit.Xml.Xsl.XsltExtensionFactory

## Summary

| Key             | Value                                                     |
| :-------------- | :-------------------------------------------------------- |
| Class           | `BinaryDataDecoders.ToolKit.Xml.Xsl.XsltExtensionFactory` |
| Assembly        | `BinaryDataDecoders.ToolKit`                              |
| Coveredlines    | `0`                                                       |
| Uncoveredlines  | `67`                                                      |
| Coverablelines  | `67`                                                      |
| Totallines      | `127`                                                     |
| Linecoverage    | `0`                                                       |
| Coveredbranches | `0`                                                       |
| Totalbranches   | `21`                                                      |
| Branchcoverage  | `0`                                                       |

## Metrics

| Complexity | Lines | Branches | Name                   |
| :--------- | :---- | :------- | :--------------------- |
| 4          | 0     | 0        | `BuildXsltExtension`   |
| 6          | 0     | 0        | `BuildMethods`         |
| 4          | 0     | 0        | `BuildMethod`          |
| 1          | 0     | 100      | `BuildConstructor`     |
| 1          | 0     | 100      | `GetExtendableMethods` |
| 7          | 0     | 0        | `EmitLoadArg`          |

## Files

## File - C:\Repos\mwwhited\BinaryDataDecoders\src\BinaryDataDecoders.ToolKit\Xml\Xsl\XsltExtensionFactory.cs

```CSharp
〰1:   using System;
〰2:   using System.Collections.Generic;
〰3:   using System.Linq;
〰4:   using System.Reflection;
〰5:   using System.Reflection.Emit;
〰6:   using System.Xml.Serialization;
〰7:   
〰8:   namespace BinaryDataDecoders.ToolKit.Xml.Xsl
〰9:   {
〰10:      public class XsltExtensionFactory
〰11:      {
〰12:          public object BuildXsltExtension(object input)
〰13:          {
‼14:              var type = input.GetType();
‼15:              var extendedMethods = GetExtendableMethods(type);
‼16:              if (!extendedMethods.Any()) return input;
〰17:  
‼18:              var typeSignature = $"{type.Name}_{Guid.NewGuid()}";
‼19:              var assemblyName = new AssemblyName(typeSignature);
‼20:              var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
‼21:              var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
〰22:  
‼23:              var typeBuilder = moduleBuilder.DefineType(typeSignature,
‼24:                      TypeAttributes.Public |
‼25:                      TypeAttributes.Class |
‼26:                      TypeAttributes.AutoClass |
‼27:                      TypeAttributes.AnsiClass |
‼28:                      TypeAttributes.BeforeFieldInit |
‼29:                      TypeAttributes.AutoLayout,
‼30:                      null);
〰31:  
‼32:              var xmlRootType = typeof(XmlRootAttribute);
‼33:              var xmlRootTypeCtor = xmlRootType.GetConstructor(Type.EmptyTypes);
‼34:              var xmlRootProp = new[] { xmlRootType.GetProperty(nameof(XmlRootAttribute.Namespace)) };
‼35:              foreach (var xmlRoot in type.GetCustomAttributes<XmlRootAttribute>())
〰36:              {
‼37:                  typeBuilder.SetCustomAttribute(new CustomAttributeBuilder(xmlRootTypeCtor, new object[0], xmlRootProp, new object[] { xmlRoot.Namespace }));
〰38:              }
〰39:  
‼40:              var wrapped = typeBuilder.DefineField("_wrapped", type, FieldAttributes.Private | FieldAttributes.InitOnly);
‼41:              BuildConstructor(typeBuilder, wrapped);
‼42:              BuildMethods(typeBuilder, type, wrapped);
〰43:  
‼44:              var typeInfo = typeBuilder.CreateTypeInfo();
‼45:              var newType = typeInfo.AsType();
‼46:              var newInstance = Activator.CreateInstance(newType, input);
〰47:  
‼48:              return newInstance;
〰49:          }
〰50:  
〰51:          private void BuildMethods(TypeBuilder typeBuilder, Type type, FieldBuilder wrapped)
〰52:          {
‼53:              foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
〰54:              {
‼55:                  if (!method.GetCustomAttributes<XsltFunctionAttribute>().Any(c => c.HideOriginalName))
‼56:                      BuildMethod(typeBuilder, wrapped, method, null);
〰57:  
‼58:                  foreach (var extend in method.GetCustomAttributes<XsltFunctionAttribute>())
〰59:                  {
‼60:                      BuildMethod(typeBuilder, wrapped, method, extend.Name);
〰61:                  }
〰62:              }
‼63:          }
〰64:  
〰65:          private void BuildMethod(TypeBuilder typeBuilder, FieldBuilder wrapped, MethodInfo method, string? methodName)
〰66:          {
‼67:              var methodBuilder = typeBuilder.DefineMethod(methodName ?? method.Name, MethodAttributes.Public);
〰68:  
‼69:              var parameters = method.GetParameters().Select(t => t.ParameterType).ToArray();
‼70:              methodBuilder.SetParameters(parameters);
‼71:              methodBuilder.SetReturnType(method.ReturnType);
〰72:  
‼73:              var il = methodBuilder.GetILGenerator();
‼74:              il.Emit(OpCodes.Ldarg_0);
‼75:              il.Emit(OpCodes.Ldfld, wrapped);
‼76:              foreach (var i in Enumerable.Range(1, parameters.Length))
‼77:                  EmitLoadArg(il, i);
〰78:  
‼79:              il.EmitCall(OpCodes.Callvirt, method, parameters);
‼80:              il.Emit(OpCodes.Ret);
‼81:          }
〰82:  
〰83:          private void BuildConstructor(TypeBuilder typeBuilder, FieldBuilder wrapped)
〰84:          {
‼85:              var ctorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new[] { wrapped.FieldType });
‼86:              var il = ctorBuilder.GetILGenerator();
‼87:              il.Emit(OpCodes.Ldarg_0);
‼88:              il.Emit(OpCodes.Ldarg_1);
‼89:              il.Emit(OpCodes.Stfld, wrapped);
‼90:              il.Emit(OpCodes.Ret);
‼91:          }
〰92:  
〰93:          private static IEnumerable<(string name, MethodInfo method)> GetExtendableMethods(Type type) =>
‼94:              from method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
‼95:              from attribute in method.GetCustomAttributes<XsltFunctionAttribute>()
‼96:              select (attribute.Name, method);
〰97:  
〰98:          private static void EmitLoadArg(ILGenerator il, int index)
〰99:          {
〰100:             switch (index)
〰101:             {
〰102:                 case 0:
‼103:                     il.Emit(OpCodes.Ldarg_0);
‼104:                     break;
〰105:                 case 1:
‼106:                     il.Emit(OpCodes.Ldarg_1);
‼107:                     break;
〰108:                 case 2:
‼109:                     il.Emit(OpCodes.Ldarg_2);
‼110:                     break;
〰111:                 case 3:
‼112:                     il.Emit(OpCodes.Ldarg_3);
‼113:                     break;
〰114:                 default:
‼115:                     if (index <= byte.MaxValue)
〰116:                     {
‼117:                         il.Emit(OpCodes.Ldarg_S, (byte)index);
〰118:                     }
〰119:                     else
〰120:                     {
‼121:                         il.Emit(OpCodes.Ldarg, index);
〰122:                     }
〰123:                     break;
〰124:             }
‼125:         }
〰126:     }
〰127: }
```

## Links

* [Return to Summary](Summary.md)
* [Table of Contents](../TOC.md)

