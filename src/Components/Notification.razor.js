export function detectAnimationEnd(id, callback)
{
    console.log("Hello World")

    document.getElementById(id).addEventListener("animationend", callback.invokeMethodAsync('onAnimationComplete'));
};