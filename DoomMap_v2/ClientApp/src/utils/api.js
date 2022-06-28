

export default {
    getAllFires: function () {
        return fetch(`/fires`);
    },
    getAdvisoryAreas: function (type) {
        return fetch(`advisoryareas/`);
    },
    getDroughtConditions: function() {
        return fetch(`/droughts`);
    },
    getStormConditions: function () {
        return fetch(`api/storm`);
    },
    getStormTrack: function (component) {
        return fetch(`api/stormtrack/${component}`);
    },
    getMetricsInBounds: function (boundingCoords) {
        return fetch('/metrics/viewmetrics', {
            method: 'POST',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: {
                'Content-Type': 'application/json'
            },
            redirect: 'follow',
            referrerPolicy: 'no-referrer',
            body: JSON.stringify(boundingCoords)
        });
    },
    getFiresInBounds: function (boundingCoords) {
        return fetch('/fires/viewfires', {
            method: 'POST',
            mode: 'cors', 
            cache: 'no-cache', 
            credentials: 'same-origin', 
            headers: {
                'Content-Type': 'application/json'
            },
            redirect: 'follow', 
            referrerPolicy: 'no-referrer',
            body: JSON.stringify(boundingCoords)
        });
    },
    getDroughtsInBounds: function (boundingCoords) {
        return fetch('api/drought/viewdroughts', {
            method: 'POST',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: {
                'Content-Type': 'application/json'
            },
            redirect: 'follow',
            referrerPolicy: 'no-referrer',
            body: JSON.stringify(boundingCoords)
        });
    },
    getAreasInBounds: function (boundingCoords) {
        return fetch('api/advisoryareas/viewareas', {
            method: 'POST',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: {
                'Content-Type': 'application/json'
            },
            redirect: 'follow',
            referrerPolicy: 'no-referrer',
            body: JSON.stringify(boundingCoords)
        });
    },
    getStormsInBounds: function (boundingCoords) {
        return fetch('api/stormtrack/viewstorms', {
            method: 'POST',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: {
                'Content-Type': 'application/json'
            },
            redirect: 'follow',
            referrerPolicy: 'no-referrer',
            body: JSON.stringify(boundingCoords)
        });
    }
    
};