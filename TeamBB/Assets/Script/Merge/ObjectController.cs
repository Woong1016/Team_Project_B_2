using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public GameObject objectToSpawn;

    // �� �Լ��� ��ư Ŭ�� �� ȣ��� ���̾�.
    public void SpawnObject()
    {
        // ���ϴ� ��ġ�� ������Ʈ�� ��ȯ�غ�.
        if (GameManager.instance != null)
        {
            if (GameManager.instance.CanFBUpgrade())
            {
                Instantiate(objectToSpawn, new Vector3(18, 14, 56), Quaternion.identity);
                GameManager.instance.DeductFBUpgradeCost();
            }
        }

        
    }
}
