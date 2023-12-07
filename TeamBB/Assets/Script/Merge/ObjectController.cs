using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectController : MonoBehaviour
{
    public GameObject objectToSpawn;
    public TMP_Text fbUpgradeCostText;        // �Ҵ� ��� �ؽ�Ʈ
    public TMP_Text nbUpgradeCostText;
    public TMP_Text mbUpgradeCostText;
    private GameManager gameManager;

    //�� �Լ��� ��ư Ŭ�� �� ȣ��� ���̾�.
    public void SpawnFBObject()
    {
        //���ϴ� ��ġ�� ������Ʈ�� ��ȯ�غ�.
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
        //���ϴ� ��ġ�� ������Ʈ�� ��ȯ�غ�.
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
        //���ϴ� ��ġ�� ������Ʈ�� ��ȯ�غ�.
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
