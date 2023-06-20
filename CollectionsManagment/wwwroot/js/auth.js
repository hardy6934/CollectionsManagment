let navbar = document.getElementById('login-nav');
const GetLoginPreviewUrl = `${window.location.origin}/account/UserLoginPreview`;

fetch(GetLoginPreviewUrl).then(function (response) {
    return response.text();
})
    .then(function (response) {
        navbar.innerHTML = response;
    })
    .catch(function () {
        console.log("something went wrong")
    });