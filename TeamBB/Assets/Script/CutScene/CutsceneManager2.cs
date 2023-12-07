using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager2 : MonoBehaviour
{
    public Image[] images; // �ƽ� �̹��� �迭
    private int currentImageIndex = 0; // ���� �̹��� �ε���

    private void Start()
    {
        // ���� �̹��� ǥ��
        ShowCurrentImage();
    }

    private void Update()
    {
        // ���콺 ���� ��ư Ŭ�� �� ���� �̹��� ǥ��
        if (Input.GetMouseButtonDown(0))
        {
            currentImageIndex++;
            if (currentImageIndex < images.Length)
            {
                ShowCurrentImage();
            }
            else
            {
                // ��� �̹����� ǥ�õǾ��� ��, ���� ��(STAGE1) �ε�
                SceneManager.LoadScene("STAGE2");
            }
        }
    }

    private void ShowCurrentImage()
    {
        // ���� �̹��� ǥ��
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(i == currentImageIndex);
        }
    }
}
