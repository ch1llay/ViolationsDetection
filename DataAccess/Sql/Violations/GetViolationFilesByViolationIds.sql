select *
from "DbViolationFile"
where "ViolationId" = any (@violationIds)