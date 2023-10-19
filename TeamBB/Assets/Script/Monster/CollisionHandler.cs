using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // OnCollisionEnter는 충돌 시작 시 호출됩니다.
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 태그가 "SpawnedObject"인지 확인합니다.
        if (collision.gameObject.CompareTag("SpawnedObject"))
        {
            // "SpawnedObject" 태그를 가진 오브젝트와 충돌했을 때 할 작업을 여기에 작성합니다.
            // 예를 들어, 오브젝트를 삭제하거나 다른 동작을 수행할 수 있습니다.
            // 이 예제에서는 오브젝트를 삭제합니다.
            Destroy(collision.gameObject);
        }
    }
}
