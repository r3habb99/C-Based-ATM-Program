using System;
using System.Collections.Generic;
using System.Linq;
    public class cardHolder
    {
        String cardNum;
        int pin;
        String firstName;
        String lastName;
        double balance;

        public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }
        public String getNum()
        {
            return cardNum;
        }
        public int getPin()
        {
            return pin;
        }
        public String getFirstName()
        {
            return firstName;
        }
        public String getLastName()
        {
            return lastName;
        }
        public double getBalance()
        {
            return balance;
        }
        public void setNum(string newCardNum)
        {
            cardNum = newCardNum;
        }
        public void setPin(int newPin)
        {
            pin = newPin;
        }
        public void setFirstName(string newFirstName)
        {
            firstName = newFirstName;
        }
        public void setLastName(string newLastName)
        {
            lastName = newLastName;
        }
        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }

        public static void Main(String[] args)
        {
            void printOption()
            {
                Console.WriteLine("Please choose from ome of the following option...");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
            }

            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much Rupees would you like to deposit : ");
                double deposit = Double.Parse(Console.ReadLine());
                currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your Rupees. Your new Balance is : " + currentUser.getBalance());

            }
            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much Rupees would you like to withdraw : ");
                double withdraw = Double.Parse(Console.ReadLine());
                //check if the user has enough money
                if (currentUser.getBalance() < withdraw)
                {
                    Console.WriteLine("Insufficient balance :( ");
                }
                else
                {
                    currentUser.setBalance(currentUser.getBalance() - withdraw);
                    Console.WriteLine("You're good to go! Thankyou :)");
                }
            }
            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Current Balance : " + currentUser.getBalance());
            }
            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("5561208352986482", 1234, "John", "Griff", 150.31));
            cardHolders.Add(new cardHolder("5130205342334742", 4321, "Johnny", "Griffein", 321.31));
            cardHolders.Add(new cardHolder("5259609302334953", 9876, "Rocky", "Balboa", 550.81));

            //Prompt User
            Console.WriteLine("Welcome to SimpleATM");
            Console.WriteLine("Please insert your debit card : ");
            string debitCardNum = "";
            cardHolder currentUser;

            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    // check against our db
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if (currentUser != null) { break; }
                    else { Console.WriteLine("Card not recognized. Please try again"); }
                }
                catch
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            Console.WriteLine("Please enter your pin : ");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    // check against our db
                    if (currentUser.getPin() == userPin) { break; }
                    else { Console.WriteLine("Incorrect Pin. Please try again"); }
                }
                catch
                {
                    Console.WriteLine("Incorrect Pin. Please try again");
                }
            }

            Console.WriteLine("Welcome " + currentUser.getFirstName() + " :) ");
            int option = 0;
            do
            {
                printOption();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            while (option != 4);
            Console.WriteLine("Thankyou! have a nice day :) ");
        }
    }
