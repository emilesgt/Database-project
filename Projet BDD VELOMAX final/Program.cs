using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Pqc.Crypto.Lms;



namespace Projet_BDD_VELOMAX_final
{
    class Program
    {
        //ASCII ART TEXT TITRES
        #region affichage ASCII
        static void intro()
        {
            Console.WriteLine(" ____   ____  ________  _____       ___   ____    ____       _       ____  ____  ");
            Console.WriteLine("|_  _| |_  _||_   __  ||_   _|    .'   `.|_   \\  /   _|     / \\     |_  _||_  _|");
            Console.WriteLine("  \\ \\   / /    | |_ \\_|  | |     /  .-.  \\ |   \\/   |      / _ \\      \\ \\  / /  ");
            Console.WriteLine("   \\ \\ / /     |  _| _   | |   _ | |   | | | |\\  /| |     / ___ \\      > `' <    ");
            Console.WriteLine("    \\ ' /     _| |__/ | _| |__/ |\\  `-'  /_| |_\\/_| |_  _/ /   \\ \\_  _/ /'`\\ \\_ ");
            Console.WriteLine("     \\_/     |________||________| `.___.'|_____||_____||____| |____||____||____|");
            Console.WriteLine("");
        }

        static void introConnexion()
        {
            Console.WriteLine("   ______    ___   ____  _____  ____  _____  ________  ____  ____  _____   ___   ____  _____  ");
            Console.WriteLine(" .' ___  | .'   `.|_   \\|_   _||_   \\|_   _||_   __  ||_  _||_  _||_   _|.'   `.|_   \\|_   _| ");
            Console.WriteLine("/ .'   \\_|/  .-.  \\ |   \\ | |    |   \\ | |    | |_ \\_|  \\ \\  / /    | | /  .-.  \\ |   \\ | |   ");
            Console.WriteLine("| |       | |   | | | |\\ \\| |    | |\\ \\| |    |  _| _    > `' <     | | | |   | | | |\\ \\| |   ");
            Console.WriteLine("\\ `.___.' \\  `-'  /_| |_\\   |_  _| |_\\   |_  _| |__/ | _/ /'`\\ \\_  _| |_\\  `-'  /_| |_\\   |_  ");
            Console.WriteLine(" `.____ .' `.___.'|_____|\\____||_____|\\____||________||____||____||_____|`.___.'|_____|\\____| ");
            Console.WriteLine("");
        }

        static void introClients()
        {
            Console.WriteLine("   ______  _____     _____  ________  ____  _____  _________   ______   ");
            Console.WriteLine(" .' ___  ||_   _|   |_   _||_   __  ||_   \\|_   _||  _   _  |.' ____ \\  ");
            Console.WriteLine("/ .'   \\_|  | |       | |    | |_ \\_|  |   \\ | |  |_/ | | \\_|| (___ \\_|");
            Console.WriteLine("| |         | |   _   | |    |  _| _   | |\\ \\| |      | |     _.____`.  ");
            Console.WriteLine("\\ `.___.'\\ _| |__/ | _| |_  _| |__/ | _| |_\\   |_    _| |_   | \\____) | ");
            Console.WriteLine(" `.____ .'|________||_____||________||_____|\\____|  |_____|   \\______.' ");
            Console.WriteLine("");
        }

        static void introProduits()
        {
            Console.WriteLine(" _______  _______      ___   ______   _____  _____  _____  _________   ______   ");
            Console.WriteLine("|_   __ \\|_   __ \\   .'   `.|_   _ `.|_   _||_   _||_   _||  _   _  |.' ____ \\  ");
            Console.WriteLine("  | |__) | | |__) | /  .-.  \\ | | `. \\ | |    | |    | |  |_/ | | \\_|| (___ \\_| ");
            Console.WriteLine("  |  ___/  |  __ /  | |   | | | |  | | | '    ' |    | |      | |     _.____`.  ");
            Console.WriteLine(" _| |_    _| |  \\ \\_\\  `-'  /_| |_.' /  \\ \\__/ /    _| |_    _| |_   | \\____) | ");
            Console.WriteLine("|_____|  |____| |___|`.___.'|______.'    `.__.'    |_____|  |_____|   \\______.' ");
            Console.WriteLine("");
        }

        static void introCommande()
        {
            Console.WriteLine("   ______    ___   ____    ____  ____    ____       _       ____  _____  ______   ________  ");
            Console.WriteLine(" .' ___  | .'   `.|_   \\  /   _||_   \\  /   _|     / \\     |_   \\|_   _||_   _ `.|_   __  | ");
            Console.WriteLine("/ .'   \\_|/  .-.  \\ |   \\/   |    |   \\/   |      / _ \\      |   \\ | |    | | `. \\ | |_ \\_| ");
            Console.WriteLine("| |       | |   | | | |\\  /| |    | |\\  /| |     / ___ \\     | |\\ \\| |    | |  | | |  _| _  ");
            Console.WriteLine("\\ `.___.'\\\\  `-'  /_| |_\\/_| |_  _| |_\\/_| |_  _/ /   \\ \\_  _| |_\\   |_  _| |_.' /_| |__/ | ");
            Console.WriteLine(" `.____ .' `.___.'|_____||_____||_____||_____||____| |____||_____|\\____||______.'|________| ");
            Console.WriteLine("");
        }

        static void introStat()
        {
            Console.WriteLine("   _____ _        _       ");
            Console.WriteLine("  / ____| |      | |      ");
            Console.WriteLine(" | (___ | |_ __ _| |_ ___ ");
            Console.WriteLine("  \\___ \\| __/ _` | __/ __|");
            Console.WriteLine("  ____) | || (_| | |_\\__ \\");
            Console.WriteLine(" |_____/ \\__\\__,_|\\__|___/");
            Console.WriteLine("");
        }

        static void introFournisseur()
        {
            Console.WriteLine("  ______                     _                         ");
            Console.WriteLine(" |  ____|                   (_)                        ");
            Console.WriteLine(" | |__ ___  _   _ _ __ _ __  _ ___ ___  ___ _   _ _ __ ");
            Console.WriteLine(" |  __/ _ \\| | | | '__| '_ \\| / __/ __|/ _ \\ | | | '__|");
            Console.WriteLine(" | | | (_) | |_| | |  | | | | \\__ \\__ \\  __/ |_| | |   ");
            Console.WriteLine(" |_|  \\___/ \\__,_|_|  |_| |_|_|___/___/\\___|\\__,_|_|   ");
            Console.WriteLine("");
        }

        static void introVendeur()
        {
            Console.WriteLine(" __      __            _                 ");
            Console.WriteLine(" \\ \\    / /           | |                ");
            Console.WriteLine("  \\ \\  / /__ _ __   __| | ___ _   _ _ __ ");
            Console.WriteLine("   \\ \\/ / _ \\ '_ \\ / _` |/ _ \\ | | | '__|");
            Console.WriteLine("    \\  /  __/ | | | (_| |  __/ |_| | |   ");
            Console.WriteLine("     \\/ \\___|_| |_|\\__,_|\\___|\\__,_|_|   ");
            Console.WriteLine("");
        }

        static void introAutre()
        {
            Console.WriteLine("      _   _____  _____  _________  _______     ________ ");
            Console.WriteLine("     / \\ |_   _||_   _||  _   _  ||_   __ \\   |_   __  | ");
            Console.WriteLine("    / _ \\  | |    | |  |_/ | | \\_|  | |__) |    | |_ \\_| ");
            Console.WriteLine("   / ___ \\ | '    ' |      | |      |  __ /     |  _| _  ");
            Console.WriteLine(" _/ /   \\ \\_\\ \\__/ /      _| |_    _| |  \\ \\_  _| |__/ | ");
            Console.WriteLine("|____| |____|`.__.'      |_____|  |____| |___||________|");
            Console.WriteLine("");
        }
        #endregion 

        //AFFICHAGE DES DIFFERENTS MENUS CHACUN SELON UN INDEX DE CHOIX, DE DIFFERENTS CHOIX ET DE LEUR TITRE
        #region Affichage méthodes
        static void AfficherMenuPrincipal(string[] options, int choixIndex)
        {
            Console.Clear();
            intro();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == choixIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
        }

        static void AfficherMenuStat(string[] options, int choixIndex)
        {
            Console.Clear();
            introStat();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == choixIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
        }

        static void AfficherMenuFournisseur(string[] options, int choixIndex)
        {
            Console.Clear();
            introFournisseur();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == choixIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
        }

        static void AfficherMenuVendeur(string[] options, int choixIndex)
        {
            Console.Clear();
            introVendeur();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == choixIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
        }

        static void AfficherMenuClients(string[] options, int choixIndex)
        {
            Console.Clear();
            introClients();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == choixIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
        }

        static void AfficherMenuProduit(string[] options, int choixIndex)
        {
            Console.Clear();
            introProduits();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == choixIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
        }

        static void AfficherMenuCommande(string[] options, int choixIndex)
        {
            Console.Clear();
            introCommande();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == choixIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
        }

        static void AfficherMenuConnexion(string[] options, int choixIndex)
        {
            Console.Clear();
            introConnexion();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == choixIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
        }

        static void AfficherMenuAutre(string[] options, int choixIndex)
        {
            Console.Clear();
            introAutre();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == choixIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
        }
        #endregion

        //CODES DES DIFFERENTS MENUS (CONNEXION,PRINCIPAL,CLIENTS,PRODUIT,FOURNISSEURS,VENDEURS,AUTRES REQUETES) ET LE MODE DEMO
        #region Menus code
        static void MenuClients(string user,string mdp) //Menu des commandes clients
        {
            string titre;
            bool continuerclient = true;
            int choixIndex = 0;
            string[] optionsMenuclients = { "Nombre de clients", "Liste clients", "Liste des entreprises","Liste des clients et leur programme", "Ajouter un client", "Supprimer un client", "Mettre à jour un client", "Quitter" };
            while (continuerclient)
            {
                AfficherMenuClients(optionsMenuclients, choixIndex);
                ConsoleKeyInfo touche = Console.ReadKey();
                MySqlConnection connection = createDB(user, mdp);
                string requete;
                switch (touche.Key)
                {
                    case ConsoleKey.UpArrow:
                        choixIndex = Math.Max(0, choixIndex - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        choixIndex = Math.Min(optionsMenuclients.Length - 1, choixIndex + 1);
                        break;
                    case ConsoleKey.Enter:
                        switch (choixIndex)
                        {
                            case 0: //nombre de clients
                                requete = "SELECT count(*) from individus;";
                                Console.Clear();
                                Console.Write("Nombre de Client : ");
                                ExecuteRequete(connection, requete);
                                connection.Close();
                                break;
                            case 1: // liste des clients hors entreprises
                                requete = "SELECT * from individus;";
                                Console.Clear();
                                titre = "Numéro client               Nom                         Prénom                      Adresse                     Numéro                      Mail\n\n";
                                ExecuteRequete(connection, requete,0,titre,true);
                                connection.Close();
                                break;
                            case 2: //liste des clients entreprises
                                requete = "SELECT * FROM boutiques_specialises GROUP BY ID_bs; ";
                                Console.Clear();
                                titre = "Numéro boutique             Nom boutique                Adresse                     Numéro                      Mail                        Personne responsable        Remise\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;
                            case 3: //Liste des clients avec fidélio
                                requete = "SELECT i.nom_ind AS 'nom', i.prenom_ind AS 'prenom', pf.No_Programme AS 'programme' FROM individus i, adhère a, prog_fidelio pf WHERE a.ID_indiv = i.ID_indiv AND a.No_programme = pf.No_programme; ";
                                Console.Clear();
                                titre = "Nom                         Prénom                      Programme (1 : Fidélio, 2 : Fidélio Argent, 3 : Fidélio Or, 4 : Fidélio Max\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;
                            case 4: //Ajout de client
                                int numC = 1;
                                Console.Clear();
                                Console.WriteLine("Donner le nom du client :");
                                string nom = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Donner le prénom du client :");
                                string prenom = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Donner l'adresse du client :");
                                string adresse = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Donner le numéro de téléphone du client :");
                                string numero = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("Donner l'adresse mail du client :");
                                string mail = Console.ReadLine();
                                Console.Clear();
                                try
                                {
                                    MySqlCommand command2 = connection.CreateCommand();
                                    command2.CommandText = "SELECT ID_indiv FROM individus;";
                                    
                                    MySqlDataReader reader;
                                    reader = command2.ExecuteReader();

                                    string[] ret = new string[reader.FieldCount];
                                    List<string> mylist = new List<string>();

                                    while (reader.Read())
                                    { 
                                        if(numC == (int)reader.GetValue(0))
                                        {
                                            numC++;
                                        }
                                    }

                                    Console.WriteLine();

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Une erreur s'est produite lors de l'exécution de la requête : " + ex.Message);
                                    Console.ReadKey();
                                    connection.Close();
                                }

                                connection.Close();
                                connection = createDB(user, mdp);
                                string query = $"INSERT INTO individus VALUES (" + numC.ToString() + ", \'" + nom + "\', \'" + prenom + "\', \'" + adresse + "\', \'" + numero + "\', \'" + mail + "\')";
                                MySqlCommand command = new MySqlCommand(query, connection);
                                try
                                {
                                    command.ExecuteNonQuery();
                                    Console.WriteLine("Tuples créés avec succès.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }

                                connection.Close();
                                connection = createDB(user, mdp);
                                break;

                            case 5: //Suppression de client    
                                requete = "SELECT * from individus;";
                                Console.Clear();
                                titre = "Numéro client               Nom                         Prénom                      Adresse                     Numéro                      Mail\n\n";
                                ExecuteRequete(connection, requete,0,titre,true);
                                connection.Close();
                                connection = createDB(user, mdp);
                                Console.WriteLine("\nQuel client voulez-vous supprimer ? rentrez le numéro (si vous voulez annuler écrire une lettre)",0,titre);
                                string supp = Console.ReadLine();
                                try
                                {
                                    supp = Convert.ToInt32(supp).ToString();
                                    string supprequete = $"DELETE FROM passe WHERE ID_indiv = "+supp+ "; DELETE FROM adhère WHERE ID_indiv = " + supp + "; DELETE FROM prepare WHERE ID_Vendeur IN(SELECT ID_Vendeur FROM Vendeurs WHERE ID_Magasin IN (SELECT ID_Magasin FROM Magasins WHERE ID_Magasin IN (SELECT ID_Magasin FROM passe WHERE ID_indiv = " + supp + ")));DELETE FROM individus WHERE ID_indiv = " + supp + "; ";
                                    command = new MySqlCommand(supprequete, connection);
                                    command.ExecuteNonQuery();
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                catch(Exception ex)
                                {
                                    Console.WriteLine("Aucun tuple n'a été supprimé");
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                break;
                            case 6: //Modification de client
                                requete = "SELECT * from individus;";
                                Console.Clear();
                                titre = "Numéro client               Nom                         Prénom                      Adresse                     Numéro                      Mail\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                connection = createDB(user, mdp);
                                Console.WriteLine("\nQuel client voulez-vous modifier ?");
                                string choix = Console.ReadLine();
                                requete = "SELECT * from individus where ID_indiv = "+choix+";";
                                Console.Clear();  
                                titre = "Numéro client               Nom                         Prénom                      Adresse                     Numéro                      Mail\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                Console.WriteLine("Quel nom voulez-vous donner au client ? ");
                                nom = Console.ReadLine();
                                Console.WriteLine("Quel prénom voulez-vous donner au client ? ");
                                prenom = Console.ReadLine();
                                Console.WriteLine("Quelle adresse voulez-vous donner au client ? ");
                                adresse = Console.ReadLine();
                                Console.WriteLine("Quel numéro voulez-vous donner au client ? ");
                                numero = Console.ReadLine();
                                Console.WriteLine("Quel mail voulez-vous donner au client ? ");
                                mail = Console.ReadLine();
                                connection = createDB(user, mdp);
                                try
                                {
                                    string supprequete = $"UPDATE individus SET nom_ind = '"+nom+"', prenom_ind = '"+prenom+"', adresse_ind = '"+adresse+"', tel_ind='"+numero+"', courriel_ind = '"+mail+"' Where ID_Indiv = '"+choix+"';"; //j'en étais là
                                    command = new MySqlCommand(supprequete, connection);
                                    command.ExecuteNonQuery();
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Aucune modification n'a été effectué");
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                break;
                            case 7: //client 
                                continuerclient = false;
                                break;

                        }
                        break;
                }
            }
        }

        static void MenuProduits(string user,string mdp) //menu des requêtes produit
        {
            string titre;
            bool continuerproduit = true;
            int choixIndex = 0;
            string[] optionsMenuproduit = { "Liste des pièces", "Modifier le stock d'une pièce ou d'un vélo", "Création d'une pièce", "Suppression d'une pièce", "Liste des bicyclettes", "Création bicyclette","Suppression d'un vélo","Quitter" };
            Console.Clear();
            while (continuerproduit)
            {
                Console.Clear();
                AfficherMenuProduit(optionsMenuproduit, choixIndex);
                ConsoleKeyInfo touche = Console.ReadKey();
                MySqlConnection connection = createDB(user, mdp);
                string requete;
                switch (touche.Key)
                {
                    case ConsoleKey.UpArrow:
                        choixIndex = Math.Max(0, choixIndex - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        choixIndex = Math.Min(optionsMenuproduit.Length - 1, choixIndex + 1);
                        break;
                    case ConsoleKey.Enter:
                        switch (choixIndex)
                        {
                            case 0: //liste des pièces 
                                requete = "SELECT * from pieces;";
                                Console.Clear();
                                titre = "Référence produit     Description           Nom du fournisseur    Numéro catalogue      Prix unitaire         Intro au marché       Fin de production     Approvisionnement   stock\n\n" ;
                                ExecuteRequete(connection, requete,6,titre,true);
                                connection.Close();
                                break;
                            case 1: //changer le stock d'une pièce ou d'une bicyclette
                                Console.Clear();
                                Console.WriteLine("Rentrer 1 pour changer le stock d'une pièce, 2 pour le stock d'une bicyclette, autre chose pour annuler");
                                string pb = Console.ReadLine();
                                try
                                {
                                    if (pb == "1") //changer le stock d'une pièce 
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Donner la référence de la pièce :");
                                        string refpiece = Console.ReadLine();
                                        Console.Clear();
                                        Console.WriteLine("Donner le nouveau stock de la pièce :");
                                        string nouveaustock = Console.ReadLine();

                                        requete = "UPDATE PIECES SET STOCK = " + nouveaustock + " WHERE Ref_Produit = '" + refpiece + "';";
                                        Console.Clear();
                                        try
                                        {
                                            ExecuteRequete(connection, requete);
                                            Console.WriteLine("Stock modifié");
                                            connection.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("stock non affecté");
                                            Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                            Console.ReadKey();
                                            connection.Close();
                                        }
                                    }
                                    else if (pb == "2") // changer le stock d'une bicyclette
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Donner la référence de la bicyclette :");
                                        string refpiece = Console.ReadLine();
                                        Console.Clear();
                                        Console.WriteLine("Donner le nouveau stock de la bicyclette :");
                                        string nouveaustock = Console.ReadLine();

                                        requete = "UPDATE modele_bicyclette SET STOCK_bicy = " + nouveaustock + " WHERE num_prod_by = '" + refpiece + "';";
                                        Console.Clear();
                                        try
                                        {
                                            ExecuteRequete(connection, requete);
                                            Console.WriteLine("Stock modifié");
                                            connection.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("stock non affecté");
                                            Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                            Console.ReadKey();
                                            connection.Close();
                                        }
                                    }

                                }
                                catch //uniquement pour empêcher le crash
                                {

                                }

                                break;
                            case 2: // création de pièce
                                Console.Clear();
                                Console.WriteLine("Nom fournisseurs : ");
                                requete = "SELECT nom_d_entreprise from fournisseurs;";
                                ExecuteRequete(connection, requete, 0, "", false);
                                connection.Close();

                                Console.WriteLine("Veuillez entrer la référence du produit");
                                string Ref_produit = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le type du produit");
                                string descrip = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le nom du fournisseur");
                                string nom_fournisseur = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le numéro de la pièce dans le catalogue du fournisseur");
                                string num_prod_catalogue_fournisseur = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le prix de la pièce");
                                string prix_unitaire_2 = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer l'année de la date d'introduction dans le marché");
                                string année_intro = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le mois de la date d'introduction dans le marché");
                                string mois_intro = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le jour de la date d'introduction dans le marché");
                                string jour_intro = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer l'année de la date de discontinuation dans le marché");
                                string année_discon = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le mois de la date de discontinuation dans le marché");
                                string mois_discon = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le jour de la date de discontinuation dans le marché");
                                string jour_discon = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer l'année de la date d'approvisionnement");
                                string année_appro = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le mois de la date d'approvisionnement");
                                string mois_appro = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le jour de la date d'approvisionnement");
                                string jour_appro = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le nombre de pièces");
                                string stock = Console.ReadLine();


                                string query = $"INSERT INTO pieces VALUES ('" + Ref_produit + "', '" + descrip + "', '" + nom_fournisseur + "', '" + num_prod_catalogue_fournisseur + "', '" + prix_unitaire_2 + "', '" + année_intro + "-" + mois_intro + "-" + jour_intro + "', '" + année_discon + "-" + mois_discon + "-" + jour_discon + "', '" + année_appro + "-" + mois_appro + "-" + jour_appro + "', '"+stock+"');";
                                connection = createDB(user, mdp);
                                MySqlCommand command = new MySqlCommand(query, connection);
                                try
                                {
                                    command.ExecuteNonQuery();
                                    Console.WriteLine("pièce créée avec succès.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                break;
                            case 3: //suppression de pièce
                                requete = "SELECT * from pieces;";
                                Console.Clear();
                                titre = "Référence produit     Description           Nom du fournisseur    Numéro catalogue      Prix unitaire         Intro au marché       Fin de production     Approvisionnement   stock\n\n";
                                ExecuteRequete(connection, requete, 6, titre, true);
                                connection.Close();
                                connection = createDB(user, mdp);
                                Console.WriteLine("\nQuelle pièce voulez-vous supprimer ? rentrez la référence (si vous voulez annuler écrire une chaine avec plus de 5 caractères)", 0, titre);
                                string supp = Console.ReadLine();
                                try
                                {
                                    if (supp.Length < 6)
                                    {
                                        string supprequete = $"DELETE FROM est_composee WHERE Ref_produit = '" + supp+ "'; DELETE FROM contient WHERE Ref_produit = '" + supp+ "'; DELETE FROM fournit WHERE Ref_produit = '" + supp+ "'; DELETE FROM pieces WHERE Ref_produit = '" + supp+ "';";
                                        command = new MySqlCommand(supprequete, connection);
                                        command.ExecuteNonQuery();
                                        Console.ReadKey();
                                        connection.Close();
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERREUR : référence trop longue");
                                        Console.ReadKey();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Aucun tuple n'a été supprimé");
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                break;
                            case 4: //liste des bicyclettes
                                requete = "SELECT * from modele_bicyclette;";
                                Console.Clear();
                                titre = "Référence produit     Nom                   Grandeur              Prix unitaire         Ligne de production   Date d'intro          Date de discon         stock\n\n";
                                ExecuteRequete(connection, requete, 6, titre, true);
                                connection.Close();
                                break;
                            case 5: //ajout de bicyclette
                                Console.Clear();
                                Console.WriteLine("Nom fournisseurs : ");
                                requete = "SELECT nom_d_entreprise from fournisseurs;";
                                ExecuteRequete(connection, requete, 0, "", false);
                                connection.Close();

                                Console.WriteLine("Veuillez entrer la référence de la bicyclette");
                                 Ref_produit = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le nom de la bicyclette");
                                 string nom = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer grandeur de la bicyclette");
                                 string grandeur = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le prix de la bicyclette");
                                 string prix_unitaire = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer la ligne de production de la bicyclette");
                                 string ligne_prod = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer l'année de la date d'introduction dans le marché");
                                 année_intro = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le mois de la date d'introduction dans le marché");
                                 mois_intro = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le jour de la date d'introduction dans le marché");
                                 jour_intro = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer l'année de la date de discontinuation dans le marché");
                                 année_discon = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le mois de la date de discontinuation dans le marché");
                                 mois_discon = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer le jour de la date de discontinuation dans le marché");
                                 jour_discon = Console.ReadLine();

           

                                Console.WriteLine("Veuillez entrer le nombre de pièces");
                                 stock = Console.ReadLine();


                                 query = $"INSERT INTO modele_bicyclette VALUES ('" + Ref_produit + "', '" + nom + "', '" + grandeur + "', '" + prix_unitaire + "', '" + ligne_prod + "', '" + année_intro + "-" + mois_intro + "-" + jour_intro + "', '" + année_discon + "-" + mois_discon + "-" + jour_discon + "', '" + stock + "');";
                                connection = createDB(user, mdp);
                                 command = new MySqlCommand(query, connection);
                                try
                                {
                                    command.ExecuteNonQuery();
                                    Console.WriteLine("bicyclette créée avec succès.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                break;
                            case 6: //suppression de bicyclette
                                requete = "SELECT * from modele_bicyclette;";
                                Console.Clear();
                                titre = "Référence produit     Nom                   Grandeur              Prix unitaire         Ligne de production   Date d'intro          Date de discon         stock\n\n";
                                ExecuteRequete(connection, requete, 6, titre, true);
                                connection.Close();
                                connection = createDB(user, mdp);
                                Console.WriteLine("\nQuelle bicyclette voulez-vous supprimer ? rentrez la référence (si vous voulez annuler écrire une chaine plus de 5 caractères)", 0, titre);
                                supp = Console.ReadLine();
                                try
                                {
                                    if (supp.Length < 6)
                                    {
                                        string supprequete = $"DELETE FROM contient WHERE num_prod_by = " + supp + "; DELETE FROM est_composee WHERE num_prod_by = " + supp + "; DELETE FROM modele_bicyclette WHERE num_prod_by = " + supp + ";"; 
                                        command = new MySqlCommand(supprequete, connection);
                                        command.ExecuteNonQuery();
                                        Console.ReadKey();
                                        connection.Close();
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERREUR : référence trop longue");
                                        Console.ReadKey();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Aucun tuple n'a été supprimé");
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                break;
                            case 7: //quitter
                                continuerproduit = false;
                                break;
                        }
                        break;
                }
            }
        }

        static void MenuCommande(string user, string mdp) //menu lié aux commandes
        {
            bool continuercommande = true;
            int choixIndex = 0;
            string[] optionsMenucommande = { "Liste des Commandes", "Ajouter une commande","Suppression commande","Mettre à jour une commande", "Quitter" };

            while (continuercommande)
            {
                Console.Clear();
                AfficherMenuCommande(optionsMenucommande, choixIndex);
                ConsoleKeyInfo touche = Console.ReadKey();
                MySqlConnection connection = createDB(user, mdp);
                string requete;
                switch (touche.Key)
                {
                    case ConsoleKey.UpArrow:
                        choixIndex = Math.Max(0, choixIndex - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        choixIndex = Math.Min(optionsMenucommande.Length - 1, choixIndex + 1);
                        break;
                    case ConsoleKey.Enter:
                        switch (choixIndex)
                        {
                            case 0: //liste des commandes
                                requete = "SELECT * from commandes;";
                                Console.Clear();
                                string titre = "Numéro de commande          Adresse de livraison        Date de livraison           Quantité                    ID magasin\n\n";
                                ExecuteRequete(connection, requete,0,titre,true);
                                connection.Close();
                                break;
                            case 1: //ajout de commande
                                Console.WriteLine("Veuillez entrer un numéro unique pour la commande");
                                string num_unique = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer une adresse de livraison");
                                string adresse_livraison = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer une date de livraison année-mois-jour");
                                string date_livraison = Console.ReadLine();

                                Console.WriteLine("Vueillez entrer la quantité de l'item");
                                string quantite_item = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer l'ID du magasin dans lequel la commande a été passé");
                                string ID_Magasin = Console.ReadLine();

                                string query = $"INSERT INTO commandes VALUES ('" + num_unique + "', \'" + adresse_livraison + "\', \'" + date_livraison + "\', \'" + quantite_item + "\', \'" + ID_Magasin + "\')";
                                connection = createDB(user, mdp);
                                MySqlCommand command = new MySqlCommand(query, connection);
                                try
                                {
                                    command.ExecuteNonQuery();
                                    Console.WriteLine("commande créée avec succès.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                break;
                            case 2: //supprimer une commande
                                requete = "SELECT * from commandes;";
                                Console.Clear();
                                titre = "Numéro de commande          Adresse de livraison        Date de livraison           Quantité                    ID magasin\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                connection = createDB(user, mdp);
                                Console.WriteLine("\nQuelle commande voulez-vous supprimer ? rentrez la référence (si vous voulez annuler écrire une chaine plus de 5 caractères)", 0, titre);
                                string supp = Console.ReadLine();
                                try
                                {
                                    if (supp.Length < 6)
                                    {
                                        string supprequete = $"DELETE FROM Passe WHERE num_unique = " + supp + "; DELETE FROM Est_Composee WHERE num_unique = " + supp + "; DELETE FROM prepare WHERE num_unique = " + supp + "; DELETE FROM Commandes WHERE num_unique =" + supp + ";";
                                         command = new MySqlCommand(supprequete, connection);
                                        command.ExecuteNonQuery();
                                        Console.ReadKey();
                                        connection.Close();
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERREUR : référence trop longue");
                                        Console.ReadKey();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Aucun tuple n'a été supprimé");
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                break;
                            case 3: // modifier une commande
                                requete = "SELECT * from commandes;";
                                Console.Clear();
                                titre = "Numéro de commande          Adresse de livraison        Date de livraison           Quantité                    ID magasin\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                connection = createDB(user, mdp);
                                Console.WriteLine("\nQuel fournisseur voulez-vous modifier ?");
                                string choix = Console.ReadLine();
                                requete = "SELECT * from commandes where num_unique = " + choix + ";";
                                Console.Clear();
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();

                                Console.WriteLine("Veuillez entrer une adresse de livraison");
                                 adresse_livraison = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer une date de livraison année-mois-jour");
                                 date_livraison = Console.ReadLine();

                                Console.WriteLine("Vueillez entrer la quantité de l'item");
                                 quantite_item = Console.ReadLine();

                                Console.WriteLine("Veuillez entrer l'ID du magasin dans lequel la commande a été passé");
                                 ID_Magasin = Console.ReadLine();
                                connection = createDB(user, mdp);
                                try
                                {
                                    string supprequete = $"UPDATE commandes SET adresse_livraison = '" + adresse_livraison + "', date_livraison = '" + date_livraison + "', quantite_item = '" + quantite_item + "', ID_Magasin='" + ID_Magasin + "' Where num_unique = '" + choix + "';";
                                    command = new MySqlCommand(supprequete, connection);
                                    command.ExecuteNonQuery();
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Aucune modification n'a été effectué");
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                break;
                            case 4: //quitter
                                continuercommande = false;
                                break;
                        }
                        break;
                }
            }
        }

        static void MenuStats(string user, string mdp) //menu requêtes statistiques
        {
            bool continuerstats = true;
            int choixIndex = 0;
            string[] optionsMenustats = { "Pièces vendus par magasin", "Pièces vendus par vendeur", "Listes des membres par programme", "Moyenne du montant des commandes", "Moyenne du nombre de pièce par commande","Moyenne de nombre de vélo par commande","Quitter" };

            while (continuerstats)
            {
                string titre = "";
                Console.Clear();
                AfficherMenuStat(optionsMenustats, choixIndex);
                ConsoleKeyInfo touche = Console.ReadKey();
                MySqlConnection connection = createDB(user, mdp);
                string requete;
                switch (touche.Key)
                {
                    case ConsoleKey.UpArrow:
                        choixIndex = Math.Max(0, choixIndex - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        choixIndex = Math.Min(optionsMenustats.Length - 1, choixIndex + 1);
                        break;
                    case ConsoleKey.Enter:
                        switch (choixIndex)
                        {
                            case 0: //Pièces vendus par magasin
                                requete = "SELECT m.ID_Magasin, m.Nom_Magasin, p.Ref_produit, p.descrip AS Description_Produit, SUM(c.quantite_item) AS Quantite_Vendue FROM Commandes c INNER JOIN Magasins m ON c.ID_Magasin = m.ID_Magasin INNER JOIN contient ct ON c.ID_Magasin = ct.ID_Magasin INNER JOIN Pieces p ON ct.Ref_produit = p.Ref_produit GROUP BY m.ID_Magasin, m.Nom_Magasin, p.Ref_produit, p.descrip; ";
                                Console.Clear();
                                titre = "ID magasin                  Nom magasin                 Ref produit                 Description produit         Quantité vendue\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;
                            case 1: //Pièces vendus par vendeur
                                requete = "SELECT v.ID_Vendeur, p.Ref_produit, p.descrip AS Description_Produit, SUM(c.quantite_item) AS Quantite_Vendue FROM Commandes c INNER JOIN prepare pr ON c.num_unique = pr.num_unique INNER JOIN Vendeurs v ON pr.ID_Vendeur = v.ID_Vendeur INNER JOIN contient ct ON c.ID_Magasin = ct.ID_Magasin INNER JOIN Pieces p ON ct.Ref_produit = p.Ref_produit GROUP BY v.ID_Vendeur, p.Ref_produit, p.descrip ORDER BY v.ID_Vendeur; ";
                                Console.Clear();
                                titre = "ID vendeur                  Ref produit                 Description produit         Quantité vendue\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;
                            case 2: // Listes des membres par programme
                                requete = "SELECT i.nom_ind, i.prenom_ind, p.No_Programme FROM individus i, adhère a, prog_fidelio p WHERE i.ID_indiv = a.ID_indiv AND a.No_Programme = p.No_Programme; ";
                                Console.Clear();
                                titre = "Nom client                  Prénom client               Numéro programme (1 : Fidélio / 2 : Fidélio Argent / 3 : Fidélio Or / 4 : Fidélio Max)\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;
                            case 3: // Moyenne du montant des commandes
                                requete = "SELECT AVG(c.quantite_item * p.prix_unitaire_2) AS moyenne_montant_commande FROM commandes c JOIN est_composee ec ON c.num_unique = ec.num_unique JOIN pieces p ON ec.Ref_produit = p.Ref_produit; ";
                                Console.Clear();
                                Console.Write("Moyenne du montant des commandes : ");
                                ExecuteRequete(connection, requete);
                                connection.Close();
                                break;
                            case 4: //Moyenne du nombre de pièce par commande
                                requete = "SELECT AVG(c.quantite_item) AS moyenne_pieces_par_commande FROM commandes c; ";
                                Console.Clear();
                                Console.Write("Moyenne du nombre de pièce dans une commande : ");
                                ExecuteRequete(connection, requete);
                                connection.Close();
                                break;
                            case 5: //Moyenne de nombre de vélo par commande
                                requete = "SELECT AVG(c.quantite_item) FROM commandes c JOIN est_composee ec ON c.num_unique = ec.num_unique JOIN modele_bicyclette mb ON ec.num_prod_by = mb.num_prod_by; ";
                                Console.Clear();
                                Console.Write("Moyenne du nombre de vélo dans une commande : ");
                                ExecuteRequete(connection, requete);
                                connection.Close();
                                break;
                            case 6: //quitter
                                continuerstats = false;
                                break;
                        }
                        break;
                }
            }
        }

        static void MenuFournisseur(string user, string mdp) //menu fournisseur
        {
            bool continuerfournisseur = true;
            int choixIndex = 0;
            string[] optionsMenufournisseur = { "Liste des Fournisseurs", "Création d'un fournisseur", "Suppression d'un fournisseur","Mettre à jour un fournisseur","Quitter" };

            while (continuerfournisseur)
            {
                Console.Clear();
                AfficherMenuFournisseur(optionsMenufournisseur, choixIndex);
                ConsoleKeyInfo touche = Console.ReadKey();
                MySqlConnection connection = createDB(user, mdp);
                string requete;
                switch (touche.Key)
                {
                    case ConsoleKey.UpArrow:
                        choixIndex = Math.Max(0, choixIndex - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        choixIndex = Math.Min(optionsMenufournisseur.Length - 1, choixIndex + 1);
                        break;
                    case ConsoleKey.Enter:
                        switch (choixIndex)
                        {
                            case 0: //liste des fournisseurs
                                requete = "SELECT * from fournisseurs;";
                                Console.Clear();
                                string titre = "Siret                       Nom de fournisseur          Responsable                 Adresse                     libelle\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;
                            case 1: // ajout d'un fournisseur
                                Console.WriteLine("Donnez un numéro de siret : ");
                                string siret= Console.ReadLine();
                                Console.WriteLine("Donnez un nom de fournisseur : ");
                                string nom= Console.ReadLine();
                                Console.WriteLine("Donnez un nom et un prénom de responsable : ");
                                string respo= Console.ReadLine();
                                Console.WriteLine("Donnez une adresse de fournisseur : ");
                                string adresse= Console.ReadLine();
                                Console.WriteLine("Donnez le libelle de satisfaction : ");
                                string libelle= Console.ReadLine();
                                string query = $"INSERT INTO fournisseurs VALUES ('" + siret + "', \'" + nom + "\', \'" + respo + "\', \'" + adresse + "\', \'" + libelle + "\')";
                                connection = createDB(user, mdp);
                                MySqlCommand command = new MySqlCommand(query, connection);
                                try
                                {
                                    command.ExecuteNonQuery();
                                    Console.WriteLine("fournisseur créé avec succès.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }



                                break;
                            case 2: //suppression d'un fournisseur
                                requete = "SELECT * from fournisseurs;";
                                Console.Clear();
                                titre = "Siret                       Nom de fournisseur          Responsable                 Adresse                     libelle\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                connection = createDB(user, mdp);
                                Console.WriteLine("\nQuel fournisseur voulez-vous supprimer ? rentrez la référence (si vous voulez annuler écrire une chaine plus de 15 caractères)", 0, titre);
                                string supp = Console.ReadLine();
                                try
                                {
                                    if (supp.Length < 16)
                                    {
                                        string supprequete = $"DELETE FROM fournit WHERE Siret = " + supp + "; DELETE FROM fournisseurs WHERE Siret = " + supp + ";";
                                        command = new MySqlCommand(supprequete, connection);
                                        command.ExecuteNonQuery();
                                        Console.ReadKey();
                                        connection.Close();
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERREUR : référence trop longue");
                                        Console.ReadKey();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Aucun tuple n'a été supprimé");
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                break;
                            case 3: //modifier un fournisseurs
                                requete = "SELECT * from fournisseurs;";
                                Console.Clear();
                                titre = "Siret                       Nom de fournisseur          Responsable                 Adresse                     libelle\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                connection = createDB(user, mdp);
                                Console.WriteLine("\nQuel fournisseur voulez-vous modifier ?");
                                string choix = Console.ReadLine();
                                requete = "SELECT * from fournisseurs where siret = " + choix + ";";
                                Console.Clear();
                                titre = "Siret                       Nom de fournisseur          Responsable                 Adresse                     libelle\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                Console.WriteLine("Donnez un nom de fournisseur : ");
                                 nom = Console.ReadLine();
                                Console.WriteLine("Donnez un nom et un prénom de responsable : ");
                                 respo = Console.ReadLine();
                                Console.WriteLine("Donnez une adresse de fournisseur : ");
                                 adresse = Console.ReadLine();
                                Console.WriteLine("Donnez le libelle de satisfaction : ");
                                 libelle = Console.ReadLine();
                                connection = createDB(user, mdp);
                                try
                                {
                                    string supprequete = $"UPDATE fournisseurs SET nom_d_entreprise = '" + nom + "', contact = '" + respo + "', adresse = '" + adresse + "', libelle='" + libelle + "' Where siret = '" + choix + "';"; 
                                    command = new MySqlCommand(supprequete, connection);
                                    command.ExecuteNonQuery();
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Aucune modification n'a été effectué");
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                break; 
                            case 4: //quitter
                                continuerfournisseur = false;
                                break;
                        }
                        break;
                }
            }
        }

        static void MenuVendeur(string user, string mdp) //menu vendeur
        {
            bool continuervendeur = true;
            int choixIndex = 0;
            string[] optionsMenuvendeur = { "Liste des vendeurs", "Ajouter un vendeur","Supprimer un vendeur","Mettre à jour un vendeur", "Quitter" };

            while (continuervendeur)
            {
                Console.Clear();
                AfficherMenuVendeur(optionsMenuvendeur, choixIndex);
                ConsoleKeyInfo touche = Console.ReadKey();
                MySqlConnection connection = createDB(user, mdp);
                string requete;
                switch (touche.Key)
                {
                    case ConsoleKey.UpArrow:
                        choixIndex = Math.Max(0, choixIndex - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        choixIndex = Math.Min(optionsMenuvendeur.Length - 1, choixIndex + 1);
                        break;
                    case ConsoleKey.Enter:
                        switch (choixIndex)
                        {
                            case 0: //liste des vendeurs
                                requete = "SELECT * from Vendeurs;";
                                Console.Clear();
                                string titre = "ID_Vendeur                  Type de contrat             Salaire                     Prime                       ID_Magasin\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;
                            case 1: //ajout de vendeur
                                Console.Clear();
                                Console.WriteLine("Donnez le numéro de vendeur : ");
                                string id_vendeur = Console.ReadLine();
                                Console.WriteLine("Donnez le type de contrat : ");
                                string typec = Console.ReadLine();
                                Console.WriteLine("Donnez le salaire : ");
                                string salaire = Console.ReadLine();
                                Console.WriteLine("Donnez la prime : ");
                                string prime = Console.ReadLine();
                                Console.WriteLine("Donnez l'identifiant du magasin : ");
                                string idmag = Console.ReadLine();
                                string query = $"INSERT INTO vendeurs VALUES ('" + id_vendeur + "', \'" + typec + "\', \'" + salaire + "\', \'" + prime + "\', \'" + idmag + "\')";
                                connection = createDB(user, mdp);
                                MySqlCommand command = new MySqlCommand(query, connection);
                                try
                                {
                                    command.ExecuteNonQuery();
                                    Console.WriteLine("vendeur créé avec succès.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }

                                break;
                            case 2: //suppression de vendeur
                                requete = "SELECT * from Vendeurs;";
                                Console.Clear();
                                titre = "ID_Vendeur                  Type de contrat             Salaire                     Prime                       ID_Magasin\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                connection = createDB(user, mdp);
                                Console.WriteLine("\nQuel vendeur voulez-vous supprimer ? rentrez la référence (si vous voulez annuler écrire une chaine plus de 5 caractères)", 0, titre);
                                string supp = Console.ReadLine();
                                try
                                {
                                    if (supp.Length < 6)
                                    {
                                        string supprequete = $"DELETE FROM prepare WHERE ID_Vendeur = "+supp+ "; DELETE FROM vendeurs WHERE ID_Vendeur = " + supp + ";"; 
                                        command = new MySqlCommand(supprequete, connection);
                                        command.ExecuteNonQuery();
                                        Console.ReadKey();
                                        connection.Close();
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERREUR : référence trop longue");
                                        Console.ReadKey();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Aucun tuple n'a été supprimé");
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                break;
                            case 3: // modification de vendeur
                                requete = "SELECT * from Vendeurs;";
                                Console.Clear();
                                 titre = "ID_Vendeur                  Type de contrat             Salaire                     Prime                       ID_Magasin\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                connection = createDB(user, mdp);
                                Console.WriteLine("\nQuel fournisseur voulez-vous modifier ?");
                                string choix = Console.ReadLine();
                                requete = "SELECT * from vendeurs where id_vendeur = " + choix + ";";
                                Console.Clear();
                                titre = "ID_Vendeur                  Type de contrat             Salaire                     Prime                       ID_Magasin\n\n";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                Console.WriteLine("Donnez le type de contrat : ");
                                 typec = Console.ReadLine();
                                Console.WriteLine("Donnez le salaire : ");
                                 salaire = Console.ReadLine();
                                Console.WriteLine("Donnez la prime : ");
                                 prime = Console.ReadLine();
                                Console.WriteLine("Donnez l'identifiant du magasin : ");
                                 idmag = Console.ReadLine();

                                connection = createDB(user, mdp);
                                try
                                {
                                    string supprequete = $"UPDATE vendeurs SET type_contrat = '" + typec + "', salaire = '" + salaire + "', prime = '" + prime + "', id_magasin='" + idmag + "' Where id_vendeur = '" + choix + "';";
                                    command = new MySqlCommand(supprequete, connection);
                                    command.ExecuteNonQuery();
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Aucune modification n'a été effectué");
                                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                                    Console.ReadKey();
                                    connection.Close();
                                }
                                break;
                            case 4:// quitter
                                continuervendeur = false;
                                break;
                        }
                        break;
                }
            }
        }

        static void MenuAutres(string user, string mdp) //menu autre 
        {
            bool continuerautre = true;
            int choixIndex = 0;
            string[] optionsMenuautre = { "Noms des clients et cumul des commandes en euros", "Liste des produits ayant un stock <=2 ", "Nombre de pièces par fournisseur","Nombre de vélos par fournisseur","Chiffre d'affaires par magasin","Ventes générées par vendeur","Trouver des individus qui on passé une commande et on un programme de fidélité (commande synchronisée)","Clients qu'ils soient des individus ou entreprises (commande avec union)","Vendeurs travaillant dans le même magasin mais pas dans les mêmes conditions salariales (auto jointure)","Quitter" };
            string titre;
            while (continuerautre)
            {
                AfficherMenuAutre(optionsMenuautre, choixIndex);
                ConsoleKeyInfo touche = Console.ReadKey();
                MySqlConnection connection = createDB(user, mdp);
                string requete;
                switch (touche.Key)
                {

                    case ConsoleKey.UpArrow:
                        choixIndex = Math.Max(0, choixIndex - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        choixIndex = Math.Min(optionsMenuautre.Length - 1, choixIndex + 1);
                        break;
                    case ConsoleKey.Enter:
                        switch (choixIndex)
                        {
                            case 0: //Noms des clients et cumul des commandes en euros
                                Console.Clear();
                                titre = "Noms des clients            cumul des commandes (en euros)  \n\n";
                                requete = "SELECT i.nom_ind, i.prenom_ind, SUM(pc.prix_unitaire_2 * c.quantite_item) AS benefice FROM individus i JOIN passe p ON i.ID_indiv = p.ID_indiv JOIN commandes c ON p.num_unique = c.num_unique JOIN est_composee ec ON c.num_unique = ec.num_unique JOIN pieces pc ON ec.Ref_produit = pc.Ref_produit GROUP BY i.nom_ind, i.prenom_ind; ";
                                ExecuteRequete(connection, requete,0,titre,true);
                                connection.Close();
                                break;
                            case 1: //Liste des produits ayant un stock <=2
                                Console.Clear();
                                titre = "Noms des produits ayant un stock <=2  \n\n";
                                requete = "SELECT Ref_produit, descrip, stock FROM Pieces WHERE stock <= 2; ";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;
                            case 2: //Nombre de pièces par fournisseur
                                Console.Clear();
                                titre = "Noms des fournisseurs       Nombre de pièces\n\n";
                                requete = "SELECT f.nom_d_entreprise AS 'nom entreprise', COUNT(p.Ref_produit) AS 'nb pieces' FROM Fournisseurs f LEFT JOIN Fournit fo ON f.Siret = fo.Siret LEFT JOIN Pieces p ON fo.Ref_produit = p.Ref_produit GROUP BY f.Siret, f.nom_d_entreprise; ";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;
                            case 3: // Nombre de vélos par fournisseur
                                Console.Clear();
                                titre = "Noms des fournisseurs       Nombre de vélos\n\n";
                                requete = "SELECT f.nom_d_entreprise, COUNT(DISTINCT c.Ref_produit) AS 'nombre de vélos' FROM Fournisseurs f INNER JOIN Fournit fo ON f.Siret = fo.Siret INNER JOIN contient c ON fo.Ref_produit = c.Ref_produit GROUP BY f.Siret, f.nom_d_entreprise; ";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;
                            case 4: //Chiffre d'affaires par magasin 
                                Console.Clear();
                                titre = "ID Magasin                  Nom Magasin                 Chiffre d'affaire (en euro)\n\n";
                                requete = "SELECT m.ID_Magasin, m.Nom_Magasin, SUM(prix_unitaire_2 * quantite_item) AS chiffre_d_affaire_généré FROM Magasins m JOIN Commandes c ON m.ID_Magasin = c.ID_Magasin JOIN est_composee ec ON c.num_unique = ec.num_unique JOIN Pieces p ON ec.Ref_produit = p.Ref_produit GROUP BY m.ID_Magasin, m.Nom_Magasin; ";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;

                            case 5: //Ventes générées par vendeur
                                Console.Clear();
                                titre = "ID Vendeur                  Ventes générées\n\n";
                                requete = "SELECT v.ID_Vendeur, COUNT(DISTINCT c.num_unique) FROM Vendeurs v JOIN prepare pr ON v.ID_Vendeur = pr.ID_Vendeur JOIN Commandes c ON pr.num_unique = c.num_unique GROUP BY v.ID_Vendeur; ";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;
                            case 6: //Trouver des individus qui on passé une commande et on un programme de fidélité (commande synchronisée)
                                Console.Clear();
                                titre = "Trouver des individus qui on passé une commande et on un programme de fidélité(commande synchronisée)\n\n";
                                requete = "SELECT p.date_comm AS 'date de commande', p.ID_bs AS 'ID boutique', p.num_unique AS 'num commande', p.ID_indiv FROM passe p INNER JOIN adhère a ON p.ID_indiv = a.ID_indiv INNER JOIN Commandes c ON p.num_unique = c.num_unique;";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;
                            case 7: //Clients qu'ils soient des individus ou entreprises (commande avec union)
                                Console.Clear();
                                titre = "Clients qu'ils soient des individus ou entreprises (commande avec union)\n\n";
                                requete = "SELECT prenom_ind AS 'Prenom ou nom de boutique', nom_ind FROM individus UNION SELECT nom_boutique, NULL FROM Boutiques_specialises;";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;
                            case 8: //Vendeurs travaillant dans le même magasin mais pas dans les mêmes conditions salariales (auto jointure)
                                Console.Clear();
                                titre = "Vendeurs travaillant dans le même magasin mais pas dans les mêmes conditions salariales (auto jointure) \n\n";
                                requete = "SELECT  v1.ID_Magasin AS 'ID Magasin ', v1.ID_Vendeur AS 'ID Vendeur 1',  v1.type_contrat AS 'type ontrat 1',  v1.salaire AS 'salaire 1',  v1.prime AS 'prime 1', v2.ID_Vendeur AS 'ID Vendeur 2',  v2.type_contrat AS 'type contrat 2',  v2.salaire AS 'salaire 2',  v2.prime AS 'prime 2' FROM  Vendeurs v1 JOIN  Vendeurs v2 ON v1.ID_Magasin = v2.ID_Magasin AND v1.ID_Vendeur != v2.ID_Vendeur;";
                                ExecuteRequete(connection, requete, 0, titre, true);
                                connection.Close();
                                break;
                            case 9: //quitter
                                continuerautre = false;
                                break;
                        }
                        break;
                }
            }
        }

        static void ModeDemo(string user, string mdp)
        {

            //Création de client
            MySqlConnection connection = createDB(user, mdp);
            int numC = 1;
            Console.Clear();
            Console.WriteLine("Création de client");
            Console.WriteLine("Donner le nom du client :");
            string nom = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Donner le prénom du client :");
            string prenom = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Donner l'adresse du client :");
            string adresse = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Donner le numéro de téléphone du client :");
            string numero = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Donner l'adresse mail du client :");
            string mail = Console.ReadLine();
            Console.Clear();
            try
            {
                MySqlCommand command2 = connection.CreateCommand();
                command2.CommandText = "SELECT ID_indiv FROM individus;";

                MySqlDataReader reader;
                reader = command2.ExecuteReader();

                string[] ret = new string[reader.FieldCount];
                List<string> mylist = new List<string>();

                while (reader.Read())
                {
                    if (numC == (int)reader.GetValue(0))
                    {
                        numC++;
                    }
                }

                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite lors de l'exécution de la requête : " + ex.Message);
                Console.ReadKey();
                connection.Close();
            }

            connection.Close();
            connection = createDB(user, mdp);
            string query = $"INSERT INTO individus VALUES (" + numC.ToString() + ", \'" + nom + "\', \'" + prenom + "\', \'" + adresse + "\', \'" + numero + "\', \'" + mail + "\')";
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Tuples créés avec succès.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                Console.ReadKey();
                connection.Close();
            }

            connection.Close();
            connection = createDB(user, mdp);


            //Modification de client
            connection = createDB(user, mdp);
            string requete = "SELECT * from individus;";
            Console.Clear();
            Console.WriteLine("Modification de client");
            string titre = "Numéro client               Nom                         Prénom                      Adresse                     Numéro                      Mail\n\n";
            ExecuteRequete(connection, requete, 0, titre, true);
            connection.Close();
            connection = createDB(user, mdp);
            Console.WriteLine("\nQuel client voulez-vous modifier ?");
            string choix = Console.ReadLine();
            requete = "SELECT * from individus where ID_indiv = " + choix + ";";
            Console.Clear();
            titre = "Numéro client               Nom                         Prénom                      Adresse                     Numéro                      Mail\n\n";
            ExecuteRequete(connection, requete, 0, titre, true);
            connection.Close();
            Console.WriteLine("Quel nom voulez-vous donner au client ? ");
            nom = Console.ReadLine();
            Console.WriteLine("Quel prénom voulez-vous donner au client ? ");
            prenom = Console.ReadLine();
            Console.WriteLine("Quelle adresse voulez-vous donner au client ? ");
            adresse = Console.ReadLine();
            Console.WriteLine("Quel numéro voulez-vous donner au client ? ");
            numero = Console.ReadLine();
            Console.WriteLine("Quel mail voulez-vous donner au client ? ");
            mail = Console.ReadLine();
            connection = createDB(user, mdp);
            try
            {
                string supprequete = $"UPDATE individus SET nom_ind = '" + nom + "', prenom_ind = '" + prenom + "', adresse_ind = '" + adresse + "', tel_ind='" + numero + "', courriel_ind = '" + mail + "' Where ID_Indiv = '" + choix + "';"; //j'en étais là
                command = new MySqlCommand(supprequete, connection);
                command.ExecuteNonQuery();
                Console.ReadKey();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Aucune modification n'a été effectué");
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                Console.ReadKey();
                connection.Close();
            }


            //Suppression de client
            connection = createDB(user, mdp);

            requete = "SELECT * from individus;";
            Console.Clear();
            Console.WriteLine("Suppression de client");
            titre = "Numéro client               Nom                         Prénom                      Adresse                     Numéro                      Mail\n\n";
            ExecuteRequete(connection, requete, 0, titre, true);
            connection.Close();
            connection = createDB(user, mdp);
            Console.WriteLine("\nQuel client voulez-vous supprimer ? rentrez le numéro (si vous voulez annuler écrire une lettre)", 0, titre);
            string supp = Console.ReadLine();
            try
            {
                supp = Convert.ToInt32(supp).ToString();
                string supprequete = $"DELETE FROM passe WHERE ID_indiv = " + supp + "; DELETE FROM adhère WHERE ID_indiv = " + supp + "; DELETE FROM prepare WHERE ID_Vendeur IN(SELECT ID_Vendeur FROM Vendeurs WHERE ID_Magasin IN (SELECT ID_Magasin FROM Magasins WHERE ID_Magasin IN (SELECT ID_Magasin FROM passe WHERE ID_indiv = " + supp + ")));DELETE FROM individus WHERE ID_indiv = " + supp + "; ";
                command = new MySqlCommand(supprequete, connection);
                command.ExecuteNonQuery();
                Console.ReadKey();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Aucun tuple n'a été supprimé");
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
                Console.ReadKey();
                connection.Close();
            }


            //Nombre de client
            connection = createDB(user, mdp);
            requete = "SELECT count(*) from individus;";
            Console.Clear();
            Console.Write("Nombre de Client : ");
            ExecuteRequete(connection, requete);
            connection.Close();


            //Noms des clients avec le cumul de toutes ses commandes en euros
            connection = createDB(user, mdp);
            Console.Clear();
            Console.WriteLine("Noms des clients avec le cumul de toutes ses commandes en euros");
            titre = "Noms des clients            cumul des commandes (en euros)  \n\n";
            requete = "SELECT i.nom_ind, i.prenom_ind, SUM(pc.prix_unitaire_2 * c.quantite_item) AS benefice FROM individus i JOIN passe p ON i.ID_indiv = p.ID_indiv JOIN commandes c ON p.num_unique = c.num_unique JOIN est_composee ec ON c.num_unique = ec.num_unique JOIN pieces pc ON ec.Ref_produit = pc.Ref_produit GROUP BY i.nom_ind, i.prenom_ind; ";
            ExecuteRequete(connection, requete, 0, titre, true);
            connection.Close();


            //liste des pièces ayant une quantité en stock <=2
            connection = createDB(user, mdp);
            Console.Clear();
            Console.WriteLine("liste des pièces ayant une quantité en stock <=2");
            titre = "Noms des produits ayant un stock <=2  \n\n";
            requete = "SELECT Ref_produit, descrip, stock FROM Pieces WHERE stock <= 2; ";
            ExecuteRequete(connection, requete, 0, titre, true);
            connection.Close();


            //liste des bicyclettes ayant une quantité en stock <=2
            connection = createDB(user, mdp);
            Console.Clear();
            Console.WriteLine("liste des bicyclettes ayant une quantité en stock <=2");
            titre = "Noms des bicyclettes ayant un stock <=2  \n\n";
            requete = "SELECT num_prod_by, nom, stock_bicy FROM modele_bicyclette WHERE stock_bicy <= 2; ";
            ExecuteRequete(connection, requete, 0, titre, true);
            connection.Close();


            //Nombre de pièces par fournisseur
            connection = createDB(user, mdp);
            Console.Clear();
            Console.WriteLine("Nombre de pièces par fournisseur");
            titre = "Noms des fournisseurs       Nombre de pièces\n\n";
            requete = "SELECT f.nom_d_entreprise AS 'nom entreprise', COUNT(p.Ref_produit) AS 'nb pieces' FROM Fournisseurs f LEFT JOIN Fournit fo ON f.Siret = fo.Siret LEFT JOIN Pieces p ON fo.Ref_produit = p.Ref_produit GROUP BY f.Siret, f.nom_d_entreprise; ";
            ExecuteRequete(connection, requete, 0, titre, true);
            connection.Close();


            //Nombre de bicyclette par fournisseur 
            connection = createDB(user, mdp);
            Console.Clear();
            Console.WriteLine("Nombre de bicyclette par fournisseur");
            titre = "Noms des fournisseurs       Nombre de vélos\n\n";
            requete = "SELECT f.nom_d_entreprise, COUNT(DISTINCT c.Ref_produit) AS 'nombre de vélos' FROM Fournisseurs f INNER JOIN Fournit fo ON f.Siret = fo.Siret INNER JOIN contient c ON fo.Ref_produit = c.Ref_produit GROUP BY f.Siret, f.nom_d_entreprise; ";
            ExecuteRequete(connection, requete, 0, titre, true);
            connection.Close();


            //CA par magasin
            connection = createDB(user, mdp);
            Console.Clear();
            Console.WriteLine("CA par magasin");
            titre = "ID Magasin                  Nom Magasin                 Chiffre d'affaire (en euro)\n\n";
            requete = "SELECT m.ID_Magasin, m.Nom_Magasin, SUM(prix_unitaire_2 * quantite_item) AS chiffre_d_affaire_généré FROM Magasins m JOIN Commandes c ON m.ID_Magasin = c.ID_Magasin JOIN est_composee ec ON c.num_unique = ec.num_unique JOIN Pieces p ON ec.Ref_produit = p.Ref_produit GROUP BY m.ID_Magasin, m.Nom_Magasin; ";
            ExecuteRequete(connection, requete, 0, titre, true);
            connection.Close();


            //ventes par vendeur
            connection = createDB(user, mdp);
            Console.Clear();
            Console.WriteLine("Ventes par vendeur");
            titre = "ID Vendeur                  Ventes générées\n\n";
            requete = "SELECT v.ID_Vendeur, COUNT(DISTINCT c.num_unique) FROM Vendeurs v JOIN prepare pr ON v.ID_Vendeur = pr.ID_Vendeur JOIN Commandes c ON pr.num_unique = c.num_unique GROUP BY v.ID_Vendeur; ";
            ExecuteRequete(connection, requete, 0, titre, true);
            connection.Close();


        }

        #endregion

        //GESTION DE CONNEXION AVEC LA DATABASE SQL ET METHODE PRINCIPAL D'AFFCHAGE
        #region SQL Code

        public static MySqlConnection createDB(string user, string passW)
        {
            string myConnectionString;
            myConnectionString = "SERVER=localhost;port=3306;" +
                                 "DATABASE=VeloMax;" +
                                 "UID=" + user + ";PASSWORD=" + passW + ";";
            MySqlConnection connection = new MySqlConnection(myConnectionString);
            connection.Open();
           
            return connection;
        }

        public static void ExecuteRequete(MySqlConnection connection, string requete,int moins=0,string titre="",bool wantpage=false) //se connecte et affiche les requêtes
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = requete;

                MySqlDataReader reader;
                reader = command.ExecuteReader();

                string[] ret = new string[reader.FieldCount];
                List<string> mylist = new List<string>();
                bool pass = true;
                int count = 0;
                int page = 1;
                bool ispage = false; 
                Console.Write(titre);
                while (reader.Read())
                {
                    if (count < 10) // affiche les lignes 10 par 10 pour ne pas surcharger la console
                    {
                        
                        string currentRowAsString = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            currentRowAsString += reader.GetValue(i).ToString();
                            int nbr = 0;
                            for (int j = 28 - reader.GetValue(i).ToString().Length - moins; j > 0; j--)
                            {

                                currentRowAsString += " ";
                                nbr++;

                            }
                        }

                        count++;
                        Console.WriteLine(currentRowAsString + "\n"); //afficharge d'une ligne
                        mylist.Add(currentRowAsString);
                        if (count == 10 && wantpage)
                        {
                            Console.WriteLine("P." + page);
                            ispage = true;
                        }
                    }

                    else
                    {

                        Console.ReadKey();
                        Console.Clear();
                        Console.Write(titre);
                        string currentRowAsString = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            currentRowAsString += reader.GetValue(i).ToString();
                            int nbr = 0;
                            for (int j = 28 - reader.GetValue(i).ToString().Length - moins; j > 0; j--)
                            {

                                currentRowAsString += " ";
                                nbr++;

                            }
                        }
                        Console.WriteLine(currentRowAsString + "\n");
                        mylist.Add(currentRowAsString);
                        page++;
                        count = 1;
                        ispage = false;
                    }
                    

                }
                if (!ispage && wantpage)
                {
                    Console.WriteLine("P." + page);
                }

                Console.ReadKey();

                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite lors de l'exécution de la requête : " + ex.Message);
                Console.ReadKey();
            }
            connection.Close();

        }

        #endregion

        //MENU DE CONNECTION ET PRINCIPALE APPELANT LA REGION "Menus code"
        #region Main
        static void Main(string[] args)
        {
            bool apresconnection = false;
            bool continuerconnection = true;
            string user="";
            string mdp="";
            int choixIndexco = 0;
            string[] optionsMenuconnection = { "root", "bozo", "Quitter" };
            MySqlConnection connection;
            while (continuerconnection) //boucle du menu connection
            {
                AfficherMenuConnexion(optionsMenuconnection, choixIndexco);
                ConsoleKeyInfo touche = Console.ReadKey();

                switch (touche.Key)
                {
                    case ConsoleKey.UpArrow:
                        choixIndexco = Math.Max(0, choixIndexco - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        choixIndexco = Math.Min(optionsMenuconnection.Length - 1, choixIndexco + 1);
                        break;
                    case ConsoleKey.Enter:
                        switch (choixIndexco)
                        {
                            case 0:
                                try //tentative de connexion à root
                                {
                                    Console.Clear();
                                    Console.Write("Identifiant : root\nMot de passe : ");
                                    user = "root";
                                    mdp = Console.ReadLine();
                                    connection = createDB(user, mdp);
                                    apresconnection = true;
                                    continuerconnection = false;
                                    connection.Close();
                                }
                                catch
                                {
                                    Console.WriteLine("Erreur connexion");
                                    Console.ReadKey();
                                }

                                break;
                            case 1:
                                try //tentative de connection à bozo
                                {
                                    Console.Clear();
                                    Console.Write("Identifiant : bozo\nMot de passe : ");
                                    user = "bozo";
                                    mdp = Console.ReadLine();
                                    connection = createDB(user, mdp);
                                    apresconnection = true;
                                    continuerconnection = false;
                                    connection.Close();
                                }
                                catch
                                {
                                    Console.WriteLine("Erreur connexion");
                                    Console.ReadKey();
                                }
                                
                                break;
                            case 2:
                                mdp = "";
                                user = "";
                                continuerconnection = false;
                                break;
                        }
                        break;
                }
            }
            if (apresconnection)
            {
                
                bool continuerprincipal = true;
                int choixIndex = 0;
                string[] optionsMenu = { "Menu Clients", "Menu Produits", "Menu Commandes", "Menu Fournisseur","Menu Vendeur","Menu Statistiques","Autres requêtes","Mode démo", "Quitter" };
                while (continuerprincipal) //boucle du menu principale
                {
                    AfficherMenuPrincipal(optionsMenu, choixIndex);
                    ConsoleKeyInfo touche = Console.ReadKey();

                    switch (touche.Key)
                    {
                        case ConsoleKey.UpArrow:
                            choixIndex = Math.Max(0, choixIndex - 1);
                            break;
                        case ConsoleKey.DownArrow:
                            choixIndex = Math.Min(optionsMenu.Length - 1, choixIndex + 1);
                            break;
                        case ConsoleKey.Enter:
                            switch (choixIndex)
                            {
                                case 0: //accès au menu client
                                    MenuClients(user, mdp);
                                    break;
                                case 1: //accès au menu produit
                                    MenuProduits(user, mdp);
                                    break;
                                case 2: //accès au menu commande
                                    MenuCommande(user, mdp);
                                    break;
                                case 3: //accès au menu fournisseur
                                    MenuFournisseur(user,mdp);
                                    break;
                                case 4: //accès au menu vendeur
                                    MenuVendeur(user, mdp);
                                    break;
                                case 5: //accès au menu stat
                                    MenuStats(user, mdp);
                                    break;
                                case 6: //accès au menu autre
                                    MenuAutres(user, mdp);
                                    break;
                                case 7: //accès au mode démo
                                    ModeDemo(user, mdp);
                                    break;
                                case 8: //quitter
                                    continuerprincipal = false;
                                    break;
                            }
                            break;
                    }
                }
            }

        }
        #endregion
    }
}
