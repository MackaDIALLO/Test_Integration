
using System;
using Xunit;
namespace dark_place_game.tests
{
    /// Cette classe contient tout un ensemble de tests unitaires pour la classe CurrencyHolder
    public class CurrencyHolderTest
    {
        public static readonly int EXEMPLE_CAPACITE_VALIDE = 2748;
        public static readonly int EXEMPLE_CONTENANCE_INITIALE_VALIDE = 978;
        public static readonly string EXEMPLE_NOM_MONNAIE_VALIDE = "Brouzouf";
        [Fact]
        public void VraiShouldBeTrue()
        {
            var vrai = true;
            Assert.True(vrai, "Erreur, vrai vaut false. Le test est volontairement mal �crit, corrigez le.");
        }
        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf10ShouldContain10Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 10);
            var result = ch.CurrentAmount == 10;
            Assert.True(result);
        }
        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf25ShouldContain25Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 25);
            var result = ch.CurrentAmount == 25;
            Assert.True(result);
        }
        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf0ShouldContain0Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 0);
            var result = ch.CurrentAmount == 0;
            Assert.True(result);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNegativeContentThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , -10);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNullNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(null,EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithEmptyNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder("",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        //#TODO_ETAPE_4
        [Fact]
        public void BrouzoufIsAValidCurrencyName ()
        {
        // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Brouzouf
        var currency = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE );
        var name = currency.CurrencyName == "Brouzouf";
        Assert.True(name);
        }

        [Fact]
        public void DollardIsAValidCurrencyName ()
        {
        // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Dollard
        var currency = new CurrencyHolder("Dollard", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE );
        var name = currency.CurrencyName == "Dollard";
        Assert.True(name);
        }

        [Fact]
        public void TestPut10CurrencyInNonFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac a moité plein, il contient maintenant la bonne quantité de currency
            var currency = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE );
            currency.put10Currency(10);
            var result = (currency.CurrentAmount == EXEMPLE_CONTENANCE_INITIALE_VALIDE+10);
            Assert.True(result);
        }

        [Fact]
        public void TestPut10CurrencyInNearlyFullCurrencyHolder()
        {
        // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac quasiquasiement plein, une exeption NotEnoughtSpaceInCurrencyHolderExeption est levée.
            Action mauvaisAppel = () => { var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 500, 491);
                ch.put10Currency(10);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
            //Assert.Throws<NotEnoughtSpaceInCurrencyHolderExeption>(mauvaisAppel);
            
        }



        [Fact]
        public void CreatingCurrencyHolderWithNameShorterThan4CharacterThrowExeption(){

            // A vous d'écrire un test qui doit échouer s'il es possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
            Action mauvaisAppel = () => new CurrencyHolder("OEU", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNameBeetwenT4And11CharacterThrowExeption(){

            // A vous d'écrire un test qui doit échouer s'il es possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
            Action mauvaisAppel = () => new CurrencyHolder("TOF", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        /**Il y a potentielement un fichier exemple de tests qui traine, supprimez le.
        Conditions de rendu
        Il faudra envoyer par mail le répertoire de la solution et un compte rendu. Envoyez par mail à
        gael.fenetgarde@campus-igs-toulouse.fr un dossier avec un compte rendu de tp et le dossier avec
        votre solution finale ce soir avant minuit.
        Partie 1
        Etape 1
        On commence par vérifier que tout fonctionne :
        Choisissez un répertoire et faites l'initialisation à la main.
        Ouvrez VS Code, enregistrez en tant que Workspace le répertoire contenant la solution puis dans
        la barre du haut de l'éditeur cliquez sur l'onglet Terminal puis choississez l'option New Terminal.
        Un Terminal s'est ouvert en bas de la fenêtre de code, n'hésitez pas à l'agrandir un peu si
        necessaire pour y voir.
        Vous devriez voir un résultat de ce style :
        Windows PowerShell
        Copyright (C) Microsoft Corporation. Tous droits réservés.
        Testez le nouveau système multiplateforme PowerShell https://aka.ms/pscore6
        PS F:\IPI_TP\test\dark-place-engine>
        tapez ensuite la commande 'ls' pour vérifier que votre répertoire contient bien la solution :*/
        [Fact]
        public void WithdrawMoreThanCurrentAmountInCurrencyHolderThrowExeption()
        {
          //A vous d'écrire un test qui vérifie que retirer (methode withdraw) une quantité negative de currency leve une exeption CantWithDrawNegativeCurrencyAmountExeption.
         //Astuce : dans ce cas prévu avant même de pouvoir compiler le test, vous allez être obligé de créer la classe CantWithDrawMoreThanCurrentAmountExeption (vous pouvez la mettre dans le meme fichier que CurrencyHolder)
         Action mauvaisAppel = () => { var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 250, 200);
                ch.Withdraw(-60);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
            //Assert.Throws<CantWithDrawMoreThanCurrentAmountExeption>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNameBeetwen4CharacterAnd11ThrowExeption(){

            // A vous d'écrire un test qui doit échouer s'il es possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
            Action mauvaisAppel = () => new CurrencyHolder("EUROSjfhfuej", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

         [Fact]
        public void BeginAInCurrencyHolderThrowExeption(){

            // A vous d'écrire un test qui doit échouer s'il es possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
            Action mauvaisAppel = () => new CurrencyHolder("A", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void BeginA1InCurrencyHolderThrowExeption(){

            // A vous d'écrire un test qui doit échouer s'il es possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
            Action mauvaisAppel = () => new CurrencyHolder("a", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void IsFullInCurrencyHolderThrowExeption(){

            // Un CurrencyHolder est plein (IsFull) si son contenu est égal à sa capacité
            Action mauvaisAppel = () => { var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 250, 300);
                ch.IsFull();
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void IsFull1InCurrencyHolderThrowExeption(){

            // Un CurrencyHolder est plein (IsFull) si son contenu est égal à sa capacité
            Action mauvaisAppel = () => { var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 250, 400);
                ch.IsFull();
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void IsFull2InCurrencyHolderThrowExeption(){

            // Un CurrencyHolder est plein (IsFull) si son contenu est égal à sa capacité
            Action mauvaisAppel = () => { var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 250, 500);
                ch.IsFull();
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void IsFull3InCurrencyHolderThrowExeption(){

            // Un CurrencyHolder est plein (IsFull) si son contenu est égal à sa capacité
            Action mauvaisAppel = () => { var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 250, 251);
                ch.IsFull();
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }




        [Fact]
        public void IsEmptyInCurrencyHolderThrowExeption(){

            // Un CurrencyHolder est plein (IsFull) si son contenu est égal à sa capacité
            Action mauvaisAppel = () => { var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 250, 13);
                ch.IsEmpty();
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void IsEmpty1InCurrencyHolderThrowExeption(){

            // Un CurrencyHolder est plein (IsFull) si son contenu est égal à sa capacité
            Action mauvaisAppel = () => { var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 250, 20);
                ch.IsEmpty();
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CapacityUnderOneInCurrencyHolderThrowExeption(){

            // Un CurrencyHolder ne peux avoir une capacité inférieure à 1
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 0, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CapacityUnderOne1InCurrencyHolderThrowExeption(){

            // Un CurrencyHolder ne peux avoir une capacité inférieure à 1
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, -1, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void WithdrawZeroThanCurrentAmountInCurrencyHolderThrowExeption()
        {
          //A vous d'écrire un test qui vérifie que retirer (methode withdraw) une quantité negative de currency leve une exeption CantWithDrawNegativeCurrencyAmountExeption.
         //Astuce : dans ce cas prévu avant même de pouvoir compiler le test, vous allez être obligé de créer la classe CantWithDrawMoreThanCurrentAmountExeption (vous pouvez la mettre dans le meme fichier que CurrencyHolder)
         Action mauvaisAppel = () => { var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 250, 200);
                ch.put10Currency(0);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void WithdrawZero1ThanCurrentAmountInCurrencyHolderThrowExeption()
        {
          //A vous d'écrire un test qui vérifie que retirer (methode withdraw) une quantité negative de currency leve une exeption CantWithDrawNegativeCurrencyAmountExeption.
         //Astuce : dans ce cas prévu avant même de pouvoir compiler le test, vous allez être obligé de créer la classe CantWithDrawMoreThanCurrentAmountExeption (vous pouvez la mettre dans le meme fichier que CurrencyHolder)
         Action mauvaisAppel = () => { var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, 250, 200);
                ch.put10Currency(0);
            };
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }



        
    
        
        //#TODO_ETAPE_4 
    }
}