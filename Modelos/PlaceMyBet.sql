CREATE DATABASE PlaceMyBet;

USE PlaceMyBet;

CREATE TABLE  evento
(idEvento INT NOT NULL,
nombreEquipo VARCHAR(50) NOT NULL,
visitantes INT ,
fechaEvento DATE NOT NULL,
PRIMARY KEY (idEvento));

CREATE TABLE mercados
(idMercado INT not NULL,
tipoMercado double NOT NULL ,
id_evento INT NOT NULL,
cuotaOver double NOT NULL,
cuotaUnder double NOT NULL,
dineroOver double NOT NULL,
dineroUnder double NOT NULL,
PRIMARY KEY (idMercado));

CREATE TABLE infoApuesta
(idApuesta INT NOT NULL, 
id_mercado INT NOT NULL,
email_usuario VARCHAR(50) NOT NULL,
tipoApuesta TINYINT(1) NOT NULL,
cuota double NOT NULL,
dineroApostado double NOT NULL,
fechaApuesta DATE NOT NULL ,
PRIMARY KEY(idApuesta));

CREATE TABLE usuario
(email VARCHAR(50) NOT NULL,
contraseña VARCHAR(50) NOT NULL,
nombre VARCHAR(30) NOT NULL,
apellido VARCHAR(30) NOT NULL,
edad INT NOT NULL,
PRIMARY KEY(email));

CREATE TABLE cuenta
(idCuenta INT NOT NULL,
email_usuario VARCHAR(50) NOT NULL,
saldo double NOT NULL,
numeroTarjeta VARCHAR(30)NOT NULL,
nombreBaco VARCHAR(30) NOT NULL,
PRIMARY KEY (idCuenta));

ALTER TABLE mercados ADD CONSTRAINT r1 FOREIGN KEY (id_evento) REFERENCES evento(idEvento);

ALTER TABLE infoApuesta ADD CONSTRAINT r2 FOREIGN KEY (id_mercado) REFERENCES mercados(idMercado) ;

ALTER TABLE infoApuesta ADD CONSTRAINT r3 FOREIGN KEY (email_usuario) REFERENCES usuario(email) ;

ALTER TABLE cuenta ADD CONSTRAINT r4 FOREIGN KEY (email_usuario) REFERENCES usuario(email) ;

INSERT INTO evento VALUES(1,'Madrid-Valencia',1000,'2020-9-23');

INSERT INTO mercados(idMercado,tipoMercado ,id_evento ,cuotaOver ,cuotaUnder ,dineroOver,dineroUnder ) VALUES(1,1.5,1,1.43,2.85,100,50);

INSERT INTO usuario(email ,contraseña ,nombre,apellido ,edad) VALUES('luo.luo.ll14@gmail.com','123','wei','luo',20);

INSERT INTO infoApuesta(idApuesta , id_mercado ,email_usuario ,tipoApuesta ,cuota ,dineroApostado ,fechaApuesta)
VALUES(1,1,'luo.luo.ll14@gmail.com',1,100,50,'2020-9-29');

INSERT INTO cuenta VALUES(1,'luo.luo.ll14@gmail.com',2000,'8712487572316','Bankia');
