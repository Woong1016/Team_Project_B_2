using UnityEngine;
using UnityEngine.SceneManagement;

public class ENDCUTSCENE : MonoBehaviour
{
    public void LoadStageMain()
    {
        // "STAGEMAIN" ���� �ε��մϴ�.
        SceneManager.LoadScene("CUTSCENE1");
    }
}
