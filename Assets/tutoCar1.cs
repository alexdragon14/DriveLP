using UnityEngine;

public class tutoCar1 : MonoBehaviour
{
    public GameObject car;
    public GameObject car2;
    public carMove carMove;
    public GameObject tutoText1;
    public GameObject tutoTextClose1;
    public GameObject tutoPanelClicker4;
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {
            carMove.speed = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tutoTrigger1"))
        {
            car.SetActive(false);
            car2.SetActive(true);
            tutoText1.SetActive(true);
            tutoTextClose1.SetActive(false);
        }
        if (collision.CompareTag("obstacle1"))
        {
            tutoPanelClicker4.SetActive(true);
        }
    }
}
