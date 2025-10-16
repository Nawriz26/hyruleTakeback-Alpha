using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    [SerializeField] private float minX = -50f;
    [SerializeField] private float maxX = 100f;
    [SerializeField] private float minY = 0f;
    [SerializeField] private float maxY = 30f;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;

        float verticalSize = cam.orthographicSize;
        float horizontalSize = verticalSize * cam.aspect;

        pos.x = Mathf.Clamp(pos.x, minX + horizontalSize, maxX - horizontalSize);
        pos.y = Mathf.Clamp(pos.y, minY + verticalSize, maxY - verticalSize);

        transform.position = pos;
    }
}
