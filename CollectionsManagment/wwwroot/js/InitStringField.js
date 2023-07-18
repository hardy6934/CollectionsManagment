let st = 0;
var String = document.getElementById("addStirng");
String.onclick = createStringElementsInside;

function createStringElementsInside() {
    //st++;
    //if (st == 1) {
    //    var fStr = document.getElementById("firstString");
    //    fStr.innerHTML = '<label asp-for="FirstStringFieldName" class="form-label">Name of this field </label>';
    //    fStr.innerHTML += '<input type="text" name="FirstStringFieldName" class="form-control">';
    //    fStr.innerHTML += '<label asp-for="FirstStringField" class="form-label">String Field </label>';
    //    fStr.innerHTML += '<input type="text" name="FirstStringField" class="form-control">';
    //}
    //if (st == 2) {
    //    var sStr = document.getElementById("SecondString");
    //    sStr.innerHTML = '<label asp-for="SecondStringFieldName" class="form-label">Name of this field </label>';
    //    sStr.innerHTML += '<input type="text" name="SecondStringFieldName" class="form-control">';
    //    sStr.innerHTML += '<label asp-for="SecondStringField" class="form-label">String Field </label>';
    //    sStr.innerHTML += '<input type="text" name="SecondStringField" class="form-control">';
    //}
    //if (st == 3) {
    //    var tStr = document.getElementById("ThirdString");
    //    tStr.innerHTML = '<label asp-for="ThirdStringFieldName" class="form-label">Name of this field </label>';
    //    tStr.innerHTML += '<input type="text" name="ThirdStringFieldName" class="form-control">';
    //    tStr.innerHTML += '<label asp-for="ThirdStringField" class="form-label">String Field </label>';
    //    tStr.innerHTML += '<input type="text" name="ThirdStringField" class="form-control">';
    //}
    //if (st > 3) {
    //    alert("Max 3 string fields");
    //}


    var fStr = document.getElementById("firstString");
    var sStr = document.getElementById("SecondString");
    var tStr = document.getElementById("ThirdString");


    var fStr1 = $('#firstString').html();
    var sStr1 = $('#SecondString').html();
    var tStr1 = $('#ThirdString').html();

    if (fStr1.length == 0) {
        fStr.innerHTML = '<label asp-for="FirstStringFieldName" class="form-label">Name of this field </label>';
        fStr.innerHTML += '<input type="text" name="FirstStringFieldName" class="form-control">';
        fStr.innerHTML += '<label asp-for="FirstStringField" class="form-label">String Field </label>';
        fStr.innerHTML += '<input type="text" name="FirstStringField" class="form-control">';
    } else if (sStr1.length == 0) {
        sStr.innerHTML = '<label asp-for="SecondStringFieldName" class="form-label">Name of this field </label>';
        sStr.innerHTML += '<input type="text" name="SecondStringFieldName" class="form-control">';
        sStr.innerHTML += '<label asp-for="SecondStringField" class="form-label">String Field </label>';
        sStr.innerHTML += '<input type="text" name="SecondStringField" class="form-control">';
    } else if (tStr1.length == 0) {
        tStr.innerHTML = '<label asp-for="ThirdStringFieldName" class="form-label">Name of this field </label>';
        tStr.innerHTML += '<input type="text" name="ThirdStringFieldName" class="form-control">';
        tStr.innerHTML += '<label asp-for="ThirdStringField" class="form-label">String Field </label>';
        tStr.innerHTML += '<input type="text" name="ThirdStringField" class="form-control">';
    }
    else alert("Max 3 String fields");

}


var StringForDelete = document.getElementById("removeStirng");
StringForDelete.onclick = removeStringElementsInside;


function removeStringElementsInside() {

    var fStr = document.getElementById("firstString");
    var sStr = document.getElementById("SecondString");
    var tStr = document.getElementById("ThirdString");


    var fStr1 = $('#firstString').html();
    var sStr1 = $('#SecondString').html();
    var tStr1 = $('#ThirdString').html();

    if (fStr1.length != 0) {
        fStr.innerHTML = '';
    } else if (sStr1.length != 0) {
        sStr.innerHTML = '';
    } else if (tStr1.length != 0) {
        tStr.innerHTML = '';
    }
    else alert("No one BigString fields");
}