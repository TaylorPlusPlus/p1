Pizza World
Project Description
This project is a pizza ordering web application. The application can be used from either a store prospective, or a customer’s prospective.

A customer can view their order history or choose a store to place a new order from. When placing a new order, a user can select from different premade pizza’s and different size options. If a customer is unhappy with one of their selections, they can remove it from their order before completion. 

A store can view a sales report or view their order history. If a store is viewing their order history, they can either search by a specific user or search all orders place at their store. A store can view all sales from either the last week or the last month. 


Technologies Used
C# version 9
.NET CORE version 3.1
ADO.NET Entity Framework
ASP.NET MVC version 5.2.7
Azure SQL server  
xUnit 
HTML  version 5.2
CSS   version 3
Bootstrap version 4.5.3


List of features ready and TODOs for future development

A store can search their entire history for a specific customer, and view all purchases made by that customer. 

A store can view the past week and month's sales by specific pizza type.

The application is designed to be viewed from an iPhone X 

To-do list:
Implement a secure login
Implement a secure payment system
Create a responsive design
Implement constant integration/deployment

Getting Started


Linux environment:

Download the .NET sdk by running the following commands

wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb

sudo dpkg -i packages-microsoft-prod.deb

sudo apt-get update; \
sudo apt-get install -y apt-transport-https && \
sudo apt-get update && \
sudo apt-get install -y dotnet-sdk-5.0
 
Parse to the directory you would like to have this application and run the following command

git clone git@github.com:TaylorPlusPlus/p1.git

Parse to the folder with the exe file by running the following commands

cd p1
cd PizzaBox.WebClient
 
Run the application by running the following command

dotnet run

Windows environment

Download the .NET sdk by doing the following steps:

Go to https://dotnet.microsoft.com/download and select Download .NET Core SDK 3.1

 
Be sure to include BOTH Windows and Unix command
Be sure to mention if the commands only work on a specific platform (eg. AWS, GCP)

All the code required to get started
Images of what it should look like
Usage
Here, you instruct other people on how to use your project after they’ve installed it. This would also be a good place to include screenshots of your project in action.

License
This project uses the following license: MIT License
