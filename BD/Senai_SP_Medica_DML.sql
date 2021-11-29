USE SENAI_SP_MEDICAL
GO

INSERT INTO CLINICA(nomeClinica, endereco, cnpj, razaoSocial)
VALUES ('Clinica Possarle', 'Av. Barão Limeira - 532', '86.400.902/0001-30', 'Senai SP Medical')
GO

INSERT INTO ESPECIALIDADE(nomeEspecialidade)
VALUES ('Acupuntura'), ('Anestesiologia'), ('Angiologia'), ('Cardiologia'), ('Cirurgia Cardiovascular'),
('Cirurgia da Mão'), ('Cirurgia do Aparelho Digestivo'), ('Cirurgia Geral'), ('Cirurgia Pediátrica'),
('Cirurgia Plástica'), ('Cirurgia Torácica'), ('Cirurgia Vascular'), ('Dermatologia'),
('Radioterapia'), ('Urologia'), ('Pediatria'), ('Psiquiatria');
GO

INSERT INTO SITUACAO(nomeSituacao)
VALUES ('Agendado'), ('Cancelado'), ('Realizado');
GO

INSERT INTO TIPO_USUARIO(nomeTipoUser)
VALUES ('Adm'), ('Cm'), ('Mdc')
GO

INSERT INTO USUARIO(idTipoUsuario, email, senha)
VALUES (1, 'enzzo@email.com', '1122'), (2, 'marcelo@email.com', '1133'),
(2, 'yuri@email.com', '1144'), (2, 'gabriela@email.com', '1155'),
(3, 'ana@email.com', '1166'), (3, 'mateus@email.com', '1177')
GO

INSERT INTO MEDICO(idUsuario, nomeMedico, idClinica, idEspecialidade, crm)
VALUES (5, 'Mateus', 1, 7, '1234 - SP'), (6, 'Ana', 1, 3, '4321 - SP')
GO

INSERT INTO PACIENTE(idUsuario, nomePaciente, dataNascimento, telefone, rg, cpf, enderecoPaciente)
VALUES(2, 'Marcelo', '02-10-1987', '11 936878369', '579548609', '47669729607', 'Av. São judas - 000'),
(3, 'Yuri', '17-03-1999', '11 963061369', '439548674', '30269729115', 'Av. São jose - 111'),
(4, 'Gabriela', '21-11-2002', '11 966778300', '679548610', '57269727781', 'Av. São carlos - 222')
GO

INSERT INTO CONSULTA(idSituacao, idPaciente, idMedico, dataConsulta, descricao)
VALUES (2, 1, 1, '23-11-2021 09:15', 'Essa consulta foi cancelado'),
(3, 2, 2, '12-09-2021 13:30', 'Já foi realizado'), (1, 3, 1, '01-01-2022 10:00', 'Ainda vai acontecer')
GO