DROP DATABASE IF EXISTS VeloMax;
CREATE DATABASE VeloMax;
USE VeloMax;

-- insertion de tuples effectué
CREATE TABLE Prog_Fidelio(
        No_Programme INT,
        PRIMARY KEY (No_Programme),
        Descri_fid VARCHAR (50),
        cout INT,
        duree INT,
        rabais INT
);

-- insertion de tuples effectué
CREATE TABLE Magasins(
        ID_Magasin INT ,
        Nom_Magasin VARCHAR(50),
        Gerant VARCHAR (50) ,
		PRIMARY KEY (ID_Magasin)
);

-- insertion de tuples effectué
CREATE TABLE Commandes(
        num_unique INT,
        PRIMARY KEY (num_unique),
        adresse_livraison VARCHAR(50),
        date_livraison DATE,
        quantite_item INT,
        ID_Magasin INT,
        FOREIGN KEY(ID_Magasin) REFERENCES Magasins(ID_Magasin)
        
);

-- insertion de tuples effectué
CREATE TABLE Boutiques_specialises(
        ID_bs INT ,
        nom_boutique VARCHAR (50),
        adresse_bs VARCHAR (50),
        telephone INT ,
        courriel VARCHAR (50) ,
        nom_personne_contact VARCHAR (50) ,
        remise_comm INT ,
		PRIMARY KEY (ID_bs)
);

-- insertion de tuples effectué
CREATE TABLE individus(
        ID_indiv INT,
        nom_ind VARCHAR (50) ,
        prenom_ind VARCHAR (50) ,
        adresse_ind VARCHAR (50) ,
        tel_ind INT ,
        courriel_ind VARCHAR (50) ,
		PRIMARY KEY (ID_indiv)
);

-- insertion de tuples effectué
CREATE TABLE modele_bicyclette(
        num_prod_by INT ,
        nom VARCHAR (50) ,
        grandeur VARCHAR (50) ,
        prix_uni INT ,
        ligne_prod VARCHAR (50) ,
        date_intro DATE ,
        date_discon DATE ,
        stock_bicy INT,
		PRIMARY KEY (num_prod_by)
);

-- insertion de tuples effectué
CREATE TABLE Vendeurs(
        ID_Vendeur INT ,
        type_contrat VARCHAR (50) ,
        salaire INT ,
        prime INT ,
        ID_Magasin INT ,
		PRIMARY KEY (ID_Vendeur),
		FOREIGN KEY (ID_Magasin) REFERENCES Magasins(ID_Magasin)
);

-- insertion de tuples effectué
CREATE TABLE Pieces(
        Ref_produit VARCHAR(50) ,
        descrip VARCHAR (50) ,
        nom_fournisseur VARCHAR (50) ,
        num_prod_catalogue_fournisseur INT ,
        prix_unitaire_2 INT ,
        date_intro_marche DATE ,
        date_discon_prod DATE ,
        date_appro DATE ,
        stock INT,
		PRIMARY KEY (Ref_produit)
);

-- insertion de tuples effectué
CREATE TABLE Fournisseurs(
        Siret VARCHAR(14) ,
        nom_d_entreprise Varchar (50) ,
        contact Varchar (50) ,
        adresse VARCHAR (50) ,
        libelle INT ,
		PRIMARY KEY (Siret)
);

-- insertion de tuples effectué
CREATE TABLE Fournit(
        Ref_produit VARCHAR(50) ,
        Siret VARCHAR(14) ,
		PRIMARY KEY (Ref_produit,Siret),
		FOREIGN KEY (Ref_produit) REFERENCES Pieces(Ref_produit),
		FOREIGN KEY (Siret) REFERENCES Fournisseurs(Siret)
);

-- insertion de tuples effectué
CREATE TABLE contient(
        Ref_produit VARCHAR(50) ,
        ID_Magasin Int ,
        num_prod_by Int ,
		PRIMARY KEY (Ref_produit,ID_Magasin,num_prod_by),
		FOREIGN KEY (Ref_produit) REFERENCES Pieces(Ref_produit),
		FOREIGN KEY (ID_Magasin) REFERENCES Magasins(ID_Magasin),
		FOREIGN KEY (num_prod_by) REFERENCES modele_bicyclette(num_prod_by)
);

-- insertion de tuples effectué
CREATE TABLE prepare(
        ID_Vendeur Int ,
        num_unique  Int ,
		PRIMARY KEY (ID_Vendeur,num_unique),
		FOREIGN KEY (ID_Vendeur) REFERENCES Vendeurs(ID_Vendeur),
		FOREIGN KEY (num_unique) REFERENCES Commandes(num_unique)
);

-- insertion de tuples effectué
CREATE TABLE est_composee(
        Ref_produit VARCHAR(50) ,
        num_unique     Int ,
        num_prod_by    Int ,
        PRIMARY KEY (Ref_produit,num_unique,num_prod_by),
        FOREIGN KEY (num_unique) REFERENCES Commandes(num_unique),
        FOREIGN KEY (Ref_produit) REFERENCES Pieces (Ref_produit),
        FOREIGN KEY (num_prod_by) REFERENCES modele_bicyclette (num_prod_by)
        );

-- insertion de tuples effectué        
CREATE TABLE adhère(
	date_adhésion DATE,
    No_Programme int,
    ID_indiv int,
    date_expi DATE,
	PRIMARY KEY (date_adhésion),
    FOREIGN KEY(No_Programme) REFERENCES Prog_fidelio(No_Programme),
    FOREIGN KEY(ID_indiv) REFERENCES Individus(ID_indiv)
    );
    
CREATE TABLE passe(
date_comm DATE,
ID_bs INT,
num_unique INT,
ID_indiv INT,
PRIMARY KEY(Date_comm),
FOREIGN KEY (ID_bs) REFERENCES Boutiques_specialises (ID_bs),
FOREIGN KEY (num_unique) REFERENCES Commandes (num_unique),
FOREIGN KEY (ID_indiv) REFERENCES individus (ID_indiv)
);

INSERT INTO modele_bicyclette ( num_prod_by, nom, grandeur, prix_uni, ligne_prod,date_intro,date_discon, stock_bicy) VALUES
(101,'Kilimandjaro', 'Adultes', 569, 'VTT','2020-12-23','2022-11-11', 11),
(102,'NorthPole', 'Adultes', 329, 'VTT','2020-12-23','2022-11-11', 13),
(103, 'MontBlanc', 'Jeunes', 399, 'VTT','2020-12-23','2022-11-11', 5),
(104, 'Hooligan', 'Jeunes', 199, 'VTT','2020-12-23','2022-11-11', 2),
(105, 'Orléans', 'Hommes', 229, 'Vélo de course','2020-12-23','2022-11-11', 8),
(106, 'Orléans', 'Dames', 229, 'Vélo de course','2020-12-23','2022-11-11', 2),
(107, 'BlueJay', 'Hommes', 349, 'Vélo de course','2020-12-23','2022-11-11', 6),
(108, 'BlueJay', 'Dames', 349, 'Vélo de course','2020-12-23','2022-11-11', 5),
(109, 'Trail Explorer', 'Filles', 129, 'Classique','2020-12-23','2022-11-11', 2),
(110, 'Trail Explorer', 'Garçons', 129, 'Classique','2020-12-23','2022-11-11', 1),
(111, 'Night Hawk', 'Jeunes', 189, 'Classique','2020-12-23','2022-11-11', 11),
(112, 'Tierra Verde', 'Hommes', 199, 'Classique','2020-12-23','2022-11-11', 12),
(113, 'Tierra Verde', 'Dames', 199, 'Classique','2020-12-23','2022-11-11', 21),
(114, 'Mud Zinger I', 'Jeunes', 279, 'BMX','2020-12-23','2022-11-11', 3),
(115, 'Mud Zinger II', 'Adultes', 359, 'BMX','2020-12-23','2022-11-11', 7);

INSERT INTO Prog_Fidelio(No_Programme, Descri_Fid, Cout, Duree, rabais)VALUES
(1, 'Fidélio', 15, 1, 5),
(2,'Fidélio Or', 25, 2, 8),
(3,'Fidélio Platine', 60, 2, 10),
(4,'Fidélio Max', 100, 3, 12);

INSERT INTO Pieces (Ref_produit, descrip, nom_fournisseur, num_prod_catalogue_fournisseur, prix_unitaire_2, date_intro_marche, date_discon_prod, date_appro, stock) VALUES 
('C32', 'cadre', 'Arsenal', 1, 100, '2023-01-15', '2024-01-15', '2024-02-01', 50),
('C34', 'cadre', 'HavertzBikes', 1, 120, '2023-02-20', '2024-02-20', '2024-03-15', 40),
('C76', 'cadre', 'HavertzBikes', 2, 130, '2023-03-25', '2024-03-25', '2024-04-10', 2),
('C43', 'cadre', 'Arsenal', 2, 110, '2023-04-10', '2024-04-10', '2024-05-01', 35),
('C44F', 'cadre', 'HavertzBikes', 3, 125, '2023-05-15', '2024-05-15', '2024-06-01', 55),
('C01', 'cadre', 'HavertzBikes', 4, 115, '2023-06-20', '2024-06-20', '2024-07-10', 48),
('C02', 'cadre', 'Arsenal', 3, 105, '2023-07-25', '2024-07-25', '2024-08-05', 42),
('C15', 'cadre', 'Arsenal', 4, 95, '2023-08-30', '2024-08-30', '2024-09-15', 38),
('C87', 'cadre', 'Arsenal', 5, 140, '2023-09-05', '2024-09-05', '2024-10-01', 63),
('C87f', 'cadre', 'HavertzBikes', 5, 135, '2023-10-10', '2024-10-10', '2024-11-05', 58),
('C25', 'cadre', 'Vasseur&Co', 1, 150, '2023-11-15', '2024-11-15', '2024-12-01', 70),
('C26', 'cadre', 'Vasseur&Co', 2, 155, '2023-12-20', '2024-12-20', '2025-01-10', 1),
('G7', 'guidon', 'Vasseur&Co', 3, 60, '2024-01-25', '2025-01-25', '2025-02-05', 30),
('G9', 'guidon', 'Arsenal', 6, 65, '2024-02-28', '2025-02-28', '2025-03-20', 32),
('G12', 'guidon', 'HavertzBikes', 6, 70, '2024-03-30', '2025-03-30', '2025-04-15', 35),
('F3', 'freins', 'Vasseur&Co', 4, 45, '2024-04-05', '2025-04-05', '2025-04-25', 20),
('F9', 'freins', 'Vasseur&Co', 5, 50, '2024-05-10', '2025-05-10', '2025-05-30', 25),
('S35', 'selle', 'Vasseur&Co', 6, 35, '2024-06-15', '2025-06-15', '2025-07-01', 15),
('S88', 'selle', 'Vasseur&Co', 7, 40, '2024-07-20', '2025-07-20', '2025-08-10', 18),
('S37', 'selle', 'Arsenal', 7, 45, '2024-08-25', '2025-08-25', '2025-09-15', 20),
('S02', 'selle', 'Vasseur&Co', 8, 30, '2024-09-30', '2025-09-30', '2025-10-15', 2),
('S03', 'selle', 'Arsenal', 8, 32, '2024-10-05', '2025-10-05', '2025-11-01', 14),
('S36', 'selle', 'Vasseur&Co', 9, 38, '2024-11-10', '2025-11-10', '2025-12-05', 16),
('S34', 'selle', 'HavertzBikes', 7, 42, '2024-12-15', '2025-12-15', '2026-01-01', 22),
('S87', 'selle', 'Arsenal', 9, 47, '2025-01-20', '2026-01-20', '2026-02-10', 24),
('DV133', 'dérailleur avant', 'Vasseur&Co', 10, 55, '2025-02-25', '2026-02-25', '2026-03-15', 28),
('DV17', 'dérailleur avant', 'HavertzBikes', 8, 60, '2025-03-30', '2026-03-30', '2026-04-20', 30),
('DV87', 'dérailleur avant', 'HavertzBikes', 9, 65, '2025-04-05', '2026-04-05', '2026-05-01', 1),
('DV57', 'dérailleur avant', 'Vasseur&Co', 11, 50, '2025-05-10', '2026-05-10', '2026-06-01', 26),
('DV15', 'dérailleur avant', 'Vasseur&Co', 12, 52, '2025-06-15', '2026-06-15', '2026-07-05', 27),
('DV41', 'dérailleur avant', 'Arsenal', 10, 58, '2025-07-20', '2026-07-20', '2026-08-10', 2),
('DV32', 'dérailleur avant', 'Arsenal', 11, 62, '2025-08-25', '2026-08-25', '2026-09-01', 31),
('DV33', 'dérailleur avant', 'Arsenal', 12, 70, '2025-09-30', '2026-09-30', '2026-10-15', 35),
('DR56', 'dérailleur avant', 'Vasseur&Co', 13, 75, '2025-10-05', '2026-10-05', '2026-11-01', 1),
('DR87', 'dérailleur avant', 'HavertzBikes', 10, 80, '2025-11-10', '2026-11-10', '2026-12-05', 40),
('DR86', 'dérailleur arrière', 'HavertzBikes', 11, 85, '2025-12-15', '2026-12-15', '2027-01-01', 42),
('DR23', 'dérailleur arrière', 'Arsenal', 13, 90, '2026-01-20', '2027-01-20', '2027-02-10', 45),
('DR76', 'dérailleur arrière', 'Vasseur&Co', 14, 95, '2026-02-25', '2027-02-25', '2027-03-15', 48),
('DR52', 'dérailleur arrière', 'Vasseur&Co', 15, 100, '2026-03-30', '2027-03-30', '2027-04-20', 2),
('R45', 'roue', 'Vasseur&Co', 16, 105, '2026-04-05', '2027-04-05', '2027-05-01', 52),
('R48', 'roue', 'Arsenal', 14, 110, '2026-05-10', '2027-05-10', '2027-06-01', 55),
('R12', 'roue', 'Vasseur&Co', 17, 115, '2026-06-15', '2027-06-15', '2027-07-05', 58),
('R19', 'roue', 'Vasseur&Co', 18, 120, '2026-07-20', '2027-07-20', '2027-08-10', 60),
('R1', 'roue', 'Arsenal', 15, 125, '2026-08-25', '2027-08-25', '2027-09-01', 62),
('R11', 'roue', 'Vasseur&Co', 19, 130, '2026-09-30', '2027-09-30', '2027-10-15', 65),
('R44', 'roue', 'HavertzBikes', 12, 135, '2026-10-05', '2027-10-05', '2027-11-01', 1),
('R46', 'roue', 'HavertzBikes', 13, 140, '2026-11-10', '2027-11-10', '2027-12-05', 70),
('R47', 'roue', 'Vasseur&Co', 20, 145, '2026-12-15', '2027-12-15', '2028-01-01', 72),
('R32', 'roue', 'Arsenal', 16, 150, '2027-01-20', '2028-01-20', '2028-02-10', 75),
('R18', 'roue', 'Vasseur&Co', 21, 155, '2027-02-25', '2028-02-25', '2028-03-15', 2),
('R2', 'roue', 'Arsenal', 17, 160, '2027-03-30', '2028-03-30', '2028-04-20', 80),
('R02', 'réflecteurs', 'Vasseur&Co', 22, 30, '2027-04-05', '2028-04-05', '2028-05-01', 15),
('R09', 'réflecteurs', 'HavertzBikes', 14, 35, '2027-05-10', '2028-05-10', '2028-06-01', 18),
('R10', 'réflecteurs', 'HavertzBikes', 15, 40, '2027-06-15', '2028-06-15', '2028-07-05', 20),
('P12', 'pédalier', 'West London Bikes', 1, 90, '2027-07-20', '2028-07-20', '2028-08-10', 2),
('P34', 'pédalier', 'West London Bikes', 2, 95, '2027-08-25', '2028-08-25', '2028-09-01', 1),
('P1', 'pédalier', 'West London Bikes', 3, 100, '2027-09-30', '2028-09-30', '2028-10-15', 50),
('P15', 'pédalier', 'West London Bikes', 4, 105, '2027-10-05', '2028-10-05', '2028-11-01', 52),
('O2', 'ordinateur', 'Vasseur&Co', 23, 55, '2027-11-10', '2028-11-10', '2028-12-05', 26),
('O4', 'ordinateur', 'Vasseur&Co', 24, 60, '2027-12-15', '2028-12-15', '2029-01-01', 28),
('S01', 'panier', 'Arsenal', 18, 65, '2028-01-20', '2029-01-20', '2029-02-10', 1),
('S05', 'panier', 'Arsenal', 19, 70, '2028-02-25', '2029-02-25', '2029-03-01', 32),
('S74', 'panier', 'Vasseur&Co', 25, 75, '2028-03-30', '2029-03-30', '2029-04-20', 35),
('S73', 'panier', 'Vasseur&Co', 26, 80, '2028-04-05', '2029-04-05', '2029-05-01', 1);

INSERT INTO Magasins(ID_Magasin, Nom_Magasin, Gerant) VALUES
(1, 'Magasin A', 'Jean Dupont'),
(2, 'Magasin B', 'Marie Leclerc'),
(3, 'Magasin C', 'Pierre Dubois'),
(4, 'Magasin D', 'Antoine Martin'),
(5, 'Magasin E', 'Sophie Bernard');

INSERT INTO Commandes(num_unique, adresse_livraison, date_livraison, quantite_item, ID_magasin) VALUES
(1, '123 Rue de Paris', '2024-05-01', 5, '1'),
(2, '456 Avenue des Fleurs', '2024-05-03', 3, '2'),
(3, '789 Boulevard du Commerce', '2024-05-05', 7, '3'),
(4, '321 Rue de la Paix', '2024-05-07', 4, '4'),
(5, '654 Avenue de la Liberté', '2024-05-09', 6, '5'),
(6, '987 Avenue des Étoiles', '2024-05-11', 8, '1'),
(7, '741 Rue de la République', '2024-05-13', 2, '2'),
(8, '852 Boulevard des Sports', '2024-05-15', 5, '3'),
(9, '369 Avenue du Soleil', '2024-05-17', 3, '4'),
(10, '159 Rue de la Liberté', '2024-05-19', 6, '5'),
(11, '753 Boulevard des Arts', '2024-05-21', 4, '1'),
(12, '258 Avenue de la Paix', '2024-05-23', 7, '2'),
(13, '654 Rue de la Science', '2024-05-25', 2, '3'),
(14, '987 Boulevard du Temps', '2024-05-27', 5, '4'),
(15, '369 Avenue de l_Espoir', '2024-05-29', 3, '5');

INSERT INTO Boutiques_specialises(ID_bs, nom_boutique, adresse_bs, telephone, courriel, nom_personne_contact, remise_comm)VALUES
(1, 'Boutique Béatrice Tarlet', '16 Pl. Dugas, 69510 Thurins', 0982459114, 'beatrice.tarlet@gmail.com', 'Béatrice tarlet', 15),
(2, 'Boutique Romain Lamauve', '17 rue du Chesnay, Asnières',0695996325, 'romain.lmv@wanadoo.fr','Romain Lamauve', 10),
(3, 'Les vélos de Léo','55 Rue du Faubourg Saint-Honoré, 75008 Paris', 0142928100, 'Leo.Cvlr@hotmail.com','Leo Cuvelier','3');

INSERT INTO Individus(ID_Indiv, nom_ind, prenom_ind, adresse_ind, tel_ind, courriel_ind) VALUES
(1, 'Dubois', 'Jean', '123 Rue de Paris', '0123456789', 'jean.dubois@example.com'),
(2, 'Martin', 'Marie', '456 Avenue des Fleurs', '0987654321', 'marie.martin@example.com'),
(3, 'Lefebvre', 'Pierre', '789 Boulevard du Commerce', '0123456789', 'pierre.lefebvre@example.com'),
(4, 'Bernard', 'Sophie', '321 Rue de la Paix', '0987654321', 'sophie.bernard@example.com'),
(5, 'Durand', 'Philippe', '654 Avenue de la Liberté', '0123456789', 'philippe.durand@example.com'),
(6, 'Garcia', 'Laura', '987 Avenue des Étoiles', '0123456789', 'laura.garcia@example.com'),
(7, 'Rodriguez', 'Antoine', '741 Rue de la République', '0987654321', 'antoine.rodriguez@example.com'),
(8, 'Fernandez', 'Camille', '852 Boulevard des Sports', '0123456789', 'camille.fernandez@example.com'),
(9, 'Lopez', 'Thomas', '369 Avenue du Soleil', '0987654321', 'thomas.lopez@example.com'),
(10, 'Martinez', 'Emma', '159 Rue de la Liberté', '0123456789', 'emma.martinez@example.com'),
(11, 'Sánchez', 'Lucas', '753 Boulevard des Arts', '0987654321', 'lucas.sanchez@example.com'),
(12, 'González', 'Manon', '258 Avenue de la Paix', '0123456789', 'manon.gonzalez@example.com'),
(13, 'Vazquez', 'Chloé', '654 Rue de la Science', '0987654321', 'chloe.vazquez@example.com'),
(14, 'Moreno', 'Théo', '987 Boulevard du Temps', '0123456789', 'theo.moreno@example.com'),
(15, 'Jiménez', 'Léa', '369 Avenue de l_Espoir', '0987654321', 'lea.jimenez@example.com'),
(16, 'Roux', 'Nathan', '123 Rue de la Victoire', '0123456789', 'nathan.roux@example.com'),
(17, 'Leroy', 'Juliette', '456 Avenue de la Joie', '0987654321', 'juliette.leroy@example.com'),
(18, 'Girard', 'Gabriel', '789 Boulevard de la Chance', '0123456789', 'gabriel.girard@example.com'),
(19, 'Caron', 'Zoé', '321 Rue de l_Espérance', '0987654321', 'zoe.caron@example.com'),
(20, 'Mercier', 'Louise', '654 Avenue de l_Amour', '0123456789', 'louise.mercier@example.com');


INSERT INTO Vendeurs(ID_Vendeur, type_contrat, salaire, prime, ID_Magasin) VALUES
(1, 'CDI', 2500, 300, 1),
(2, 'CDI', 2600, 350, 2),
(3, 'CDI', 2400, 280, 3),
(4, 'CDI', 2700, 380, 4),
(5, 'CDI', 2800, 400, 5),
(6, 'CDI', 2550, 320, 1),
(7, 'CDI', 2650, 360, 2),
(8, 'CDI', 2450, 290, 3),
(9, 'CDI', 2750, 390, 4),
(10, 'CDI', 2850, 410, 5),
(11, 'CDI', 2600, 330, 1),
(12, 'CDI', 2700, 370, 2),
(13, 'CDI', 2500, 300, 3),
(14, 'CDI', 2800, 400, 4),
(15, 'CDI', 2900, 420, 5),
(16, 'CDI', 2650, 340, 1),
(17, 'CDI', 2750, 380, 2),
(18, 'CDI', 2550, 310, 3),
(19, 'CDI', 2850, 410, 4),
(20, 'CDI', 2950, 430, 5);

INSERT INTO Fournisseurs(SIRET, nom_d_entreprise, contact, adresse, libelle) VALUES
('67890123456789', 'BikeParts', 'Lucie Girard', '987 Boulevard de la Victoire', 1),
('78901234567890', 'CycleExpert', 'Thomas Lefevre', '147 Rue de la République', 2),
('89012345678901', 'SpeedyBikes', 'Emma Moreau', '258 Avenue des Sports', 4),
('90123456789012', 'BikePro', 'Louis Renault', '369 Boulevard de la Liberté', 2),
('01234567890123', 'VeloTech', 'Julie Martinez', '456 Avenue de la Science', 3);

INSERT INTO Fournit(Ref_produit, Siret)
VALUES
('C32', '67890123456789'),
('C34', '78901234567890'),
('C76', '78901234567890'),
('C43', '67890123456789'),
('C44F', '78901234567890'),
('C01', '78901234567890'),
('C02', '67890123456789'),
('C15', '67890123456789'),
('C87', '67890123456789'),
('C87f', '78901234567890'),
('C25', '01234567890123'),
('C26', '01234567890123'),
('G7', '01234567890123'),
('G9', '67890123456789'),
('G12', '78901234567890'),
('F3', '01234567890123'),
('F9', '01234567890123'),
('S35', '01234567890123'),
('S88', '01234567890123'),
('S37', '67890123456789'),
('S02', '01234567890123'),
('S03', '67890123456789'),
('S36', '01234567890123'),
('S34', '78901234567890'),
('S87', '67890123456789'),
('DV133', '01234567890123'),
('DV17', '78901234567890'),
('DV87', '78901234567890'),
('DV57', '01234567890123'),
('DV15', '01234567890123'),
('DV41', '67890123456789'),
('DV32', '67890123456789'),
('DV33', '67890123456789'),
('DR56', '01234567890123'),
('DR87', '78901234567890'),
('DR86', '78901234567890'),
('DR23', '67890123456789'),
('DR76', '01234567890123'),
('DR52', '01234567890123'),
('R45', '01234567890123'),
('R48', '67890123456789'),
('R12', '01234567890123'),
('R19', '01234567890123'),
('R1', '67890123456789'),
('R11', '01234567890123'),
('R44', '78901234567890'),
('R46', '78901234567890'),
('R47', '01234567890123'),
('R32', '67890123456789'),
('R18', '01234567890123'),
('R2', '67890123456789'),
('R02', '01234567890123'),
('R09', '78901234567890'),
('R10', '78901234567890'),
('P12', '01234567890123'),
('P34', '01234567890123'),
('P1', '01234567890123'),
('P15', '01234567890123'),
('O2', '01234567890123'),
('O4', '01234567890123'),
('S01', '67890123456789'),
('S05', '67890123456789'),
('S74', '01234567890123'),
('S73', '01234567890123');

INSERT INTO Contient(Ref_produit,ID_Magasin,num_prod_by) VALUES
('C01', 3, 104),
('C01', 4, 104),
('C02', 3, 104),
('C02', 4, 104),
('C15', 3, 104),
('C15', 4, 104),
('C87', 3, 104),
('C87', 4, 104),
('C87f', 3, 104),
('C87f', 4, 104);

INSERT INTO Prepare(ID_Vendeur, num_unique) VALUES
(1,1),
(7,2),
(18,3),
(4,4),
(5,5),
(2,6),
(12,7),
(3,8),
(19,9),
(10,10),
(6,11),
(17,12),
(13,13),
(14,14),
(20,15);

INSERT INTO est_composee(Ref_produit, num_unique, num_prod_by) VALUES
('C32', 1, 105),
('C34', 2, 103),
('C76', 3, 107),
('C43', 4, 104),
('C44F', 5, 103),
('C01', 6, 109),
('C02', 7, 102),
('C15', 8, 108),
('C87', 9, 106),
('C87f', 10, 103),
('C87', 11, 106),
('C87', 12, 106),
('C87', 13, 106),
('C87', 14, 106),
('C87', 15, 106);

INSERT INTO adhère(date_adhésion, No_Programme, ID_indiv, date_expi) VALUES
('2023-05-15', 2, 1, '2025-05-15'),
('2023-06-20', 1, 2, '2024-06-20'),
('2023-07-25', 3, 3, '2025-07-25'),
('2023-08-30', 1, 4, '2024-08-30'),
('2023-09-05', 4, 5,'2026-09-05');

INSERT INTO passe(date_comm, ID_bs, num_unique, ID_indiv) VALUES
('2024-05-01', 1, 1, 1),
('2024-05-03', 2, 2, 2),
('2024-05-05', 3, 3, 3),
('2024-05-07', 2, 4, 4),
('2024-05-09', 1, 5, 5);