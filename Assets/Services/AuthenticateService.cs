using System;
using System.Threading.Tasks;

public class AuthenticateService : AbstractControl
{
    public static string tokenSession { get; private set; }

    public async Task loginAsync(UserModel user)
    {
        validateUser(user);
        try
        {
            var response = await Post("auth", user);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string contents = await response.Content.ReadAsStringAsync();
                validateAccess(user, contents);
                getListCharacters(user);
                Logger("Usuário Autenticado!");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Logger("Usuário ou senha inválidos");
            }
            else
            {
                Logger("Falha na conexão : " + response.StatusCode + DateTime.Now);
            }
        }
        catch (Exception ex)
        {
            Logger(ex.Message);
        }
    }
    private void validateAccess(UserModel user, string contents)
    {
        if (JsonParam(contents, "token") != null)
        {
            Common.acc = user.UserName;
            Common.accessKey = user.AccessKey;
            Common.token = JsonParam(contents, "token");
        }
        else
        {
            throw new Exception("Erro ao efetuar login.");
        }
    }
    private void validateUser(UserModel user)
    {
        user.UserName = "andrade01";
        user.AccessKey = "123456";
        if (user.UserName == null && user.AccessKey == null)
        {
            throw new Exception("Erro ao efetuar login.");
        }
    }
    private void getListCharacters(UserModel user)
    {
        HUDSelectCharacterControl selectCharacterControl = new HUDSelectCharacterControl();
        selectCharacterControl.getCharacterList(user.UserName);
    }
}