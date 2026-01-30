using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using ResumeProjectNight.Context;

#nullable disable

namespace ResumeProjectNight.Migrations
{
    [DbContext(typeof(ResumeContext))]
    [Migration("20260116123000_FixPortfolioCategoryFK2")]
    public partial class FixPortfolioCategoryFK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF COL_LENGTH('dbo.Portfolios', 'CategoryId') IS NULL
BEGIN
    IF COL_LENGTH('dbo.Portfolios', 'ProjectCategoryCategoryId') IS NOT NULL
    BEGIN
        EXEC sp_rename 'dbo.Portfolios.ProjectCategoryCategoryId', 'CategoryId', 'COLUMN';
    END
    ELSE
    BEGIN
        ALTER TABLE dbo.Portfolios ADD CategoryId int NULL;
    END
END
");

            migrationBuilder.Sql(@"
IF COL_LENGTH('dbo.Portfolios', 'CategoryId') IS NOT NULL
BEGIN
    DECLARE @defaultCategoryId int;
    SELECT TOP 1 @defaultCategoryId = CategoryId FROM dbo.ProjectCategories ORDER BY CategoryId;

    IF @defaultCategoryId IS NULL
    BEGIN
        SET IDENTITY_INSERT dbo.ProjectCategories ON;
        INSERT INTO dbo.ProjectCategories (CategoryId, CategoryName) VALUES (1, 'Default');
        SET IDENTITY_INSERT dbo.ProjectCategories OFF;
        SET @defaultCategoryId = 1;
    END

    UPDATE dbo.Portfolios SET CategoryId = @defaultCategoryId WHERE CategoryId IS NULL;
END
");

            migrationBuilder.Sql(@"
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Portfolios_ProjectCategories_ProjectCategoryCategoryId')
    ALTER TABLE dbo.Portfolios DROP CONSTRAINT FK_Portfolios_ProjectCategories_ProjectCategoryCategoryId;

IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Portfolios_ProjectCategories_ProjectCategoryId')
    ALTER TABLE dbo.Portfolios DROP CONSTRAINT FK_Portfolios_ProjectCategories_ProjectCategoryId;
");

            migrationBuilder.Sql(@"
IF COL_LENGTH('dbo.Portfolios', 'CategoryId') IS NOT NULL
BEGIN
    IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Portfolios_CategoryId' AND object_id = OBJECT_ID('dbo.Portfolios'))
        DROP INDEX IX_Portfolios_CategoryId ON dbo.Portfolios;

    IF EXISTS (
        SELECT 1
        FROM sys.columns
        WHERE object_id = OBJECT_ID('dbo.Portfolios')
          AND name = 'CategoryId'
          AND is_nullable = 1
    )
        ALTER TABLE dbo.Portfolios ALTER COLUMN CategoryId int NOT NULL;
END
");

            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Portfolios_CategoryId' AND object_id = OBJECT_ID('dbo.Portfolios'))
    CREATE INDEX IX_Portfolios_CategoryId ON dbo.Portfolios(CategoryId);
");

            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Portfolios_ProjectCategories_CategoryId')
    ALTER TABLE dbo.Portfolios ADD CONSTRAINT FK_Portfolios_ProjectCategories_CategoryId
        FOREIGN KEY (CategoryId) REFERENCES dbo.ProjectCategories(CategoryId) ON DELETE CASCADE;
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Portfolios_ProjectCategories_CategoryId')
    ALTER TABLE dbo.Portfolios DROP CONSTRAINT FK_Portfolios_ProjectCategories_CategoryId;

IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Portfolios_CategoryId' AND object_id = OBJECT_ID('dbo.Portfolios'))
    DROP INDEX IX_Portfolios_CategoryId ON dbo.Portfolios;

IF COL_LENGTH('dbo.Portfolios', 'CategoryId') IS NOT NULL
    ALTER TABLE dbo.Portfolios DROP COLUMN CategoryId;
");
        }
    }
}

