let b = 0;
var BigString = document.getElementById("addBigStirng");
BigString.onclick = createBigStringElementsInside;

function createBigStringElementsInside() {
    b++;
    if (b == 1) {
        var fStr = document.getElementById("firstBigString");
        fStr.innerHTML = '<label asp-for="FirstBigStringFieldName" class="form-label">Name of this field </label>';
        fStr.innerHTML += '<input type="text" name="FirstBigStringFieldName" class="form-control">';
        fStr.innerHTML += '<label asp-for="FirstBigStringField" class="form-label">Datetime Field </label>';
        fStr.innerHTML += '<textarea type="datetime-local" name="FirstBigStringField" class="form-control"></textarea>';
    }
    if (b == 2) {
        var sStr = document.getElementById("SecondBigString");
        sStr.innerHTML = '<label asp-for="SecondBigStringFieldName" class="form-label">Name of this field </label>';
        sStr.innerHTML += '<input type="text" name="SecondBigStringFieldName" class="form-control">';
        sStr.innerHTML += '<label asp-for="SecondBigStringField" class="form-label">Datetime Field </label>';
        sStr.innerHTML += '<textarea type="datetime-local" name="SecondBigStringField" class="form-control"></textarea>';
    }
    if (b == 3) {
        var tStr = document.getElementById("ThirdBigString");
        tStr.innerHTML = '<label asp-for="ThirdBigStringFieldName" class="form-label">Name of this field </label>';
        tStr.innerHTML += '<input type="text" name="ThirdBigStringFieldName" class="form-control">';
        tStr.innerHTML += '<label asp-for="ThirdBigStringField" class="form-label">Datetime Field </label>';
        tStr.innerHTML += '<textarea type="datetime-local" name="ThirdBigStringField" class="form-control" rows="3"></textarea>';
    }
    if (b > 3) {
        alert("Max 3 BigString fields");
    }
}   