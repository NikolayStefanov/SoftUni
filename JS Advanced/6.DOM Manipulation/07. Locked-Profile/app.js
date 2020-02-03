function lockedProfile() {
    let buttons = document.querySelectorAll("button");
    [...buttons].forEach(but => but.addEventListener('click', handle));
    function handle(e){
        let showOrHide = e.target.textContent;

        if (e.target.parentElement.children[4].checked && showOrHide == 'Show more') {
            e.target.previousElementSibling.style.display = 'block';
            e.target.textContent = 'Hide it';
        }
        if (e.target.parentElement.children[4].checked && showOrHide == 'Hide it') {
            e.target.previousElementSibling.style.display = 'none';
            e.target.textContent = 'Show more';
        }
    }
}