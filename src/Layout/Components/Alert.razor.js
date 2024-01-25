export function listenToAnimationEnd(id, dotnet) {
    var alert = document.querySelector('#' + id);
    alert.addEventListener("animationend", (event) => {
        if (event.animationName.includes("fadeOut"))
        {
            dotnet.invokeMethodAsync('DeleteAlert')
        }
    })
}