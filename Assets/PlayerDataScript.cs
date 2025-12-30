using System.Threading.Tasks;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Authentication;
using TMPro;
using System.Collections;
using System;
using System.Collections.Generic;
using Unity.Services.CloudSave;

public class PlayerDataScript : MonoBehaviour
{
    public TMP_InputField registerNameField;
    public TMP_InputField registerPassField;
    public AuthManager authManager;
    public AuthManagerFirst authManagerFirst;
    public GameObject panelClose;
    public TextMeshProUGUI nameProfile;
    public TextMeshProUGUI nameProfile2;
    public TextMeshProUGUI totalScoreText;
    bool isSignIn = false;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        nameProfile.text = PlayerPrefs.GetString("username");
        nameProfile2.text = PlayerPrefs.GetString("username");
        totalScoreText.text = PlayerPrefs.GetInt("totalScore").ToString();
        try
        {
            // Initialize Unity Services
            await UnityServices.InitializeAsync();
            // Check if already signed in
            if (!AuthenticationService.Instance.IsSignedIn)
            {
                // Anonymous sign-in
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                Debug.Log("Anonymous Sign-In Successful. User ID: " + AuthenticationService.Instance.PlayerId);

                var savedData = await CloudSaveService.Instance.Data.Player.LoadAllAsync();

            }
            
        }
        catch (Exception ex)
        {
            Debug.LogError("Unity Authentication failed: " + ex.Message);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void registerAccount()
    {
        string username = registerNameField.text;
        string password = registerPassField.text;

        try
        {
            authManager.AddUsernamePasswordAsync(username, password);

        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }

    public void loginAccount()
    {
        string username = registerNameField.text;
        string password = registerPassField.text;

        try
        {
            authManagerFirst.SignInWithUsernamePasswordAsync(username, password);
            StartCoroutine(panelTime());

        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
            
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
            
        }

    }

    IEnumerator panelTime()
    {
        yield return new WaitForSeconds(3);
        if (isSignIn)
        {
            panelClose.SetActive(false);
        }
    }

}
