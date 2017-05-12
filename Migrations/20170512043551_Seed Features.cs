using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Leather Seats')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Navigation')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Rear Camera')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Auto-Braking')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("REMOVE FROM Features WHERE Name IN ('Leather Seats','Navigation','Rear Camera','Auto-Braking')");
        }
    }
}
