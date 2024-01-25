export function getRGBColorValue(id){
    const e = document.getElementById(id)
    let rgbString = window.getComputedStyle(e, null).backgroundColor
    rgbString = rgbString.replace("rgb(", "")
    rgbString = rgbString.replace(")", "")
    return rgbString
}

export function getHexColorValue(id) {
    let rgbString = getRGBColorValue(id)
    let rgbArray = rgbString.split(",")
    return "#" + componentToHex(rgbArray[0]).toLocaleUpperCase() + componentToHex(rgbArray[1]).toLocaleUpperCase() + componentToHex(rgbArray[2]).toLocaleUpperCase()
}
function componentToHex(c) {
    var hex = parseInt(c).toString(16);
    return hex.length == 1 ? "0" + hex : hex;
}