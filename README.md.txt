

Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools

@"Server=(localdb)\mssqllocaldb;Database=Classificados;Integrated Security=True"

    Add-Migration InitialCreate
    Update-Database 