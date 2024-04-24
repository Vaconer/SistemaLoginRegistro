@Code
    ViewData("Title") = "Home Page"
End Code

<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewData("Title")</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.3.0/css/bootstrap.min.css">
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f8f9fa;
            color: #343a40;
            margin: 0;
            padding: 0;
        }

        main {
            max-width: 800px;
            margin: 20px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            color: #007bff;
            font-weight: bold;
        }

        p {
            margin-bottom: 10px;
        }

        .btn-primary {
            background-color: #007bff;
            border-color: #007bff;
            transition: all 0.3s ease;
        }

            .btn-primary:hover {
                background-color: #0056b3;
                border-color: #0056b3;
            }

        #chartContainer {
            width: 100%;
            height: 300px;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <main>
        <h2>Bem-vindo, @Model.UsernameUS!</h2>
        <p>Seu ID: @Model.IDUs</p>
        <p>Sua senha: @Model.PassWordUs</p>

        <!-- Gráfico de pizza -->
        <div id="chartContainer"></div>

        @Html.ActionLink("Editar Perfil", "Edit", "Home", Nothing, New With {.class = "btn btn-primary"})
    </main>

    <!-- Scripts -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/canvasjs/1.7.0/canvasjs.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.3.0/js/bootstrap.bundle.min.js"></script>
    <script>
        window.onload = function () {
            var chart = new CanvasJS.Chart("chartContainer", {
                animationEnabled: true,
                title: {
                    text: "Linguagens Web Dominadas"
                },
                data: [{
                    type: "pie",
                    startAngle: 240,
                    yValueFormatString: "##0.00\"%\"",
                    indexLabel: "{label} {y}",
                    dataPoints: [
                        { y: 40, label: "HTML" },
                        { y: 25, label: "CSS" },
                        { y: 20, label: "JavaScript" },
                        { y: 15, label: "PHP" }
                    ]
                }]
            });
            chart.render();
        }
    </script>
</body>
</html>
