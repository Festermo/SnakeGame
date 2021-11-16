using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Snake target;
    public Vector3 offset;

    private void Start()
    {
        transform.position = target.transform.position + offset; //add some offset from snake to look better
    }

    private void LateUpdate()
    {
        transform.position += new Vector3(0, 0, target.speed * Time.deltaTime); // follow snake on Z axis
    }
}
