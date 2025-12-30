using System;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManagerScript : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TextMeshProUGUI usernameText;
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI dialog1;
    public GameObject nameConfirmation;
    public carMove carMove;
    public carMove carQuizMove;
    string username = null;
    string character = "Male";
    string error;

    public void setName()
    {
        if (usernameField != null && !string.IsNullOrEmpty(usernameField.text)) 
        {
            username = usernameField.text;
            usernameText.text = username;
            nameConfirmation.SetActive(true);
            error = null;
            errorText.text = error;
        }
        else
        {
            error = "*Sila isi ruang yang disediakan!";
            errorText.text = error;
        }
        
    }

    public void charMaleSelect()
    {
        character = "Male";
    }

    public void charFemaleSelect()
    {
        character = "Female";
    }

    public void charConfirm()
    {
        SaveUserData();
        PlayerPrefs.SetString("username", username);
        PlayerPrefs.SetString("character", character);
        PlayerPrefs.SetInt("totalScore", 0);
        dialog1.text = "Hai " + username + "! Terima Kasih kerana sertai kami. Mari kita mulakan tutorial cara bermain DriveLP.";
    }

    public void carMoveTuto()
    {
        carMove.speed = 1;
        carQuizMove.speed = 1;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void carMoveTutoStop()
    {
        carMove.speed = 0;
        carQuizMove.speed = 0;
    }

    public async void SaveUserData()
    {
        try
        {
            // Initialize Unity Services
            await UnityServices.InitializeAsync();
            // Check if already signed in
            if (AuthenticationService.Instance.IsSignedIn)
            {
                string userId = AuthenticationService.Instance.PlayerId;
                var playerData = new Dictionary<string, object>{
                 {"userId", userId},
                {"charname", username},
                {"character", character},
                {"totalScore", 0 }
                };
                var result = await CloudSaveService.Instance.Data.Player.SaveAsync(playerData);
                Debug.Log($"Saved data {string.Join(',', playerData)}");
            }
            else
            {
                Debug.LogError("User not sign in!");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Unity Authentication failed: " + ex.Message);
        }
    }
}
