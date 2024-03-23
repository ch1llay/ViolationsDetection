insert into "DbViolationFile" ("Id", "ViolationId", "FileId")
values (@Id, @ViolationId, @FileId)
returning "Id", "ViolationId", "FileId"