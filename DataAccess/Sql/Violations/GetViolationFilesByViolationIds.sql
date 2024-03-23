select *
from "DbViolationFile"
where "ViolationId" = any (@violationIds) and "WithDetect" = true