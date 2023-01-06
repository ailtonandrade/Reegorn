using System;
using System.Threading.Tasks;

public class AuthenticateService : AbstractControl
{
    public static string tokenSession { get; private set; }

    public async Task loginAsync(UserModel user)
    {
        user.UserName = "andrade01";
        user.AccessKey = "123456";

        if(user.UserName != null && user.AccessKey != null){
            try
            {
                var response = Post("auth", user);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string contents = await response.Content.ReadAsStringAsync();
                    if (JsonParam(contents, "token") != null)
                    {
                        tokenSession = contents;
                        PushDropScene("MainLand", "Home");
                        Logger("Usuário Autenticado!");
                    }


                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Logger("Usuário ou senha inválidos");
                }
                else
                {
                    Logger("Falha na conexão = " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Logger(ex.Message);
            }
        }
    }
}