export function toggleSideNav() {
    var element = document.getElementById("sideBarContainer");
    element.classList.toggle("active");
}

function alertUser(message) {
    alert(message ?? "Null message");
}

function toggleDiv() {
    alert("test");
}
