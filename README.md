DroneSafety
============
Setup
------
1. Install VS (Visual Studio)
1. Connect VS to GitHib (optional)
1. Create a DocumentDB in Azure portal
1. Create a storage account in Azure portal
1. Add the [Azure Function tools](https://aka.ms/azfunctiontools) to VS
1. Create a Function project with timer trigger [(help)](https://blogs.msdn.microsoft.com/webdev/2016/12/01/visual-studio-tools-for-azure-functions/)
1. Rename `appsettings.example.json` to `appsettings.json` (sensitive keys so DO NOT COMMIT)
1. Add your AzureWebJobsStorage key For AzureWebJobsStorage (open storage account in Azure Portal -> Access Keys -> three dots -> View Connection String)
1. Add your Document DB details (open in Azure portal -> Keys)

How this was done
---------------------
1. Setup an [output binding] (https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-documentdb#a-iddocdboutputadocumentdb-output-binding) setting connection to "documentDBConnectionString". Other settings are explained at the top of the page
2. Write the code in run.csx
3. F5 to run locally
