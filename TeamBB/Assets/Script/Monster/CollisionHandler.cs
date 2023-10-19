using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // OnCollisionEnter�� �浹 ���� �� ȣ��˴ϴ�.
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� �±װ� "SpawnedObject"���� Ȯ���մϴ�.
        if (collision.gameObject.CompareTag("SpawnedObject"))
        {
            // "SpawnedObject" �±׸� ���� ������Ʈ�� �浹���� �� �� �۾��� ���⿡ �ۼ��մϴ�.
            // ���� ���, ������Ʈ�� �����ϰų� �ٸ� ������ ������ �� �ֽ��ϴ�.
            // �� ���������� ������Ʈ�� �����մϴ�.
            Destroy(collision.gameObject);
        }
    }
}
