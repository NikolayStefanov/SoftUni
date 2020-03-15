function attachEvents() {
    let getWeatherButton = document.querySelector("#submit");
    getWeatherButton.addEventListener('click', async () => {
        try {
            let targetCity = document.querySelector("#location").value;
            let theUrlForTheCity = 'https://judgetests.firebaseio.com/locations.json';
            let allLocations = await (await fetch(theUrlForTheCity)).json();
            let target = allLocations.find(x => x.name === targetCity);

            if (target) {
                let cityCode = target.code;
                let urlForCurrentCondition = `https://judgetests.firebaseio.com/forecast/today/${cityCode}.json`;
                let currentCondition = await (await fetch(urlForCurrentCondition)).json();
                document.querySelector("#forecast").style.display = 'block';
                document.querySelector("#current > div.label").innerHTML = 'Current conditions'
                document.querySelector("#upcoming").style.display = 'block';
                let currentDiv = document.querySelector("#current");
                if (currentDiv.childElementCount >1) {
                    document.querySelector("#current .forecasts").remove();

                }

                if (currentCondition) {
                    let forecastDiv = createHtmlElement('div', 'forecasts', null);
                    let currWeather = conditionSymbolFunc(currentCondition.forecast.condition)
                    let conditionSymbol = createHtmlElement('span', 'condition symbol', currWeather)
                    forecastDiv.appendChild(conditionSymbol);

                    let condition = createHtmlElement('span', 'condition', null);
                    let firstForecastData = createHtmlElement('span', 'forecast-data', currentCondition.name);
                    let lowAndHighTemperature = `${currentCondition.forecast.low}°/${currentCondition.forecast.high}°`
                    let secondForecastData = createHtmlElement('span', 'forecast-data', lowAndHighTemperature)
                    let thirdForecastData = createHtmlElement('span', 'forecast-data', currWeather);
                    condition.appendChild(firstForecastData);
                    condition.appendChild(secondForecastData);
                    condition.appendChild(thirdForecastData);
                    forecastDiv.appendChild(condition);

                    currentDiv.appendChild(forecastDiv);

                    let upcommingUrl = `https://judgetests.firebaseio.com/forecast/upcoming/${cityCode}.json`;
                    let upcommingCondition = await (await fetch(upcommingUrl)).json();
                    if (document.querySelector("#upcoming").childElementCount > 1) {
                        document.querySelector("#upcoming .forecast-info").remove();
                    }
                    if (upcommingCondition) {
                        let threeDaysForecastInfo = createHtmlElement('div', 'forecast-info', null);

                        upcommingCondition.forecast.forEach(day=>{
                            let spanUpcomming = createHtmlElement('span', 'upcoming', null);

                            let currCondition = conditionSymbolFunc(day.condition);
                            let upcomingSymbol = createHtmlElement('span', 'symbol', currCondition);
                            let currTemperature =  `${day.low}°/${day.high}°`
                            let forecastDataTemperature = createHtmlElement('span', 'forecast-data',currTemperature)
                            let forecastDataWeather = createHtmlElement('span', 'forecast-data', currCondition);

                            spanUpcomming.appendChild(upcomingSymbol);
                            spanUpcomming.appendChild(forecastDataTemperature);
                            spanUpcomming.appendChild(forecastDataWeather);
                            threeDaysForecastInfo.appendChild(spanUpcomming);
                            document.querySelector("#upcoming").appendChild(threeDaysForecastInfo);
                        })
                        
                    } else {
                        throw Error();
                    }

                } else {
                    throw Error();
                }

            } else {
                throw Error();
            }
        } catch (err) {
            let forecastSection = document.querySelector("#forecast");
            forecastSection.children[1].style.display = 'none';
            forecastSection.children[0].innerHTML = '';
            let newElement = createHtmlElement('div', 'label', 'ERROR')
            forecast.children[0].appendChild(newElement);
            forecastSection.style.display = 'block';
        }

    })


}

function conditionSymbolFunc(condition) {
    switch (condition) {
        case 'Sunny':
            return '☀'
        case 'Partly sunny':
            return '⛅'
        case 'Overcast':
            return '☁'
        case 'Rain':
            return '☂'
    }
}

function createHtmlElement(tagName, className, value) {
    let newTag = document.createElement(tagName);
    if (className) {
        newTag.className = className;
    }
    if (value) {
        newTag.innerText = value;
    }
    return newTag;
}

attachEvents();