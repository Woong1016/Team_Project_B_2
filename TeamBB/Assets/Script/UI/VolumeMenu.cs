using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject StopWindow;

    public void OnClickstopbutton()
    {
        Time.timeScale = 0;
        StopWindow.SetActive(true);
    }

    public void OnClickContiButtom()
    {
        Time.timeScale = 1;
        StopWindow.SetActive(false);
    }
}
