using UnityEngine;

public class GoExit : MonoBehaviour
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
