using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Collider objectCollider;

    void Start()
    {
        objectCollider = GetComponent<Collider>();
    }

    void OnMouseDown()
    {
        isDragging = true;
        objectCollider.enabled = false;

        Vector3 clickPosition = Input.mousePosition;
        clickPosition.z = Camera.main.WorldToScreenPoint(transform.position).z;

        offset = transform.position - Camera.main.ScreenToWorldPoint(clickPosition);
    }

    void OnMouseUp()
    {
        isDragging = false;
        objectCollider.enabled = true;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;

            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePos) + offset;
            targetPosition.y = transform.position.y;
            transform.position = targetPosition;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TowerEvolution>() != null)
        {
            Destroy(gameObject);
        }
    }
}
