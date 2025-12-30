using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class playerpull : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float distance = 1f;
    public LayerMask boxMask;
    public Button pullButton;

    GameObject box;
    GameObject box2;
    GameObject box3;
    GameObject box4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "box" && Input.GetKey(KeyCode.E))
        {
            box = hit.collider.gameObject;

            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
        }

        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.down * transform.localScale.x, distance, boxMask);

        if (hit2.collider != null && hit2.collider.gameObject.tag == "box" && Input.GetKey(KeyCode.E))
        {
            box2 = hit2.collider.gameObject;

            box2.GetComponent<FixedJoint2D>().enabled = true;
            box2.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            box2.GetComponent<FixedJoint2D>().enabled = false;
        }

        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit3.collider != null && hit3.collider.gameObject.tag == "box" && Input.GetKey(KeyCode.E))
        {
            box3 = hit3.collider.gameObject;

            box3.GetComponent<FixedJoint2D>().enabled = true;
            box3.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            box3.GetComponent<FixedJoint2D>().enabled = false;
        }

        RaycastHit2D hit4 = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance, boxMask);

        if (hit4.collider != null && hit4.collider.gameObject.tag == "box")
        {
            box4 = hit4.collider.gameObject;

            box4.GetComponent<FixedJoint2D>().enabled = true;
            box4.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            box4.GetComponent<FixedJoint2D>().enabled = false;
        }

       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.left * transform.localScale.x * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.up * transform.localScale.x * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.down * transform.localScale.x * distance);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Button pressed down!");
        // Perform actions when the button is pressed
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "box" && Input.GetKey(KeyCode.E))
        {
            box = hit.collider.gameObject;

            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }

        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.down * transform.localScale.x, distance, boxMask);

        if (hit2.collider != null && hit2.collider.gameObject.tag == "box" && Input.GetKey(KeyCode.E))
        {
            box2 = hit2.collider.gameObject;

            box2.GetComponent<FixedJoint2D>().enabled = true;
            box2.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }

        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit3.collider != null && hit3.collider.gameObject.tag == "box" && Input.GetKey(KeyCode.E))
        {
            box3 = hit3.collider.gameObject;

            box3.GetComponent<FixedJoint2D>().enabled = true;
            box3.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }

        RaycastHit2D hit4 = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance, boxMask);

        if (hit4.collider != null && hit4.collider.gameObject.tag == "box")
        {
            box4 = hit4.collider.gameObject;

            box4.GetComponent<FixedJoint2D>().enabled = true;
            box4.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Button released!");
        // Perform actions when the button is released
        box.GetComponent<FixedJoint2D>().enabled = false;
        box2.GetComponent<FixedJoint2D>().enabled = false;
        box3.GetComponent<FixedJoint2D>().enabled = false;
        box4.GetComponent<FixedJoint2D>().enabled = false;
    }

}
