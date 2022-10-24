using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;

    public Transform target;
    public float smoothSpeed = 0.04f;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // LateUpdate is called every frame, if the Behaviour is enabled
    void LateUpdate()
    {
        Vector3 newPosititon = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        transform.position = newPosititon;
    }
}
