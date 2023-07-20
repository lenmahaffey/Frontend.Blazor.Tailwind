export async function dismissAlertInTime(id, timeToWait) {
    var alert = document.querySelector('#alert' + id + ' > button');
    await sleep(timeToWait);
    alert.click();
}

export function dismissAlert(id) {
    var alert = document.querySelector('#alert' + id +'> button')
    alert.click();
}

const sleep = async (milliseconds) => {
    await new Promise(resolve => {
        return setTimeout(resolve, milliseconds)
    });
};