﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeuxDuPendu;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServeurJeuDuPendu
{
    class ServeurTCP
    {
        //Attributs
        TcpListener lEcouteur;
        Mots lesMots;
        int nbrJoueurs;

        public ServeurTCP(string adresseIP, int noPort)
        {
            this.lEcouteur = new System.Net.Sockets.TcpListener
                    (IPAddress.Parse(adresseIP),noPort);
            this.nbrJoueurs = 0;
        }

        public void Demarrer()
        {
            lEcouteur.Start();
        }

        public void execBouclePrincipale()
        {
            while(true)
            {
                if (nbrJoueurs == 0)
                    Console.WriteLine("Attente de connexion...");
                TcpClient unClient = lEcouteur.AcceptTcpClient();

                //Un thread par client
                Thread threadPrClient = new Thread
                    (new ParameterizedThreadStart(GestionnaireClient));
                threadPrClient.Start();
            }
        }

        public void GestionnaireClient(object clientTCP)
        {
            //Connexion de joueur, donc un joueur de plus
            lock(this)
                nbrJoueurs++;

            TcpClient unClient = clientTCP as TcpClient;

            //Envoi du mot à trouver au client,
            //ou du message d'attente d'un autre client

            while(nbrJoueurs < 2)
            {
                Console.WriteLine("Attente d'un deuxième joueur...");
                Thread.Sleep(500);
            }

            bool finExec = false;
            while(!finExec)
            {
    
            }
        }
    }
}
