# Real Estate Management App (WPF, C#/.NET)

## Overview

This project is a Real Estate Management Application built using WPF, C#, and .NET. It demonstrates core concepts of Object-Oriented Programming (OOP), dynamic binding, generics, serialization, and data management using Entity Framework and LINQ.<br>
(Currently a very basic UI implementation) <br>

## Key Features

- #### Application Structure

  Categories:<br>
  Residential, Commercial, Institutional

  Building Types:<br>
  Residential: Villa, Apartment, Townhouse<br>
  Commercial: Hotels, Shops, Warehouses, Factories<br>
  Institutional: Hospitals, Schools, Universities<br>

  Legal Forms:<br>
  Ownership, Tenement, Rental 

- #### Design Principles

  (Abstract classes later got changed due to the serialization etc..)

  Interface IEstate and abstract class Estate<br>
  Abstract classes: Residential, Commercial, Institutional<br>
  Use of dynamic binding for runtime object creation

- #### Data Management

  Generic `IListManager<T>` interface and `ListManager<T>` implementation (possible to use in other projects)<br>
  EstateManager inherits `ListManager<T>` 

- #### Persistence

  JSON and XML serialization

- #### Architecture

  Multi-layer architecture: PL (Presentation Layer), BLL (Business Logic Layer), DAL (Data Access Layer)<br>
  DTO Layer and Service Layer<br>
  Shared Models Library and Utilities library for shared functions<br>

- #### Database Integration

  Entity Framework for data storage and manipulation<br>
  LINQ for querying the database
  <br>

### Project Setup
#### Prerequisites

- .NET SDK (latest version)

- SQL Server LocalDB (included with Visual Studio)

- Entity Framework Core Tools


#### Getting Started

1. Clone the Repository:

    `git clone <repository-url>`<br>
    `cd <project-folder>`

2. Install Dependencies:

    `dotnet restore`

3. Set Up the Database
    - Ensure `SQL Server LocalDB` is instealled.
    - Update the connection string in `EstateContext.cs` if needed

4. Apply Migration (In VS): 
    - If migrations are present:
      <br>(Package Manager Console)<br>
      `Update-Database`<br>
    - If not, create and apply migrations:<br>
      `Add-Migration InitialCreate -Context EstateDataAccess`<br>
      `Update-Database`<br>

5. Run the Application:


#### Future Enhancements

Improve UI/UX design<br>
...