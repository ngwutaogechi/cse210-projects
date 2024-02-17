To use the BankAccount program, here's everything someone needs to know:

BankAccount Class:

This class represents a simple bank account.
It has a private field balance to store the current balance of the account.
It provides three public methods:
Deposit(decimal amount): Allows depositing a positive amount into the account. If the provided amount is greater than zero, it will be added to the account balance.
Withdraw(decimal amount): Allows withdrawing a positive amount from the account, given that the withdrawal amount is less than or equal to the current balance. If the provided amount is greater than zero and less than or equal to the account balance, it will be subtracted from the balance.
GetBalance(): Returns the current balance of the account.
Usage (Main Method):

In the Main method of the Program class, an instance of BankAccount is created using the constructor new BankAccount().
The Deposit method is called to deposit an amount of 100 into the account.
The Withdraw method is called to withdraw an amount of 50 from the account.
Finally, the GetBalance method is called to retrieve and print the current balance of the account to the console.
How to Interact with the Program:

To use this program, you can run it in a C# development environment such as Visual Studio or an online C# compiler.
You can modify the deposit and withdrawal amounts in the Main method as per your requirements.
Compile and execute the program to see the output, which will display the current balance of the bank account after the deposit and withdrawal operations.
Important Notes:

Ensure that the amount provided for deposit and withdrawal is a positive decimal value.
The withdrawal amount should not exceed the current balance of the account. Otherwise, the withdrawal operation will not be allowed.
The GetBalance method returns the current balance of the account, which can be useful for displaying the account balance to the user or performing further calculations.