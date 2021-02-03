Imports System.Data

Public Class Funcao

    Public Function ConverterResultado(ByVal lst As ArrayList) As DataTable

        Dim table As New DataTable

        For index = 0 To DirectCast(lst(0), NameValueCollection).AllKeys.Length - 1
            table.Columns.Add(DirectCast(lst(0), NameValueCollection).AllKeys(index).ToString())
        Next

        For Each array As NameValueCollection In lst

            Dim newRow = table.NewRow()

            For index = 0 To DirectCast(lst(0), NameValueCollection).AllKeys.Length - 1
                newRow(index) = array(index)
            Next

            table.Rows.Add(newRow)

        Next

        Return table

    End Function

End Class