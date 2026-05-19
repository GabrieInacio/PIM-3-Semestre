CREATE DATABASE petshop;
GO

USE petshop;
GO

-- CLIENTES

CREATE TABLE clientes (

    id INT PRIMARY KEY IDENTITY(1,1),

    nome VARCHAR(100) NOT NULL,

    telefone VARCHAR(20),

    email VARCHAR(100) UNIQUE,

    endereco VARCHAR(150)

);

-- FUNCIONÁRIOS

CREATE TABLE funcionario (

    idFuncionario INT PRIMARY KEY IDENTITY(1,1),

    nome VARCHAR(100) NOT NULL,

    cargo VARCHAR(50),

    telefone VARCHAR(15),

    email VARCHAR(100)

);

-- PETS

CREATE TABLE pets (

    idPet INT PRIMARY KEY IDENTITY(1,1),

    nome VARCHAR(100) NOT NULL,

    especie VARCHAR(50),

    raca VARCHAR(50),

    idade INT,

    cliente_id INT,

    FOREIGN KEY (cliente_id)
    REFERENCES clientes(id)

);

-- SERVIÇOS

CREATE TABLE servicos (

    idServico INT PRIMARY KEY IDENTITY(1,1),

    nome VARCHAR(100) NOT NULL

);

-- AGENDAMENTOS

CREATE TABLE agendamento (

    idAgendamento INT PRIMARY KEY IDENTITY(1,1),

    dataHora DATETIME,

    observacao VARCHAR(200),

    idPet INT,

    idServico INT,

    idFuncionario INT,

    FOREIGN KEY (idPet)
    REFERENCES pets(idPet),

    FOREIGN KEY (idServico)
    REFERENCES servicos(idServico),

    FOREIGN KEY (idFuncionario)
    REFERENCES funcionario(idFuncionario)

);

-- INSERIR SERVIÇOS

INSERT INTO servicos (nome)
VALUES
('Banho'),
('Tosa'),
('Vacinação');
