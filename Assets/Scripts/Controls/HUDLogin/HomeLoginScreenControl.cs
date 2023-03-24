using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HomeLoginScreenControl : AuthenticateService
{
    // Start is called before the first frame update
    float halfScreenY;
    float halfScreenX;
    //modal inteiro
    GameObject HomeScreenBackground;
    GameObject HomeScreenShadow;

    //lado login
    GameObject LoginModal;

    //lado register
    GameObject RegisterModal;

    //button play
    GameObject ButtonPlay;

    //Section Login Inputs
    GameObject UserLabel;
    GameObject UserInput;
    GameObject PassLabel;
    GameObject PassInput;
    GameObject ButtonLostAcc;
    GameObject ButtonRegisterAcc;

    //Service
    AuthenticateService service = new AuthenticateService();

    void Start()
    {
        //setLayout();
        onClickButtonPlay();


    }
    void onClickButtonPlay()
    {
        GameObject.Find("ButtonPlay").GetComponent<Button>().onClick.AddListener(async () =>
        {
            UserModel user = new UserModel();
            user.UserName = GameObject.Find("UserInput").GetComponent<TMP_InputField>().text;
            user.AccessKey = GameObject.Find("PassInput").GetComponent<TMP_InputField>().text;
            var response = await loginAsync(user);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // VALIDA SE HÁ UM IP VÁLIDO SOLICITANTE DO LOGIN
                validateIsNewIpAddress(user, contents);
                //CASO IP NOVO, SOLICITAR CONFIANÇA AO USUÁRIO
                alertAboutNewIpAddress(user, contents);

                validateAccess(user, contents);

                if (ErrorModel.isValid())
                {
                    getListCharacters(user);
                    UpdateCommon();
                    Logger("Usuário Autenticado!");
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Logger("Usuário ou senha inválidos");
                Logout();
            }
            else
            {
                Logger("Falha na conexão : " + ToJson(response) + DateTime.Now);
                Logout();
            }
        });
    }
    private void alertAboutNewIpAddress(UserModel user, string contents)
    {
        //CASO O IP SEJA RESPONDIDO COMO NOVO PELA API, MOSTRA O MODAL PARA CONFIRMAR SALVAMENTO DE CONFIANÇA
        if (user.IsNewIpAddress == 1)
        {
            //CHAMA E AGUARDA RETORNO COM RESPOSTA
            string response = await ShowConfirmModal("Atenção", "Um Novo IP foi detectado, deseja adicioná-lo como confiável ?", JsonParam(contents, "IpAddress"), true, false, true);
            //TODO : CRIAR METODOS QUE TRATAM A RESPOSTA DO MODAL
            switch (response)
            {
                case "YES":
                    {
                        SetIpAsDenied(user,false);
                        break;
                    }
                case "NO":
                    {
                        SetIpAsDenied(user,true);
                        break;
                    }
                case "OK":
                    {
                        break;
                    }
                case "CANCEL":
                    {
                        break;
                    }
            }
        }
    }

    void setLayout()
    {
        halfScreenY = Screen.height / 2;
        halfScreenX = Screen.width / 2;
        //modal inteiro
        HomeScreenBackground = GameObject.Find("HomeScreenBackground");
        HomeScreenShadow = GameObject.Find("HomeScreenShadow");

        //lado login
        LoginModal = GameObject.Find("LoginModal");

        //lado register
        RegisterModal = GameObject.Find("RegisterModal");

        //button play
        ButtonPlay = GameObject.Find("ButtonPlay");

        //Section Login Inputs
        UserLabel = GameObject.Find("UserLabel");
        UserInput = GameObject.Find("UserInput");
        PassLabel = GameObject.Find("PassLabel");
        PassInput = GameObject.Find("PassInput");
        ButtonLostAcc = GameObject.Find("ButtonLostAcc");
        ButtonRegisterAcc = GameObject.Find("ButtonRegister");




        if (Screen.width > 600)
        {
            //modal inteiro
            var ModalHomeRect = HomeScreenBackground.transform as RectTransform;
            var ModalHomeShadowRect = HomeScreenShadow.transform as RectTransform;

            //lado login
            var ModalLoginRect = LoginModal.transform as RectTransform;

            //lado register
            var ModalRegisterRect = RegisterModal.transform as RectTransform;

            //button play
            var ButtonPlayRect = ButtonPlay.transform as RectTransform;

            //Section Login Inputs
            var UserLabelRect = UserLabel.transform as RectTransform;
            var UserInputRect = UserInput.transform as RectTransform;
            var PassLabelRect = PassLabel.transform as RectTransform;
            var PassInputRect = PassInput.transform as RectTransform;
            var ButtonLostAccRect = ButtonLostAcc.transform as RectTransform;
            var ButtonRegisterAccRect = ButtonLostAcc.transform as RectTransform;

            //position inputs and buttons
            UserLabel.transform.position = new Vector2(halfScreenX - 175, halfScreenY - 60);
            UserInput.transform.position = new Vector2(halfScreenX - 175, halfScreenY - 70);
            PassLabel.transform.position = new Vector2(halfScreenX - 175, halfScreenY - 95);
            PassInput.transform.position = new Vector2(halfScreenX - 175, halfScreenY - 105);
            ButtonLostAcc.transform.position = new Vector2(halfScreenX - 195, halfScreenY - 125);
            ButtonRegisterAcc.transform.position = new Vector2(halfScreenX - 145, halfScreenY - 125);
            ButtonPlay.transform.position = new Vector2(HomeScreenBackground.transform.position.x - 65, HomeScreenBackground.transform.position.y - 85);

            //position areas
            HomeScreenBackground.transform.position = new Vector2(halfScreenX - 5, halfScreenY - 5);
            HomeScreenShadow.transform.position = new Vector2(halfScreenX, halfScreenY);
            LoginModal.transform.position = new Vector2(HomeScreenBackground.transform.position.x - 120, HomeScreenBackground.transform.position.y);
            RegisterModal.transform.position = new Vector2(HomeScreenBackground.transform.position.x + 120, HomeScreenBackground.transform.position.y);

            //sizing areas
            ButtonPlayRect.sizeDelta = new Vector2(90, 30);
            ModalHomeShadowRect.sizeDelta = new Vector2(500, 300);
            ModalHomeRect.sizeDelta = new Vector2(500, 300);
            ModalLoginRect.sizeDelta = new Vector2(230, 280);
            ModalRegisterRect.sizeDelta = new Vector2(230, 280);

            //sizing inputs and buttons
            UserLabelRect.sizeDelta = new Vector2(110, 24);
            UserInputRect.sizeDelta = new Vector2(110, 24);
            PassLabelRect.sizeDelta = new Vector2(110, 24);
            PassInputRect.sizeDelta = new Vector2(110, 24);
        }
    }
}
