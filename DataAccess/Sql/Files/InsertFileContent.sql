insert into "DbFileContent" ("Id", "FileId", "Content")
values (@Id, @FileId, @Content)
returning "Id", "FileId", "Content"