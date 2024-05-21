function openLoginPopup() {
    document.getElementById("SigninPopup").style.display = "none";
    document.getElementById("loginPopup").style.display = "block";
}

function closeLoginPopup() {
    document.getElementById("loginPopup").style.display = "none";
}

document.addEventListener("DOMContentLoaded", function () {
    document.addEventListener('click', function (event) {
        var popup = document.getElementById('loginPopup');
        if (!popup.contains(event.target) && event.target.id !== 'loginButton' && event.target.id !== 'bellButton') {
            popup.style.display = "none";
        }
    });
});

function openSigninPopup() {
    document.getElementById("loginPopup").style.display = "none";
    document.getElementById("SigninPopup").style.display = "block";
}

function closeSigninPopup() {
    document.getElementById("SigninPopup").style.display = "none";
}

document.addEventListener("DOMContentLoaded", function () {
    document.addEventListener('click', function (event) {
        var popup = document.getElementById('SigninPopup');
        if (!popup.contains(event.target) && event.target.id !== 'signinButton') {
            popup.style.display = "none";
        }
    });
});

function handleBellClick() {
    const bellButton = document.getElementById('bellButton');
    const normalBellSrc = '/img/Çizgisiz Zil.png';
    const pressedBellSrc = '/img/Çizgili ve Basık Zil.png';
    const ringingBellSrc = '/img/Zil.png';

    bellButton.src = pressedBellSrc;
    bellButton.classList.add('pressed');

    setTimeout(() => {
        bellButton.src = ringingBellSrc;
        bellButton.classList.remove('pressed');
    }, 100); // 100ms sonra basılı zil görüntüsü yerine ses çıkaran zil görüntüsü

    openLoginPopup();

    setTimeout(() => {
        bellButton.src = normalBellSrc;
    }, 500); // 500ms sonra tekrar normal zil görüntüsüne dön

}
