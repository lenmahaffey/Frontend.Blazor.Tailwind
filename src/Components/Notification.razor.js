export function detectHideAnimationEnd(id, dotnet) {
    document.getElementById(id).addEventListener("animationend", hideAnimationEnd(dotnet));
};

function hideAnimationEnd(dotnet) {
    dotnet.invokeMethodAsync('onHideAnimationEnd')
}

function displayAnimationEnd(dotnet) {
    dotnet.invokeMethodAsync('onDisplayAnimationEnd')
}