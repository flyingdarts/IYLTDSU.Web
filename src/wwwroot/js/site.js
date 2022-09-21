
function createToast(message) {
    var toastContainer = document.getElementById("toastContainer");

    var toastDiv = document.createElement("div");
    toastDiv.classList.add("toast");
    toastDiv.setAttribute("role", "alert");
    toastDiv.setAttribute("aria-live", "assertive");
    toastDiv.setAttribute("aria-atmoic", "true");
    toastContainer.appendChild(toastDiv);

    var toastHeaderDiv = document.createElement("div");
    toastHeaderDiv.classList.add("toast-header");
    toastDiv.appendChild(toastHeaderDiv);

    var toastSpan = document.createElement("span");
    toastSpan.innerText = "info";
    toastSpan.classList.add("material-icons");
    toastHeaderDiv.appendChild(toastSpan);

    var title = document.createElement("strong");
    title.innerText = "Boostrap";
    title.classList.add("me-auto");
    toastHeaderDiv.appendChild(title);

    var small = document.createElement("small");
    small.innerText = "11 mins ago";
    toastHeaderDiv.appendChild(small);

    var button = document.createElement("button");
    button.classList.add("btn-close");
    button.type = "button";
    button.setAttribute("data-bs-dismiss", "toast");
    button.setAttribute("aria-label", "Close");
    toastHeaderDiv.appendChild(button);

    var toastMessageDiv = document.createElement("div");
    toastMessageDiv.innerHTML = message;
    toastMessageDiv.classList.add("toast-body");
    toastDiv.appendChild(toastMessageDiv);
}

function AddListItem(message) {
    document.getElementsByClassName("for-debugging")[0].innerHTML += message;
    showToast(message);
}
async function showToast(message) {
    createToast(message);
    const toasts = document.getElementsByClassName("toast");
    for (let toastEl of toasts) {
        new bootstrap.Toast(toastEl).show();
    };
}

function isNullOrUndefined(obj) {
    return obj === null || obj === undefined;
}