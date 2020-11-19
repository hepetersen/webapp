var span = document.getElementsByClassName("close")[0];

showModal = function(id, text)
{
    var modal = document.getElementById("editModal");
    document.getElementById("updateText").value = text;
    document.getElementById("updateSubmit").setAttribute('onclick', 'putPost(' + id + ')');
    modal.style.display = "block";

    var span = document.getElementsByClassName("close")[0];
}

function putPost(id)
{
    const intId = Number(id);
    const putPostApiUrl = "https://localhost:5001/api/posts/" + intId;
    const postText = document.getElementById("updateText").value;
    
    fetch(putPostApiUrl, {
        method:"PUT",
        mode: "cors",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify({
            id: intId,
            text: postText
        })
    })
        .then((response) => {
            console.log(response);
            getPosts();
            //refreshPage();
        })
}

closeModal = function(){
    var modal = document.getElementById("editModal");
    modal.style.display = "none";
}

window.onclick = function(event){
    var modal = document.getElementById("editModal");
    if(event.target == modal) {
        modal.style.display = "none";
    }
}