using UnityEngine;

public class GoExit : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        // 에디터에서는 동작하지 않음
        Debug.Log("게임 종료 스크립트는 에디터에서 동작하지 않습니다.");
#else
        // 빌드된 게임에서는 동작
        Application.Quit();
#endif
    }
}
