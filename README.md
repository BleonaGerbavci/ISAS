# ISAS
# Social Media Platform Backend

## Overview

This repository contains the backend of a Social Media Platform. The backend is developed using .NET and provides APIs that can be tested and executed via Swagger. This README will guide you through setting up the project, configuring the database, and enabling additional features such as automated building and system monitoring.

## Prerequisites

- .NET SDK (version 8.0.x)
- Visual Studio or any other C# IDE
- SQL Server or any other compatible database system
- NuGet Package Manager
- Prometheus and Grafana (for system monitoring)

## Getting Started

### Step 1: Clone the Repository

Clone this repository to your local machine using the following command:


##**Step 2: Install Required Packages**

![image](https://github.com/BleonaGerbavci/ISAS/assets/93130459/e9874f46-f46c-47b4-91bc-f05e7b85119a)
![image](https://github.com/BleonaGerbavci/ISAS/assets/93130459/b4f8ed62-9dea-45af-96eb-f381fb80162c)

**Step 3: Configure the Database**
Create a new database using your preferred database system.

Update the connection string in appsettings.json to point to your database

**Step 4: Run the Project**
Run the project using the following command:
dotnet run

Navigate to http://localhost:5000/swagger in your web browser to access the Swagger UI and test the APIs.

**Step 5: Automated Building**
To enable automated building using GitHub Actions:

Ensure your .github/workflows/dotnetTest.yml file is properly configured

**Step 6: System Monitoring**
To set up system monitoring using Prometheus and Grafana:

Install Prometheus and Grafana on your server or local machine.

Configure Prometheus to scrape metrics from your application. Add a configuration in prometheus.yml:
scrape_configs:
  - job_name: 'SocialMedia'
    static_configs:
      - targets: ['localhost:5000'] # Update the target to your application's address
Run Prometheus with the updated configuration.

Install and Configure Grafana:

Add Prometheus as a data source in Grafana.
Create dashboards and panels to visualize the metrics. You can use the metrics such as CPU usage, memory usage, disk usage, response time, error rate, etc.







