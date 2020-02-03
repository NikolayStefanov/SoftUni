function attachEventsListeners() {
    let buttons = document.querySelectorAll('input[type=button]');
    [...buttons].forEach(button => button.addEventListener('click', handle));

    function handle(e) {
        let currElementType = e.target.getAttribute('id');
        switch (currElementType) {
            case 'daysBtn':
                let days = +(document.querySelector("#days").value);

                let daysToHours = (days*24);
                document.querySelector("#hours").value = daysToHours;
                let daysToMinutes = (days*1440);
                document.querySelector("#minutes").value = daysToMinutes;
                let daysToSeconds = (days*86400);
                document.querySelector("#seconds").value = daysToSeconds;  
                break;
            case 'hoursBtn':
                let hours =+(document.querySelector("#hours").value);

                let hoursToDays = (hours/24);
                document.querySelector("#days").value = hoursToDays;
                let hoursToMinutes = (hours * 60);
                document.querySelector("#minutes").value = hoursToMinutes;
                let hoursToSeconds = (hours * 3600);
                document.querySelector("#seconds").value = hoursToSeconds;
                break;
            case 'minutesBtn':
                let minutes = +(document.querySelector("#minutes").value);

                let minutesToDays = (minutes/1440);
                document.querySelector("#days").value = minutesToDays;
                let minutesToHours = (minutes/60);
                document.querySelector("#hours").value = minutesToHours;
                let minutesToSeconds = (minutes * 60);
                document.querySelector("#seconds").value = minutesToSeconds;

                break;
            case 'secondsBtn':
                let secondsText = +(document.querySelector("#seconds").value);

                let secondToDays =  (secondsText / (3600*24));
                document.querySelector("#days").value = secondToDays;
                let secondToHours = (secondsText / 3600);
                document.querySelector("#hours").value = secondToHours;
                let secondToMinutes = (secondsText/60);
                document.querySelector("#minutes").value = secondToMinutes;
                break;
        }

    }
}