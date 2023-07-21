export function detectAnimationEnd(id, dotnet)
{
    document.getElementById(id).addEventListener("animationend", dotnet.invokeMethodAsync('onAnimationEnd'));
};