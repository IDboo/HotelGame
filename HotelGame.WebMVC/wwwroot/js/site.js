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

function openLoginPopup() {
    document.getElementById("loginPopup").style.display = "block";
}

function closeLoginPopup() {
    document.getElementById("loginPopup").style.display = "none";
}
