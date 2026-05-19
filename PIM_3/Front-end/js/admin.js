const API =
  "https://localhost:7205/api";

// TROCAR PAGINAS
function mostrarSecao(secao){

  let paginas =
    document.querySelectorAll(".pagina");

  paginas.forEach(function(pagina){

    pagina.style.display = "none";

  });

  document.getElementById(secao).style.display =
    "block";
}

// =========================
// GRAFICO
// =========================

const ctx =
  document.getElementById('grafico');

new Chart(ctx, {

  type:'bar',

  data:{

    labels:[
      'Jan',
      'Fev',
      'Mar',
      'Abr',
      'Mai',
      'Jun'
    ],

    datasets:[{

      label:'Vendas',

      data:[
        1200,
        1900,
        3000,
        2500,
        4200,
        5000
      ],

      borderWidth:1

    }]

  }

});

// =========================
// LISTAR CLIENTES
// =========================

async function listarClientes(){

  const resposta =
    await fetch(`${API}/clientes`);

  const clientes =
    await resposta.json();

  let tabela =
    document.getElementById("tabelaClientes");

  tabela.innerHTML = "";

  clientes.forEach(cliente => {

    tabela.innerHTML += `
      <tr>
        <td>${cliente.nome}</td>
        <td>${cliente.telefone}</td>
        <td>${cliente.pet}</td>
        <td>${cliente.tipoPet}</td>
      </tr>
    `;

  });

  document.getElementById("clientesTotal").innerText =
    clientes.length;

  document.getElementById("petsTotal").innerText =
    clientes.length;
}

// =========================
// CADASTRAR CLIENTE
// =========================

async function adicionarCliente(){

  const cliente = {

    nome:
      document.getElementById("nomeCliente").value,

    telefone:
      document.getElementById("telefoneCliente").value,

    pet:
      document.getElementById("nomePet").value,

    tipoPet:
      document.getElementById("tipoPet").value

  };

  const resposta =
    await fetch(`${API}/clientes`, {

      method:"POST",

      headers:{
        "Content-Type":"application/json"
      },

      body:JSON.stringify(cliente)

    });

  if(resposta.ok){

    alert("Cliente cadastrado!");

    listarClientes();

  }else{

    alert("Erro ao cadastrar!");

  }
}

// =========================
// LISTAR PRODUTOS
// =========================

async function listarProdutos(){

  const resposta =
    await fetch(`${API}/produtos`);

  const produtos =
    await resposta.json();

  let tabela =
    document.getElementById("tabelaEstoque");

  tabela.innerHTML = "";

  let total = 0;

  produtos.forEach(produto => {

    total += produto.quantidade;

    tabela.innerHTML += `
      <tr>
        <td>${produto.nome}</td>
        <td>${produto.categoria}</td>
        <td>${produto.quantidade}</td>
        <td>R$ ${produto.preco}</td>
      </tr>
    `;

  });

  document.getElementById("estoqueTotal").innerText =
    total;
}

// =========================
// ADICIONAR PRODUTO
// =========================

async function adicionarProduto(){

  const produto = {

    nome:
      document.getElementById("nomeProduto").value,

    categoria:
      document.getElementById("categoriaProduto").value,

    quantidade:
      parseInt(
        document.getElementById("quantidadeProduto").value
      ),

    preco:
      parseFloat(
        document.getElementById("precoProduto").value
      )

  };

  const resposta =
    await fetch(`${API}/produtos`, {

      method:"POST",

      headers:{
        "Content-Type":"application/json"
      },

      body:JSON.stringify(produto)

    });

  if(resposta.ok){

    alert("Produto adicionado!");

    listarProdutos();

  }else{

    alert("Erro ao adicionar!");

  }
}

// =========================
// CARREGAR DADOS
// =========================

listarClientes();

listarProdutos();