USE SENAI_SP_MEDICAL
GO

SELECT * FROM TIPO_USUARIO
SELECT * FROM USUARIO
SELECT * FROM CLINICA
SELECT * FROM ESPECIALIDADE
SELECT * FROM SITUACAO
SELECT * FROM PACIENTE
SELECT * FROM MEDICO
SELECT * FROM CONSULTA

SELECT nomeUsuario 'Nome', email 'Email', nomeTipoUser 'tipo de usu�rio', cpf, rg
FROM USUARIO u
INNER JOIN PACIENTE p
ON u.idUsuario = p.idUsuario
INNER JOIN TIPO_USUARIO tu
ON tu.idTipoUsuario = u.idTipoUsuario
GO

SELECT * FROM USUARIO u
INNER JOIN MEDICO m
ON u.idUsuario = m.idUsuario


SELECT nomeUsuario, email, cpf, enderecoPaciente
FROM usuario u
INNER JOIN paciente
ON u.idUsuario = paciente.idUsuario

