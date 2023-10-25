using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageFader : MonoBehaviour
{
    public Image[] images; // 페이드 인/아웃을 적용할 이미지 배열
    public float fadeDuration = 1.0f; // 페이드 인/아웃에 걸리는 시간

    private int currentImageIndex = 0;

    private void Start()
    {
        // 처음 이미지를 페이드 인 시작
        StartCoroutine(FadeImageIn());
    }

    // 이미지를 페이드 인하는 코루틴
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

        // 현재 이미지를 페이드 아웃
        StartCoroutine(FadeImageOut());
    }

    // 이미지를 페이드 아웃하는 코루틴
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

        // 다음 이미지로 이동
        currentImageIndex++;

        if (currentImageIndex < images.Length)
        {
            // 다음 이미지를 페이드 인
            StartCoroutine(FadeImageIn());
        }
    }
}
