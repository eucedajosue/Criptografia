Imports System.Security.Cryptography
Imports System.Text

Public Class Criptografia
    Private clave As String = "12345678"
    Private clave64b As String = "AMQt0O0zHADQL8oCaTFVKnEsac3FMRSW"

    Public Function encriptar(ByVal entrada As String) As String
        Dim resultado As String = ""

        Try
            resultado = generar_encriptado(entrada)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

        Return resultado
    End Function

    Private Function generar_encriptado(input As String) As String
        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes(clave) 'La clave debe ser de 8 caracteres
        Dim EncryptionKey() As Byte = Convert.FromBase64String(clave64b) 'No se puede alterar la cantidad de caracteres pero si la clave
        Dim buffer() As Byte = Encoding.UTF8.GetBytes(input)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider

        des.Key = EncryptionKey
        des.IV = IV

        Return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
    End Function

    Public Function desencriptar(ByVal entrada As String) As String
        Dim resultado As String = ""

        Try
            resultado = generar_desencriptado(entrada)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

        Return resultado
    End Function

    Private Function generar_desencriptado(entrada As String) As String
        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes(clave) 'La clave debe ser de 8 caracteres
        Dim EncryptionKey() As Byte = Convert.FromBase64String(clave64b) 'No se puede alterar la cantidad de caracteres pero si la clave
        Dim buffer() As Byte = Convert.FromBase64String(entrada)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider

        des.Key = EncryptionKey
        des.IV = IV

        Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
    End Function
End Class
