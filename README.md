Drone Safety
===========
Backend for Drone Safety, Team Echo's project for the Part IB Cambridge Computer Science group project 2017.

Local setup
------------
1. Install VS (Visual Studio)
1. Connect VS to GitHib (optional)
1. Create a DocumentDB in Azure portal
1. Create a storage account in Azure portal
1. Add the [Azure Function tools](https://aka.ms/azfunctiontools) to VS
1. Create a Function project with timer trigger [(help)](https://blogs.msdn.microsoft.com/webdev/2016/12/01/visual-studio-tools-for-azure-functions/)
1. Rename `appsettings.example.json` to `appsettings.json` (sensitive keys so DO NOT COMMIT)
1. Add your AzureWebJobsStorage key For AzureWebJobsStorage (open storage account in Azure Portal -> Access Keys -> three dots -> View Connection String)
1. Add your Document DB details (open in Azure portal -> Keys)

Deployment
-----------
1. Create an Azure Functions app.
1. Setup to deploy from GitHub.
1. Add the correct values for `DocumentDbUri`, `DocumentDbKey`, `DocumentDbConnectionString` in App Settings from the Azure portal.