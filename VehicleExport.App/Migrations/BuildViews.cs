using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleExport.App.Migrations
{
    public static class InitialViews
    {
        public static void BuildInitialViews(this MigrationBuilder migrationBuilder)
        {
            BuildLayoutFieldMapList(migrationBuilder);
			BuildDealerList(migrationBuilder);
            BuildWarrantiesList(migrationBuilder);
            BuildProductsList(migrationBuilder);
            BuildMakesList(migrationBuilder);
            //BuildProjectStatsView(migrationBuilder);
            //BuildInvoiceSummaryView(migrationBuilder);
            //BuildTimeEntryStatsStoredProc(migrationBuilder);
        }

        private static void BuildLayoutFieldMapList(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.Sql(@"
            if object_id('LayoutFieldMapList','v') is not null
                drop view LayoutFieldMapList;
            ");

            migrationBuilder.Sql(@"
            create view LayoutFieldMapList
            as
	            SELECT 
				   lfm.[LayoutFieldsMapId]
				  ,lfm.[LayoutId]
				  ,lfm.[LayoutFieldId]
				  ,lfm.[HeaderLabel]
				  ,lfm.[FieldOrder]
				  ,lfm.[ConcurrencyTimestamp]
				  ,lf.[Name]
			  FROM [TWD_VehicleExport].[dbo].[LayoutFieldsMap] lfm
			  LEFT JOIN TWD_VehicleExport..LayoutFields lf
			  ON
			  lf.LayoutFieldId = lfm.LayoutFieldId
            ");
			
        }
        private static void BuildDealerList(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
            if object_id('Dealers','v') is not null
                drop view Dealers;
            ");

            migrationBuilder.Sql(@"
            CREATE OR ALTER VIEW Dealers
            as
			SELECT DealerId
				,Name AS DealerName
			FROM TWD_VehicleStickers.dbo.VS_Dealer
			WHERE Enabled = 1
				AND name NOT LIKE '#%'
            ");

        }

        private static void BuildWarrantiesList(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
            if object_id('Warranties','v') is not null
                drop view [Warranties];
            ");

            migrationBuilder.Sql(@"
				CREATE OR ALTER VIEW [Warranties] AS
					SELECT WarrantyId
						,WarrantyName
					FROM TWD_VehicleStickers.dbo.VS_Warranty
            ");

        }

        private static void BuildProductsList(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
            if object_id('Products','v') is not null
                drop view [Products];
            ");

            migrationBuilder.Sql(@"
				CREATE OR ALTER VIEW [Products] AS
					SELECT ProductId
						,Description AS ProductName
					FROM TWD_VehicleStickers.dbo.VS_Products
					WHERE ProductId > 0
            ");

        }

        private static void BuildMakesList(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
            if object_id('Makes','v') is not null
                drop view [Makes];
            ");

            migrationBuilder.Sql(@"
				CREATE OR ALTER VIEW [Makes] AS
					SELECT DISTINCT MK as [Make]
					FROM IDI_RDATA.dbo.selling
            ");

        }

        /*
        private static void BuildTimeEntryStatsStoredProc(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            if object_id('TimeEntryStatsByResource','p') is not null
                drop procedure TimeEntryStatsByResource;
            ");

            migrationBuilder.Sql(@"
           CREATE PROCEDURE TimeEntryStatsByResource @startDate datetime2(7) = null, @endDate datetime2(7) = null, @projectId int = null AS

WITH TotalHoursBilledByProjectByResource AS
(
	SELECT
		p.Id As ProjectId,
		jtes.ResourceId As ResourceId,
		SUM(jtes.HoursWorked) AS TotalHoursWorked,
		SUM(jtes.HoursBilled) AS TotalHoursBilled,
		SUM(jtes.HoursBilled * jts.BillingRate) AS TotalBilled
	FROM ..Projects p
	LEFT JOIN ..JiraTasks jts
	ON
	jts.ProjectId = p.Id
	LEFT JOIN ..JiraTimeEntries jtes
	ON
	jts.Id = jtes.JiraTaskId
	WHERE
	(
		(@startDate IS NULL OR jtes.RapidestEntryDate >= @startDate)
		AND
		(@endDate IS NULL OR jtes.RapidestEntryDate <= @endDate)
		AND
		(@projectId IS NULL or p.Id = @projectId)
	)
	GROUP BY
		p.Id,
		jtes.ResourceId
)


SELECT
	p.Id AS ProjectId,
	rsc.FirstName + COALESCE(' ' + rsc.LastName, '') AS SignatureName,
	totals.TotalHoursWorked AS HoursWorked,
	totals.TotalHoursBilled AS HoursBilled,
	totals.TotalBilled AS TotalBilled,
	(totals.TotalBilled / totals.TotalHoursBilled) AS Rate
FROM ..Projects p
LEFT JOIN ..JiraTasks jts
ON
jts.ProjectId = p.Id
LEFT JOIN ..JiraTimeEntries jtes
ON
jts.Id = jtes.JiraTaskId
LEFT JOIN ..AspNetUsers rsc 
ON
rsc.Id = jtes.ResourceId
LEFT JOIN
TotalHoursBilledByProjectByResource totals
ON
totals.ProjectId = p.Id
AND
totals.ResourceId = jtes.ResourceId
WHERE
	(
		(@startDate IS NULL OR jtes.RapidestEntryDate >= @startDate)
		AND
		(@endDate IS NULL OR jtes.RapidestEntryDate <= @endDate)
		AND
		(@projectId IS NULL or p.Id = @projectId)
	)
GROUP BY 
	p.Id,
	rsc.FirstName,
	rsc.LastName,
	totals.TotalHoursWorked,
	totals.TotalHoursBilled,
	totals.TotalBilled
            ");
        }
		*/
    }
}
