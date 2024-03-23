insert into "DbFile" ("Id", "UserId", "Filename", "ContentType", "CreatedDate")
values (@Id, @UserId, @Filename, @ContentType, @CreatedDate)
returning "Id", "UserId", "Filename", "ContentType", "CreatedDate"