using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dimActive : MonoBehaviour
{
    public Button pole;
    public Button textBg;
    public Button mainBtn;
    public Button activeBtn;
    public TextMeshProUGUI text;
    string oriText;
    public int section;

    public void Start()
    {
        oriText = text.text;
    }

    public void Update()
    {
        

        if (activeBtn.interactable == false)
        {
            pole.interactable = false;
            textBg.interactable = false;
            mainBtn.interactable = false;
            text.text = "Selesaikan Seksyen\r\n" + (section - 1) + " Dahulu!";
        }
        else
        {
            pole.interactable = true;
            textBg.interactable = true;
            mainBtn.interactable = true;
            text.text = oriText;
        }
    }
}
