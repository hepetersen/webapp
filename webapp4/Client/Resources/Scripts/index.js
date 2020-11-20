function getPosts() {
    const allPostsApiUrl = "https://localhost:5001/api/post";

    fetch(allPostsApiUrl).then(function (response) {
        console.log(response); //testing response
        return response.json();
    }).then(function (json) {
        let html = "<table class=\"table-bordered table-hover\">";
        html += " <tr><th>Post Text:</th>"
        json.forEach((post) => {
            html += "<tr><td>" + post.text
                + "</td>";
        });
        html += "</table>";
        document.getElementById("postTable").innerHTML = html;
    }).catch(function (error) {
        console.log(error);
    })
}


function makePost() {
    const makePostApiUrl = "https://localhost:5001/api/post";
    const postText = document.getElementById("text").value;
    const postDate = new Date();

    fetch(makePostApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify({
            text: postText,
            date: postDate
        })
    })
        .then((response) => {
            console.log(response);
            getPosts();
            refreshPage();
        })
}


function deletePost() {
    const deletePostsApiUrl = "https://localhost:5001/api/post";

    fetch(deletePostsApiUrl).then(function (response) {
        console.log(response); //testing response
        return response.json();
    }).then(function (json) {
        let html = "<table class=\"table-bordered table-hover\">";
        html += " <tr><th>Post Text</th><th>Delete</th>";
        json.forEach((post) => {
            html += "<tr><td>" + post.text
                + "</td>" + "<td>" + "<button type='button' onclick='deletePostById(" + post.id + ")' class='btn btn-default'>" +
                "<span class='glyphicon glyphicon-remove'/>" +
                "</button>" + "</td>" + "</tr>";
        });
        html += "</table>";
        document.getElementById("deleteTable").innerHTML = html;
    }).catch(function (error) {
        console.log(error);
    })
}

function deletePostById(id) {
    const deletePostApiUrl = "https://localhost:5001/api/post/" + id;
    const postId = id;

    fetch(deletePostApiUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify({
            id: Number(postId),
        })
    })
        .then((response) => {
            console.log(response);
            refreshPage();
            getPosts();
        })
}

function refreshPage() {
    window.location.reload();
}

function editPost() {
    const editPostsApiUrl = "https://localhost:5001/api/post";

    fetch(editPostsApiUrl).then(function (response) {
        console.log(response); //testing response
        return response.json();
    }).then(function (json) {
        let html = "<table class=\"table-bordered table-hover\">";
        html += " <tr><th>Post Text</th><th>Edit</th>";
        json.forEach((post) => {
            let tempText = post.text;
            let tempId = post.id;
            html += "<tr key=" + post.id +"><tr><td>" + post.text
                + "</td>" + "<td>" + "<button type='button' class='btn btn-default' onclick= \"showModal(" + tempId + ",\'" + tempText + "\')\">" +
                "<span class='glyphicon glyphicon-edit'/>" +
                "</button>" + "</td>" + "</tr>";
        });
        html += "</table>";

        document.getElementById("editTable").innerHTML = html;
    }).catch(function (error) {
        console.log(error);
    })
}


