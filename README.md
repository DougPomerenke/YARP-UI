# YARP - Yet Another Retirement Planner

![ScreenShot](https://github.com/DougPomerenke/YARP-UI/assets/141588660/486cd0f2-1c28-4c8d-8b1a-50c43dcc6e3d)


## Summary
YARP is an application for running Monte Carlo simulations to help one make financial decisions regarding retirement. The application is developed on the Microsoft .NET stack. The UI is Blazor, the API is .NET Core, and currently, the Cosmso Db emulator is used for saving the account holders financial data.

### Architecture

### Usage
Data inputs are current account balance, retirement age, social security payout age, monthly contributions till retirement, and monthly retirement income. The simulation runs over a 50 year timeframe, or until the account balance goes negative. The age of the account holder when this happens is saved in a statistics component. As more iterations of the simulation are run, the resulting age is added to the history component. The statistical data is displayed. Currently, the minus one sigma value is used as an indicator for a successful plan.

The balance calculations are done in the web API. It is up to code in the UI to set parameters and handle results. The API returns account balance numbers for every year of run. This is displayed by the UI. If more than one simulation is run, the results of the last iteration are displayed. 

For each year of a simulation run, values for inflation and rate of return are randomly generated within a range determined by the input parameters.

### Installation

Currently, there is no installer for yarp. It requires a Windows development environment and some proficiency in Visual Studio and the .NET framework.






