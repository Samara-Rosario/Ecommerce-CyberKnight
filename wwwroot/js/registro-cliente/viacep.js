var endereco = document.getElementById('endereco');

function limpa_formulário_cep() {
    //Limpa valores do formulário de cep.
    endereco.innerText = ("");
    
}

function mostrarCep(conteudo) {
    console.log(conteudo);

    if (!("erro" in conteudo)) {
        //Atualiza os campos com os valores.
        endereco.innerText = (conteudo.logradouro);
        endereco.innerText += ", "+ (conteudo.bairro);
        endereco.innerText += ", " + (conteudo.localidade);
        endereco.innerText += "/" + (conteudo.uf);
    } //end if.
    else {
        //CEP não Encontrado.
        limpa_formulário_cep();
        endereco.innerText = "CEP não encontrado.";
    }
}


function pesquisacep(valor) {

    //Nova variável "cep" somente com dígitos.
    var cep = valor.replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep != "") {

        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            // inputRua.value = "...";
            // document.getElementById('bairro').value = "...";
            // document.getElementById('cidade').value = "...";
            // document.getElementById('uf').value = "...";
            // document.getElementById('ibge').value = "...";

            //Cria um elemento javascript.
            var script = document.createElement('script');

            //Sincroniza com o callback.
            script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=mostrarCep';

            //Insere script no documento e carrega o conteúdo.
            document.body.appendChild(script);

            endereco.classList.remove("text-danger");

        } //end if.
        else {
            //cep é inválido.
            // limpa_formulário_cep();
            endereco.innerText = ("Formato de CEP inválido.");
            endereco.classList.add("text-danger");
        }
    } //end if.
    else {
        //cep sem valor, limpa formulário.
        limpa_formulário_cep();
        endereco.classList.add("text-danger");
    }
};