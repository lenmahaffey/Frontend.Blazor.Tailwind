export function openSpinner(spinner) {
    var modal = new bootstrap.Modal(spinner)
    console.log(modal)
    modal.show()
}
export function closeSpinner(spinner) {
    var modal = new bootstrap.Modal(spinner)
    modal.hide()
}

export function setAttributes(spinner, isStatic, dotnet) {
    if (isStatic) {
        console.log("isStatic")
        spinner.children[0].setAttribute("data-bs-backdrop", "static")
        spinner.children[0].setAttribute("data-bs-keyboard", "false")
    }
    else {
        console.log("!isStatic")
        spinner.children[0].setAttribute("data-bs-backdrop", "true")
        spinner.children[0].setAttribute("data-bs-keyboard", "true")
    }
    dotnet.invokeMethodAsync('OpenSpinner')
}