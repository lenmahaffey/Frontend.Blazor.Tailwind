export function detectDisplayAnimationEnd(id, dotnet)
{
    console.log("Begin Display Animation");
    document.getElementById(id).addEventListener("animationend", displayAnimationEnd(dotnet));
};

export function detectHideAnimationEnd(id, dotnet) {

    console.log("Begin Hide Animation");
    document.getElementById(id).addEventListener("animationend", hideAnimationEnd(dotnet));
};

function hideAnimationEnd(dotnet) {
    dotnet.invokeMethodAsync('onHideAnimationEnd')
}

function displayAnimationEnd(dotnet) {
    dotnet.invokeMethodAsync('onDisplayAnimationEnd')
}