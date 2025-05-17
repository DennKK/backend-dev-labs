function saveToLocalStorage() {
    const value = document.getElementById('storageInput').value;
    localStorage.setItem('localValue', value);
    document.getElementById('localOutput').innerText = 'LocalStorage: ' + value;
}

function saveToSessionStorage() {
    const value = document.getElementById('storageInput').value;
    sessionStorage.setItem('sessionValue', value);
    document.getElementById('sessionOutput').innerText = 'SessionStorage: ' + value;
}

function clearClientStorage() {
    localStorage.removeItem('localValue');
    sessionStorage.removeItem('sessionValue');
    document.getElementById('localOutput').innerText = 'LocalStorage: —';
    document.getElementById('sessionOutput').innerText = 'SessionStorage: —';
}

window.onload = function () {
    const localVal = localStorage.getItem('localValue');
    const sessionVal = sessionStorage.getItem('sessionValue');

    document.getElementById('localOutput').innerText =
        localVal ? 'LocalStorage: ' + localVal : 'LocalStorage: —';

    document.getElementById('sessionOutput').innerText =
        sessionVal ? 'SessionStorage: ' + sessionVal : 'SessionStorage: —';
};
