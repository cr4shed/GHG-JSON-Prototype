# GHG JSON Prototype

### Setup Instructions:
1. Open Visual Studio.
2. Click "Clone a repository".
3. Click the green "< > Code" button on this repository.
4. Copy the HTTPS link.
5. Paste the link in Visual Studio in the "Repository location" field.

### Application Information:
- The "Add Data" button will add two new mock GHG reports, one for 2021 and one for 2022.
- The "Load Data" button will load the two new mock reports from the database and display them.
- Entity Framework handles all of the JSON serialization and deserialization which can be found in `PrototypeDbContext.cs`
- The JSON activity data in the can be copy and pasted from the database to the `json.json` file, which will format it for viewing.
- To access the local database follow these steps:
    1. In the top toolbar of Visual Studio open View -> SQL Server Object Explorer.
    2. In the SQL Server Object Explorer expand SQL Server -> (localdb)\MSSQLLocalDB -> Databases -> PrototypeDbContext -> Tables.
    3. In the Tables directory, right click on "dbo.Reports" and click "View Data".
    4. (In some cases the "View Data" may not open properly. To fix this, simply open another file and then navigate back to the data tab).

### Additional Resources:
[Microsoft Value Conversions Documentation](https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations)

[Microsoft Serialization Options Documentation](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions?view=net-8.0)

[Microsoft .NET 8 Serialization Changes](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8#serialization)

[Microsoft .NET 8 General JSON Roadmap](https://github.com/dotnet/runtime/issues/77020)

[Newtonsoft Serialization Options (also supported)](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonSerializerSettings.htm)
