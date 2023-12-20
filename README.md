# FintechAPI
It's a web application, created to perform a CRUD of financial transactions by WEB API in json

## Models used in the application

TransactionModel:

* Id
* Value
* Description
* Type (boolean wich true is Receipt & false is Expend)
* Created (DateTime)
* UserId  
* CategoryId
* BanckId

UserModel: 

* Id
* Name
* Email
* Password
* PhoneNumber
* Created (DateTime)
* List of Categorys 
* List of Transactions

CategoryModel: 

* Id
* Name
* Type (boolean wich true is Receipt & false is Expend)
* Created (DateTime)
* UserId

BankModel:

* Id
* Value 
* Label

Obs: The Bank is the only entity that the methods Put, Delete and Post are private in BanckControl, these methods were just used to add the already added Banck's objects.


## In addition to CRUD, the Transaction has other features:

* Sum all receipts;
* Sum all expends;
* Sum the total user's amount.

## The features currently in development:

* Find existing emails;
* Password Cryptography;
* Recover Password.

## Technologies used:

<table>
<tr>
<th>C#</th>
<th>Oracle- SQL Developer</th>
<th>Swagger</th>
</tr>
<tr>
<td>6.0</td>
<td>23.1.1</td>
<td>6.5.0</td>
</tr>
</table>

## Libraries used: 

<table>
<tr>
<th>Microsoft.EntityFrameworkCore</th>
<th>Microsoft.EntityFrameworkCore.Tools</th>
<th>Oracle.EntityFrameworkCore</th>
<th>Oracle.ManagedDataAccess.Core</th>
<th>Swashbuckle.AspNetCore</th>
</tr>
<tr>
<td>7.0.13</td>
<td>7.0.13</td>
<td>7.21.12</td>
<td>3.21.120</td>
<td>6.5.0</td>
</tr>
</table>

## Steps to add the transaction using the Swagger:

1) Run the application to open the Swagger interface;
2) Add user with the Post method;
3) Add category (use the userId to insert the object);
4) Add transaction (insert the userId, the categoryId, and the bankId to add the object);
5) Finished. It's possible to see all the entities and use the operations methods using the Get methods, you just need to insert the respective userId.

Obs: In the front-end application you won't need to insert the userId manually, it'll be inserted automatically after the user sign in.

