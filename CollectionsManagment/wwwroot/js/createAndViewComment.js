


document.getElementById("CreateComment").addEventListener("click", () => {

    const ItemId = document.getElementById('Id').value;
    const Comment = document.getElementById('CommentContent').value; 

    const GetLoginPreviewUrl = `${window.location.origin}/Comment/CreateComment?ItemId=${ItemId}&Content=${Comment}`;

    fetch(GetLoginPreviewUrl).then(function () {
    });

    Comment.value = "";
});

//var ReciverInput = document.getElementById("username");
//ReciverInput.onchange = function () {

//    let navbar = document.getElementById('History');
//    const GetChatHistory = `${window.location.origin}/Chat/ChatHistory?Sender=${sender}&Reciver=${ReciverInput.value}`;

//    fetch(GetChatHistory).then(function (response) {
//        return response.text();
//    })
//        .then(function (response) {
//            navbar.innerHTML = response;
//            AddEvent();
//        })
//        .catch(function () {
//            console.log("something went wrong")
//        });

//    chatRoomValues = document.getElementById('chatroom');
//    chatRoomValues.innerHTML = "";


//};
