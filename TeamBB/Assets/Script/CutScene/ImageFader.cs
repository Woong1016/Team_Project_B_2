using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    public Image[] images; // ���̵� ��/�ƿ��� ������ �̹��� �迭
    public float fadeDuration = 1.0f; // ���̵� ��/�ƿ��� �ɸ��� �ð�

    private int currentImageIndex = 0;

    private void Start()
    {
        // ó�� �̹����� ���̵� �� ����
        StartCoroutine(FadeImageIn());
    }

    // �̹����� ���̵� ���ϴ� �ڷ�ƾ
    private IEnumerator FadeImageIn()
    {
        Image targetImage = images[currentImageIndex];
        Color imageColor = targetImage.color;

        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            imageColor.a = Mathf.Lerp(0.0f, 1.0f, elapsedTime / fadeDuration);
            targetImage.color = imageColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        imageColor.a = 1.0f;
        targetImage.color = imageColor;

        yield return new WaitForSeconds(fadeDuration);

        // ���� �̹����� ���̵� �ƿ�
        StartCoroutine(FadeImageOut());
    }

    // �̹����� ���̵� �ƿ��ϴ� �ڷ�ƾ
    private IEnumerator FadeImageOut()
    {
        Image targetImage = images[currentImageIndex];
        Color imageColor = targetImage.color;

        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            imageColor.a = Mathf.Lerp(1.0f, 0.0f, elapsedTime / fadeDuration);
            targetImage.color = imageColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        imageColor.a = 0.0f;
        targetImage.color = imageColor;

        // ���� �̹����� �̵�
        currentImageIndex++;

        if (currentImageIndex < images.Length)
        {
            // ���� �̹����� ���̵� ��
            StartCoroutine(FadeImageIn());
        }
    }
}
