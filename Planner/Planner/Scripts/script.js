function goSearch() {
    let search = document.querySelector('#searchInput').value;
    if (location.href.includes("Planner")) {
        location.href = "./Search?name=" + search;
    }
    else {
        location.href = "./Planner/Search?name=" + search;
    }
}