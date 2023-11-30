using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // OnCollisionEnter�� �浹 ���� �� ȣ��˴ϴ�.
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �±װ� "SpawnedObject"���� Ȯ���մϴ�.
        if (other.gameObject.CompareTag("SpawnedObject"))
        {
            // "SpawnedObject" �±׸� ���� ������Ʈ�� �浹���� �� �� �۾��� ���⿡ �ۼ��մϴ�.
            // ���� ���, ������Ʈ�� �����ϰų� �ٸ� ������ ������ �� �ֽ��ϴ�.
            // �� ���������� ������Ʈ�� �����մϴ�.
           
                Hpbar.hp -= 1;
               
            Destroy(other.gameObject);
        }

    }
}