using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public GameObject objectToSpawn;

    // �� �Լ��� ��ư Ŭ�� �� ȣ��� ���̾�.
    public void SpawnObject()
    {
        // ���ϴ� ��ġ�� ������Ʈ�� ��ȯ�غ�.
        Instantiate(objectToSpawn, new Vector3(0, 10, 0), Quaternion.identity);
    }

    
}
