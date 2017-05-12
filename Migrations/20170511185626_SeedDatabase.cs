using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Toyota')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Honda')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Chrysler')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Ford')");
        
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Corolla', (SELECT ID FROM Makes WHERE Name = 'Toyota'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Prius',(SELECT ID FROM Makes WHERE Name = 'Toyota'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Accord',(SELECT ID FROM Makes WHERE Name = 'Honda'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Civic',(SELECT ID FROM Makes WHERE Name = 'Honda'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('200',(SELECT ID FROM Makes WHERE Name = 'Chrysler'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('300',(SELECT ID FROM Makes WHERE Name = 'Chrysler'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Pacifica',(SELECT ID FROM Makes WHERE Name = 'Chrysler'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Focus',(SELECT ID FROM Makes WHERE Name = 'Ford'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Fusion',(SELECT ID FROM Makes WHERE Name = 'Ford'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Mustang',(SELECT ID FROM Makes WHERE Name = 'Ford'))");
        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN ('Toyota', 'Honda', 'Chrysler', 'Ford')");
        }
    }
}
