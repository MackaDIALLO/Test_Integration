using System;
namespace dark_place_game
{
    [System.Serializable]
    /// Une Exeption Custom
    // Je prends une erreur CS0234 quand j'utilise l'une ou l'autre de ces deux exceptions.
    public class NotEnoughtSpaceInCurrencyHolderExeption : System.Exception { }
    public class CantWithDrawMoreThanCurrentAmountExeption : System.Exception { }
    public class CurrencyHolder
    {
        public static readonly string CURRENCY_DEFAULT_NAME = "Unnamed";
        /// Le nom de la monnaie
        public string CurrencyName
        {
            get { return currencyName; }
            private set
            {
                currencyName = value;
            }
        }
        // Le champs interne de la property
        private string currencyName = CURRENCY_DEFAULT_NAME;
        /// Le montant actuel
        public int CurrentAmount
        {
            get { return currentAmount; }
            private set
            {
                currentAmount = value;
            }
        }
        // Le champs interne de la property
        private int currentAmount = 0;
        /// La contenance maximum du conteneur
        public int Capacity
        {
            get { return capacity; }
            private set
            {
                capacity = value;
            }
        }
        // Le champs interne de la property
        private int capacity = 0;
        public CurrencyHolder(string name, int capacity, int amount)
        {
            if(amount < 0){
                throw new System.ArgumentException("Argument invalide");
            }

            if(capacity < 1){
                throw new System.ArgumentException("Argument invalide");
            }

            if(name == null){
                throw new System.ArgumentException("Argument invalide");
            }

            if(name == ""){
                throw new System.ArgumentException("Argument invalide");
            }

            if(name.Length < 4 || name.Length > 11 || name[0] == 'a' || name[0] == 'A'){
                throw new System.ArgumentException("Argument invalide");
            }

            Capacity = capacity;
            CurrencyName = name;
            CurrentAmount = amount;
        }

        public void put10Currency(int nb){
            if(capacity < currentAmount+nb || nb <= 0)
                throw new System.ArgumentException("Argument invalide");

            currentAmount += nb;
            
        }

        public bool IsEmpty()
        {
            if( currentAmount != 0)
                throw new System.ArgumentException("Argument invalide");

            return true;
        }
        public bool IsFull()
        {
            if( currentAmount != capacity)
                throw new System.ArgumentException("Argument invalide");

            return true;
            
        }
        public void Store(int amount)
        {
        }
        public void Withdraw(int amount)
        {
            if(capacity < currentAmount-amount || amount <= 0)
                throw new System.ArgumentException("Argument invalide");

            currentAmount -= amount;
        }
    }
}