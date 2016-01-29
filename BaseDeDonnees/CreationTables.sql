CREATE TABLE caracteristic(
	numcaract int NOT NULL PRIMARY KEY, 
	def varchar(255),
	nom varchar(255), 
	typecar varchar(255),
	valeur int
);

CREATE TABLE jedi(
	numjedi int NOT NULL PRIMARY KEY,
	nom varchar(255),
	sith bit
);

CREATE TABLE link_jedi_caracteristic(
	numjedi int NOT NULL,
	numcaracteristic int NOT NULL,
	CONSTRAINT pk_jedi_caract PRIMARY KEY (numjedi,numcaracteristic)
);

CREATE TABLE match(
	nummatch int NOT NULL PRIMARY KEY, 
	numjedi1 int, 
	numjedi2 int, 
	phase varchar(255), 
	numstade int
);

CREATE TABLE stade(
	numstade int NOT NULL PRIMARY KEY, 
	nbplace int, 
	planete varchar(255), 
);

CREATE TABLE link_stade_caracteristic(
	numstade int NOT NULL,
	numcaracteristic int NOT NULL,
	CONSTRAINT pk_stade_caract PRIMARY KEY (numstade,numcaracteristic)
);

CREATE TABLE utilisateur(
	numuser int NOT NULL PRIMARY KEY, 
	nom varchar(255), 
	prenom varchar(255), 
	loginuser varchar(255),
	passworduser varchar(255)
);

