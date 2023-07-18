let b = 0;
var BigString = document.getElementById("addBigStirng");
BigString.onclick = createBigStringElementsInside;
 

function createBigStringElementsInside() {
    //b++;
    //if (b == 1) {
    //    var fStr = document.getElementById("firstBigString");
    //    fStr.innerHTML = '<label asp-for="FirstBigStringFieldName" class="form-label">Name of this field </label>';
    //    fStr.innerHTML += '<input type="text" name="FirstBigStringFieldName" class="form-control">';
    //    fStr.innerHTML += '<label asp-for="FirstBigStringField" class="form-label">TextArea Field </label>';
    //    fStr.innerHTML += '<textarea   name="FirstBigStringField" class="form-control"></textarea>';
    //}
    //if (b == 2) {
    //    var sStr = document.getElementById("SecondBigString");
    //    sStr.innerHTML = '<label asp-for="SecondBigStringFieldName" class="form-label">Name of this field </label>';
    //    sStr.innerHTML += '<input type="text" name="SecondBigStringFieldName" class="form-control">';
    //    sStr.innerHTML += '<label asp-for="SecondBigStringField" class="form-label">TextArea Field </label>';
    //    sStr.innerHTML += '<textarea  name="SecondBigStringField" class="form-control"></textarea>';
    //}
    //if (b == 3) {
    //    var tStr = document.getElementById("ThirdBigString");
    //    tStr.innerHTML = '<label asp-for="ThirdBigStringFieldName" class="form-label">Name of this field </label>';
    //    tStr.innerHTML += '<input type="text" name="ThirdBigStringFieldName" class="form-control">';
    //    tStr.innerHTML += '<label asp-for="ThirdBigStringField" class="form-label">TextArea Field </label>';
    //    tStr.innerHTML += '<textarea  name="ThirdBigStringField" class="form-control" rows="3"></textarea>';
    //}
    //if (b > 3) {
    //    alert("Max 3 BigString fields");
    //    b = 4;
    //}



    var fStr = document.getElementById("firstBigString");
    var sStr = document.getElementById("SecondBigString");
    var tStr = document.getElementById("ThirdBigString");
     
    
    var fStr1 = $('#firstBigString').html();
    var sStr1 = $('#SecondBigString').html();
    var tStr1 = $('#ThirdBigString').html(); 

    if (fStr1.length == 0) {
        fStr.innerHTML = '<label asp-for="FirstBigStringFieldName" class="form-label">Name of this field </label>';
        fStr.innerHTML += '<input type="text" name="FirstBigStringFieldName" class="form-control">';
        fStr.innerHTML += '<label asp-for="FirstBigStringField" class="form-label">TextArea Field </label>';
        fStr.innerHTML += '<textarea   name="FirstBigStringField" class="form-control"></textarea>';
    } else if (sStr1.length == 0) {
        sStr.innerHTML = '<label asp-for="SecondBigStringFieldName" class="form-label">Name of this field </label>';
        sStr.innerHTML += '<input type="text" name="SecondBigStringFieldName" class="form-control">';
        sStr.innerHTML += '<label asp-for="SecondBigStringField" class="form-label">TextArea Field </label>';
        sStr.innerHTML += '<textarea  name="SecondBigStringField" class="form-control"></textarea>';
    } else if (tStr1.length == 0) {
        tStr.innerHTML = '<label asp-for="ThirdBigStringFieldName" class="form-label">Name of this field </label>';
        tStr.innerHTML += '<input type="text" name="ThirdBigStringFieldName" class="form-control">';
        tStr.innerHTML += '<label asp-for="ThirdBigStringField" class="form-label">TextArea Field </label>';
        tStr.innerHTML += '<textarea  name="ThirdBigStringField" class="form-control" rows="3"></textarea>';
    }
    else alert("Max 3 BigString fields");
     
}    


var BigStringForDelete = document.getElementById("remmoveBigStirng");
BigStringForDelete.onclick = removeBigStringElementsInside;


function removeBigStringElementsInside() {

    var fStr = document.getElementById("firstBigString");
    var sStr = document.getElementById("SecondBigString");
    var tStr = document.getElementById("ThirdBigString");


    var fStr1 = $('#firstBigString').html();
    var sStr1 = $('#SecondBigString').html();
    var tStr1 = $('#ThirdBigString').html();

    if (fStr1.length != 0) {
        fStr.innerHTML = '';
    } else if (sStr1.length != 0) {
        sStr.innerHTML = '';
    } else if (tStr1.length != 0) {
        tStr.innerHTML = '';
    }
    else alert("No one BigString fields");
}