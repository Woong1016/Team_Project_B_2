using UnityEngine;
using UnityEngine.UI;

public class GameStartManager : MonoBehaviour
{
    public Text preStartText; // 게임 시작 전에 표시할 텍스트
    public Text startText; // 게임 시작 시 표시할 텍스트

    private bool gameStarted = false;
    private bool readyToStart = false;

    private void Start()
    {
        Time.timeScale = 0; // 게임 시작 시 씬을 일시정지합니다.
        preStartText.gameObject.SetActive(true);
        startText.gameObject.SetActive(false);
        preStartText.text = "클릭하면 시작합니다!";
    }

    private void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            if (!readyToStart)
            {
                readyToStart = true;
                preStartText.gameObject.SetActive(false);
                Time.timeScale = 1; // 일시정지 해제
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
        // 게임 시작 로직을 여기에 추가하십시오.
    }
}
