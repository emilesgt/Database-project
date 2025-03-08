	-- 1.Produire un rapport statistique présentant les quantités vendues de chaque item qui se
	-- trouve dans l’inventaire de VéloMax dans son ensemble, par magasin et par vendeur
SELECT m.ID_Magasin,
       m.Nom_Magasin,
       p.Ref_produit,
       p.descrip AS Description_Produit,
       SUM(c.quantite_item) AS Quantite_Vendue
FROM Commandes c
INNER JOIN Magasins m ON c.ID_Magasin = m.ID_Magasin
INNER JOIN contient ct ON c.ID_Magasin = ct.ID_Magasin
INNER JOIN Pieces p ON ct.Ref_produit = p.Ref_produit
GROUP BY m.ID_Magasin, m.Nom_Magasin, p.Ref_produit, p.descrip;

SELECT v.ID_Vendeur,
       p.Ref_produit,
       p.descrip AS Description_Produit,
       SUM(c.quantite_item) AS Quantite_Vendue,
       
FROM Commandes c
INNER JOIN prepare pr ON c.num_unique = pr.num_unique
INNER JOIN Vendeurs v ON pr.ID_Vendeur = v.ID_Vendeur
INNER JOIN contient ct ON c.ID_Magasin = ct.ID_Magasin
INNER JOIN Pieces p ON ct.Ref_produit = p.Ref_produit
GROUP BY v.ID_Vendeur, p.Ref_produit, p.descrip;



-- 2. Produire la liste des membres pour chaque programme d’adhésion.
SELECT i.nom_ind, i.prenom_ind, p.No_Programme
FROM individus i, adhère a, prog_fidelio p
WHERE i.ID_indiv = a.ID_indiv
AND a.No_Programme = p.No_Programme;


-- 3. Affichez la date d’expiration des adhésions
SELECT i.nom_ind, i.prenom_ind, a.date_expi
FROM adhère a
JOIN individus i ON a.ID_indiv = i.ID_indiv;


-- 4. Retrouvez-le (ou les) meilleur client en fonction des quantités vendues en nombre de
-- pièces vendues ou en cumul en euros

-- 5. Faîtes une analyse des commandes : par exemple, moyenne des montants des commandes,
-- moyenne du nombre de pièces ou de vélos par commande.
SELECT AVG(c.quantite_item * p.prix_unitaire_2) AS moyenne_montant_commande
FROM commandes c
JOIN est_composee ec ON c.num_unique = ec.num_unique
JOIN pieces p ON ec.Ref_produit = p.Ref_produit;

SELECT AVG(c.quantite_item) AS moyenne_pieces_par_commande
FROM commandes c;

SELECT AVG(c.quantite_item) AS "moyenne velos par commande"
FROM commandes c
JOIN est_composee ec ON c.num_unique = ec.num_unique
JOIN modele_bicyclette mb ON ec.num_prod_by = mb.num_prod_by;

-- 6. Calcul des bonus des salariés en fonction de la satisfaction client et du CA réalisé par
-- chacun, calcul du bonus moyen



SELECT nom_ind AS 'nom', prenom_ind AS 'prenom'
FROM individus
GROUP BY IDD_ind;

INSERT INTO Individus (ID_indiv, nom_ind, prenom_ind, adresse_ind, tel_ind, courriel_ind) VALUES
({ID_indiv}, {nom_ind}, {prenom_ind}, {adresse_ind}, {tel_ind}, {courriel_ind});

DELETE FROM indivius WHERE ID_indiv = {ID_indiv};

SELECT i.nom_ind AS 'nom', i.prenom_ind AS 'prenom', pf.No_Programme AS 'programme'
FROM individus i, adhère a, prog_fidelio pf
WHERE a.ID_indiv = i.ID_indiv AND a.No_programme = pf.No_programme;

SELECT nom_d_entreprise AS 'fournisseur'
FROM fournisseurs;

DELETE FROM fournit WHERE Siret = ___;
DELETE FROM fournisseurs WHERE Siret = ___;


UPDATE Fournisseurs
SET nom = ___ , adresse = ___, telephone = 'New Supplier Phone'
WHERE Siret = ___ ;

UPDATE individus
SET nom_ind='gouzi',
prenom_ind='skkr',
adresse_ind='brrpa',
tel_ind=0345,
courriel_ind='grrr'
WHERE ID_indiv=1;

SELECT * FROM individus;


DELETE FROM Passe WHERE num_unique = ___;
DELETE FROM Est_Composee WHERE num_unique = ___;
DELETE FROM Commande WHERE num_unique = ___;

UPDATE Commande
SET adresse_livraison = ___ , date_livraison = ___, quantite_item = ___, ID_Magasin = ___
WHERE num_unique = ___ ;

SELECT * FROM vendeurs;

DELETE FROM prepare WHERE ID_Vendeur = ___;
DELETE FROM vendeurs WHERE ID_Vendeur = ___;

INSERT INTO Vendeurs (ID_vendeur, type_contrat, salaire, prime, ID_Magasin) VALUES
({ID_vendeur}, {type_contrat}, {salaire}, { prime}, { ID_Magasin});

INSERT INTO pieces(Ref_produit, descrip, nom_fournisseur, num_prod_catalogue_fournisseur, prix_unitaire_2, date_intro_marche, date_discon_prod, date_appro, stock) VALUES
({Ref_produit}, {descrip}, {nom_fournisseur}, {num_prod_catalogue_fournisseur}, {prix_unitaire_2}, {date_intro_marche}, {date_discon_prod}, {date_appro}, {stock});

DELETE FROM est_composee WHERE Ref_produit =___;
DELETE FROM contient WHERE Ref_produit =___;
DELETE FROM fournit WHERE Ref_produit =___;
DELETE FROM pieces WHERE Ref_produit = ___;

SELECT nom, stock_bicy  FROM modele_bicyclette;


DELETE FROM contient WHERE num_prod_by = ___;
DELETE FROM est_composee WHERE num_prod_by = ___;
DELETE FROM modele_bicyclette WHERE num_prod_by = ___;



DELETE FROM est_composee WHERE Ref_produit ='C01';
DELETE FROM contient WHERE Ref_produit ='C01';
DELETE FROM fournit WHERE Ref_produit ='C01';
DELETE FROM pieces WHERE Ref_produit = 'C01';

SELECT Stock FROM pieces WHERE Ref_produit = ' ';


