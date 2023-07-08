let d = 0;
var dateTimeEl = document.getElementById("addDateTime");
dateTimeEl.onclick = createDateTimeElementsInside;

function createDateTimeElementsInside() {
    d++;
    if (d == 1) {
        var fBool = document.getElementById("firstDateTime");
        fBool.innerHTML = '<label asp-for="FirstDatetimeFieldName" class="form-label">Name of this field </label>';
        fBool.innerHTML += '<input type="text" name="FirstDatetimeFieldName" class="form-control">';
        fBool.innerHTML += '<label asp-for="FirstDatetimeField" class="form-label">Datetime Field </label>';
        fBool.innerHTML += '<input type="datetime-local" name="FirstDatetimeField" class="form-control">';
    }
    if (d == 2) {
        var sBool = document.getElementById("SecondDateTime");
        sBool.innerHTML = '<label asp-for="SecondDatetimeFieldName" class="form-label">Name of this field </label>';
        sBool.innerHTML += '<input type="text" name="SecondDatetimeFieldName" class="form-control">';
        sBool.innerHTML += '<label asp-for="SecondDatetimeField" class="form-label">Datetime Field </label>';
        sBool.innerHTML += '<input type="datetime-local" name="SecondDatetimeField" class="form-control">';
    }
    if (d == 3) {
        var tBool = document.getElementById("ThirdDateTime");
        tBool.innerHTML = '<label asp-for="ThirdDatetimeFieldName" class="form-label">Name of this field </label>';
        tBool.innerHTML += '<input type="text" name="ThirdDatetimeFieldName" class="form-control">';
        tBool.innerHTML += '<label asp-for="ThirdDatetimeField" class="form-label">Datetime Field </label>';
        tBool.innerHTML += '<input type="datetime-local" name="ThirdDatetimeField" class="form-control">';
    }
    if (d > 3) {
        alert("Max 3 DateTime fields");
    }
}   