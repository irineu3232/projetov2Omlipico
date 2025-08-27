create database bdOlimpicos2108;
use bdOlimpicos2108;

Create table Modalidades(
codModalidade int primary key auto_increment,
nomeModalidade varchar(50)
);

INSERT INTO Modalidades (nomeModalidade) VALUES
('Atletismo'),('Natação'),('Vôlei de Quadra'),('Vôlei de Praia');

select * from Modalidades;

Create table Provas(
codProva int primary key auto_increment,
nomeProva varchar(100),
codModalidade int
);


alter table Provas add constraint Fk_Modalidades foreign key(codModalidade) references Modalidades(codModalidade);

insert into Provas (nomeProva, codModalidade)
values('10000m Feminino',1),
 ('10000m Masculino', 1),
('100m Feminino', 1),
('100m Masculino', 1),
('100m com barreiras Feminino', 1),
('110m com Barreiras Masculino', 1),
('1500m Masculino', 1),
('200m Feminino', 1),
('200m Masculino', 1),
('20km Marcha Atlética Feminina', 1),
('20km Marcha Atlética Masculino', 1),
('3000m com Obstáculos Feminino', 1),
('3000m com Obstáculos Masculino', 1),
('400m Feminino', 1),
('400m Feminino Feminino', 1),
('400m Masculino', 1),
('400m com Barreiras Feminina', 1),
('400m com Barreiras Feminino', 1),
('400m com Barreiras Masculino', 1),
('5000m Feminino', 1),
('5000m Masculino', 1),
('50km Marcha Atlética', 1),
('60m Masculino', 1),
('800m Feminino', 1),
('800m Masculino', 1),
('80m com Barreiras Feminino', 1),
('Arremesso de Peso Feminino', 1),
('Arremesso de Peso Masculino', 1),
('Arremesso do Peso Masculino', 1),
('Cross Country Masculino', 1),
('Decatlon', 1),
('Decatlon Masculino', 1),
('Heptatlo Feminino', 1),
('Lançamento de Dardo Feminino', 1),
('Lançamento de Dardo Masculino', 1),
('Lançamento de Disco Feminino', 1),
('Lançamento de Disco Masculino', 1),
('Lançamento do Dardo', 1),
('Lançamento do Dardo Feminino', 1),
('Lançamento do Disco Feminino', 1),
('Lançamento do Disco Masculino', 1),
('Lançamento do Martelo Masculino', 1),
('Maratona Feminina', 1),
('Maratona Masculina', 1),
('Marcha Atletica Masculina 20km', 1),
('Marcha Atlética 20 Km Feminino', 1),
('Marcha Atlética 20 Km Masculino', 1),
('Marcha Atlética 50 Km Masculino', 1),
('Marcha Atlética Feminino 20km', 1),
('Pentatlo Feminino', 1),
('Revezamento 4 x 100m Feminino', 1),
('Revezamento 4 x 100m Masculino', 1),
('Revezamento 4 x 400 Masculino', 1),
('Revezamento 4 x 400m Feminino', 1),
('Revezamento 4 x 400m Masculino', 1),
('Revezamento 4 x 400m Misto', 1),
('Revezamento Marcha Atlética Misto', 1),
('Revezametno 4 x 400m Masculino', 1),
('Salto Triplo Feminino', 1),
('Salto Triplo Masculino', 1),
('Salto com Vara Feminino', 1),
('Salto com Vara Masculino', 1),
('Salto em Altura Feminino', 1),
('Salto em Altura Masculino', 1),
('Salto em Distância Feminino', 1),
('Salto em Distância Masculino', 1);
 

 select * from Provas;
 select * from Modalidades;
 

 INSERT INTO provas (nomeProva, codModalidade) VALUES
('100m Borboleta Feminino', 2),
('100m Borboleta Masculino', 2),
('100m Costas Feminino', 2),
('100m Costas Masculino', 2),
('100m Livre Feminino', 2),
('100m Livre Masculino', 2),
('100m Nado Livre Masculino', 2),
('100m Peito Feminino', 2),
('100m Peito Masculino', 2),
('1500m Livre Feminino', 2),
('1500m Livre Masculino', 2),
('1500m Nado Livre', 2),
('200m Borboleta Feminino', 2),
('200m Borboleta Masculino', 2),
('200m Costas Masculino', 2),
('200m Livre Feminino', 2),
('200m Livre Masculino', 2),
('200m Medley Feminino', 2),
('200m Medley Masculino', 2),
('200m Nado Livre', 2),
('200m Nado Livre Masculino', 2),
('200m Peito Feminino', 2),
('200m Peito Masculino', 2),
('400m Livre Feminino', 2),
('400m Livre Masculino', 2),
('400m Medley Feminino', 2),
('400m Medley Masculino', 2),
('400m Nado Livre Feminino', 2),
('400m Nado Livre Masculino', 2),
('50m Livre Feminino', 2),
('50m Livre Masculino', 2),
('800m Livre Feminino', 2),
('800m Livre Masculino', 2),
('800m Nado Livre Feminino', 2),
('800m Nado Livre Natação', 2),
('Mixed 4 x 100m Medley Relay', 2),
('Revezamento 4 x 100m Nado Livre Masculino', 2),
('Revezamento 4 x 200m Nado Livre Masculino', 2),
('Revezamento 4x100m Livre Feminino', 2),
('Revezamento 4x100m Livre Masculino', 2),
('Revezamento 4x100m Medley Feminino', 2),
('Revezamento 4x100m Medley Masculino', 2),
('Revezamento 4x100m Medley Misto', 2),
('Revezamento 4x100m Nado Livre Feminino', 2),
('Revezamento 4x200m Livre Feminino', 2),
('Revezamento 4x200m Livre Masculino', 2),
('Revezamento 4x200m Nado Livre Feminino', 2);


 select * from Provas where codModalidade = 2;
 select * from Modalidades;


 insert into Provas (nomeProva, codModalidade)
 values ('Volei de quadra Masculino',3),
		('Volei de quadra feminino',3);
 
 insert into Provas (nomeProva, codModalidade)
 values ('Volei de praia Masculino',4),
		('Volei de praia feminino',4);


CREATE TABLE Estados (
  codEstado int primary key auto_increment,
  nomeEstado varchar(255) not null
);

create table Cidades(
codCidade int primary key auto_increment,
nomeCidade varchar(255) not null,
codEstado int
);

INSERT INTO Estados(nomeEstado) VALUES
('Acre'),
('Alagoas'),
('Alemanha'),
('Amapá'),
('Amazonas'),
('Argentina'),
('Armênia'),
('Austrália'),
('Bahia'),
('Bielorussia'),
('Bélgica'),
('Ceará'),
('China'),
('Colômbia'),
('Croácia'),
('Cuba'),
('Distrito Federal'),
('EUA'),
('Espanha'),
('Espírito Santo'),
('França'),
('Goiás'),
('Grã-Bretanha'),
('Holanda'),
('Hungria'),
('Inglaterra'),
('Itália'),
('Japão'),
('Lituânia'),
('Maranhão'),
('Mato Grosso'),
('Mato Grosso do Sul'),
('Minas Gerais'),
('Paraná'),
('Paraíba'),
('Pará'),
('Pernambuco'),
('Piauí'),
('Polônia'),
('Portugal'),
('Rio Grande do Norte'),
('Rio Grande do Sul'),
('Rio de Janeiro'),
('Rondônia'),
('Roraima'),
('Santa Catarina'),
('Sergipe'),
('Suiça'),
('Suécia'),
('São Paulo'),
('Sérvia'),
('Uruguai'),
('nan');


 insert into Cidades (nomeCidade,codEstado) values
('?', 50),
('Adamantina', 50),
('Aguaí', 50),
('Americana', 50),
('Amparo', 50),
('Andradina', 50),
('Araraquara', 50),
('Araras', 50),
('Araçatuba', 50),
('Artur Nogueira', 50),
('Arujá', 50),
('Atibaia', 50),
('BASTOS', 50),
('Barra Bonita', 50),
('Barueri', 50),
('Bauru', 50),
('Boa Esperança do Sul', 50),
('Botucatu', 50),
('Brasília', 50),
('CAMPINAS', 50),
('Caieiras', 50),
('Campinas', 50),
('Campo Limpo Paulista', 50),
('Campos do Jordão', 50),
('Capivari', 50),
('Capão Bonito', 50),
('Caraguatatuba', 50),
('Carapicuíba', 50),
('Casa Branca', 50),
('Catanduva', 50),
('Colina', 50),
('Conchal', 50),
('Coronel Macedo', 50),
('Cosmopólis', 50),
('Cotia', 50),
('Cruzeiro', 50),
('Cubatão', 50),
('Descalvado', 50),
('Diadema', 50),
('Dracena', 50),
('Ferraz de Vasconcelos', 50),
('Franca', 50),
('Garça', 50),
('Guararapes', 50),
('Guaratinguetá', 50),
('Guarujá', 50),
('Guarulhos', 50),
('Guaíra', 50),
('ITARIRI', 50),
('ITU', 50),
('Ibirá', 50),
('Ibitinga', 50),
('Iguape', 50),
('Ilha Solteira', 50),
('Ilhabela', 50),
('Indiaporã', 50),
('Ipaussu', 50),
('Itanhaém', 50),
('Itapeva', 50),
('Itatiba', 50),
('Itu', 50),
('Ituverava', 50),
('Jacareí', 50),
('Jandira', 50),
('Jaú', 50),
('Jundiaí', 50),
('Juquiá', 50),
('Leme', 50),
('Lençóis Paulista', 50),
('Limeira', 50),
('Lins', 50),
('Lorena', 50),
('Lucélia', 50),
('Marília', 50),
('Matão', 50),
('Mauá', 50),
('Mococa', 50),
('Mogi das Cruzes', 50),
('Morungaba', 50),
('Nova Odessa', 50),
('Orlândia', 50),
('Osasco', 50),
('Osvaldo Cruz', 50),
('Pacaembu', 50),
('Paraguaçu Paulista', 50),
('Parapuã', 50),
('Pariquera-Açu', 50),
('Patrocinio Paulista', 50),
('Pedregulho', 50),
('Pedro de Toledo', 50),
('Penápolis', 50),
('Peruíbe', 50),
('Pindamonhangaba', 50),
('Piracicaba', 50),
('Piraju', 50),
('Pirassununga', 50),
('Porto Ferreira', 50),
('Potirendaba', 50),
('Praia Grande', 50),
('Presidente Prudente', 50),
('Promissão', 50),
('Quintana', 50),
('Registro', 50),
('Ribeirão Preto', 50),
('Rio Claro', 50),
('Rio de Janeiro', 50),
('Rosárial', 50),
('Rubineia', 50),
('Salto', 50),
('Santa Bárbara d Oeste', 50),
('Santa Maria da Serra', 50),
('Santa Rita do Passa Quatro', 50),
('Santo André', 50),
('Santo Antônio de Posse', 50),
('Santos', 50),
('Saudades', 50),
('Sertãozinho', 50),
('Sorocaba', 50),
('Sumaré', 50),
('Suzano', 50),
('São Bernardo do Campo', 50),
('São Caetano do Sul', 50),
('São Carlos', 50),
('São Joaquim da Barra', 50),
('São José do Rio Preto', 50),
('São José dos Campos', 50),
('São João da Boa Vista', 50),
('São Manuel', 50),
('São Paulo', 50),
('São Roque', 50),
('São Sebastião', 50),
('São Vicente', 50),
('Taubaté', 50),
('Tietê', 50),
('Tupi Paulista', 50),
('Tupã', 50),
('Ubatuba', 50),
('Valinhos', 50),
('Vinhedo', 50),
('Vista Alegre do Alto', 50),
('Votorantim', 50),
('Álvares Machado', 50);


-- Criando a FK cidade
alter table Cidades add constraint FK_Estado foreign key(codEstado) references Estados(codEstado);


CREATE TABLE Edicao (
  codEdicao int primary key auto_increment,
  ano int,
  sede varchar(30)
);

CREATE TABLE Atletas (
  codAtleta int primary key auto_increment,
  nomeAtleta varchar(255),
  dataNascimento varchar(20),
  sexo char(1),
  altura decimal(5,2) DEFAULT NULL,
  peso decimal(5,2) DEFAULT NULL,
  codCidade int
);

CREATE TABLE Resultadosatletas (
  codAtletaRes int primary key auto_increment,
  codAtleta int,
  codProva int,
  codEdicao int,
  resultado varchar(255) DEFAULT NULL,
  medalha varchar(255) DEFAULT NULL
);

-- Criando as FKs das tabelas
alter table Atletas add constraint FK_Cidades_Ateltas foreign key(codCidade) references Cidades(codCidade); 
alter table Resultadosatletas add constraint fk_codAtleta foreign key(codAtleta) references Atletas(codAtleta); 
alter table Resultadosatletas add constraint fk_codProva foreign key(codProva) references Provas(codProva); 
alter table Resultadosatletas add constraint fk_codEdicao foreign key(codEdicao) references Edicao(codEdicao); 


INSERT INTO Edicao (ano, sede) VALUES
(1900, 'Paris'),
(1920, 'Antuérpia'),
(1924, 'Paris'),
(1932, 'Los Angeles'),
(1936, 'Berlim'),
(1948, 'Londres'),
(1952, 'Helsinque'),
(1956, 'Melbourne'),
(1960, 'Roma'),
(1964, 'Tóquio'),
(1968, 'Cidade do México'),
(1972, 'Munique'),
(1976, 'Montreal'),
(1980, 'Moscou'),
(1984, 'Los Angeles'),
(1988, 'Seul'),
(1992, 'Barcelona'),
(1996, 'Atlanta'),
(2000, 'Sydney'),
(2004, 'Atenas'),
(2008, 'Pequim'),
(2012, 'Londres'),
(2016, 'Rio de Janeiro'),
(2020, 'Tóquio'),
(2024, 'Paris'),
(2028, 'Los Angeles'),
(2032, 'Brisbane');

INSERT INTO Atletas (nomeAtleta, dataNascimento, sexo, altura, peso, codCidade) 
VALUES('Adhemar Ferreira da Silva', '1927-09-29', 'M', NULL, NULL, 129),
('Aderval Luiz Arvani', '1949-01-07', 'M', NULL, NULL, 129),
('Stephanie Balduccini', '2004-09-20', 'F',NULL, NULL, 129),
('Thaissa Barbosa Presti', '1988-04-26', 'F',NULL, NULL, 129),
('Wanda dos Santos', '1932-06-01', 'F', NULL, NULL, 129),
('Manuel dos Santos Filho', '1939-02-22', 'M', NULL, NULL,129),
('Marcelo Teles Negrão', '1972-10-10', 'M', NULL, NULL, 129),
('Fofão', '1970-03-10', 'F', NULL, NULL, 129);


insert into Resultadosatletas(codAtleta, codProva, codEdicao, resultado, medalha)
values (8,115,18,'3°Lugar','Bronze'),
	   (8,115,19,'3°Lugar','Bronze'),
       (8,115,20,'4°Lugar',''),
       (8,115,21,'1°Lugar','Ouro');
 

insert into Resultadosatletas(codAtleta, codProva, codEdicao, resultado, medalha)
values (1,60,6,'8°Lugar',''),
	   (1,60,7,'1°Lugar','Ouro'),
       (1,60,8,'1°Lugar','Ouro'),
       (1,60,9,'14°Lugar','');       

insert into Resultadosatletas(codAtleta, codProva, codEdicao, resultado, medalha)
values (3,109,24,'Eliminada na primeira fase',''),
	   (3,105,24,'Eliminada na primeira fase',''),
       (3,113,25,'7°Lugar',''),
       (3,102,25,'Eliminada nas preliminares',''),      
       (3,110,25,'Eliminada nas preliminares','');       
       
-- Adicionando Modalidade
insert into Modalidades(nomeModalidade)
values('Ginástica Artística');

-- Adicionando a Atleta
insert into Atletas (nomeAtleta, dataNascimento, Sexo, altura, peso, codCidade)
values('Rebeca Rodrigues de Andrade','08-05-1999','F', 1.51, 46,47);




insert into Provas (nomeProva, codModalidade) values ('Individual All-ARound Feminino',5),('Equipes Feminino',5),('Solo Feminino',5),('Barras Assimétricas Feminino',5),('Trave de Equilibrio Feminino',5),('Barras Assimétricas Feminino',5),
('Salto sobre a mesa Femininino',5),('Solo Feminino',5),('Individual All-Around Feminino',5),('Equipes Feminino',5),('Individual Geral Feminino',5),('Solo Feminino',5),
('Salto sobre a mesa Feminino',5),('Trave de Equilibrio Feminino',5);


select * from resultadosatletas;

insert into resultadosatletas(codAtleta, codProva, codEdicao, resultado, medalha) values(9,118,23,'11°Lugar',''),(9,119,23,'8°Lugar',''),(9,120,23,'Não se classificou para a final',''),
(9,121,23,'Não se classificou para a final',''),(9,122,23,'Não se classificou para a final',''),(9,121,24,'Não se classificou para a final',''),
(9,125,24,'1°Lugar','Ouro'),(9,120,24,'5°Lugar',''),(9,118,24,'2°Lugar','Prata'),(9,119,25,'3°Lugar','Bronze'),(9,124,25,'2°Lugar','Prata'),
(9,120,25,'1°Lugar','Ouro'),(9,125,25,'2°Lugar','Prata'),(9,122,25,'4°Lugar','');




SELECT 
    a.nomeAtleta,
    a.dataNascimento,
    c.nomeCidade AS cidadeNascimento,
    e.nomeEstado AS estadoNascimento,
    m.nomeModalidade,
    p.nomeProva,
    ra.resultado,
    ra.medalha,
    ed.ano AS anoEdicao,
    ed.sede
FROM resultadosatletas ra
INNER JOIN atletas a ON ra.codAtleta = a.codAtleta
INNER JOIN cidades c ON a.codCidade = c.codCidade
INNER JOIN estados e ON c.codEstado = e.codEstado
INNER JOIN provas p ON ra.codProva = p.codProva
INNER JOIN modalidades m ON p.codModalidade = m.codModalidade
INNER JOIN edicao ed ON ra.codEdicao = ed.codEdicao;


insert into Atletas (nomeAtleta, dataNascimento,sexo,altura,peso,codCidade)
values ('Fabiana Marcelino Claudino','21-01-1985','F',null,null,129),
       ('Mareanne "Mari" Steinbrecher','23-08-1983','F',null,null,129),
	   ('Sheila Tavares de Castro Blassioli','01-07-1983','F',null,null,129);
  
 insert into resultadosatletas(codAtleta, codProva, codEdicao, resultado, medalha)
 values(10,115,21,'1°Lugar','Ouro'),(11,115,21,'1°Lugar','Ouro'),(12,115,21,'1°Lugar','Ouro');
  
insert into Atletas(nomeAtleta, dataNascimento, sexo, altura, peso, codCidade)
values('Fernanda Neves Beling','05-12-1982','F',null,null,129);

insert into Modalidades(nomeModalidade)
values('Basquete');

insert into Provas (nomeProva, codModalidade)
values('Basquete Feminino',5);

insert into resultadosatletas(codAtleta, codProva, codEdicao, resultado, medalha) values(13,119,21,'11°Lugar','');
