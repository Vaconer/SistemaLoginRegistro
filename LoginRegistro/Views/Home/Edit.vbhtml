@ModelType LoginRegistro.TBLUserInfo
@Code
    ViewData("Title") = "Edit"
End Code

<style>
    /* Estilos CSS */
    .green-dot {
        position: fixed;
        bottom: -50%;
        left: 30%;
        width: 3000px;
        height: 3000px;
        background-color: green;
        border-radius: 50%;
        z-index: -1;
    }

    .form-container {
        border: 1px solid #ccc;
        padding: 20px;
        margin: 20px;
        width: 27%;
        margin-top: 15%;
        background-color: #f5f5f5;
        box-shadow: 0 8px 10px 0 rgba(0, 0, 0, 0.3);
        border-radius: 10px;
        opacity: 0; /* Inicialmente, definimos a opacidade como 0 */
        transition: opacity 0.5s ease, margin-left 0.5s ease; /* Adicionamos uma transição suave para a opacidade e a margem esquerda */
        margin-left: -30%; /* Definimos a margem esquerda como -30% para que o formulário comece à esquerda */
    }

        .form-container.fade-in {
            opacity: 1; /* Quando a classe fade-in é aplicada, a opacidade muda para 1 */
            margin-left: 0%; /* Quando a classe fade-in é aplicada, a margem esquerda muda para 0% */
        }

    .form-horizontal h2 {
        margin-top: 10%;
        margin-bottom: 5%;
        padding-left: 30%;
        font-size: 35px;
    }

    .form-horizontal {
        margin-left: 5%;
    }

    .form-group {
        position: relative;
    }

    .form-control {
        width: 100%;
        border: none; /* Remove todas as bordas padrão */
        border-bottom: 1px solid black; /* Apenas borda inferior preta */
        border-left: 1px solid black; /* Apenas borda esquerda preta */
        border-radius: 0; /* Remove o arredondamento das bordas */
        box-sizing: border-box; /* Mantém a largura total, incluindo a borda */
        padding: 8px; /* Adiciona espaço interno */
        border-radius: 5px;
        background-color: transparent;
    }

    .form-group:first-child .form-control {
        border-top: none; /* Remove a borda superior para o primeiro grupo */
    }

    .form-group:last-child .form-control {
        border-right: none; /* Remove a borda direita para o último grupo */
    }

    .form-login {
        margin-left: 30%;
        border: 1px solid black;
        width: 20%;
        border-radius: 8px;
    }

        .form-login:hover input[type="submit"] {
            background-color: black;
            color: white;
        }

    /* Estilos para remover contorno, borda e sombra ao focar */
    .form-control:focus {
        box-shadow: none;
        border: none;
        outline: none;
        background-color: transparent;
        border: 1px solid black;
    }

    .link {
        margin-left: 25%;
    }
</style>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-container">
        <div class="form-horizontal">

            <h2>Edit</h2>

            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

            <div class="form-group">
                @Html.HiddenFor(Function(model) model.IDUs)
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.UsernameUS, "Usuário", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.UsernameUS, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.UsernameUS, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.PassWordUs, "Senha", htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.PassWordUs, New With {.htmlAttributes = New With {.class = "form-control", .type = "password"}})
                    @Html.ValidationMessageFor(Function(model) model.PassWordUs, "", New With {.class = "text-danger"})
                </div>
            </div>

            <br />

            <div class="form-login">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="Save" class="btn btn-default" />
                </div>
            </div>

            <div class="link">
                @Html.ActionLink("Back to List", "Index")
            </div>
        </div>
    </div>
End Using

<div class="green-dot"></div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    <script>
        // Adiciona a classe fade-in ao form-container para aplicar o efeito de fade-in e mover para a direita
        document.addEventListener("DOMContentLoaded", function (event) {
            var formContainer = document.querySelector(".form-container");
            formContainer.classList.add("fade-in");
            setTimeout(function () {
                formContainer.style.marginLeft = "0%"; // Define a margem esquerda como 0% após um pequeno atraso
            }, 50);
        });
    </script>
End Section
