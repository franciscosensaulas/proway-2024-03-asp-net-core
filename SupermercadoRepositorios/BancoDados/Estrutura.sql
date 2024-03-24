DROP TABLE IF EXISTS estoques;
DROP TABLE IF EXISTS produtos;
DROP TABLE IF EXISTS estantes;
DROP TABLE IF EXISTS categorias;

CREATE TABLE categorias(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(25)
);

-- Consultar o id e nome da tabela de categorias
SELECT id, nome FROM categorias;

DELETE FROM categorias WHERE id = 5;


CREATE TABLE estantes (
	id INT PRIMARY KEY IDENTITY(1, 1),
	nome VARCHAR(50) NOT NULL,
	sigla VARCHAR(3) NOT NULL -- NOT NULL é um campo obrigatório, ou seja, no cadastro usuário terá que informar
);

INSERT INTO estantes (nome, sigla) VALUES
('Temperos', 'A01'),
('Massas', 'A02');

CREATE TABLE produtos(
	id INT PRIMARY KEY IDENTITY(1, 1),
	nome VARCHAR(150) NOT NULL,
	preco_unitario DECIMAL(10,2) NOT NULL,
	id_categoria INT NOT NULL, -- Coluna para referenciar a outra tabela
	
	-- Criando a referencia (dependencia) da tabela de produtos com categorias
	FOREIGN KEY (id_categoria) REFERENCES categorias(id) 
);

INSERT INTO categorias (nome) VALUES
	('Padaria'),
	('Limpeza'),
	('Higiene'),
	('Frutas'),
	('Verduras');

INSERT INTO produtos (nome, preco_unitario, id_categoria) VALUES
	('Ajax multiuso', 16.00, 2), -- Categoria Limpeza que possuí o id 2
	('Sabonete Dove', 4.99, 3), -- Categoria Higiene que possuí o id 3
	('Shampoo Dove', 4.99, 3), -- Categoria Higiene que possuí o id 3
	('Pão francês', 43.99, 1), -- Categoria Padaria que possuí o id 3
	('Sabonete Lux', 4.99, 3), -- Categoria Higiene que possuí o id 3
	('Pasta de dente Colgate', 14.99, 3), -- Categoria Higiene que possuí o id 3
	('Pasta de dente Soriso', 24.99, 3), -- Categoria Higiene que possuí o id 3
	('Escova de dente Condor', 34.99, 3), -- Categoria Higiene que possuí o id 3
	('Pastel de carne', 45.0, 1), -- Categoria Padaria que possuí o id 3
	('Escova de dente Soriso', 44.99, 3), -- Categoria Higiene que possuí o id 3
	('Manga', 4.99, 4), -- Categoria Frutas que possuí o id 4
	('Pão integral', 41.99, 1), -- Categoria Padaria que possuí o id 3
	('Shampoo Seda', 4.99, 3), -- Categoria Higiene que possuí o id 3
	('Melancia', 3.99, 4), -- Categoria Frutas que possuí o id 4
	('Cebola', 3.99, 5), -- Categoria Verduras que possuí o id 5
	('Pastel de frango', 3.99, 1), -- Categoria Padaria que possuí o id 3
	('Cenoura', 3.99, 5), -- Categoria Verduras que possuí o id 5
	('Batata', 3.99, 5), -- Categoria Verduras que possuí o id 5
	('Pastel de pizza', 41.99, 1), -- Categoria Padaria que possuí o id 3
	('Maça', 24.99, 4), -- Categoria Frutas que possuí o id 4
	('Uva', 3.99, 4), -- Categoria Frutas que possuí o id 4
	('Laranja', 7.99, 4), -- Categoria Frutas que possuí o id 4
	('Mamão', 9.99, 4), -- Categoria Frutas que possuí o id 4
	('Morango', 2.99, 4), -- Categoria Frutas que possuí o id 4
	('Pimentão', 3.99, 5); -- Categoria Verduras que possuí o id 5

SELECT * FROM produtos;
SELECT * FROM categorias;


ALTER TABLE produtos ADD data_vencimento DATE;
ALTER TABLE produtos ADD observacao TEXT;