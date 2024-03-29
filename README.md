# Description

Alfred est un logiciel conçu pour les développeurs. Il est conçu pour apporter aux développeurs leurs projets tout préparé, simplifiant ainsi chaque étape de la conception à l'exécution. Ce projet à vu le jour à l'occasion du cursus "Développement  
 Logiciel Avancé". 
 
# Tables des matières

1. [Prérequis](#prérequis) 
2. [Installation](#installation)
3. [Auteurs](#auteurs)

# Prérequis

Pour ce projet vous aurez besoin :
* Dernière version de Docker installée sur votre ordinateur. (https://www.docker.com).

# Installation

Réalisez un git pull du projet dans le dossier de votre choix puis ouvrez le projet avec votre IDE préféré.

Depuis un un cmd ou PowerShell, rendez vous à la racine du projet et exécuté cette commandes pour créer la base de données dans un container docker :

```bash
docker compose up -d
```

Dans votre IDE, cherchez puis ouvrez la **console de gestion des packages NuGet**
> **Note:** Sur Visual Studio aller dans Outils > Gestionnaire du package NuGet > Console du Gestionnaire du package.

Une fois dans le terminal, **et si** le dossier Migration ne contient rien, exécutez cette commande :
```bash
Add-Migration InitialCreate
```
Une fois cela fait, mettez à jour la base de donnée en exécutant cette commande :
 ```bash
Update-Database
 ```
 Une fois cela fait, lancer le projet. Et créez vous un compte via l'onglet inscrivez vous.
 
# Auteurs
* Maël Mainsard (https://github.com/MaelMainsard)
* Maxence Pille (https://github.com/PillouMK)
* Damien Forafo (https://github.com/DamienForafo)
* Hugo (https://github.com/hugoty)
