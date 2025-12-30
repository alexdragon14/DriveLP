using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.SceneManagement;

//when something get into the alta, make the runes glow
namespace Cainos.PixelArtTopDown_Basic
{

    public class PropsAltar : MonoBehaviour
    {
        public List<SpriteRenderer> runes;
        public List<SpriteRenderer> roadSign;
        public float lerpSpeed;
        public GameObject weaponBtn;
        public GameObject enterBtn;
        public GameObject wallLock;
        public int sectionId;
        public int levelId;

        private Color curColor;
        private Color targetColor;
        private Color curColor2;
        private Color targetColor2;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                targetColor = new Color(1, 1, 1, 1);
                targetColor2 = new Color(1, 1, 1, 0);
                weaponBtn.SetActive(false);
                enterBtn.SetActive(true);
            }

            if (other.CompareTag("box"))
            {
                targetColor = new Color(1, 1, 1, 1);
                targetColor2 = new Color(1, 1, 1, 0);
                Destroy(wallLock);
            }


        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                targetColor = new Color(1, 1, 1, 0);
                targetColor2 = new Color(1, 1, 1, 1);
                weaponBtn.SetActive(true);
                enterBtn.SetActive(false);
            }
        }

        private void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }

            curColor2 = Color.Lerp(curColor2, targetColor2, lerpSpeed * Time.deltaTime);

            foreach (var r in roadSign)
            {
                r.color = curColor2;
            }
        }

        IEnumerator DoSomething(float duration)
        {
            yield return new WaitForSeconds(duration);
        }

        public void backMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void nextLevel()
        {
            if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
            {
                PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
                PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
                PlayerPrefs.Save();
            }
            string levelName = "Level " + sectionId + "-" + (levelId + 1);
            SceneManager.LoadScene(levelName);

        }
    }
}
