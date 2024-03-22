select *
from "DbFile"
where "FileContainerId" = any (@fileContainerId)