Imports System
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports System.Text

Namespace BinaryDataDecoders.CodeAnalysis.Tests.CSharp
    <Serializable>
    Class SampleClass_NoVisibility
        <Obsolete>
        Public Sub New()
        End Sub

        Public Sub New(
<[In]> ByVal value As Integer)
        End Sub

        Private Shared Sub New()
        End Sub

        Protected Overrides Sub Finalize()
        End Sub

        Public ReadOnly Property PropertyGetterOnlyArrow As String
            Get
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property PropertyGetterOnly As String

        Public WriteOnly Property PropertySetterOnly As String
            Set(ByVal value As String)
            End Set
        End Property

        Default Public Property Item(ByVal index As Integer) As Integer
            Get
                Return index
            End Get
            Set(ByVal value As Integer)
                index = value
            End Set
        End Property

        Protected Property ProtectedProperty As Integer
        Public Shared Property PropertyStaticPublic As Integer
        Private Shared Property PropertyStaticPrivate As Integer
        Friend Shared Property PropertyStaticInternal As Integer
        Public ReadOnly _public As SampleClass_Public
        Public _public2 As SampleClass_Public
        Private Shared ReadOnly _static As SampleClass_Public

        Public Sub MethodVoid()
        End Sub

        Public Shared Sub MethodStaticVoid()
        End Sub

        Public Sub MethodInput(ByVal input1 As String, ByVal input2 As String)
        End Sub

        Public Sub MethodInput(Of T)(ByVal input1 As String, ByVal input2 As T)
        End Sub

        <ReturnAttrib>
        Public Function MethodIntReturn() As Integer
            Return 0
        End Function
    End Class

    Public Class ReturnAttribAttribute
        Inherits Attribute
    End Class

    Public Class SampleClass_Public
    End Class

    Interface SampleInterface
        Private Property [Property] As Integer
    End Interface

    Public Class SampleClass_Generic(Of T)
        Private Property [Property] As T
    End Class

    Friend Class SampleClass_Internal
    End Class

    Public NotInheritable Class SampleClass_PublicSealed
    End Class

    Public MustInherit Class SampleClass_PublicAbstract
        Friend Class Nested
        End Class
    End Class

    Module SampleClass_PublicStatic
    End Module

    Public Structure SampleStruct
    End Structure

    Public Enum SampleEnum
        V1
        V2
    End Enum
End Namespace
