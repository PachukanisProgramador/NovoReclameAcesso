
CREATE DATABASE reclameacesso;
USE reclameacesso;
SET GLOBAL max_allowed_packet = 16777216;

GRANT ALL PRIVILEGES ON reclameacesso TO 'Thiago'@'ThiagoURSS';

CREATE TABLE Reclamacoes(
idReclamacoes INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
texto VARCHAR(5000) NOT NULL,
tituloTexto VARCHAR(200) NOT NULL,
danoSofrido TINYINT NOT NULL,
CNPJInstituicao BIGINT(14),
IdUsuarios INT NOT NULL,
IdTipoNecessidade INT NOT NULL
) ENGINE = InnoDB;


CREATE TABLE Instituicoes(
idInstituicoes INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
Nome VARCHAR(200) NOT NULL,
Endereco VARCHAR(200) NOT NULL,
Email VARCHAR (150) NOT NULL,
idTiposNecessidades INT NOT NULL
) ENGINE = Innodb;

CREATE TABLE Midia(
idMidia INT PRIMARY KEY AUTO_INCREMENT,
ArquivoMidia MEDIUMBLOB,
idUsuarios INT NOT NULL,
caminhoMidia VARCHAR(1000) NOT NULL
) ENGINE = InnoDB;

CREATE TABLE Usuarios(
idUsuarios INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
Nome VARCHAR(150) NOT NULL,
Email VARCHAR(150) NOT NULL
) ENGINE = InnoDB;

CREATE TABLE TiposNecessidades(
idTiposNecessidades INT PRIMARY KEY NOT NULL,
tipoNecessidade VARCHAR(150) NOT NULL
) ENGINE = InnoDB;

drop table Usuarios;
select * from usuarios;

insert into TiposNecessidades(idTiposNecessidades, tipoNecessidade) values ('1', 'Deficiência Visual'), ('2', 'Deficiência Física'), ('3', 'Deficiência Mental'), ('4', 'Deficiência Auditiva'), ('5', 'Paralisia Cerebral'), ('6', 'Geral');

Insert into Instituicoes(idInstituicoes, Nome, Endereco, Email, idTiposNecessidades) values ('', 'APADV', 'São Bernardo do Campo - SP', 'apadv.saobcampo@gmail.com', '1'),
('', 'Fundação Dorina Nowill para Cegos','São Paulo - SP', 'relacionamento@fundacaodorina.org.br', '1'),
('', 'Secretaria Municipal da Pessoa com Deficiência','São Paulo - SP', 'atendimentosmped@prefeitura.sp.gov.br', '5'), 
('', 'Vidas','São Paulo - SP', 'vidas@vidas.org.br', '2'), ('', 'Need','São Paulo - SP', 'needbrasilorg@yahoo.com.br', '2'),
('', 'Need', 'São Paulo - SP', 'needbrasilorg@yahoo.com.br', '3'), 
('','APASMA', 'Mauá - SP', 'contato@apasma.org.br', '4'), ('','Fraternidade Irmã Clara', 'Barra Funda - SP', 'contato@ficfeliz.org.br', '5'),
('', 'Associação Brasileira de Paralisia Cerebral', 'São Paulo - SP', 'contatoabpc@paralisiacerebral.org.br', '5'),
('','São Bernardo', 'São Bernardo do Campo - SP', 'viabilidade.vre@saobernardo.sp.gov.br', '6'), ('','Secretaria Municipal de Licenciamento SP', 'São Paulo - SP', 'segur3@prefeitura.sp.gov.br', '6'),
('','Coordenadoria de Projetos de Inclusão - SP', 'São Paulo - SP', 'renatabelluzzo@prefeitura.sp.gov.br', '6'),
('','Secretário Municipal de Urbanismo e Licenciamento - SP', 'São Paulo - SP', 'smulgabinete@prefeitura.sp.gov.br', '6'),
('','Prefeitura de Diadema', 'Diadema - SP', 'central.atendimento@diadema.sp.gov.br', '6'),
('','Programa de Mobilidade Urbana Sustentável de Santo André', 'Santo André - SP', 'ugp@santoandre.sp.gov.br', '6'),
('','Secretaria Municipal de Serviços Urbanos SCS', 'São Caetano - SP', 'sesurb@saocaetanodosul.sp.gov.br', '6');