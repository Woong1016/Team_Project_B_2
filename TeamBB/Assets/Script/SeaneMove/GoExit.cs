using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        // �����Ϳ����� �������� ����
        Debug.Log("���� ���� ��ũ��Ʈ�� �����Ϳ��� �������� �ʽ��ϴ�.");
#else
        // ����� ���ӿ����� ����
        Application.Quit();
#endif
    }
}
