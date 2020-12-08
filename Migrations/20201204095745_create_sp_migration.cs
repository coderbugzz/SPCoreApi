using Microsoft.EntityFrameworkCore.Migrations;

namespace SPCoreApi.Migrations
{
    public partial class create_sp_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE sp_CreateMember(
                                        @emailAddress VARCHAR(100), 
                                        @userName VARCHAR(100), 
                                        @contactNumber VARCHAR(100), 
                                        @Status VARCHAR(100), 
                                        @retVal int out)
                                    AS
                                    BEGIN

                                    INSERT INTO MemberProfiles(
                                        EmailAddress, 
                                        UserName, 
                                        ContactNumber, 
                                        [Status]) 
                                        VALUES(@emailAddress, @userName, @contactNumber, @Status);

                                        ---check for number of rows affected
                                        IF(@@ROWCOUNT > 0)
                                        BEGIN
                                            SET @retVal = 200 -- command was executed successfully
                                        END
                                        ELSE
                                        BEGIN
                                            SET @retVal = 500  -- nothing is updated
                                        END
                                    END");
            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE sp_GetMembers
                                    AS
                                    BEGIN
                                        Select * FROM MemberProfiles
                                    END");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
               migrationBuilder.Sql("drop procedure sp_createMember");
               migrationBuilder.Sql("drop procedure sp_GetMembers");
        }
    }
}
