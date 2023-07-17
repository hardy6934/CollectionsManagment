


function create() {
    const ItemId = document.getElementById('Id').value;
    const Comment = document.getElementById('CommentContent').value;

    const CreateComment = `${window.location.origin}/Comment/CreateComment?ItemId=${ItemId}&Content=${Comment}`;

    fetch(CreateComment).then(function () {

    });



    if (Comment != null && Comment != "") {
        const CommRoom = document.getElementById('CommentRoom');
        const GetAccName = `${window.location.origin}/Item/GetCurrentUserName`;

        fetch(GetAccName).then(function (response) {
            return response.text();
        }).then(function (response) {
            CommRoom.innerHTML += `<label class="form-label" for="n_Content">${Comment}</label>`;
            CommRoom.innerHTML += "  ";
            CommRoom.innerHTML += `<label class="form-label" for="n_dateTime">${new Date().toLocaleString()}</label>`;
            CommRoom.innerHTML += "  ";
            CommRoom.innerHTML += `<label class="form-label" for="n_SenderName">${response}</label>`;
            CommRoom.innerHTML += `<br/>`;
        });

    }

    document.getElementById('CommentContent').value = "" ;
};