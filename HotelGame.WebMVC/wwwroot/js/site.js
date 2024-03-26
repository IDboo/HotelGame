var ifLogged = true;

function sw() {
    console.log(ifLogged);
    ifLogged = !ifLogged;

    if (ifLogged) {
        document.getElementById('loginButtonText').innerHTML = 'Oyna';
    } else {
        document.getElementById('loginButtonText').innerHTML = 'Devam Et';
    }
}
