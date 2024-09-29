namespace SimpleBankingControlPanel.Application.User.Commands.Login;

public class LoginResponse
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}