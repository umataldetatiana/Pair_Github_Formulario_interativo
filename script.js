document.addEventListener('DOMContentLoaded', (event) => {
    // Seleciona todos os campos de entrada
    const inputs = document.querySelectorAll('input');

    // Função para validar entrada
    function validateInput(input) {
        if (input.value === '') {
            input.classList.add('invalid');
            input.classList.remove('valid');
        } else {
            input.classList.add('valid');
            input.classList.remove('invalid');
        }
    }

    // Adiciona um ouvinte de evento a cada campo de entrada
    inputs.forEach(input => {
        input.addEventListener('input', () => validateInput(input));
    });

    // Função para mostrar/ocultar pergunta
    function toggleQuestion(option, question) {
        if (option.checked) {
            question.style.display = 'block';
        } else {
            question.style.display = 'none';
        }
    }

    // Seleciona as opções de resposta para a Pergunta 3
    const question3Option1 = document.querySelector('#option1');
    const question3Option2 = document.querySelector('#option2');

    // Seleciona a Pergunta 4
    const question4 = document.querySelector('#question4');

    // Adiciona ouvintes de eventos às opções de resposta para a Pergunta 3
    question3Option1.addEventListener('change', () => toggleQuestion(question3Option1, question4));
    question3Option2.addEventListener('change', () => toggleQuestion(question3Option2, question4));

    // Função para salvar entrada
    function saveInput(input) {
        localStorage.setItem(input.id, input.value);
    }

    // Seleciona o botão 'Salvar e Continuar Depois'
    const saveButton = document.querySelector('#save-button');

    // Adiciona um ouvinte de evento 'click' ao botão
    if (saveButton) {
        saveButton.addEventListener('click', event => {
            event.preventDefault();
            inputs.forEach(input => saveInput(input));
        });
    }

    // Função para habilitar/desabilitar botão de envio
    function toggleSubmitButton(consentCheckbox, submitButton) {
        submitButton.disabled = !consentCheckbox.checked;
    }

    // Seleciona a caixa de consentimento de dados
    const consentCheckbox = document.querySelector('#consent');

    // Seleciona o botão de envio
    const submitButton = document.querySelector('#submit-button');

    // Adiciona um ouvinte de evento 'change' à caixa de consentimento de dados
    consentCheckbox.addEventListener('change', () => toggleSubmitButton(consentCheckbox, submitButton));

    // Função para verificar se o formulário está validado
    function isFormValid(inputs) {
        return Array.from(inputs).every(input => input.classList.contains('valid'));
    }

    // Função para enviar formulário
    function submitForm(event, form, inputs) {
        event.preventDefault();
        if (isFormValid(inputs)) {
            alert('Obrigado por preencher o formulário!');
            form.reset();
        } else {
            alert('Por favor, preencha todos os campos corretamente.');
        }
    }

    // Seleciona o formulário
    const form = document.querySelector('#interactiveForm');


    // Adiciona um ouvinte de evento 'submit' ao formulário
    form.addEventListener('submit', event => submitForm(event, form, inputs));
});

