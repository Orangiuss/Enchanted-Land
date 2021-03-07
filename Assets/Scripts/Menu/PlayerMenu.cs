using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Proyecto26;
using TMPro;

public class PlayerMenu : MonoBehaviour
{
    private string databaseURL = "https://enchantedland-ae7db-default-rtdb.firebaseio.com/";
    private string AuthKey = "AIzaSyD_kvrwhmg8uQCSNFmZYhzR4lHpDoTZkrA";

    private string idToken;
    private string refreshToken;
    private User user = new User();

    public bool activePanel;
    public GameObject infosComptePanel;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI emailText;

    void Start()
    {
        if (PlayerPrefs.GetString("localIdPlayer") != null)
        {
            user.localId = PlayerPrefs.GetString("localIdPlayer");
            idToken = PlayerPrefs.GetString("IdTokenPlayer");
            refreshToken = PlayerPrefs.GetString("RefreshToken");
            Debug.Log("Vous etes bien connecté !");

            Debug.Log("IdToken :" + idToken);
            Debug.Log("Refresh :" + refreshToken);
            StartCoroutine(RefreshToken());
        }
        else
		{
            Debug.Log("GROSSE ERREUR !");
		}

        activePanel = false;
        infosComptePanel = GameObject.Find("InfosCompte");
        infosComptePanel.SetActive(activePanel);
        GetUserInformations(user);
    }

    // Update is called once per frame
    void Update()
    {
        infosComptePanel.SetActive(activePanel);
        //GetUserInformations(user);
    }

    private void GetUserInformations(User user)
	{
        RestClient.Get<User>(url: databaseURL + "users/" + user.localId + ".json").Then(onResolved: response =>
        {
             user = response;
            nameText.text = "Nom :" + user.nomUtilisateur;
            emailText.text = "Email :" + user.email;
        });
    }

    private IEnumerator RefreshToken()
    {
        yield return new WaitForSeconds(10);
        string userData = "{\"grant_type\":\"refresh_token\",\"refresh_token\":\"" + refreshToken +"\"}";
        Debug.Log(userData);
        RestClient.Post<RefreshResponse>("https://securetoken.googleapis.com/v1/token?key=" + AuthKey, userData).Then(
            response =>
            {
                Debug.Log(response.ToString());
                idToken = response.id_token;
                refreshToken = response.refresh_token;
                Debug.Log(idToken);
                Debug.Log(refreshToken);
                StartCoroutine(RefreshToken());
            }).Catch(error =>
            {
                Debug.Log(error);
            });
    }

    public void AfficherInfos()
	{
        if (activePanel == false)
		{
            activePanel = true;
        }
        else
		{
            activePanel = false;
        }
	}

    public void SupprimerCompte()
	{
        DeleteAccount(user);
    }

    private void DeleteAccount(User user)
	{
        string userData = "{\"idToken\":\"" + idToken + "\"}";
        RestClient.Post("https://identitytoolkit.googleapis.com/v1/accounts:delete?key=" + AuthKey, userData).Then(
        response =>
        {
            RestClient.Delete(url: databaseURL + "users/" + user.localId + ".json").Then(onResolved: response2 =>
            {
                RestClient.Delete(url: databaseURL + "collections/" + user.localId + ".json").Then(onResolved: response3 =>
                {
                    SceneManager.LoadScene("RegisterLogin");
                    Debug.Log("Compte supprimé");
                }).Catch(error =>
                {
                    Debug.Log(error);
                });
            }).Catch(error =>
            {
                Debug.Log(error);
            });
        }).Catch(error =>
        {
            Debug.Log(error);
        });
    }
}
