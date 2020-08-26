function setDeveloper(event) {
    $("#games").load(`Games/Filter?type=Developer&name=${event.target.name}`);
}

function setGenre(event) {
    location.search = `type=Genre&name=${event.target.name}`;
}
