using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    public Image[] images; // �̹��� ��ü �迭
    public Text clickText; // "ȭ���� Ŭ���ϼ���" �ؽ�Ʈ ��ü
    public float fadeInTime = 2f; // ��Ÿ���� �� �ɸ��� �ð�
    public float fadeOutTime = 2f; // ������� �� �ɸ��� �ð�

    private int currentImageIndex = 0;
    private float timer = 0f;
    private bool fadeIn = true;

    void Start()
    {
        // ���� �� Ŭ�� �ؽ�Ʈ ��Ȱ��ȭ
        clickText.gameObject.SetActive(false);

        // ��� �̹����� ����
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

            // ���� �̹����� ���� ���İ� ����
            images[currentImageIndex].color = new Color(1f, 1f, 1f, alpha);

            if (alpha >= 1f)
            {
                // �̹����� ������ ��Ÿ�� ��
                fadeIn = false;
                timer = 0f;
                // "ȭ���� Ŭ���ϼ���" �޽��� Ȱ��ȭ
                clickText.gameObject.SetActive(true);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentImageIndex < images.Length - 1)
                {
                    // ���� �̹����� �Ѿ��
                    currentImageIndex++;
                    fadeIn = true;
                    clickText.gameObject.SetActive(false);
                }
                else
                {
                    // ��� �̹����� ��Ÿ�� �� ȭ�� Ŭ�� �� ���� ������ �̵�
                    SceneManager.LoadScene("NextScene");
                }
            }
        }
    }
}
