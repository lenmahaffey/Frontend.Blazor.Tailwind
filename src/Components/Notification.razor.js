export function detectDisplayAnimationEnd(id, dotnet)
{
    console.log(id);
    console.log("Animation start");
    document.getElementById(id).addEventListener("animationend", dotnet.invokeMethodAsync('onDisplayAnimationEnd'));
};

export function detectHideAnimationEnd(id, dotnet) {
    console.log("animation end");
    document.getElementById(id).addEventListener("animationend", dotnet.invokeMethodAsync('onHideAnimationEnd'));
};