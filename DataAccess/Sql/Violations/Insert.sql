insert into "DbViolation" ("Id", "UserId", "Address", "ViolationType", "EventDate", "CreatedDate", "Comment", "ViolationStatus")
values (@Id, @UserId, @Address, @ViolationType, @EventDate, @CreatedDate, @Comment, @ViolationStatus@)
returning "Id", "UserId", "Address", "ViolationType", "EventDate", "CreatedDate", "Comment", "ViolationStatus"