using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    //public Image healthBar;
    //public Image[] healthPoints;

    //float health, maxHealth = 100;
    //float lerpSpeed;

    public static int hp = 10;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject life4;
    public GameObject life5;
    public GameObject life6;
    public GameObject life7;
    public GameObject life8;
    public GameObject life9;
    public GameObject life10;
    public GameObject GameOver; // 게임오버 화면 GameObject

    void Start()
    {
        SetGameOverScreenActive(false);
        life1.GetComponent<Image>().enabled = true;
        life2.GetComponent<Image>().enabled = true;
        life3.GetComponent<Image>().enabled = true;
        life4.GetComponent<Image>().enabled = true;
        life5.GetComponent<Image>().enabled = true;
        life6.GetComponent<Image>().enabled = true;
        life7.GetComponent<Image>().enabled = true;  
        life8.GetComponent<Image>().enabled = true;
        life9.GetComponent<Image>().enabled = true;     
        life10.GetComponent<Image>().enabled = true;
    }

    void Update()
    {
        switch (hp)
        {
            case 9:
                life1.GetComponent<Image>().enabled = false;
                break;
            case 8:
                life2.GetComponent<Image>().enabled = false;
                break;
            case 7:
                life3.GetComponent<Image>().enabled = false;
                break;
            case 6:
                life4.GetComponent<Image>().enabled = false;
                break;
            case 5:
                life5.GetComponent<Image>().enabled = false;
                break;
            case 4:
                life6.GetComponent<Image>().enabled = false;
                break;
            case 3:
                life7.GetComponent<Image>().enabled = false;
                break;
            case 2:
                life8.GetComponent<Image>().enabled = false;
                break;
            case 1:
                life9.GetComponent<Image>().enabled = false;
                break;
            case 0:
                life10.GetComponent<Image>().enabled = false;
                // 모든 라운드가 끝났을 때 클리어 화면 활성화
                SetGameOverScreenActive(true);
                break;
        }

    }
    // 클리어 화면 및 하위 객체 활성화/비활성화를 처리하는 메서드
    private void SetGameOverScreenActive(bool isActive)
    {
        GameOver.SetActive(isActive);
    }

    //void ColorChanger()
    //{
    //    Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
    //}

    //bool DisplayHealthPoint(float _health, int pointNumber)
    //{
    //    return ((pointNumber * 10) >= _health);
    //}

    //public void Damage(float damagePoints)
    //{
    //    if (health > 0)
    //        health -= damagePoints;
    //}
    //public void Heal(float healingPoints)
    //{
    //    if (health < maxHealth)
    //        health += healingPoints;
    //}


}
