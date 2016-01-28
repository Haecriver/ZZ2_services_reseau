CREATE TABLE caracteristic(
	numcaract int, 
	def varchar(255),
	nom varchar(255), 
	typecar varchar(255),
	valeur int
);

CREATE TABLE jedi(
	numjedi int,
	nom varchar(255),
	sith bit
);

CREATE TABLE link_jedi_caracteristic(
	numjedi int,
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
);

CREATE TABLE link_stade_caracteristic(
	numstade int,
	numcaracteristic int
);

CREATE TABLE utilisateur(
	nom varchar(255), 
	prenom varchar(255), 
	loginuser varchar(255), 
	passworduser varchar(255)
);

