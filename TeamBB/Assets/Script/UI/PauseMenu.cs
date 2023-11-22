using UnityEngine;

public class VolumeMenu : MonoBehaviour
{
    public GameObject VolumeWindow;

    public void OnClickstopbutton()
    {
        Time.timeScale = 0;
        VolumeWindow.SetActive(true);
    }

    public void OnClickContiButtom()
    {
        Time.timeScale = 1;
        VolumeWindow.SetActive(false);
    }
}
