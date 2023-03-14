using UnityEngine;

public class IKFootSolver : MonoBehaviour
{
    [SerializeField] private LayerMask terrainLayer;
    [SerializeField] private Transform hips;
    [SerializeField] private Transform ankleIK;

    public Vector3 initialFootOffset;
    public Vector3 initialAnkleOffset;

    private void Start()
    {
        initialFootOffset = transform.localPosition;
        initialAnkleOffset = ankleIK.localPosition;
    }

    void Update()
    {
        Ray ray = new Ray(hips.position + (hips.forward * -initialAnkleOffset.x), Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 1, terrainLayer))
        {
            transform.position = hitInfo.point + Vector3.forward * initialFootOffset.z;
            transform.up = hitInfo.normal;
            
            Vector3 newPosition = hitInfo.point + Vector3.up * initialAnkleOffset.y;
            ankleIK.position = newPosition;
        }
    }
}