export function displayError() {
    setTimeout(() => document.getElementById('errorBox').style.display = 'block', 250);
    setTimeout(() => document.getElementById('errorBox').style.display = 'none', 5000);
}

export function displaySuccess() {
    setTimeout(() => document.getElementById('successBox').style.display = 'block', 250);
    setTimeout(() => document.getElementById('successBox').style.display = 'none', 5000);
}