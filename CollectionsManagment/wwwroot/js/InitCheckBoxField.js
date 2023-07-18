
var k = 0;
var button = document.getElementById("addCheckBox");
button.onclick = createBoolElementsInside;

function createBoolElementsInside() {
    //k++;
    //if (k == 1) {
    //    var fBool = document.getElementById("firstBool");
    //    fBool.innerHTML = ' <label asp-for="FirstBoolFieldName" class="form-label">Name of this field </label>';
    //    fBool.innerHTML += '<input type = "text" name= "FirstBoolFieldName" class= "form-control" value="">';
    //    fBool.innerHTML += '<label asp-for= "FirstBoolField" class= "form-label"> Bool Field </label>';
    //    fBool.innerHTML += '<input type="checkbox" class="form-check-input" data-val="true" data-val-required="The StringForFirstBoolField field is required." id="StringForFirstBoolField" name="StringForFirstBoolField" value="true">';
    //    fBool.innerHTML += '<input type="hidden" name="StringForFirstBoolField" value="false">';

    //}
    //if (k == 2) {
    //    var sBool = document.getElementById("SecondBool");
    //    sBool.innerHTML = '<label asp-for= "SecondBoolFieldName" class= "form-label"> Name of this field </label>';
    //    sBool.innerHTML += '<input type = "text" name= "SecondBoolFieldName" class= "form-control" value="">';
    //    sBool.innerHTML += '<label asp-for= "SecondBoolField" class= "form-label"> Bool Field </label>';
    //    sBool.innerHTML += '<input type="checkbox" class="form-check-input" data-val="true" data-val-required="The StringForSecondBoolField field is required." id="StringForSecondBoolField" name="StringForSecondBoolField" value="true">';
    //    sBool.innerHTML += '<input type="hidden"  data-val="true" name="StringForSecondBoolField" value="false">';
    //}
    //if (k == 3) {
    //    var tBool = document.getElementById("ThirdBool");
    //    tBool.innerHTML = '<label asp-for= "ThirdtBoolFieldName" class= "form-label"> Name of this field </label>';
    //    tBool.innerHTML += '<input type = "text" name= "ThirdtBoolFieldName" class= "form-control" value="">';
    //    tBool.innerHTML += '<label asp-for= "ThirdtBoolField" class= "form-label"> Bool Field </label>';
    //    tBool.innerHTML += '<input type="checkbox" class="form-check-input" data-val="true" data-val-required="The StringForThirdBoolField field is required." id="StringForThirdBoolField" name="StringForThirdBoolField" value="true"/>';
    //    tBool.innerHTML += '<input type="hidden" name="StringForThirdBoolField" value="false"/>';
    //}
    //if (k > 3) {
    //    alert("Max 3 bool fields");
    //}



    var fBool = document.getElementById("firstBool"); 
    var sBool = document.getElementById("SecondBool");
    var tBool = document.getElementById("ThirdBool");

    var fBoolEl = $('#firstBool').html();
    var sBoolEl = $('#SecondBool').html();
    var tBoolEl = $('#ThirdBool').html(); 

    if (fBoolEl.length == 0) {
        fBool.innerHTML = ' <label asp-for="FirstBoolFieldName" class="form-label">Name of this field </label>';
        fBool.innerHTML += '<input type = "text" name= "FirstBoolFieldName" class= "form-control" value="">';
        fBool.innerHTML += '<label asp-for= "FirstBoolField" class= "form-label"> Bool Field </label>';
        fBool.innerHTML += '<input type="checkbox" class="form-check-input" data-val="true" data-val-required="The StringForFirstBoolField field is required." id="StringForFirstBoolField" name="StringForFirstBoolField" value="true">';
        fBool.innerHTML += '<input type="hidden" name="StringForFirstBoolField" value="false">';
    } else if (sBoolEl.length == 0) {
        sBool.innerHTML = '<label asp-for= "SecondBoolFieldName" class= "form-label"> Name of this field </label>';
        sBool.innerHTML += '<input type = "text" name= "SecondBoolFieldName" class= "form-control" value="">';
        sBool.innerHTML += '<label asp-for= "SecondBoolField" class= "form-label"> Bool Field </label>';
        sBool.innerHTML += '<input type="checkbox" class="form-check-input" data-val="true" data-val-required="The StringForSecondBoolField field is required." id="StringForSecondBoolField" name="StringForSecondBoolField" value="true">';
        sBool.innerHTML += '<input type="hidden"  data-val="true" name="StringForSecondBoolField" value="false">';
    } else if (tBoolEl.length == 0) {
        tBool.innerHTML = '<label asp-for= "ThirdtBoolFieldName" class= "form-label"> Name of this field </label>';
        tBool.innerHTML += '<input type = "text" name= "ThirdtBoolFieldName" class= "form-control" value="">';
        tBool.innerHTML += '<label asp-for= "ThirdtBoolField" class= "form-label"> Bool Field </label>';
        tBool.innerHTML += '<input type="checkbox" class="form-check-input" data-val="true" data-val-required="The StringForThirdBoolField field is required." id="StringForThirdBoolField" name="StringForThirdBoolField" value="true"/>';
        tBool.innerHTML += '<input type="hidden" name="StringForThirdBoolField" value="false"/>';
    }
    else alert("Max 3 CheckBox fields");
}



var buttonForRemove = document.getElementById("removeCheckBox");
buttonForRemove.onclick = removeBoolElementsInside;

function removeBoolElementsInside() {
     

    var fBool = document.getElementById("firstBool");
    var sBool = document.getElementById("SecondBool");
    var tBool = document.getElementById("ThirdBool");

    var fBoolEl = $('#firstBool').html();
    var sBoolEl = $('#SecondBool').html();
    var tBoolEl = $('#ThirdBool').html();

    if (fBoolEl.length != 0) {
        fBool.innerHTML = '';
    } else if (sBoolEl.length != 0) {
        sBool.innerHTML = '';
    } else if (tBoolEl.length != 0) {
        tBool.innerHTML = '';
    }
    else alert("No one CheckBox field");
}