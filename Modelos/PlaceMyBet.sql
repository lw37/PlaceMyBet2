CREATE DATABASE PlaceMyBet;

USE PlaceMyBet;

CREATE TABLE  EVENTOS
(idEvento INT NOT NULL,
nombreEquipo VARCHAR(50) NOT NULL,
visitante INT NOT NULL,
fechaEvento DATE NOT NULL,
PRIMARY KEY (idEventos));

CREATE TABLE MERCADOS
(idMercado INT not NULL,
tipoMercado double NOT NULL ,
id_evento INT NOT NULL,
cuotaOver double NOT NULL,
cuotaUnder double NOT NULL,
dineroOver double NOT NULL,
dineroUnder double NOT NULL,
PRIMARY KEY (idMercado));

CREATE TABLE APUESTAS
(idApuesta INT NOT NULL, 
id_mercado INT NOT NULL,
email_usuario VARCHAR(50) NOT NULL,
tipoApuesta TINYINT(1) NOT NULL,
cuota double NOT NULL,
dineroApostado double NOT NULL,
fechaApuesta DATE NOT NULL ,
PRIMARY KEY(idApuesta));

CREATE TABLE USUARIOS
(email VARCHAR(50) NOT NULL,
nombre VARCHAR(30) NOT NULL,
apellido VARCHAR(30) NOT NULL,
edad INT NOT NULL,
PRIMARY KEY(email));

CREATE TABLE CUENTAS
(idCuenta INT NOT NULL,
email_usuario VARCHAR(50) NOT NULL,
saldo double NOT NULL,
numeroTarjeta VARCHAR(30)NOT NULL,
nombreBaco VARCHAR(30) NOT NULL,
PRIMARY KEY (idCuenta));

ALTER TABLE MERCADOS ADD CONSTRAINT r1 FOREIGN KEY (id_evento) REFERENCES eventos(idEvento);

ALTER TABLE APUESTAS ADD CONSTRAINT r2 FOREIGN KEY (id_mercado) REFERENCES mercados(idMercado) ;

ALTER TABLE APUESTAS ADD CONSTRAINT r3 FOREIGN KEY (email_usuario) REFERENCES usuarios(email) ;

ALTER TABLE CUENTAS ADD CONSTRAINT r4 FOREIGN KEY (email_usuario) REFERENCES usuarios(email) ;

INSERT INTO EVENTOS VALUES(1,'Madrid-Valencia',1000,'2020-9-23');

INSERT INTO MERCADOS(idMercado,tipoMercado ,id_evento ,cuotaOver ,cuotaUnder ,dineroOver,dineroUnder ) VALUES(1,1.5,1,1.43,2.85,100,50);

INSERT INTO USUARIOS(email,nombre,apellido ,edad) VALUES('luo.luo.ll14@gmail.com','wei','luo',20);

INSERT INTO APUESTAS(idApuesta , id_mercado ,email_usuario ,tipoApuesta ,cuota ,dineroApostado ,fechaApuesta)
VALUES(1,1,'luo.luo.ll14@gmail.com',1,100,50,'2020-9-29');

INSERT INTO cuentas VALUES(1,'luo.luo.ll14@gmail.com',2000,'8712487572316','Bankia');
