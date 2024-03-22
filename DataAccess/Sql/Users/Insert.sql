insert into "DbUser" ("Id", "AvatarFileId", "Login", "PasswordHash", "FirstName", "LastName", "Patronymic", "PhoneNumber", "Email")
values (@Id, @AvatarFileId, @Login, @PasswordHash, @FirstName, @LastName, @Patronymic, @PhoneNumber, @Email)
returning "Id", "AvatarFileId", "Login", "PasswordHash", "FirstName", "LastName", "Patronymic", "PhoneNumber", "Email"