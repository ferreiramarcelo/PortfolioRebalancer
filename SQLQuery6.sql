select h.Id, h.Name, p.Id, p.Name, m.Ratio, RANK() OVER (PARTITION BY h.Id ORDER BY m.Ratio DESC) AS [Rank]
from ModelMaps m
join Householdmodels h on m.HouseholdModelId = h.Id
join PortfolioModels p on m.PortfolioModelId = p.Id
order by h.Name


select h.Id, h.Name, SUM(m.Ratio)
from ModelMaps m
join Householdmodels h on m.HouseholdModelId = h.Id
join PortfolioModels p on m.PortfolioModelId = p.Id
group by h.Id, h.Name