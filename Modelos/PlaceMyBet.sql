CREATE DATABASE PlaceMyBet;

USE PlaceMyBet;

CREATE TABLE  eventos
(idEventos INT NOT NULL,
nombreEquipos VARCHAR(50) NOT NULL,
visitantes INT ,
fechaEventos DATE NOT NULL,
PRIMARY KEY (idEventos));

CREATE TABLE mercados
(idMercados INT not NULL,
tipoMercados double NOT NULL ,
id_eventos INT NOT NULL,
cuotaOver double NOT NULL,
cuotaUnder double NOT NULL,
dineroOver double NOT NULL,
dineroUnder double NOT NULL,
PRIMARY KEY (idMercados));

CREATE TABLE infoApuestas
(idApuestas INT NOT NULL, 
id_mercados INT NOT NULL,
email_usuarios VARCHAR(50) NOT NULL,
tipoApuestas TINYINT(1) NOT NULL,
cuotas double NOT NULL,
dineroApostados double NOT NULL,
fechaApuestas DATE NOT NULL ,
PRIMARY KEY(idApuestas));

CREATE TABLE usuarios
(email VARCHAR(50) NOT NULL,
nombres VARCHAR(30) NOT NULL,
apellidos VARCHAR(30) NOT NULL,
edad INT NOT NULL,
PRIMARY KEY(email));

CREATE TABLE cuentas
(idCuentas INT NOT NULL,
email_usuarios VARCHAR(50) NOT NULL,
saldos double NOT NULL,
numeroTarjetas VARCHAR(30)NOT NULL,
nombreBacos VARCHAR(30) NOT NULL,
PRIMARY KEY (idCuentas));

ALTER TABLE mercados ADD CONSTRAINT r1 FOREIGN KEY (id_eventos) REFERENCES eventos(idEventos);

ALTER TABLE infoApuestas ADD CONSTRAINT r2 FOREIGN KEY (id_mercados) REFERENCES mercados(idMercados) ;

ALTER TABLE infoApuestas ADD CONSTRAINT r3 FOREIGN KEY (email_usuarios) REFERENCES usuarios(email) ;

ALTER TABLE cuentas ADD CONSTRAINT r4 FOREIGN KEY (email_usuarios) REFERENCES usuarios(email) ;

INSERT INTO eventos VALUES(1,'Madrid-Valencia',1000,'2020-9-23');

INSERT INTO mercados(idMercados,tipoMercados ,id_eventos ,cuotaOver ,cuotaUnder ,dineroOver,dineroUnder ) VALUES(1,1.5,1,1.43,2.85,100,50);

INSERT INTO usuarios(email,nombres,apellidos ,edad) VALUES('luo.luo.ll14@gmail.com','wei','luo',20);

INSERT INTO infoApuestas(idApuestas , id_mercados ,email_usuarios ,tipoApuestas ,cuotas ,dineroApostados ,fechaApuestas)
VALUES(1,1,'luo.luo.ll14@gmail.com',1,100,50,'2020-9-29');

INSERT INTO cuentas VALUES(1,'luo.luo.ll14@gmail.com',2000,'8712487572316','Bankia');
