insert into "DbTask" ("Id", "Title", "CreatedDate", "StartExecutionDate", "DeadlineDate")
values (@Id, @Title, @CreatedDate, @StartExecutionDate, @DeadlineDate)
returning "Id", "ProjectId", "Title", "CreatedDate", "StartExecutionDate", "DeadlineDate"