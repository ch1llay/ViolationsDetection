insert into "DbViolationFile" ("Id", "ViolationId", "FileId", "WithDetect")
values (@Id, @ViolationId, @FileId, @WithDetect)
returning "Id", "ViolationId", "FileId", "WithDetect"