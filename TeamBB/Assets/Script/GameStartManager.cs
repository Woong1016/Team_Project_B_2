using UnityEngine;
using UnityEngine.UI;

public class GameStartManager : MonoBehaviour
{
    public Text preStartText; // ���� ���� ���� ǥ���� �ؽ�Ʈ
    public Text startText; // ���� ���� �� ǥ���� �ؽ�Ʈ

    private bool gameStarted = false;
    private bool readyToStart = false;

    private void Start()
    {
        Time.timeScale = 0; // ���� ���� �� ���� �Ͻ������մϴ�.
        preStartText.gameObject.SetActive(true);
        startText.gameObject.SetActive(false);
        preStartText.text = "Ŭ���ϸ� �����մϴ�!";
    }

    private void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            if (!readyToStart)
            {
                readyToStart = true;
                preStartText.gameObject.SetActive(false);
                Time.timeScale = 1; // �Ͻ����� ����
                return;
            }

            gameStarted = true;
            preStartText.gameObject.SetActive(false);
            startText.gameObject.SetActive(true);
            StartGame();
        }
    }

    private void StartGame()
    {
        // ���� ���� ������ ���⿡ �߰��Ͻʽÿ�.
    }
}
