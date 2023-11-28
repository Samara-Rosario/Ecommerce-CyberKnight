const password = document.getElementById('password');
const icon = document.getElementById('icon');

var btnSenha = document.getElementById("btnSenha");
var inputSenha = document.getElementById('senha');

var btnConfirmSenha = document.getElementById("btnConfirmSenha");
var inputConfirmSenha = document.getElementById('ConfirmarSenha');



function hideSenha(){
    if(btnSenha.classList.contains("bi-eye-slash")){
        inputSenha.setAttribute("type", "text");
        
        btnSenha.classList.remove("bi-eye-slash");
        btnSenha.classList.add("bi-eye");
    }else{
        inputSenha.setAttribute("type", "password");
        
        btnSenha.classList.remove("bi-eye");
        btnSenha.classList.add("bi-eye-slash");
    }
}


function hideConfirmSenha() {
    if(btnConfirmSenha.classList.contains("bi-eye-slash")){
        inputConfirmSenha.setAttribute("type", "text");
        
        btnConfirmSenha.classList.remove("bi-eye-slash");
        btnConfirmSenha.classList.add("bi-eye");
    }else{
        inputConfirmSenha.setAttribute("type", "password");
        
        btnConfirmSenha.classList.remove("bi-eye");
        btnConfirmSenha.classList.add("bi-eye-slash");
    }
}

function showHide(){
    if(password.type === 'password'){
        password.setAttribute('type', 'text');
        icon.classList.remove('hide')
    }else{
        password.setAttribute('type', 'password');
        icon.classList.remove(hide)
    }
}