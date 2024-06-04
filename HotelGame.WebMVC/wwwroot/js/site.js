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
    const normalBellSrc = '/img/Bell.png';
    const pressedBellSrc = '/img/Bell_Line_Down.png';
    const ringingBellSrc = '/img/Bell_Line.png';

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

function login(event) {
    event.preventDefault();
    const formData = new FormData(event.target);
    fetch('/Account/Login', {
        method: 'POST',
        body: formData
    }).then(response => response.json())
        .then(data => {
            if (data.success) {
                window.location.href = data.redirectUrl;
            } else {
                document.getElementById("loginError").innerText = data.message;
            }
        });
}

function signup(event) {
    event.preventDefault();
    const formData = new FormData(event.target);
    fetch('/Account/SignUp', {
        method: 'POST',
        body: formData
    }).then(response => response.json())
        .then(data => {
            if (data.success) {
                closeSigninPopup();
                openLoginPopup();
            } else {
                document.getElementById("signupError").innerText = data.message;
            }
        });
}

document.getElementById("loginForm").addEventListener("submit", login);
document.getElementById("signupForm").addEventListener("submit", signup);
