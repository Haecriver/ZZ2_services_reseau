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
	CONSTRAINT pk_jedi_caract PRIMARY KEY (numjedi,numcaracteristic),
	CONSTRAINT fk_caract_jc_link FOREIGN KEY (numcaracteristic) REFERENCES caracteristic (numcaract)
	 ON DELETE CASCADE
	 ON UPDATE CASCADE,
	CONSTRAINT fk_jedi_jc_link FOREIGN KEY (numjedi) REFERENCES jedi (numjedi)
	 ON DELETE CASCADE
	 ON UPDATE CASCADE
);

CREATE TABLE stade(
	numstade int NOT NULL PRIMARY KEY, 
	nbplace int, 
	planete varchar(255), 
);

CREATE TABLE link_stade_caracteristic(
	numstade int NOT NULL,
	numcaracteristic int NOT NULL,
	CONSTRAINT pk_stade_caract PRIMARY KEY (numstade,numcaracteristic),
	CONSTRAINT fk_caract_sc_link FOREIGN KEY (numcaracteristic) REFERENCES caracteristic (numcaract)
	 ON DELETE CASCADE
	 ON UPDATE CASCADE,
	CONSTRAINT fk_stade_sc_link FOREIGN KEY (numstade) REFERENCES stade (numstade)
	 ON DELETE CASCADE
	 ON UPDATE CASCADE
);

CREATE TABLE match(
	nummatch int NOT NULL PRIMARY KEY, 
	numjedi1 int, 
	numjedi2 int, 
	phase varchar(255), 
	numstade int,
	CONSTRAINT fk_jedi1_match FOREIGN KEY (numjedi1) REFERENCES jedi (numjedi),
	CONSTRAINT fk_jedi2_match FOREIGN KEY (numjedi2) REFERENCES jedi (numjedi),
	CONSTRAINT fk_stade_match FOREIGN KEY (numstade) REFERENCES stade (numstade)
	 ON DELETE CASCADE
	 ON UPDATE CASCADE
);

CREATE TABLE utilisateur(
	numuser int NOT NULL PRIMARY KEY, 
	nom varchar(255), 
	prenom varchar(255), 
	loginuser varchar(255),
	passworduser varchar(255)
);

