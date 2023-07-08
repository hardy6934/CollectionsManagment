let n = 0;
var num = document.getElementById("addNumeric");
num.onclick = createNumElementsInside;

function createNumElementsInside() {
    n++;
    if (n == 1) {
        var fNum = document.getElementById("firstNum");
        fNum.innerHTML = '<label asp-for="FirstNumericFieldName" class="form-label">Name of this field </label>';
        fNum.innerHTML += '<input type="text" name="FirstNumericFieldName" class="form-control">';
        fNum.innerHTML += '<label asp-for="FirstNumericField" class="form-label">String Field </label>';
        fNum.innerHTML += '<input type="number" name="FirstNumericField" class="form-control">';
    }
    if (n == 2) {
        var sNum = document.getElementById("SecondNum");
        sNum.innerHTML = '<label asp-for="SecondNumericFieldName" class="form-label">Name of this field </label>';
        sNum.innerHTML += '<input type="text" name="SecondNumericFieldName" class="form-control">';
        sNum.innerHTML += '<label asp-for="SecondNumericField" class="form-label">String Field </label>';
        sNum.innerHTML += '<input type="number" name="SecondNumericField" class="form-control">';
    }
    if (n == 3) {
        var tNum = document.getElementById("ThirdNum");
        tNum.innerHTML = '<label asp-for="ThirdNumericFieldName" class="form-label">Name of this field </label>';
        tNum.innerHTML += '<input type="text" name="ThirdNumericFieldName" class="form-control">';
        tNum.innerHTML += '<label asp-for="ThirdNumericField" class="form-label">String Field </label>';
        tNum.innerHTML += '<input type="number" name="ThirdNumericField" class="form-control">';
    }
    if (n > 3) {
        alert("Max 3 num fields");
    }
}   