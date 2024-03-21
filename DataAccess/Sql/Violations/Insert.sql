insert into "DbActionDirection" ("Id", "LifeSphereId", "Title", "Description", "CreatedDate")
values (@Id, @LifeSphereId, @Title, @Description, @CreatedDate)
returning "Id", "LifeSphereId", "Title", "Description", "CreatedDate"  