using UnityEngine;
using UnityEngine.SceneManagement;
public class GoMain : MonoBehaviour
{
    public void LoadStageMain()
    {
        // "STAGEMAIN" 씬을 로드합니다.
        SceneManager.LoadScene("Main");
    }
}
