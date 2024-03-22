select *
from "DbFileContainer"
where "ViolationId" = any (@violationIds)