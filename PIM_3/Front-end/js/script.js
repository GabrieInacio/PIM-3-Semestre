// ========================
// MODAL LOGIN / AGENDAMENTO
// ========================

const modal = document.getElementById("modal");

function abrirLogin() {
  modal.style.display = "flex";
}

function fecharLogin() {
  modal.style.display = "none";
}

// FECHAR AO CLICAR FORA
window.addEventListener("click", function (e) {
  if (e.target === modal) {
    modal.style.display = "none";
  }
});


// ========================
// AGENDAMENTO (API)
// ========================

async function agendar() {

  const nomePet = document.getElementById("nomePet").value;
  const servico = document.getElementById("servico").value;
  const dataHora = document.getElementById("dataHora").value;

  const msg = document.getElementById("msg");

  if (!nomePet || !servico || !dataHora) {
    msg.innerText = "Preencha todos os campos!";
    msg.style.color = "red";
    return;
  }

  try {

    const response = await fetch("https://localhost:7205/api/agendamentos", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        nomePet,
        servico,
        dataHora
      })
    });

    if (response.ok) {
      msg.innerText = "Agendamento realizado com sucesso!";
      msg.style.color = "green";

      // limpa campos
      document.getElementById("nomePet").value = "";
      document.getElementById("servico").value = "";
      document.getElementById("dataHora").value = "";

    } else {
      msg.innerText = "Erro ao agendar!";
      msg.style.color = "red";
    }

  } catch (error) {
    msg.innerText = "Erro na conexão com a API!";
    msg.style.color = "red";
  }
}


// ========================
// LOGIN (mantido simples)
// ========================

const loginForm = document.getElementById("loginForm");

loginForm.addEventListener("submit", function (e) {
  e.preventDefault();

  const email = loginForm.querySelector('input[type="email"]').value;
  const senha = loginForm.querySelector('input[type="password"]').value;

  if (email === "" || senha === "") {
    alert("Preencha todos os campos");
    return;
  }

  alert("Login realizado com sucesso!");
  modal.style.display = "none";
});


// ========================
// SCROLL HEADER
// ========================

const header = document.querySelector(".header");

window.addEventListener("scroll", function () {

  if (window.scrollY > 50) {
    header.style.background = "#ffffff";
    header.style.boxShadow = "0 2px 20px rgba(0,0,0,0.12)";
  } else {
    header.style.background = "#ffffff";
    header.style.boxShadow = "0 2px 20px rgba(0,0,0,0.08)";
  }

});


// ========================
// ANIMAÇÃO DOS CARDS
// ========================

const cards = document.querySelectorAll(".card");

cards.forEach((card, index) => {

  card.style.opacity = "0";
  card.style.transform = "translateY(40px)";

  setTimeout(() => {
    card.style.transition = "0.6s";
    card.style.opacity = "1";
    card.style.transform = "translateY(0)";
  }, index * 200);

});


// ========================
// ANIMAÇÃO GALERIA
// ========================

const imagens = document.querySelectorAll(".galeria-grid img");

imagens.forEach((img, index) => {

  img.style.opacity = "0";
  img.style.transform = "scale(0.9)";

  setTimeout(() => {
    img.style.transition = "0.5s";
    img.style.opacity = "1";
    img.style.transform = "scale(1)";
  }, index * 150);

});


// ========================
// BOTÃO VOLTAR AO TOPO
// ========================

const botaoTopo = document.createElement("button");

botaoTopo.innerHTML = "↑";

document.body.appendChild(botaoTopo);

botaoTopo.style.position = "fixed";
botaoTopo.style.bottom = "20px";
botaoTopo.style.right = "20px";
botaoTopo.style.width = "50px";
botaoTopo.style.height = "50px";
botaoTopo.style.border = "none";
botaoTopo.style.borderRadius = "50%";
botaoTopo.style.background = "#2563eb";
botaoTopo.style.color = "white";
botaoTopo.style.fontSize = "22px";
botaoTopo.style.cursor = "pointer";
botaoTopo.style.display = "none";
botaoTopo.style.zIndex = "999";

window.addEventListener("scroll", function () {

  if (window.scrollY > 300) {
    botaoTopo.style.display = "block";
  } else {
    botaoTopo.style.display = "none";
  }

});

botaoTopo.addEventListener("click", function () {
  window.scrollTo({
    top: 0,
    behavior: "smooth"
  });
});