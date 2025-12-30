using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class panellOpener : MonoBehaviour
{
    public GameObject Panel;
    public float delay;

    public void OpenPanel()
    {
  
        if (Panel != null)
        {
            Animator animator = Panel.GetComponent<Animator>();
            if (Panel.activeSelf == false)
            {
                
                Panel.SetActive(true);

                if (animator != null)
                {
                    bool isOpen = animator.GetBool("open");

                    animator.SetBool("open", !isOpen);
                }
            }
            else if (Panel.activeSelf == true)
            {
                
                if (animator != null)
                {
                    bool isOpen = animator.GetBool("open");

                    animator.SetBool("open", !isOpen);

                    StartCoroutine(DoSomething(delay));
                }
                

                
            }
            
        }
    }

    IEnumerator DoSomething (float duration)
    {
        yield return new WaitForSeconds(duration);
        Panel.SetActive(false);
    }

}
