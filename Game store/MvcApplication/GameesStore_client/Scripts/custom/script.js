function setDeveloper(event) {
    $("#games").load(`/Games/Filter?type=Developer&name=${encodeURIComponent(event.target.name)}`);
}

function setGenre(event) {
    $("#games").load(`/Games/Filter?type=Genre&name=${encodeURIComponent(event.target.name)}`);
}

function goSearch() {
    location.href = "/Games/Search?name=" + document.querySelector('#name').value;
}

function setOption(event) {
    if (event.target.value == "url") {
        $("#" + event.target.value).removeClass("d-none");
        $("#comp").addClass("d-none");
    }
    else if (event.target.value == "comp") {
        $("#" + event.target.value).removeClass("d-none");
        $("#url").addClass("d-none");
    }
}