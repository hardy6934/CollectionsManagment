
var SearchInCollButton = document.getElementById('SearchInColl');
SearchInCollButton.onclick = StartSearchingInColl;



function StartSearchingInColl()
{

    var collectionsAfterSearch = document.getElementById('CollsAfterSearch');
    var collectionsBeforeSearch = document.getElementById('CollectionsBeforeSearch');



    const req = `${window.location.origin}/Collection/SearchInCollections?name=${document.getElementById('SearchValueForCollection').value}`;
     

    fetch(req).then(function(response) {
    return response.text();
})
        .then(function (response) {
       collectionsBeforeSearch.innerHTML = '';
       collectionsAfterSearch.innerHTML = response;
})
        .catch (function () {
    console.log("something went wrong")
        });

};

