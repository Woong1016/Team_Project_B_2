using UnityEngine;
using UnityEngine.SceneManagement;

public class GoStage3 : MonoBehaviour
{
    public void LoadStageMain()
    {
        // "STAGEMAIN" 씬을 로드합니다.
        SceneManager.LoadScene("STAGE3");
    }
}
