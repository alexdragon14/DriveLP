using UnityEngine;

public class CarControllerScript : MonoBehaviour
{
    public float moveSpeed = 1f; // Speed of movement
    private bool moveLeft = false;
    private bool moveRight = false;
    public carMove carMove;
    public GameObject text1;
    public GameObject textClose1;
    public GameObject panelOpen1;
    public GameObject text2;
    public GameObject textClose2;
    public GameObject panelOpen2;

    void Update()
    {
        if (moveLeft)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (moveRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    // Methods to be called by the buttons
    public void StartMoveLeft()
    {
        moveLeft = true;
    }

    public void StopMoveLeft()
    {
        moveLeft = false;
    }

    public void StartMoveRight()
    {
        moveRight = true;
    }

    public void StopMoveRight()
    {
        moveRight = false;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("tutoTrigger2"))
        {
            carMove.speed = 0;
            panelOpen1.SetActive(true);
            text1.SetActive(true);
            textClose1.SetActive(false);
            
        }

        if(collision.CompareTag("tutoTrigger3"))
        {
            carMove.speed = 0;
            text2.SetActive(true);
            textClose2.SetActive(false);
            panelOpen2.SetActive(true);
        }
    }
}
