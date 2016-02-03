INSERT INTO jedi VALUES (0, 'Armand', 0);	/*Jedi de test*/
INSERT INTO caracteristic VALUES (0, 'Chance', 'Rien', 'Jedi', 0);
INSERT INTO link_jedi_caracteristic VALUES (0,0);

/*Caratetitiques Jedis*/

INSERT INTO caracteristic VALUES (1, 'Chance', 'Amateur de la force', 'Jedi', 20);
INSERT INTO caracteristic VALUES (2, 'Chance', 'Disciple de la force', 'Jedi', 40);
INSERT INTO caracteristic VALUES (3, 'Chance', 'Maitre de la force', 'Jedi', 60);
INSERT INTO caracteristic VALUES (4, 'Chance', 'Force obscure', 'Jedi', 30);

INSERT INTO caracteristic VALUES (5, 'Defense', 'Agilite', 'Jedi', 20);
INSERT INTO caracteristic VALUES (6, 'Defense', 'Acrobate', 'Jedi', 40);
INSERT INTO caracteristic VALUES (7, 'Defense', 'Rodrigez!', 'Jedi', 60);

INSERT INTO caracteristic VALUES (8, 'Sante', 'Endurance', 'Jedi', 20);
INSERT INTO caracteristic VALUES (9, 'Sante', 'Robustesse', 'Jedi', 40);
INSERT INTO caracteristic VALUES (10, 'Sante', 'Wookie', 'Jedi', 60);

INSERT INTO caracteristic VALUES (11, 'Sante', 'Armure legere', 'Jedi', 20);
INSERT INTO caracteristic VALUES (12, 'Sante', 'Armure lourde', 'Jedi', 40);
INSERT INTO caracteristic VALUES (13, 'Sante', 'Armure cybernetique', 'Jedi', 60);

INSERT INTO caracteristic VALUES (14, 'Force', 'Entrainement', 'Jedi', 20);
INSERT INTO caracteristic VALUES (15, 'Force', 'Force de la nature', 'Jedi', 40);
INSERT INTO caracteristic VALUES (16, 'Force', 'Badassitude', 'Jedi', 60);
INSERT INTO caracteristic VALUES (17, 'Force', 'Entrainement avec Yoda', 'Jedi', 50);

INSERT INTO caracteristic VALUES (23,'Chance','Technique de l homme bourre','Jedi',100);
INSERT INTO caracteristic VALUES (24, 'Chance', 'Personnage principal', 'Jedi', 80);

/*Caracteritique Stades*/
INSERT INTO caracteristic VALUES (18, 'Chance', 'Lave', 'Stade', -20);
INSERT INTO caracteristic VALUES (19, 'Sante', 'Desert', 'Stade', -20);
INSERT INTO caracteristic VALUES (20, 'Defense', 'Foret', 'Stade', 10);
INSERT INTO caracteristic VALUES (21, 'Force', 'Rayon de soleil rouge', 'Stade', 20);
INSERT INTO caracteristic VALUES (22, 'Force', 'Mauvais karma', 'Stade', -20);

/*Jedis (et leurs caracteritiques)*/
INSERT INTO jedi VALUES (1,'Luke',0);
INSERT INTO link_jedi_caracteristic VALUES (1,3);
INSERT INTO link_jedi_caracteristic VALUES (1,5);
INSERT INTO link_jedi_caracteristic VALUES (1,11);
INSERT INTO link_jedi_caracteristic VALUES (1,14);
INSERT INTO link_jedi_caracteristic VALUES (1,17);

INSERT INTO jedi VALUES (2,'Darth Vader',1);
INSERT INTO link_jedi_caracteristic VALUES (2,3);
INSERT INTO link_jedi_caracteristic VALUES (2,5);
INSERT INTO link_jedi_caracteristic VALUES (2,9);
INSERT INTO link_jedi_caracteristic VALUES (2,12);
INSERT INTO link_jedi_caracteristic VALUES (2,16);
INSERT INTO link_jedi_caracteristic VALUES (2,4);

INSERT INTO jedi VALUES (3,'Benjamin',0);
INSERT INTO link_jedi_caracteristic VALUES (3,3);
INSERT INTO link_jedi_caracteristic VALUES (3,7);
INSERT INTO link_jedi_caracteristic VALUES (3,10);
INSERT INTO link_jedi_caracteristic VALUES (3,13);
INSERT INTO link_jedi_caracteristic VALUES (3,16);

INSERT INTO jedi VALUES (4,'JarJar',1);
INSERT INTO link_jedi_caracteristic VALUES (4,1);
INSERT INTO link_jedi_caracteristic VALUES (4,5);
INSERT INTO link_jedi_caracteristic VALUES (4,14);
INSERT INTO link_jedi_caracteristic VALUES (4,23);

INSERT INTO jedi VALUES (5,'Palpatine',1);
INSERT INTO link_jedi_caracteristic VALUES (5,3);
INSERT INTO link_jedi_caracteristic VALUES (5,7);
INSERT INTO link_jedi_caracteristic VALUES (5,11);
INSERT INTO link_jedi_caracteristic VALUES (5,17);
INSERT INTO link_jedi_caracteristic VALUES (5,4);

INSERT INTO jedi VALUES (6,'Mace Windu',0);
INSERT INTO link_jedi_caracteristic VALUES (6,2);
INSERT INTO link_jedi_caracteristic VALUES (6,6);
INSERT INTO link_jedi_caracteristic VALUES (6,8);
INSERT INTO link_jedi_caracteristic VALUES (6,11);
INSERT INTO link_jedi_caracteristic VALUES (6,15);

INSERT INTO jedi VALUES (7,'Rey',0);
INSERT INTO link_jedi_caracteristic VALUES (7,1);
INSERT INTO link_jedi_caracteristic VALUES (7,5);
INSERT INTO link_jedi_caracteristic VALUES (7,11);
INSERT INTO link_jedi_caracteristic VALUES (7,14);
INSERT INTO link_jedi_caracteristic VALUES (7,24);

INSERT INTO jedi VALUES (8,'Obi Wan Kennobi',0);
INSERT INTO link_jedi_caracteristic VALUES (8,3);
INSERT INTO link_jedi_caracteristic VALUES (8,6);
INSERT INTO link_jedi_caracteristic VALUES (8,11);
INSERT INTO link_jedi_caracteristic VALUES (8,14);
INSERT INTO link_jedi_caracteristic VALUES (8,17);

INSERT INTO jedi VALUES (9,'Grievious',1);
INSERT INTO link_jedi_caracteristic VALUES (9,5);
INSERT INTO link_jedi_caracteristic VALUES (9,9);
INSERT INTO link_jedi_caracteristic VALUES (9,13);
INSERT INTO link_jedi_caracteristic VALUES (9,16);

INSERT INTO jedi VALUES (10,'Darth Maul',1);
INSERT INTO link_jedi_caracteristic VALUES (10,2);
INSERT INTO link_jedi_caracteristic VALUES (10,6);
INSERT INTO link_jedi_caracteristic VALUES (10,11);
INSERT INTO link_jedi_caracteristic VALUES (10,16);

/*Stades (et leurs caracteritiques)*/
INSERT INTO stade VALUES (1,100,'Jakku');
INSERT INTO link_stade_caracteristic VALUES (1,19);

INSERT INTO stade VALUES (2,300,'Tatouine');
INSERT INTO link_stade_caracteristic VALUES (2,19);
INSERT INTO link_stade_caracteristic VALUES (2,22);

INSERT INTO stade VALUES (3,50,'Mustafar');
INSERT INTO link_stade_caracteristic VALUES (3,18);

INSERT INTO stade VALUES (4,500,'Endor'); /*Bcp de places parceque les ewoks sont petits */
INSERT INTO link_stade_caracteristic VALUES (4,20);

INSERT INTO stade VALUES (5,200,'Krypton'); /*Wait ... */
INSERT INTO link_stade_caracteristic VALUES (5,21);

/*Creation match test par defaut*/
INSERT INTO match VALUES (1,3,4,'Finale',5);

/*Creation des users*/
INSERT INTO utilisateur VALUES ( 1,'Pissavy', 'Pierre-Loup', 'pierre-loup', '7713171214110574628179941158658824220234100233');
INSERT INTO utilisateur VALUES ( 2,'Michel', 'Anne-Lise', 'anne-lise', '12916199140682391079923112232164102223981571488011890');
INSERT INTO utilisateur VALUES ( 3,'Chevalier', 'Pierre', 'pierre', '2401021318310619256116541193723344131559617824019430');
INSERT INTO utilisateur VALUES ( 4,'Raux', 'Gaël', 'gael', '123106311952523078187380202221896801648561198');
            
INSERT INTO utilisateur VALUES ( 5,'Garcon', 'Benoit', 'begarco', '174751664024916112120513931501462532411992882123115'); /* l'intru*/
