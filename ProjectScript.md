# Team Procedures for Creating\Deploying\Running Azure-Based MUD Maker Applications

## I Want to...

### Setup Azure Devops

* Go to [Azure DevOps Organization Dashboard for Team 2](https://dev.azure.com/MSSA-Team-2/)
* Click 'Create New Project'
* Enter a Project Name, Description, and Visibility of Public.
* Click 'Create'

### Setup Azure AD / Integrate with Azure Devops

* Go to the Azure Portal.
* Using the blades on the left, go to Azure Active Directory.
* Ensure that you are in the desired Directory, if not, click on "switch directory."
* To add users, navigate to the "Users" selection in the left blade.
* Click "New User."
* Click "Invite user."
* Continue to add your desired users.
* It may prompt all the requested users to log out and log back in before they have access to the directory.
* Next will be connecting Azure AD to your Azure Devops.
* Sign into your Azure DevOps Organization.
* Remain in the highest level of directory, do NOT go into a project.
* In the bottom left of the blade, click on "Organization settings."
* Select "Azure Active Directory."
* Select your directory from the dropdown menu, and click "Connect."
* All users will then be prompted to log out and sign back in.* 

### Define and assign Roles in Azure AD (assign members as project admins.)

* Within the [Azure Devops](https://dev.azure.com/MSSA-Team-2/), click "Organizations Settings" from the lower left hand side of the screen.
* Click "Permissions".
* In the right hand window, click "Users."
* Click "Add New User".
* In the Add New User dialog, enter the e-mail address for the person being added to the project.
* Add the new user to the appropriate project.
* Click 'Add' when complete.

### Create a Repo

* Within the Project on the Azure Devops Project Portal, click on 'Repos'
* On the right hand side of the screen, scroll to the bottom.  Under 'Or initialize with a README or gitignore, select 'Add a README'.
* On the drop down menu for 'Add a .gitignore' select 'VisualStudio'.
* Select 'Initialize'.

### Connect the repo to Visual Studio

* Within the Project on the Azure Devops Project Portal, click on 'Repos'.
* On the upper-right portion of the screen, click 'Clone'.
* Copy the URL next to 'HTTPS'
* Launch Visual Studio and select 'Clone or Checkout code' in the upper right of the 'Get Started' window.
* Under 'Repository location', paste the url copied in the previous step.
* Click 'Clone'.

### Initialize a new MVC template application with Identity FrameWork pre-installed (this is a one time action by a single member of the team)

* Within the cloned project in Visual Studio, click File -> New -> Project
* Select ASP.NET Core Web Application.
* In the Configure New Project window, enter "MUD-Maker" for project name.
* Under location, navigate to the location of the local repository for MUD-maker create in the "Connect the repo to Visual Studio" step.
* Click create.
* On the "Create a new ASP.NET Core Web Application" window, select "Web Application (Model-View-Controller).
* Under "Authentication" click "Change"
* In the Change Authentication window select the radio button for "Individual User Accounts".
* Click "OK", then click "Create"
* Test the application (without debugging).  You should have a functioning web page with the ability to create new login accounts, and login/logout.
* If the application works correctly, commit the changes to the Master branch of the project.

### Create a new Development Branch (this is a one time action by a single member of the team)

* In the bottom right corner of Visual Studio, click the master branch, and then click "Mange Branches".
* In the Team Explorer slide out, right click on the "Master" branch, and select "New Branch From".
* In the "Enter a Branch" text box, type "Development".
* select "Create Branch".
* Once the Development branch is created, right click "Development" in the Team Explorer slide out, and select "Push Branch" from the pop-out menu.

### Set up the EF Database and Migrate to SSMS

* Within the solution in Visual Studio, navigate to *ProjectName*/Data/ApplicationDbContext.cs. 
* Create the DbSets and Classes for each table that will be migrated to SSMS.
* Locate & open the project's repository folder on your local machine.
* Open the project's solution folder (this should be named the same as the repository folder)
    -You should now see Program.cs, Startup.cs, and others...)
* Open Git Bash here.
* Type the following command... (ensure that there are no errors)

```
dotnet ef migrations add MudDBElements
```
* Type the following command... (ensure that there are no errors)
```
dotnet ef database update
```

### Deploy the Web Application and SQL Database to Azure

* Follow these instructions here: [Deploy the app to Azure](https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-webapp-using-vs?view=aspnetcore-3.0#deploy-the-app-to-azure)

### Plug in Seed Data into the Database to Ensure it Operates Appropiately

* Navigate to the Solutions/Models folder.
* Create a new class called SeedData.
* In the using statement, make sure to include "Microsoft.AspNetCore.Builder", "Microsoft.Extensions.DependencyInjection", "Microsoft.EntityFrameworkCore", "Sytem.Link"
* Create a method called EnsurePopulated, which takes the ApplicationDbContext and if there is no context, it will insert the following seed data.
* Implement the base seed data, such as MudID, MudName, MudDescription.