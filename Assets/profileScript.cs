using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class profileScript : MonoBehaviour
{
    public GameObject accountValid;
    public GameObject register;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void accountPanelOpener()
    {
        await UnityServices.InitializeAsync();

        if (AuthenticationService.Instance.IsSignedIn)
        {
            string username = AuthenticationService.Instance.PlayerName; // Retrieves the username
            if (username == null)
            {
                register.SetActive(true);
            }
            else
            {
                accountValid.SetActive(true);
            }
        }
    }
}
