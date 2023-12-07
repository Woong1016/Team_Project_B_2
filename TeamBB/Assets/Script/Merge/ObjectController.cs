using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectController : MonoBehaviour
{
    public GameObject objectToSpawn;
    public TMP_Text fbUpgradeCostText;        // 불닭 비용 텍스트
    public TMP_Text nbUpgradeCostText;
    public TMP_Text mbUpgradeCostText;
    private GameManager gameManager;

    //이 함수는 버튼 클릭 시 호출될 것이야.
    public void SpawnFBObject()
    {
        //원하는 위치에 오브젝트를 소환해봐.
        if (GameManager.instance != null)
        {
            if (GameManager.instance.CanFBUpgrade())
            {
                Instantiate(objectToSpawn, new Vector3(18, 14, 56), Quaternion.identity);
                GameManager.instance.DeductFBUpgradeCost();
            }
        }

        fbUpgradeCostText.text = "" + GameManager.instance.GetFBUpgradeCost();
    }

    public void SpawnNBObject()
    {
        //원하는 위치에 오브젝트를 소환해봐.
        if (GameManager.instance != null)
        {
            if (GameManager.instance.CanNBUpgrade())
            {
                Instantiate(objectToSpawn, new Vector3(2, 14, 56), Quaternion.Euler(-123, -9, 84));
                GameManager.instance.DeductNBUpgradeCost();
            }
        }

        nbUpgradeCostText.text = "" + GameManager.instance.GetNBUpgradeCost();
    }

    public void SpawnMBObject()
    {
        //원하는 위치에 오브젝트를 소환해봐.
        if (GameManager.instance != null)
        {
            if (GameManager.instance.CanMBUpgrade())
            {
                Instantiate(objectToSpawn, new Vector3(-18, 14, 56), Quaternion.identity);
                GameManager.instance.DeductMBUpgradeCost();
            }
        }

        mbUpgradeCostText.text = "" + GameManager.instance.GetMBUpgradeCost();
    }
}   
