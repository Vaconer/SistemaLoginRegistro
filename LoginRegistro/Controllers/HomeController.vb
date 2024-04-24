Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Core.Metadata.Edm
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Validation
Imports System.Linq
Imports System.Web.Mvc
Imports UserSignUpLogin.Models

Namespace UserSignUpLogin.Controllers
    Public Class HomeController
        Inherits Controller

        Private ReadOnly db As New DBuserSignupLoginEntities()

        ' GET: Home/Index
        Public Function Index() As ActionResult
            If Session("IdUsSS") Is Nothing Then
                Return RedirectToAction("Login")
            End If

            Dim userId As Integer = Convert.ToInt32(Session("IdUsSS"))

            Dim currentUser = db.TBLUserInfoes.Find(userId)

            If currentUser Is Nothing Then
                Session.Clear()
                Return RedirectToAction("Login")
            End If

            ' Passa os dados do usuário para a view
            Return View(currentUser)
        End Function


        ' GET: Home/ChangePassword
        Public Function ChangePassword() As ActionResult
            If Session("IdUsSS") Is Nothing Then
                Return RedirectToAction("Login")
            End If

            Dim userId As Integer = Convert.ToInt32(Session("IdUsSS"))

            Dim currentUser = db.TBLUserInfoes.Find(userId)

            If currentUser Is Nothing Then
                Session.Clear()
                Return RedirectToAction("Login")
            End If

            Return View(currentUser)
        End Function

        ' POST: Home/ChangePassword
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function ChangePassword(ByVal newPassword As String) As ActionResult
            If Session("IdUsSS") Is Nothing Then
                Return RedirectToAction("Login")
            End If

            Dim userId As Integer = Convert.ToInt32(Session("IdUsSS"))

            Dim currentUser = db.TBLUserInfoes.Find(userId)

            If currentUser Is Nothing Then
                Session.Clear()
                Return RedirectToAction("Login")
            End If

            If ModelState.IsValid Then
                ' Atualiza a senha do usuário
                currentUser.PassWordUs = newPassword
                db.Entry(currentUser).Property(Function(u) u.PassWordUs).IsModified = True
                db.SaveChanges()
                Return Content("Senha atualizada com sucesso!")
            End If

            Return View(currentUser)
        End Function

        ' GET: Home/Login
        Public Function Login() As ActionResult
            Return View()
        End Function

        ' POST: Home/Login
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function Login(ByVal tBLUserInfo As TBLUserInfo) As ActionResult
            Dim checkLogin = db.TBLUserInfoes.FirstOrDefault(Function(x) x.UsernameUS.Equals(tBLUserInfo.UsernameUS) AndAlso x.PassWordUs.Equals(tBLUserInfo.PassWordUs))
            If checkLogin IsNot Nothing Then
                Session("IdUsSS") = checkLogin.IDUs.ToString()
                Session("UsernameSS") = checkLogin.UsernameUS.ToString()
                Return RedirectToAction("Index")
            Else
                ViewBag.Notification = "Usuário ou senha inválidos"
                Return View()
            End If
        End Function

        ' GET: Home/Logout
        Public Function Logout() As ActionResult
            Session.Clear()
            Return RedirectToAction("Login")
        End Function

        ' GET: Home/Signup
        Public Function Signup() As ActionResult
            Return View()
        End Function

        ' POST: Home/Signup
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function Signup(ByVal tBLUserInfo As TBLUserInfo) As ActionResult
            If db.TBLUserInfoes.Any(Function(x) x.UsernameUS = tBLUserInfo.UsernameUS) Then
                ViewBag.Notification = "Essa conta já existe"
                Return View()
            Else
                db.TBLUserInfoes.Add(tBLUserInfo)
                db.SaveChanges()

                Session("IdUsSS") = tBLUserInfo.IDUs.ToString()
                Session("UsernameSS") = tBLUserInfo.UsernameUS.ToString()
                Return RedirectToAction("Index")
            End If
        End Function

        ' GET: Home/Details
        Public Function Details() As ActionResult
            If Session("IdUsSS") Is Nothing Then
                Return RedirectToAction("Login")
            End If

            Dim userId As Integer = Convert.ToInt32(Session("IdUsSS"))

            Dim currentUser = db.TBLUserInfoes.Find(userId)

            If currentUser Is Nothing Then
                Session.Clear()
                Return RedirectToAction("Login")
            End If

            Return View(currentUser)
        End Function

        ' GET: Home/Edit
        Public Function Edit() As ActionResult
            ' Verifica se o usuário está autenticado
            If Session("IdUsSS") Is Nothing Then
                Return RedirectToAction("Login")
            End If

            ' Obtém o ID do usuário da sessão
            Dim userId As Integer = Convert.ToInt32(Session("IdUsSS"))

            ' Busca o usuário no banco de dados pelo ID
            Dim currentUser = db.TBLUserInfoes.Find(userId)

            ' Verifica se o usuário existe
            If currentUser Is Nothing Then
                ' Se não existir, limpa a sessão e redireciona para a página de login
                Session.Clear()
                Return RedirectToAction("Login")
            End If

            ' Retorna a view de edição com o usuário encontrado
            Return View(currentUser)
        End Function

        ' POST: Home/Edit
        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function Edit(ByVal model As TBLUserInfo) As ActionResult
            ' Verifica se o usuário está autenticado
            If Session("IdUsSS") Is Nothing Then
                Return RedirectToAction("Login")
            End If

            ' Verifica se o modelo é válido
            If ModelState.IsValid Then
                ' Atualiza as informações do usuário no banco de dados
                db.Entry(model).State = EntityState.Modified
                db.SaveChanges()

                ' Redireciona para a página de detalhes do usuário
                Return RedirectToAction("Index")
            End If

            ' Se houver erros de validação, retorna a view de edição com o modelo
            Return View(model)
        End Function
    End Class
End Namespace
