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
            BuildClientStatsView(migrationBuilder);
            //BuildProjectStatsView(migrationBuilder);
            //BuildInvoiceSummaryView(migrationBuilder);
			//BuildTimeEntryStatsStoredProc(migrationBuilder);
        }

        private static void BuildClientStatsView(MigrationBuilder migrationBuilder)
        {
			/*
            migrationBuilder.Sql(@"
            if object_id('ClientStats','v') is not null
                drop view ClientStats;
            ");

            migrationBuilder.Sql(@"
            create view ClientStats
            as
	            select
		            c.Id as ClientId,
		            count(*) as NumberOfProjects,
                    concat(ap.FirstName, ' ', ap.LastName) AS SalesRepName
	            from Clients c
		            join Projects p on p.ClientId = c.Id
                    join AspNetUsers ap ON ap.Id = c.SalesRepApplicationUserId
	            group by c.Id, ap.FirstName, ap.LastName
            ");
			*/
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
