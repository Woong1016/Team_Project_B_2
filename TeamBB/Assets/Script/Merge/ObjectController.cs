using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public GameObject objectToSpawn;

    // 이 함수는 버튼 클릭 시 호출될 것이야.
    public void SpawnObject()
    {
        // 원하는 위치에 오브젝트를 소환해봐.
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
