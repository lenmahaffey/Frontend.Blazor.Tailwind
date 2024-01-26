export function openSpinner(spinner) {
    var modal = new bootstrap.Modal(spinner)
    modal.show()
}
export function closeSpinner(spinner) {
    var modal = bootstrap.Modal.getInstance(spinner)
    console.log(modal)
    modal.hide()
}

export function setAttributes(spinner, isStatic, dotnet) {
    if (isStatic) {
        spinner.children[0].setAttribute("data-bs-backdrop", "static")
        spinner.children[0].setAttribute("data-bs-keyboard", "false")
    }
    else {
        spinner.children[0].setAttribute("data-bs-backdrop", "true")
        spinner.children[0].setAttribute("data-bs-keyboard", "true")
    }
    dotnet.invokeMethodAsync('OpenSpinner')
}