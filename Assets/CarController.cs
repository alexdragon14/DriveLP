using System;
using System.Collections;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Action onDestroyCallback; // Callback for when the car is destroyed
    private GameObject carObject;
    public Animator animator;
    public GameObject[] roadSign;
    

    void Start()
    {
        carObject = GetComponent<GameObject>();
    }

    void Update()
    {
       
    }

    void OnDestroy()
    {
        // Invoke the callback when the car is destroyed
        onDestroyCallback?.Invoke();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle1") || collision.CompareTag("obstacle2") || 
            collision.CompareTag("obstacle3") || collision.CompareTag("obstacle4") || collision.CompareTag("obstacle5"))
        {
            animator.SetBool("Explode", true);
            StartCoroutine(DoSomething(collision));
        }

        if (collision.CompareTag("RoadSignLine"))
        {
            
            String collisionName = collision.transform.parent.gameObject.name;
            GameObject col = collision.gameObject;
            GameObject rs = col.transform.parent.gameObject;
            Destroy(rs);
            

            if (collisionName == "roadSignPlace0")
            {
                GameObject obstacle0 = GameObject.Find("obstacleRoadSpawner0");
                if (rs.CompareTag("roadSign1"))
                {
                    if (obstacle0.CompareTag("obstacle1"))
                    {
                        Destroy(obstacle0);
                    }
                }
                else if (rs.CompareTag("roadSign2"))
                {
                    if (obstacle0.CompareTag("obstacle2"))
                    {
                        Destroy(obstacle0);
                    }
                }
                else if (rs.CompareTag("roadSign3"))
                {
                    if (obstacle0.CompareTag("obstacle3"))
                    {
                        Destroy(obstacle0);
                    }
                }
                else if (rs.CompareTag("roadSign4"))
                {
                    if (obstacle0.CompareTag("obstacle4"))
                    {
                        Destroy(obstacle0);
                    }
                }
                else if (rs.CompareTag("roadSign5"))
                {
                    if (obstacle0.CompareTag("obstacle5"))
                    {
                        Destroy(obstacle0);
                    }
                }

            }
            else if (collisionName == "roadSignPlace1")
            {
                GameObject obstacle1 = GameObject.Find("obstacleRoadSpawner1");
                if (rs.CompareTag("roadSign1"))
                {
                    if (obstacle1.CompareTag("obstacle1"))
                    {
                        Destroy(obstacle1);
                    }
                }
                else if (rs.CompareTag("roadSign2"))
                {
                    if (obstacle1.CompareTag("obstacle2"))
                    {
                        Destroy(obstacle1);
                    }
                }
                else if (rs.CompareTag("roadSign3"))
                {
                    if (obstacle1.CompareTag("obstacle3"))
                    {
                        Destroy(obstacle1);
                    }
                }
                else if (rs.CompareTag("roadSign4"))
                {
                    if (obstacle1.CompareTag("obstacle4"))
                    {
                        Destroy(obstacle1);
                    }
                }
                else if (rs.CompareTag("roadSign5"))
                {
                    if (obstacle1.CompareTag("obstacle5"))
                    {
                        Destroy(obstacle1);
                    }
                }
            }
            else if (collisionName == "roadSignPlace2")
            {
                GameObject obstacle2 = GameObject.Find("obstacleRoadSpawner2");
                if (rs.CompareTag("roadSign1"))
                {
                    if (obstacle2.CompareTag("obstacle1"))
                    {
                        Destroy(obstacle2);
                    }
                }
                else if (rs.CompareTag("roadSign2"))
                {
                    if (obstacle2.CompareTag("obstacle2"))
                    {
                        Destroy(obstacle2);
                    }
                }
                else if (rs.CompareTag("roadSign3"))
                {
                    if (obstacle2.CompareTag("obstacle3"))
                    {
                        Destroy(obstacle2);
                    }
                }
                else if (rs.CompareTag("roadSign4"))
                {
                    if (obstacle2.CompareTag("obstacle4"))
                    {
                        Destroy(obstacle2);
                    }
                }
                else if (rs.CompareTag("roadSign5"))
                {
                    if (obstacle2.CompareTag("obstacle5"))
                    {
                        Destroy(obstacle2);
                    }
                }
            }
            else if (collisionName == "roadSignPlace3")
            {
                GameObject obstacle3 = GameObject.Find("obstacleRoadSpawner3");
                if (rs.CompareTag("roadSign1"))
                {
                    if (obstacle3.CompareTag("obstacle1"))
                    {
                        Destroy(obstacle3);
                    }
                }
                else if (rs.CompareTag("roadSign2"))
                {
                    if (obstacle3.CompareTag("obstacle2"))
                    {
                        Destroy(obstacle3);
                    }
                }
                else if (rs.CompareTag("roadSign3"))
                {
                    if (obstacle3.CompareTag("obstacle3"))
                    {
                        Destroy(obstacle3);
                    }
                }
                else if (rs.CompareTag("roadSign4"))
                {
                    if (obstacle3.CompareTag("obstacle4"))
                    {
                        Destroy(obstacle3);
                    }
                }
                else if (rs.CompareTag("roadSign5"))
                {
                    if (obstacle3.CompareTag("obstacle5"))
                    {
                        Destroy(obstacle3);
                    }
                }
            }
            else if (collisionName == "roadSignPlace4")
            {
                GameObject obstacle4 = GameObject.Find("obstacleRoadSpawner4");
                if (rs.CompareTag("roadSign1"))
                {
                    if (obstacle4.CompareTag("obstacle1"))
                    {
                        Destroy(obstacle4);
                    }
                }
                else if (rs.CompareTag("roadSign2"))
                {
                    if (obstacle4.CompareTag("obstacle2"))
                    {
                        Destroy(obstacle4);
                    }
                }
                else if (rs.CompareTag("roadSign3"))
                {
                    if (obstacle4.CompareTag("obstacle3"))
                    {
                        Destroy(obstacle4);
                    }
                }
                else if (rs.CompareTag("roadSign4"))
                {
                    if (obstacle4.CompareTag("obstacle4"))
                    {
                        Destroy(obstacle4);
                    }
                }
                else if (rs.CompareTag("roadSign5"))
                {
                    if (obstacle4.CompareTag("obstacle5"))
                    {
                        Destroy(obstacle4);
                    }
                }
            }
        }
    }

  



    IEnumerator DoSomething(Collider2D carobject)
    {
        yield return new WaitForSeconds(1);
        Destroy(carobject.gameObject);
    }
}
