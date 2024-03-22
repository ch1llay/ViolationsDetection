select *
from "DbViolation"
where "UserId" = any (@userIds)