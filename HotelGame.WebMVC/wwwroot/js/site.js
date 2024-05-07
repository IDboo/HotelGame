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
        if (!popup.contains(event.target) && event.target.id !== 'loginButton') {
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
