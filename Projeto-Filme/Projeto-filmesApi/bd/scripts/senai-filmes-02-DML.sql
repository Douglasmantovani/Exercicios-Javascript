-- Define o banco de dados que ser� utilizado
USE Filmes;
GO
use master

-- Insere dois g�neros na tabela Generos
INSERT INTO Generos	(Nome)
VALUES				('A��o')
					,('Drama');
GO

-- Insere dois filmes na tabela Filmes
INSERT INTO Filmes	(Titulo, IdGenero)
VALUES				('Vingadores 2', 1)
GO

select *from Usuarios
-- Insere dois novos usu�rios
INSERT INTO Usuarios (NomeUsuario,Email, Senha, Permissao)
VALUES				 ('Saulo123','saulo@email.com', '123', 'Comum')
					,('Admin123','adm@adm.com', '123', 'Administrador');
GO