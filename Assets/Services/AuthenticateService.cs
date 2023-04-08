using System;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class AuthenticateService : AbstractControl
{
    public static string tokenSession { get; private set; }

    public async Task<HttpResponseMessage> loginAsync(UserModel user)
    {
        validateUser(user);
        try
        {
            var response = await Login(GetHash("andrade01" + "123456"), await GetAddress());
            var contents = response;

            return contents;
        }
        catch
        {
            Logger("Falha na conexão : " + DateTime.Now);
            Logout();
            throw new Exception("Erro de conexão.");

        }
    }


    public static string GetHash(string input)
    {
        // Cria uma instância do objeto MD5
        using (MD5 md5Hash = MD5.Create())
        {
            // Converte a entrada string em um array de bytes
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Calcula o hash MD5 para o array de bytes
            byte[] hashBytes = md5Hash.ComputeHash(inputBytes);

            // Converte o hash em uma string hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
    public void validateAccess(UserModel user, string contents)
    {
        // VERIFICA SE O TOKEN CONTEM INFORMAÇÕES CORRETAS
        if (JsonParam(contents, "token") != null)
        {
            Common.acc = user.UserName;
            Common.accessKey = user.AccessKey;
            Common.token = JsonParam(contents, "token");
        }
        else
        {
            //EMITE ERRO EM CASO DE FALHA NO LOGIN
            string msg = "Erro ao efetuar login.";
            Logger(msg);
            ErrorModel.LoginValid = msg;
            throw new Exception(msg);
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
    public void getListCharacters(UserModel user)
    {
        HUDSelectCharacterControl selectCharacterControl = new HUDSelectCharacterControl();
        selectCharacterControl.getCharacterList(user);
    }

    public async Task<string> GetAddress()
    {
        // cria um objeto HttpClient
        HttpClient cliente = new HttpClient();

        // faz uma requisição HTTP para o serviço ipify que retorna o endereço IP externo atual
        HttpResponseMessage resposta = await cliente.GetAsync("https://api.ipify.org?format=json");

        // lê a resposta como uma string
        string respostaString = await resposta.Content.ReadAsStringAsync();

        // desserializa a string JSON em um objeto dinâmico
        JObject json = JObject.Parse(respostaString);

        // obtém o endereço IP externo como uma string
        string enderecoIP = json["ip"].ToString();

        // retorna o endereço IP externo
        return enderecoIP;
    }

}