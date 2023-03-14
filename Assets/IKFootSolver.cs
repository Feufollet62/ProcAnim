using UnityEngine;

public class IKFootSolver : MonoBehaviour
{
    [SerializeField] private LayerMask terrainLayer;
    [SerializeField] private Transform hips;

    public Vector3 initialOffset;

    private void Start()
    {
        initialOffset = transform.localPosition;
    }

    void Update()
    {
        Ray ray = new Ray(hips.position + (hips.forward * -initialOffset.x), Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 1, terrainLayer))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.green);

            Vector3 newPosition = hitInfo.point + transform.up * initialOffset.y;
            
            transform.position = newPosition;
            transform.up = hitInfo.normal;
            
            Debug.DrawLine(ray.origin, newPosition, Color.magenta);
        }
    }
}