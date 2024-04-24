@ModelType IEnumerable(Of LoginRegistro.TBLUserInfo)
@Code
ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.IDUs)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.UsernameUS)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PassWordUs)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IDUs)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.UsernameUS)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PassWordUs)
        </td>
        <td>
            @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
        </td>
    </tr>
Next

</table>
