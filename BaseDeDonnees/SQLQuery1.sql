DROP TABLE jedis;
DROP TABLE caracteristics;
DROP TABLE match;
DROP TABLE stade;
DROP TABLE utilisateur;

CREATE TABLE caracteristics(
	numcaract int, 
	typecar varchar(255),
	nom varchar(255), 
	valeur int
);

CREATE TABLE jedis(
	numjedi int,
	name varchar(255),
	issith bit,
	numcaracteristic int
);

CREATE TABLE match(
	nummatch int, 
	numjedi1 int, 
	numjedi2 int, 
	phase varchar(255), 
	numstade int
);

CREATE TABLE stade(
	numstade int, 
	nbplace int, 
	planete varchar(255), 
	numcaracteristic int
);

CREATE TABLE utilisateur(
	nom varchar(255), 
	prenom varchar(255), 
	loginuser varchar(255), 
	passworduser varchar(255)
);

INSERT INTO jedis VALUES (1, 'Armand', 0, null);

SELECT * FROM jedis;
