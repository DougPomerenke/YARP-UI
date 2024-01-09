# YARP - Yet Another Retirement Planner

![ScreenShot](https://github.com/DougPomerenke/YARP-UI/assets/141588660/486cd0f2-1c28-4c8d-8b1a-50c43dcc6e3d)


## Summary
YARP is an application for running Monte Carlo simulations to help one make financial decisions regarding retirement. The application is developed on the Microsoft .NET stack. The UI is Blazor, the API is .NET Core, and currently, the Cosmso Db emulator is used for saving the account holders financial data.

### Architecture
YARP has three components, a UI based on Microsoft's .NET 8 and Blazor framework, an API based on MS .NET 8, and a database using CosmosDb. The database contains data describing an account holder's financial situation and retirement parameters. The API does two things, interfaces with the database so the UI component does not, and performs the Monte Carlo calculations. The UI displays the input parameters for a simulation run and displays the output parameters. It also provides a screen for editing an account holders data. 

### Usage
Data inputs are current account balance, retirement age, social security payout age, monthly contributions till retirement, and monthly retirement income. The simulation runs over a 50 year timeframe, or until the account balance goes negative. The age of the account holder when this happens is saved in a statistics component. As more iterations of the simulation are run, the resulting age is added to the history component. The statistical data is displayed. Currently, the minus one sigma value is used as an indicator for a successful plan.

The balance calculations are done in the web API. It is up to code in the UI to set parameters and handle results. The API returns account balance numbers for every year of run. This is displayed by the UI. If more than one simulation is run, the results of the last iteration are displayed. 

For each year of a simulation run, values for inflation and rate of return are randomly generated within a range determined by the input parameters.

![image](https://github.com/DougPomerenke/YARP-UI/assets/141588660/de09af4f-7023-4f5c-b239-099b56809d65)




![image](https://github.com/DougPomerenke/YARP-UI/assets/141588660/3ae50c5d-ecd5-41b0-a0f8-e84cd7ace917)




![image](https://github.com/DougPomerenke/YARP-UI/assets/141588660/6ee97560-5bc4-42c8-83d4-55fd2d5bd463)




![image](https://github.com/DougPomerenke/YARP-UI/assets/141588660/5ddd42a6-5f9f-423c-9c26-5dae487394ea)


### Installation

Currently, there is no installer for yarp. It requires a Windows development environment and some proficiency in Visual Studio and the .NET framework.

OS:

Windows 10 Pro

Platform:

.NET 8

Development Environment:

Microsoft Visual Studio Community 2022 (64-bit) - Preview Version 17.9.0 Preview 1.1 (Or later)

Cosmsos Db Emulator:

https://learn.microsoft.com/en-us/azure/cosmos-db/how-to-develop-emulator?tabs=windows%2Ccsharp&pivots=api-mongodb  (Link valid, 1/9/2024)

Dependencies:

Microsoft.EntityFrameworkCore.Cosmos  (API solution)

Blazor.Bootstrap  (UI solution)


Get your copy of the source code for both solutions, YARP-UI and YARP-API

Install the Cosmos DB emulation. Follow the link for download link and instructions.

Launch the Azure Cosmos DB Emulator from the Start Menu. Bookmark this URL for later use. If you close this tab, the emulator continues to run.

Copy the Account Key produced by the DB install into Program.cs in the BalanceCalculatorAccountHolderApi project.

Start the API in debug, there should be two Swaggar Windows that open.

Copy the contents of the YARP-API "src\Sample Data for CosmosDB.txt" file into the Swagger BalanceCalculatorAccountHolderApi POST method's request body. This should created the DB schema and insert the data.

Verify the DB contents with the Swagger's BalanceCalculatorAccountHolderApi POST method.

Start the UI in debug.







