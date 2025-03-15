Certainly! Here's your updated README with the missing section on testing the endpoints included:

---

# Project Setup Guide

This guide will help you set up the project, configure the database, apply migrations, and run the application.

## Database Setup Options

You have two options to set up the database for this project:

### Option 1: Running a SQL Server Docker Container
If you prefer to run a SQL Server container, follow these steps:

1. **Pull the SQL Server Docker Image**  
   Run the following command to download the latest SQL Server 2022 Docker image:
   ```bash
   docker pull mcr.microsoft.com/mssql/server:2022-latest
   ```

2. **Run the SQL Server Container**  
   After pulling the image, start the container using the following command:
   ```bash
   docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Demo12345678" -p 1450:1433 --name Insurance -d mcr.microsoft.com/mssql/server:2022-latest
   ```
   
   **Note for Mac Users:**  
   If you're using a Mac, you may need to add the following flag to ensure compatibility:
   ```bash
   docker run --platform linux/amd64 -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Demo12345678" -p 1450:1433 --name Insurance -d mcr.microsoft.com/mssql/server:2022-latest
   ```
   
   **Quick Tip:**  
   To avoid adding the `--platform` flag every time, you can set the default platform by running:
   ```bash
   export DOCKER_DEFAULT_PLATFORM=linux/amd64
   ```
   
   For more information on running SQL Server in Docker, refer to:
   - [SQL Server Docker Hub](https://hub.docker.com/r/microsoft/mssql-server)
   - [SQL Server Quickstart Guide for Docker](https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&tabs=cli&pivots=cs1-bash)

### Option 2: Mocking the Database (For Quick Testing)
If you want to quickly test the application without a real database, you can use mock implementations.

1. **Navigate to the Program.cs File**  
   Go to the `Program.cs` file where you can swap out the actual database with the in-memory mock implementations. See image below:
   <img width="1036" alt="Pasted Graphic 26" src="https://github.com/user-attachments/assets/73cdec36-c3d5-487e-8128-222d76024097" />

---

## Configuring the Application

### appsettings.Development

Ensure that your `appsettings.Development.json` contains the necessary configurations for the environment. This file should be set up correctly for either using the SQL Server Docker container or mocking the database.
<img width="1288" alt="Pasted Graphic 24" src="https://github.com/user-attachments/assets/c5bdec6d-61bf-4e41-9949-2042837a26c8" />

---

## Applying Migrations

To apply the migrations and set up the database schema, follow these steps:

1. **Navigate to the Infrastructure Folder**  
   Open your terminal and change the directory to the `Infrastructure` folder:
   ```bash
   cd Infrastructure
   ```

2. **Run the Database Migrations**  
   Use Entity Framework to apply the migrations and create the necessary tables:
   ```bash
   dotnet ef database update
   ```

Once the migrations are applied, the database will contain the three required tables.

---

## Testing the Endpoints

The project includes three `.http` files in the `Infrastructure/REST/Http` folder. These files contain the API endpoints for testing.

### Using the REST Client Extension
To test the endpoints, you need to install the [REST Client extension](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) for Visual Studio Code.

Once installed, you can open the `.http` files and directly execute the HTTP requests to test the endpoints.

---

## Running the Application

To run the application:

1. **Navigate to the Infrastructure Folder**  
   ```bash
   cd Infrastructure
   ```

2. **Run the Application**  
   Start the application by running:
   ```bash
   dotnet run
   ```

This will launch the application, and you can begin testing or interacting with the APIs.

---

## Additional Notes

- You can switch between using the Docker container or the mock database by modifying the configurations in `Program.cs`.
- The database credentials and configurations can be adjusted as needed in `appsettings.Development.json`.
- If you encounter issues with the SQL Server Docker container, ensure that Docker is running and your machine has enough resources allocated to run the container.

---