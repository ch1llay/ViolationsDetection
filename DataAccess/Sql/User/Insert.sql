insert into "DbUser" ("Id", "Login", "PasswordHash", "Email", "Name", "Birthday", "Height", "Weight")
values (@Id, @Login, @PasswordHash, @Email, @Name, @Birthday, @Height, @Weight)
returning "Id", "Login", "PasswordHash", "Email", "Name", "Birthday", "Height", "Weight"