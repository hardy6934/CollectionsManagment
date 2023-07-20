var SearchTagsButton = document.getElementById("TagSearch");
SearchTagsButton.onclick = StartSearching; 



function StartSearching() { 
    var TagsFromTagCloud = document.getElementById('allTagsFromTagCloud');

    var TagAfterSearch = document.getElementById('tagAfterSearch');

     
      
    const FindTagItems = `${window.location.origin}/TagItem/GetTagItemsForSearchByNameInTagCloud?name=${document.getElementById('TagSearchValue').value}`;

    fetch(FindTagItems).then(function (response) { 
             
    }); 

    fetch(FindTagItems).then(function (response) {
        return response.text();
    })
        .then(function (response) {
            TagsFromTagCloud.innerHTML = '';
            TagAfterSearch.innerHTML = response;
        })
        .catch(function () {
            console.log("something went wrong")
        });

};
