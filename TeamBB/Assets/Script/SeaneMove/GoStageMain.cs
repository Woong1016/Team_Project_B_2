using UnityEngine;
using UnityEngine.SceneManagement;

public class GoStageMain : MonoBehaviour
{
    public void LoadStageMain()
    {
        // "STAGEMAIN" 씬을 로드합니다.
        SceneManager.LoadScene("STAGEMAIN");
    }
}
