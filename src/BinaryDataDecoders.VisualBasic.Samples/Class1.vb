Public Class Class1

    'comment 1
    Public Sub Test(input As String)
        Console.WriteLine(input)
        'comment 2
    End Sub

    Public Function TestOutput(input As String) As String
        Return input
    End Function

    Public Function TestAnonymous() As Object
        Return New With {.Name = "Hello", .World = ""}
    End Function
    Public Function TestAnonymousKeyed() As Object
        Return New With {Key .Name = "Hello", Key .World = ""}
    End Function
End Class
