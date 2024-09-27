# Zoo Manager

**Zoo Manager** is a WPF (Windows Presentation Foundation) desktop application that allows users to manage zoos and their associated animals using an SQL database. The app provides functionality to add, update, delete, and associate animals to zoos.
(Project was created to test DB with WPF)

## Features

- **Manage Zoos**: Add, update, or delete zoos.
- **Manage Animals**: Add, update, or delete animals.
- **Associate Animals with Zoos**: Add or remove animals to/from zoos.
- **View Data**: Display all zoos, animals, and associated animals in an easy-to-read format.

## Screenshots
![image](https://github.com/user-attachments/assets/4dbdb05b-474e-4583-b92d-42fc416da96a)


## Technologies Used

- **WPF (Windows Presentation Foundation)** for the user interface.
- **C#** for application logic.
- **SQL Server** for database management.
- **ADO.NET** for database interaction.
- **Visual Studio** for development.

## Database Structure

The application interacts with three tables:

1. **Zoo**: Stores information about zoos.
    - `Id`: Unique identifier for the zoo.
    - `Location`: The location of the zoo.
  
2. **Animal**: Stores information about animals.
    - `Id`: Unique identifier for the animal.
    - `Name`: The name of the animal.
  
3. **ZooAnimal**: Links animals to zoos.
    - `Id`: Unique identifier.
    - `ZooId`: Foreign key to the Zoo table.
    - `AnimalId`: Foreign key to the Animal table.

## Getting Started

### Prerequisites

- **Visual Studio 2019 or later** (with .NET desktop development workload installed).
- **SQL Server** (local or remote).
- **SQL Server Management Studio (SSMS)** (optional, for managing the database).

### Setting Up the Database

1. Create a new SQL Server database using SSMS or another tool.
2. Create the necessary tables using the following SQL commands:

```sql
CREATE TABLE Zoo (
    Id INT PRIMARY KEY IDENTITY,
    Location NVARCHAR(100) NOT NULL
);

CREATE TABLE Animal (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE ZooAnimal (
    Id INT PRIMARY KEY IDENTITY,
    ZooId INT FOREIGN KEY REFERENCES Zoo(Id),
    AnimalId INT FOREIGN KEY REFERENCES Animal(Id)
);
```

3. Insert some initial data into the database:

```sql
INSERT INTO Zoo (Location) VALUES ('New York Zoo'), ('San Diego Zoo');
INSERT INTO Animal (Name) VALUES ('Lion'), ('Tiger'), ('Elephant');
```

### Configuration

1. Open the solution in **Visual Studio**.
2. Go to `App.config` and set up the connection string:

```xml
<connectionStrings>
    <add name="WPFZooManager.Properties.Settings.TestDbConnectionString" 
         connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=YOUR_DATABASE_NAME;Integrated Security=True" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

Replace `YOUR_SERVER_NAME` and `YOUR_DATABASE_NAME` with the correct values for your SQL Server instance.

### Running the Application

1. Once the database is set up, press **F5** in Visual Studio to run the application.
2. You will see a UI with three sections:
   - **Zoo List**: Displays available zoos.
   - **Animal List**: Displays available animals.
   - **Associated Animals**: Displays animals associated with the selected zoo.

### Functionality

- **Add Zoo**: Type a zoo location into the text box and click the **Add Zoo** button.
- **Update Zoo**: Select a zoo from the list, edit the location in the text box, and click **Update Zoo**.
- **Delete Zoo**: Select a zoo and click **Delete Zoo** to remove it from the database.
- **Add Animal**: Type an animal name into the text box and click **Add Animal**.
- **Update Animal**: Select an animal, edit its name, and click **Update Animal**.
- **Delete Animal**: Select an animal and click **Delete Animal**.
- **Associate Animal with Zoo**: Select a zoo and an animal, then click **Add Animal to Zoo**.
- **Remove Animal from Zoo**: Select a zoo and an associated animal, then click **Remove Animal**.

### Error Handling

The application includes basic error handling, which shows message boxes when exceptions occur.

## Future Improvements

- Improve error messages and feedback to the user.
- Add search functionality for zoos and animals.
- Implement input validation to ensure correct data formats.
- Enhance UI design with better styling.
