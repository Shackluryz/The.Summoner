using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{

    [SerializeField] private InputField usuarioField = null;
    [SerializeField] private InputField senhaField = null;
    [SerializeField] private Text feedbackmsg = null;
    [SerializeField] private Toggle rememberData = null;

    void Start() {
        if(PlayerPrefs.HasKey("remember") && PlayerPrefs.GetInt("remember") == 1) {
            usuarioField.text = PlayerPrefs.GetString("rememberLogin");
            senhaField.text = PlayerPrefs.GetString("rememberPass");

        }
    }

    public void FazerLogin() {
        if (usuarioField.text == "" || senhaField.text == "") {
            FeedbackError("Preencha os campos!");
        } else {
            string usuario = usuarioField.text;
            string senha = senhaField.text;

            if (rememberData.isOn)
            {
                PlayerPrefs.SetInt("remember", 1);
                PlayerPrefs.SetString("rememberLogin", usuario);
                PlayerPrefs.SetString("rememberPass", senha);
            }

            StartCoroutine(Login(usuario, senha));
        }
    }

    IEnumerator Login(string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("login", username);
        form.AddField("senha", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://thesummonerbookiii.000webhostapp.com/usuario.php", form)) {

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError) {
                FeedbackError(www.error);
            } else {

                if (www.downloadHandler.text == "1") {
                    FeedbackOk("Login Realizado com sucesso\nCarregando o Jogo...");
                    StartCoroutine(CarregaScene());
                } else {
                    FeedbackError(www.downloadHandler.text);
                }   
            }
        }

    }

    IEnumerator CarregaScene() {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }

    void FeedbackOk(string mensagem) {
        feedbackmsg.CrossFadeAlpha(100f, 0f, false);
        feedbackmsg.text = mensagem;
    }
    void FeedbackError(string mensagem) {
        feedbackmsg.CrossFadeAlpha(100f, 1f, false);
        feedbackmsg.text = mensagem;
        feedbackmsg.CrossFadeAlpha(0f, 2f, false);
        usuarioField.text = "";
        senhaField.text = "";
    }

}