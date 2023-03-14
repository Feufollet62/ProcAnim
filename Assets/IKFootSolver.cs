using UnityEngine;

public class IKFootSolver : MonoBehaviour
{
    [SerializeField] private LayerMask terrainLayer;
    [SerializeField] private Transform hips;

    private Vector3 initialOffset;

    private void Start()
    {
        initialOffset = transform.localPosition;
    }

    void Update()
    {
        Ray ray = new Ray(hips.position + (hips.right * initialOffset.x), Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 2, terrainLayer))
        {
            transform.position = hitInfo.point + initialOffset;
            transform.up = hitInfo.normal;
        }
    }
}