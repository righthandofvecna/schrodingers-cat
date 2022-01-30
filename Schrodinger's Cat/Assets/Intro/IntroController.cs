using UnityEngine;
using UnityEngine.SceneManagement;


public class IntroController : MonoBehaviour
{

    public GameObject Page1GO;
    public GameObject Page2GO;
    public GameObject Page3GO;
    public GameObject Page4GO;

    public void Page1() {
        Page1GO.SetActive(true);
        Page2GO.SetActive(false);
        Page3GO.SetActive(false);
        Page4GO.SetActive(false);
    }

    public void Page2() {
        Page1GO.SetActive(false);
        Page2GO.SetActive(true);
        Page3GO.SetActive(false);
        Page4GO.SetActive(false);
    }

    public void Page3() {
        Page1GO.SetActive(false);
        Page2GO.SetActive(false);
        Page3GO.SetActive(true);
        Page4GO.SetActive(false);
    }

    public void Page4() {
        Page1GO.SetActive(false);
        Page2GO.SetActive(false);
        Page3GO.SetActive(false);
        Page4GO.SetActive(true);
    }

    public void StartGame() {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    }
}