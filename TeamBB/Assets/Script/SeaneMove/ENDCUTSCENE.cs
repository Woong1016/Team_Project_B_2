using UnityEngine;
using UnityEngine.SceneManagement;

public class ENDCUTSCENE : MonoBehaviour
{
    public void LoadStageMain()
    {
        // "STAGEMAIN" 씬을 로드합니다.
        SceneManager.LoadScene("CUTSCENE1");
    }
}
