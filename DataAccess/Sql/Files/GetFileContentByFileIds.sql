select *
from "DbFileContent"
where "FileId" = any (@fileIds)