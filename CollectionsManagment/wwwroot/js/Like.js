
function createLike() {
    const ItemId = document.getElementById('Id').value; 
    count = document.querySelector("#count");

    const CreateLike = `${window.location.origin}/Like/CreateLike?itemId=${ItemId}`;

    fetch(CreateLike).then(function (response) {
        if (response.status == 201)
        {
            count.textContent++;
        }
    }); 
};