using UnityEngine;

public class firstTimeScript : MonoBehaviour
{
    public GameObject firstTimerOnly;

    int storedData = 0;

    public string dataStoredName = "DriveLP_FirstTime";

    [SerializeField]
    bool deleteStoredDataInEditor = false;

    void Awake()
    {
        storedData = PlayerPrefs.GetInt(dataStoredName, 0);

        if (firstTimerOnly != null)
        {
            firstTimerOnly.SetActive(storedData == 0);
        }
        else
        {
            Debug.Log("There is no GameObject assigned in the firstTimeOnly variable in inspector");
        }

        PlayerPrefs.SetInt(dataStoredName, 1);
    }

    private void OnValidate()
    {
        if (deleteStoredDataInEditor)
        {
            deleteStoredDataInEditor = false;
            PlayerPrefs.DeleteKey(dataStoredName);
            Debug.Log("Data Delete, Message will appear next session");
        }
    }
}
