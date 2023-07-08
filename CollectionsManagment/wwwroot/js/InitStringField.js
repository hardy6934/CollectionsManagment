let st = 0;
var String = document.getElementById("addStirng");
String.onclick = createStringElementsInside;

function createStringElementsInside() {
    st++;
    if (st == 1) {
        var fStr = document.getElementById("firstString");
        fStr.innerHTML = '<label asp-for="FirstStringFieldName" class="form-label">Name of this field </label>';
        fStr.innerHTML += '<input type="text" name="FirstStringFieldName" class="form-control">';
        fStr.innerHTML += '<label asp-for="FirstStringField" class="form-label">String Field </label>';
        fStr.innerHTML += '<input type="text" name="FirstStringField" class="form-control">';
    }
    if (st == 2) {
        var sStr = document.getElementById("SecondString");
        sStr.innerHTML = '<label asp-for="SecondStringFieldName" class="form-label">Name of this field </label>';
        sStr.innerHTML += '<input type="text" name="SecondStringFieldName" class="form-control">';
        sStr.innerHTML += '<label asp-for="SecondStringField" class="form-label">String Field </label>';
        sStr.innerHTML += '<input type="text" name="SecondStringField" class="form-control">';
    }
    if (st == 3) {
        var tStr = document.getElementById("ThirdString");
        tStr.innerHTML = '<label asp-for="ThirdStringFieldName" class="form-label">Name of this field </label>';
        tStr.innerHTML += '<input type="text" name="ThirdStringFieldName" class="form-control">';
        tStr.innerHTML += '<label asp-for="ThirdStringField" class="form-label">String Field </label>';
        tStr.innerHTML += '<input type="text" name="ThirdStringField" class="form-control">';
    }
    if (st > 3) {
        alert("Max 3 string fields");
    }
}   