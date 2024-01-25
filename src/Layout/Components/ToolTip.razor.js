let toolTip = document.getElementById("toolTip")
export function addMouseEvents(element) {
	element.onmouseenter = function (e) {
		var x = e.clientX;
		var y = e.clientY;
		mouseEnter(this, (x), (y));
	}
	element.onmousemove = function (e) {
		var x = e.clientX;
		var y = e.clientY;
		mouseMove((x), (y));
	}
	element.onmouseleave = function () {
		mouseLeave(element);
	}
}

function mouseEnter(x, y) {
	toolTip.style.top = (y + 15) + "px";
	toolTip.style.left = (x) + "px";
	showToolTip()
}

function mouseMove(x, y) {
	toolTip.style.top = (y + 15) + "px";
	toolTip.style.left = (x) + "px";
}

function mouseLeave(element) {
	hideToolTip()
}

function hideToolTip() {
	toolTip.style.display = "none";
}
function showToolTip() {
	toolTip.style.display = "block";
}