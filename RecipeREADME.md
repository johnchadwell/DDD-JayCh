# DDD Magenic Masters Class

Domain Driven Design

## Project Description

The project chosen for this class was to build a recipe inventory system for a restaurant. The objective was to design a inventory tracking system such that as orders are made and inventory items are deducted based on the the recipe ingredients. When an inventory item "quantity" is reduced to a certain threshold from numerous orders then an inventory order is generated. Once the inventory order is delivered then the quantity value is updated for that inventory item.

## Design Limitations

I chose not to include anything related to the cost of inventory and how that gets reflected in the order cost. Although it is closely tied to inventory it has nothing to do with tracking inventory consumption.

## Objectives

In addition to creating a design model I wanted to go further and evaluate how my design would affect development activities. So I chose to build 3 projects: web front end, backend REST API and a Class library. 

## Pull the source code

```sh
cd $mygitroot
git clone https://github.com/Magenic/DDD.git
cd DDD
```

## Set up and reboot docker

In the docker settings, add the `DDD/Data` folder to the *Settings/Resources/File Sharing*

![Settings](Docker-FileShare.png)

> Apply and restart docker!

## Folders

* Code/ - Code
* Data/ - Data and helpers
* Scripts/ - Docker Scripts to spin up/down SQL Server for code demos

## Scripts

> All of the script are designed to be used with [GIT-BASH](https://git-scm.herokuapp.com/book/en/v2/Getting-Started-The-Command-Line)

The sample code will use a linix based Docker container image of [Microsoft SQL Server 2017](https://hub.docker.com/_/microsoft-mssql-server) where the port for sql of ~~1433~~ is remapped to **1466** to avoid colliding with any local instances you may have.

If you need to modify the scripts to suit your particular needs you can modify the [environment variables](https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-configure-environment-variables?view=sql-server-2017) as desired.

## How to use the provided scripts

Start by changing directory to `scripts/`

```bash
cd scripts
```

### Start Docker Image

```bash
./start-sql.sh
2017-CU21-ubuntu-16.04: Pulling from mssql/server
Digest: sha256:586a0e2535f191c59ff7b9aa1a70ae03bac0747ef0d2021cdea24326bcf2c3e4
Status: Image is up to date for mcr.microsoft.com/mssql/server:2017-CU21-ubuntu-16.04
mcr.microsoft.com/mssql/server:2017-CU21-ubuntu-16.04
4a771b7bf116b9b0acdbb6ecd005346a7163f31d48520ddbcaca1e08cd4a546b
SQL Running on Port: 1466
```

> **Info:** SQL Server takes a while to start, so give it a few minutes to get up and running 

This will install and start SQL:

* Address: `localhost,1466`
* Username: `sa`
* Password: `ddd20demoSQL-`
* Port: `1466`

Docker Info:

* Container Name: `ddd-sql`
* Image: `mcr.microsoft.com/mssql/server:2017-CU21-ubuntu-16.04`

### Stop Docker Image

```bash
./stop-sql.sh
```

### Bash Shell into SQL Server Docker Image

> Warning: You will be `root`

```bash
./cli-bash.sh
# 
```
Use `exit` to close the shell

### SQLCMD on SQL Server Docker Image

This will open the command line SQLCMD prompt:

```bash
./prompt-sql.sh
1> 
```

Use `exit` to close the shell

### Connection String for C# ADO or Entity Framework

```cs
var connectionString = "Server=localhost,1466;Database={Insert DB Name here};User Id=sa;Password=ddd20demoSQL-;"
```

### SQL Server Management Studio

If you want to use [SSMS](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssm) 

1. Download or update it

2. Start it
 
3. In the new connection dialog
![New Connection](SSMS-Connect.png)

4. Use SSMS as usual

![SSMS Browse](SSMS-Browse.png)

## Bicycle Schema

![Schema](Bicycle_DB_Diagram.png)

## YouTube Videos related to DDD

[YouTube DDD Videos](https://www.youtube.com/user/spookdejur1962/search?query=DDD)

## About Us

> Stuart Williams
> Larry Smithmier 
> Rocky Lhotka 



