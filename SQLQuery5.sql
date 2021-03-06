/****** Script for SelectTopNRows command from SSMS  ******/

SELECT hh.Name, hm.Name, pm.Name, mm.Ratio
  FROM [PortfolioRebalancer].[dbo].[PortfolioModels] pm
JOIN [PortfolioRebalancer].[dbo].[ModelMaps] mm
	ON mm.PortfolioModelId = pm.Id
JOIN [PortfolioRebalancer].[dbo].[HouseholdModels] hm
	ON mm.HouseholdModelId = hm.Id
JOIN [PortfolioRebalancer].[dbo].[Households] hh
	ON hm.Id = hh.HouseholdModelId
ORDER BY hh.Name


/*
DELETE FROM [PortfolioRebalancer].[dbo].[ModelMaps] WHERE 1=1;
DELETE FROM [PortfolioRebalancer].[dbo].[Portfolios] WHERE 1=1;
DELETE FROM [PortfolioRebalancer].[dbo].[Households] WHERE 1=1;
DELETE FROM [PortfolioRebalancer].[dbo].[HouseholdModels] WHERE 1=1;
DELETE FROM [PortfolioRebalancer].[dbo].[PortfolioModels] WHERE 1=1;
*/
