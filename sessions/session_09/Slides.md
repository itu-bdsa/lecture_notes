---
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
backgroundImage: url('https://marp.app/assets/hero-background.svg')
footer: '![width:300px](https://github.com/itu-bdsa/lecture_notes/blob/main/images/banner.png?raw=true)'
marp: true
style: |
  section {
    font-size: 25px;
  }
  container {
    height: 300px;
    width: 100%;
    display: block;
    justify-content: right;
    text-align: right;
  }
  header {
    float: right;
  }

  a {
    color: blue;
    text-decoration: underline;
    background-color: lightgrey;
    font-size: 80%;
  }

  table {
    font-size: 22px;
  }
---

# **Analysis, Design and Software Architecture (BDSA)**
Session 9
[Rasmus Lystrøm, Senior Cloud Solution Architect](rnie@itu.dk)

---

# Agenda

* Databases
* Migrations in CI/CD
* Create Cheep (to Chirp!)
* Input Validation
* JavaScript and `libman`
* Partials - reusable code
* UI Testing

---

# Databases

![bg](images/databases.png)

---

# Relational Databases (SQL)

Microsoft SQL Server
Oracle Database
IBM Db2
MySQL
MariaDB
PostgreSQL
SQLite

Google BigQuery
Amazon Relational Database Service (Amazon RDS)
Azure SQL

![bg left](images/pyramids.jpg)

---

## Document (NoSQL)

Google Firestore
Azure Cosmos DB
Amazon DynamoDB
MongoDB
Couchbase
Redis
Elasticsearch
Neo4j

![bg right](images/skyscrapers.jpg)

---

# Most popular databases

Source: <https://survey.stackoverflow.co/2023/#most-popular-technologies-database>

![bg right](images/database-popularity.png)

---

# SQL Server

```bash
MSSQL_SA_PASSWORD="33eca922-74a0-11ee-9e21-00155d9a126b"

docker run \
-e "ACCEPT_EULA=Y" \
-e "MSSQL_SA_PASSWORD=$MSSQL_SA_PASSWORD" \
-p 1433:1433 \
--name sql-server \
-d mcr.microsoft.com/mssql/server:2022-latest
```

<https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker>

---

# SQL Server Docker Container + Azure Data Studio

## Demo

---

![bg right:60%](images/lock.jpg)

# Secrets

---

# Secrets

```bash
CONNECTION_STRING="Data Source=localhost,1433;Initial Catalog=Chirp;User=sa;Password=33eca922-74a0-11ee-9e21-00155d9a126b;TrustServerCertificate=True"

dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:Chirp" "$CONNECTION_STRING"
```

---

# Azure SQL

## Demo

![bg right:60%](images/azure-sql.png)

---

# Task

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 15 minutes
-->
<style scoped>
section {
   font-size: 21px;
}
</style>

1. Local (Docker)

   - Run a container with SQL Server 2022.
   - Connection your app to SQL Server.
   - Delete and recreate migrations.
   - Test everything runs as before.

2. Cloud (Azure)

   - Create Entra ID Group `Chirp SQL Admins`.
   - Create SQL Server with database (`Basic` tier) - Group is admin.
   - Ensure SQL Server firewall is open for Azure services.
   - Create managed identity on web app.
   - Make identity member of group.
   - Grab connection string.

`Server=tcp:<server-fqdn>,1433; Initial Catalog=<database-name>; Encrypt=True;TrustServerCertificate=False; Connection Timeout=30; Authentication="Active Directory Default"`

---

# Migrations in CI/CD

## Demo

---

# Create Cheep (to Chirp!)

## Demo

---

# Partials

## Demo

---

# UI Testing

## Demo

---

# Thank you

![bg right:60% contain](images/applause.png)
