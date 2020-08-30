function setDeveloper(event) {
    $("#games").load(`/Games/Filter?type=Developer&name=${encodeURIComponent(event.target.name)}`);
}

function setGenre(event) {
    $("#games").load(`/Games/Filter?type=Genre&name=${encodeURIComponent(event.target.name)}`);
}

function goSearch() {
    let search = document.querySelector('#searchInput').value;
    location.href = "Games/Search?name=" + search;
}