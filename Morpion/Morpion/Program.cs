/**
 * Jeu du Morpion
 * Date 22/11/2019
 * Author : Baucheron Romain
 */

using System;

namespace Morpion
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] grille =
            {
                " -----------  ",
                "|   |   |   |",
                " -----------  ",
                "|   |   |   |",
                " -----------  ",
                "|   |   |   |",
                " -----------  "
            }; // Grille du morpion
            int x = 5; // Position abscisses du curseur

            // Affichage de la grille
            for (int k = 0; k < 7; k++)
            {
                Console.SetCursorPosition(10, x);
                Console.Write(grille[k]);
                x++;
            }

            // Déclaration
            int l = 0, c = 0, nbcoup = 0, joueur = 1;
            int[] positionl = new int[3] { 6, 8, 10 }; // Tableau pour enregistrer la position des lignes
            int[] positionc = new int[3] { 12, 16, 20 }; // Tableau pour enregistrer la position des colonnes
            bool gagne = false; // Variable qui permet de boucler tant qu'il n'y a pas de gagnant
            char[,] coups = new char[3, 3]; // Tableau à 2 dimenssions pour enregistrer les coups joué

            /*
            * Saisie ligne
            */
            static int ligne()
            {
                Console.SetCursorPosition(10, 16);
                Console.Write("Ligne = ");
                int l = int.Parse(Console.ReadKey().KeyChar.ToString());
                return l;
            }

            /*
             * Saisie colonne
             */
            static int colonne()
            {
                // Saisie de la colonne
                Console.SetCursorPosition(10, 15);
                Console.Write("Colonne = ");
                int c = int.Parse(Console.ReadKey().KeyChar.ToString());
                return c;
            }

            /*
             * N° du joueur
             */
            static void numj(int num)
            {
                Console.SetCursorPosition(0, 14);
                Console.Write("C'est au tour du joueur " + num);
            }

            /*
             * Effacer les choix du joueur précédent
             */
            static void erase()
            {
                Console.SetCursorPosition(19, 16);
                Console.Write("\b \b"); // Efface ligne
                Console.SetCursorPosition(21, 15);
                Console.Write("\b \b"); // Efface colonne
            }

            // Boucle sur les essais
            while (!gagne && nbcoup != 9)
            {
                if (joueur == 1)
                {
                    // Affichage tour du joueur 1
                    numj(1);
                    // Saisie de la ligne+colonne avec controle du joueur 1
                    do
                    {
                        c = colonne();
                        l = ligne();
                        // X à la position choisie
                        Console.SetCursorPosition(positionc[c - 1], positionl[l - 1]);
                        Console.Write("X");
                        // Sauvegarde du coup dans un tableau à 2 dimenssions
                        coups[c - 1, l - 1] = 'X';
                    } while (l > 3 || l < 1 || c > 3 || c < 1);
                    // Effacer la ligne du joueur 2
                    erase();
                    joueur++;
                    nbcoup++;
                }
                else
                {
                    // Affichage tour du joueur 2
                    numj(2);
                    // Saisie de la ligne+colonne avec controle du joueur 2
                    do
                    {
                        c = colonne();
                        l = ligne();
                        // X à la position choisie
                        Console.SetCursorPosition(positionc[c - 1], positionl[l - 1]);
                        Console.Write("O");
                        // Sauvegarde du coup dans un tableau à 2 dimenssions
                        coups[c - 1, l - 1] = 'O';
                    } while (l > 3 || l < 1 || c > 3 || c < 1);
                    // Effacer la ligne du joueur 1
                    erase();
                    joueur--;
                    nbcoup++;
                }

                // Recherche d'un gagnant
                if (
                    coups[0, 0] == 'X' && coups[0, 1] == 'X' && coups[0, 2] == 'X' ||
                    coups[1, 0] == 'X' && coups[1, 1] == 'X' && coups[1, 2] == 'X' ||
                    coups[2, 0] == 'X' && coups[2, 1] == 'X' && coups[2, 2] == 'X' ||
                    coups[0, 0] == 'X' && coups[1, 0] == 'X' && coups[2, 0] == 'X' ||
                    coups[0, 1] == 'X' && coups[1, 1] == 'X' && coups[2, 1] == 'X' ||
                    coups[0, 2] == 'X' && coups[1, 2] == 'X' && coups[2, 2] == 'X' ||
                    coups[0, 0] == 'X' && coups[1, 1] == 'X' && coups[2, 2] == 'X' ||
                    coups[2, 0] == 'X' && coups[1, 1] == 'X' && coups[0, 2] == 'X' ||
                    coups[0, 0] == 'O' && coups[0, 1] == 'O' && coups[0, 2] == 'O' ||
                    coups[1, 0] == 'O' && coups[1, 1] == 'O' && coups[1, 2] == 'O' ||
                    coups[2, 0] == 'O' && coups[2, 1] == 'O' && coups[2, 2] == 'O' ||
                    coups[0, 0] == 'O' && coups[1, 0] == 'O' && coups[2, 0] == 'O' ||
                    coups[0, 1] == 'O' && coups[1, 1] == 'O' && coups[2, 1] == 'O' ||
                    coups[0, 2] == 'O' && coups[1, 2] == 'O' && coups[2, 2] == 'O' ||
                    coups[0, 0] == 'O' && coups[1, 1] == 'O' && coups[2, 2] == 'O' ||
                    coups[2, 0] == 'O' && coups[1, 1] == 'O' && coups[0, 2] == 'O'
                    )
                {
                    gagne = true;
                }
            }

            // Affichage résultat final
            if (gagne)
            {
                if (joueur == 1)
                {
                    joueur = 2;
                }
                else
                {
                    joueur = 1;
                }
                Console.SetCursorPosition(10, 18);
                Console.Write("Le joueur " + joueur + " gagne la partie.");
            }
            else
            {
                Console.SetCursorPosition(10, 18);
                Console.Write("Égalité");
            }
            Console.ReadLine();
        }
    }
}
