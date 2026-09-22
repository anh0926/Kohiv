# Azure Deployment – Kohiv

This document describes the basic process for deploying Kohiv to Azure App Service with Azure SQL Database.

---

## 1. Before Azure

Before deploying, make sure the application works locally.

### Build

From the solution folder:

```bash
dotnet build
```

### Test the main workflow

Run the application locally and confirm the main workflow works:

```text
/ → Experience list
Create → Save → Details → Back to list
```

---

# 2. Create Azure SQL Database

In the **Azure Portal**:

1. Search for **SQL databases**.
2. Click **Create**.
3. Select or create a resource group.

Example:

```text
rg-kohiv
```

4. Enter a database name.

Example:

```text
KohivDb
```

5. For **Server**, select **Create new**.

Example:

```text
kohiv-sql-server-yourname
```

6. Choose **SQL authentication** for now.
7. Create an administrator username and password.
8. Store the credentials securely.
9. For compute/pricing, choose the cheapest sensible option for a portfolio project.

> Creating the Azure SQL Database creates an empty database. It does not automatically create the Kohiv tables from the local database.

Microsoft documentation:

[Create a single Azure SQL Database](https://learn.microsoft.com/ga-ie/azure/azure-sql/database/single-database-create-quickstart?view=azuresql)

---

# 3. Allow Local Machine Access to Azure SQL

For the initial deployment, allow your development machine to connect to Azure SQL.

In the **SQL Server** resource:

```text
Networking → Public access
```

Add your current client IP address.

This allows tools such as EF Core to connect from your computer when applying the database migrations.

> **Security:** Only allow the IP addresses that you actually need. Do not leave unnecessary access open.

---

# 4. Get the Azure SQL Connection String

Open the **Azure SQL Database** in the Azure Portal.

Find the **ADO.NET connection string** and copy it.

It will look similar to:

```text
Server=tcp:YOUR_SERVER.database.windows.net,1433;Initial Catalog=KohivDb;Persist Security Info=False;User ID=YOUR_USER;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
```

Replace:

```text
{your_password}
```

with the actual Azure SQL administrator password when configuring the connection.

> **Security:** Never commit the Azure SQL password to source control.

---

# 5. Apply EF Core Migrations to Azure SQL

The Azure database starts without the Kohiv tables, so apply the existing EF Core migrations to it.

Run the commands from the Kohiv solution folder:

```text
C:\Repos\Kohiv
```

### 5.1 Set the Azure connection string temporarily

In PowerShell:

```powershell
$env:ConnectionStrings__DefaultConnection="Server=tcp:YOUR_SERVER.database.windows.net,1433;Initial Catalog=KohivDb;Persist Security Info=False;User ID=YOUR_USER;Password=YOUR_PASSWORD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
```

The double underscore:

```text
ConnectionStrings__DefaultConnection
```

maps to the ASP.NET Core configuration key:

```text
ConnectionStrings:DefaultConnection
```

This temporarily overrides the local `DefaultConnection` from `appsettings.json` for the current PowerShell session.

### 5.2 Apply the migrations

Run:

```powershell
dotnet ef database update --project src\Kohiv.Infrastructure --startup-project src\Kohiv.Web
```

The command:

* uses the EF Core migrations in `Kohiv.Infrastructure`
* uses `Kohiv.Web` as the startup project
* connects using the temporary Azure `DefaultConnection`
* applies the migrations to the Azure SQL database

Expected result:

```text
Build started...
Build succeeded.
Applying migration '...'.
Done.
```

### 5.3 Remove the temporary connection string

After the migration succeeds:

```powershell
Remove-Item Env:ConnectionStrings__DefaultConnection
```

This only removes the temporary environment variable from the current PowerShell session. It does not change Azure or `appsettings.json`.

### 5.4 Verify the Azure database

Open the Azure SQL Database and check that the Kohiv tables have been created.

For example:

```text
__EFMigrationsHistory
Categories
Experiences
ExperienceImages
```

---

# 6. Create the Azure App Service

In the **Azure Portal**:

1. Search for **App Services**.
2. Click **Create → Web App**.
3. Select the same resource group where appropriate.
4. Choose the desired App Service name.
5. Select the appropriate .NET runtime.
6. Choose the cheapest sensible App Service plan for the portfolio project.
7. Create the Web App.

> The App Service name determines the Azure-provided hostname, such as:
>
> `your-app-name.azurewebsites.net`

The Web App does not need to create another database because the Azure SQL Database was created separately.

---

# 7. Configure the Azure App Service Connection String

The deployed application needs to connect to the Azure SQL Database.

In the Azure App Service:

```text
Settings → Environment variables → Connection strings
```

Add:

```text
Name: DefaultConnection
Type: SQLAzure
Value: <Azure SQL connection string>
```

Replace:

```text
{your_password}
```

with the actual Azure SQL password.

Save the configuration.

### Why this is separate from `appsettings.json`

The local `appsettings.json` can continue to point to the local SQL Server:

```text
Local Kohiv
    ↓
appsettings.json
    ↓
Local SQL Server
```

When Kohiv runs in Azure, the App Service connection string provides the production value:

```text
Azure App Service
    ↓
DefaultConnection
    ↓
Azure SQL Database
```

The Azure App Service configuration overrides the corresponding application configuration value.

> **Do not put the production Azure SQL password into `appsettings.json` or commit it to source control.**

---

# 8. Publish Kohiv.Web

Publish the **Kohiv.Web** project because it is the ASP.NET Core startup/web project.

The published application includes the compiled dependencies required by:

```text
Kohiv.Web
Kohiv.Application
Kohiv.Infrastructure
Kohiv.Domain
```

The other projects do not need to be published separately.

---

# 9. Deploy to Azure App Service

Deploy the published `Kohiv.Web` application to the Azure App Service.

After deployment, open the Azure App Service URL and test the application.

Check:

```text
/ → Experience list
Create → Save → Details → Back to list
```

---

# 10. Troubleshooting

If the deployed application shows:

```text
An error occurred while processing your request.
```

check the following:

### Azure SQL

* Does the Azure database contain the Kohiv tables?
* Does `__EFMigrationsHistory` exist?
* Were the EF migrations successfully applied?

### App Service connection string

Check:

```text
App Service
→ Settings
→ Environment variables
→ Connection strings
→ DefaultConnection
```

Make sure it points to the Azure SQL database, not the local database.

### Azure SQL networking

If the migration cannot connect from your computer, check:

```text
Azure SQL Server
→ Networking
→ Public access
```

and make sure your current client IP is allowed.

For errors occurring after deployment, check the App Service logs/Log stream for the actual exception rather than enabling Development Mode on the public application.

---

# Deployment Architecture

The overall setup is:

```text
                    Azure
┌──────────────────────────────────────────┐
│                                          │
│   Azure App Service                     │
│   Kohiv.Web                             │
│        │                                 │
│        │ DefaultConnection              │
│        ▼                                 │
│   Azure SQL Database                    │
│   KohivDb                               │
│                                          │
└──────────────────────────────────────────┘
             ▲
             │
             │ EF Core migrations
             │
        Local Computer
        Kohiv project
```

The local project does not connect to the Azure Web App when applying migrations.

Instead:

```text
Local Kohiv project
        ↓
EF Core migrations
        ↓
Azure SQL Database
```

The deployed application then connects separately:

```text
Azure App Service
        ↓
Azure SQL Database
```
