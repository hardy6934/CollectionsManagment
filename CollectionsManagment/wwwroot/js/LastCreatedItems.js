
    lastItems = document.getElementById('lastItems');

    const GetItems = `${window.location.origin}/MainPage/GetLastCreatedItems`;

    fetch(GetItems).then(function (response) {
        return response.text();
    })
        .then(function (response) {
            lastItems.innerHTML = response;
        })
        .catch(function () {
            console.log("something went wrong")
        });