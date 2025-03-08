-- requetes
DELETE FROM passe WHERE ID_indiv = 3;
DELETE FROM adhère WHERE ID_indiv = 3;
DELETE FROM prepare WHERE ID_Vendeur IN (SELECT ID_Vendeur FROM Vendeurs WHERE ID_Magasin IN (SELECT ID_Magasin FROM Magasins WHERE ID_Magasin IN (SELECT ID_Magasin FROM passe WHERE ID_indiv = 3)));
DELETE FROM individus WHERE ID_indiv = 3;
SELECT ID_Indiv FROM individus;


UPDATE Individus SET {autre chose que ID_Indiv} = {new value} WHERE ID_Indiv = {ID_indiv};


SELECT i.nom_ind, i.prenom_ind, SUM(pc.prix_unitaire_2 * c.quantite_item) AS benefice
FROM individus i
JOIN passe p ON i.ID_indiv = p.ID_indiv
JOIN commandes c ON p.num_unique = c.num_unique
JOIN est_composee ec ON c.num_unique = ec.num_unique
JOIN pieces pc ON ec.Ref_produit = pc.Ref_produit
GROUP BY i.nom_ind, i.prenom_ind;

SELECT f.nom_d_entreprise AS 'nom entreprise', COUNT(p.Ref_produit) AS 'nb pieces'
FROM Fournisseurs f
LEFT JOIN Fournit fo ON f.Siret = fo.Siret;

SELECT p.date_comm AS 'date de commande', p.ID_bs AS 'ID boutique', p.num_unique AS 'num commande', p.ID_indiv
FROM passe p
INNER JOIN adhère a ON p.ID_indiv = a.ID_indiv
INNER JOIN Commandes c ON p.num_unique = c.num_unique;


SELECT prenom_ind AS 'Prenom ou nom de boutique', nom_ind
FROM individus
UNION
SELECT nom_boutique, NULL
FROM Boutiques_specialises;

SELECT DISTINCT i1.nom_ind, i1.prenom_ind, i1.adresse_ind
FROM individus i1
JOIN individus i2 ON i1.adresse_ind = i2.adresse_ind
AND i1.ID_indiv <> i2.ID_indiv;




SELECT Ref_produit, descrip, stock
FROM Pieces
WHERE stock <= 2;


SELECT f.nom_d_entreprise, COUNT(DISTINCT c.Ref_produit) AS 'nombre de vélos'
FROM Fournisseurs f
INNER JOIN Fournit fo ON f.Siret = fo.Siret
INNER JOIN contient c ON fo.Ref_produit = c.Ref_produit
GROUP BY f.Siret, f.nom_d_entreprise;


SELECT m.ID_Magasin, m.Nom_Magasin, SUM(prix_unitaire_2 * quantite_item) AS "chiffre d'affaire généré"
FROM Magasins m
JOIN Commandes c ON m.ID_Magasin = c.ID_Magasin
JOIN est_composee ec ON c.num_unique = ec.num_unique
JOIN Pieces p ON ec.Ref_produit = p.Ref_produit
GROUP BY m.ID_Magasin, m.Nom_Magasin;


SELECT v.ID_Vendeur, COUNT(DISTINCT c.num_unique)
FROM Vendeurs v
JOIN prepare pr ON v.ID_Vendeur = pr.ID_Vendeur
JOIN Commandes c ON pr.num_unique = c.num_unique
GROUP BY v.ID_Vendeur;


SELECT 
v1.ID_Magasin AS 'ID Magasin ',
v1.ID_Vendeur AS 'ID Vendeur 1', 
v1.type_contrat AS 'type ontrat 1', 
v1.salaire AS 'salaire 1', 
v1.prime AS 'prime 1',  
v2.ID_Vendeur AS 'ID Vendeur 2', 
v2.type_contrat AS 'type contrat 2', 
v2.salaire AS 'salaire 2', 
v2.prime AS 'prime 2'
FROM 
Vendeurs v1
JOIN 
Vendeurs v2 ON v1.ID_Magasin = v2.ID_Magasin AND v1.ID_Vendeur != v2.ID_Vendeur;


