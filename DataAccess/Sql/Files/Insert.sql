insert into "DbFile" ("Id", "UserId", "Filename", "CreatedDate")
values (@Id, @UserId, @Filename, @CreatedDate)
returning "Id", "UserId", "Filename", "CreatedDate"