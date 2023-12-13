var btnSenha = document.getElementById("btnSenha");
var inputSenha = document.getElementById('inputSenha');

function hideSenha() {
    if (btnSenha.classList.contains("bi-eye-slash")) {
        inputSenha.setAttribute("type", "text");

        btnSenha.classList.remove("bi-eye-slash");
        btnSenha.classList.add("bi-eye");
    } else {
        inputSenha.setAttribute("type", "password");

        btnSenha.classList.remove("bi-eye");
        btnSenha.classList.add("bi-eye-slash");
    }
}
