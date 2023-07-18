let n = 0;
var num = document.getElementById("addNumeric");
num.onclick = createNumElementsInside;

function createNumElementsInside() {
    //n++;
    //if (n == 1) {
    //    var fNum = document.getElementById("firstNum");
    //    fNum.innerHTML = '<label asp-for="FirstNumericFieldName" class="form-label">Name of this field </label>';
    //    fNum.innerHTML += '<input type="text" name="FirstNumericFieldName" class="form-control">';
    //    fNum.innerHTML += '<label asp-for="FirstNumericField" class="form-label">String Field </label>';
    //    fNum.innerHTML += '<input type="number" name="FirstNumericField" class="form-control">';
    //}
    //if (n == 2) {
    //    var sNum = document.getElementById("SecondNum");
    //    sNum.innerHTML = '<label asp-for="SecondNumericFieldName" class="form-label">Name of this field </label>';
    //    sNum.innerHTML += '<input type="text" name="SecondNumericFieldName" class="form-control">';
    //    sNum.innerHTML += '<label asp-for="SecondNumericField" class="form-label">String Field </label>';
    //    sNum.innerHTML += '<input type="number" name="SecondNumericField" class="form-control">';
    //}
    //if (n == 3) {
    //    var tNum = document.getElementById("ThirdNum");
    //    tNum.innerHTML = '<label asp-for="ThirdNumericFieldName" class="form-label">Name of this field </label>';
    //    tNum.innerHTML += '<input type="text" name="ThirdNumericFieldName" class="form-control">';
    //    tNum.innerHTML += '<label asp-for="ThirdNumericField" class="form-label">String Field </label>';
    //    tNum.innerHTML += '<input type="number" name="ThirdNumericField" class="form-control">';
    //}
    //if (n > 3) {
    //    alert("Max 3 num fields");
    //}

    var fNum = document.getElementById("firstNum");
    var sNum = document.getElementById("SecondNum");
    var tNum = document.getElementById("ThirdNum");


    var fNum1 = $('#firstNum').html();
    var sNum1 = $('#SecondNum').html();
    var tNum1 = $('#ThirdNum').html();

    if (fNum1.length == 0) {
        fNum.innerHTML = '<label asp-for="FirstNumericFieldName" class="form-label">Name of this field </label>';
        fNum.innerHTML += '<input type="text" name="FirstNumericFieldName" class="form-control">';
        fNum.innerHTML += '<label asp-for="FirstNumericField" class="form-label">Numerical Field </label>';
        fNum.innerHTML += '<input type="number" name="FirstNumericField" class="form-control">';
    } else if (sNum1.length == 0) {
        sNum.innerHTML = '<label asp-for="SecondNumericFieldName" class="form-label">Name of this field </label>';
        sNum.innerHTML += '<input type="text" name="SecondNumericFieldName" class="form-control">';
        sNum.innerHTML += '<label asp-for="SecondNumericField" class="form-label">Numerical Field </label>';
        sNum.innerHTML += '<input type="number" name="SecondNumericField" class="form-control">';
    } else if (tNum1.length == 0) {
        tNum.innerHTML = '<label asp-for="ThirdNumericFieldName" class="form-label">Name of this field </label>';
        tNum.innerHTML += '<input type="text" name="ThirdNumericFieldName" class="form-control">';
        tNum.innerHTML += '<label asp-for="ThirdNumericField" class="form-label">Numerical Field </label>';
        tNum.innerHTML += '<input type="number" name="ThirdNumericField" class="form-control">';
    }
    else alert("Max 3 Num fields");

}


var NumForDelete = document.getElementById("removeNumeric");
NumForDelete.onclick = removeNumElementsInside;


function removeNumElementsInside() {

    var fNum = document.getElementById("firstNum");
    var sNum = document.getElementById("SecondNum");
    var tNum = document.getElementById("ThirdNum");


    var fNum1 = $('#firstNum').html();
    var sNum1 = $('#SecondNum').html();
    var tNum1 = $('#ThirdNum').html();

    if (fNum1.length != 0) {
        fNum.innerHTML = '';
    } else if (sNum1.length != 0) {
        sNum.innerHTML = '';
    } else if (tNum1.length != 0) {
        tNum.innerHTML = '';
    }
    else alert("No one Num fields");
}