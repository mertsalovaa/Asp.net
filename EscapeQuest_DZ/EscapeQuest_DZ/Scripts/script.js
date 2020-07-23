
function go(id) {
    if (location.href.includes("Room")) {
        location.href = "Details?id=" + id;
    }
    else {
        location.href = "Room/Details?id=" + id;
    }
}

function goMainPage() {
    location.href = "";
    location.href = "./Index";
}

function ViewPhoto(imageSrc) {
    document.querySelector("#main-img").src = imageSrc;
}

function goSearch() {
    let search = document.querySelector('#searchInput').value;
    location.href = "./Room/Search?name=" + search;
}