CREATE PROCEDURE [dbo].[PobierzNadawce]
	@Id int = 0,
	@Email varchar OUT,
	@Telefon varchar OUT
AS
	SELECT @Email = Email, @Telefon = Telefon from Nadawcy where Id = @Id

RETURN 0
