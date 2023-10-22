using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    public Image[] images; // 이미지 객체 배열
    public Text clickText; // "화면을 클릭하세요" 텍스트 객체
    public float fadeInTime = 2f; // 나타나는 데 걸리는 시간
    public float fadeOutTime = 2f; // 사라지는 데 걸리는 시간

    private int currentImageIndex = 0;
    private float timer = 0f;
    private bool fadeIn = true;

    void Start()
    {
        // 시작 시 클릭 텍스트 비활성화
        clickText.gameObject.SetActive(false);

        // 모든 이미지를 숨김
        foreach (Image image in images)
        {
            image.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    void Update()
    {
        if (fadeIn)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Clamp01(timer / fadeInTime);

            // 현재 이미지에 대해 알파값 설정
            images[currentImageIndex].color = new Color(1f, 1f, 1f, alpha);

            if (alpha >= 1f)
            {
                // 이미지가 완전히 나타날 때
                fadeIn = false;
                timer = 0f;
                // "화면을 클릭하세요" 메시지 활성화
                clickText.gameObject.SetActive(true);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentImageIndex < images.Length - 1)
                {
                    // 다음 이미지로 넘어가기
                    currentImageIndex++;
                    fadeIn = true;
                    clickText.gameObject.SetActive(false);
                }
                else
                {
                    // 모든 이미지가 나타난 후 화면 클릭 시 다음 씬으로 이동
                    SceneManager.LoadScene("NextScene");
                }
            }
        }
    }
}
