insert into "DbFile" ("Id", "UserId", "FileContainerId", "Filename", "CreatedDate")
values (@Id, @UserId, @FileContainerId, @Filename, @CreatedDate)
returning  "Id", "UserId", "FileContainerId", "Filename", "CreatedDate"