CREATE PROCEDURE [dbo].[PobierzOdbiorce]
	@Id int = 0,
	@Email varchar OUT,
	@Telefon varchar OUT
AS
	SELECT @Email = Email, @Telefon = Telefon from Odbiorcy where Id = @Id

RETURN 0
