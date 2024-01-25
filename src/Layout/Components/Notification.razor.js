export function listenToAnimationEnd(id, dotnet) {
    var notification = document.querySelector('#' + id);
    notification.addEventListener("animationend", (event) => {
        if (event.animationName.includes("slideOutRight"))
        {
            dotnet.invokeMethodAsync('DeleteNotification')
        }
    })
}