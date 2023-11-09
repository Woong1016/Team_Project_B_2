using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    private bool isDragging = false;

    void OnMouseDown()
    {
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        }
    }
}
