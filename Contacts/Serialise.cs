using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Contacts
{
    /// <summary>
    /// Classe S�rialise
    /// Permet de sauvegarder en binaire et r�cup�rer des objets
    /// </summary>
    public abstract class Serialise
    {
        /// <summary>
        /// S�rialisation
        /// </summary>
        /// <param name="fichier">nom du fichier de sauvegarde</param>
        /// <param name="objet">objet � s�rialiser</param>
        public static void Sauve(string fichier, Object objet)
        {
            // si le fichier existe, il faut le supprimer
            if (File.Exists(fichier))
            {
                File.Delete(fichier);
            }
            // cr�ation du flux pour l'�criture dans le fichier
            FileStream flux = new FileStream(fichier, FileMode.Create);
            // cr�ation d'un objet pour le formatage en binaire des informations
            BinaryFormatter fbinaire = new BinaryFormatter();
            // s�rialisation des objets de la collection
            fbinaire.Serialize(flux, objet);
            // fermeture du flux
            flux.Close();
        }

        /// <summary>
        /// D�s�rialisation
        /// </summary>
        /// <param name="fichier">nom du fichier de sauvegarde</param>
        /// <returns>objet d�s�rialis�</returns>
        public static Object Recup(string fichier)
        {
            // Contr�le de l'existance du fichier
            if (File.Exists(fichier))
            {
                // ouverture du flux pour la lecture dans le fichier
                FileStream flux = new FileStream(fichier, FileMode.Open);
                // cr�ation d'un objet pour le formatage en binaire des informations
                BinaryFormatter fbinaire = new BinaryFormatter();
                // r�cup�ration de l'objet s�rialis�
                try
                {
                    Object objet = fbinaire.Deserialize(flux);
                    // fermeture du flux
                    flux.Close();
                    // retour de l'objet
                    return objet;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
