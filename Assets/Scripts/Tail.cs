using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public Transform SnakeHead;
    public float length;
    public GameObject tailPrefab;
    [HideInInspector]
    public List<Transform> snakeParts = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    void Awake()
    {
        positions.Add(SnakeHead.position);
    }

    void Update()
    {
        float distance = (SnakeHead.position - positions[0]).magnitude;
        if (distance > length)
        {
            Vector3 direction = (SnakeHead.position - positions[0]).normalized; //direction to the head
            positions.Insert(0, positions[0] + direction * length); //replace with current position
            positions.RemoveAt(positions.Count - 1);
            distance -= length; //not to become more than 1
        }
        for (int i = 0; i < snakeParts.Count; i++)
        {
            snakeParts[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / length); //move tail parts smoothly
        }
    }

    public void AddPart()
    {
        Transform part = Instantiate(tailPrefab.transform, positions[positions.Count - 1], Quaternion.identity, transform);
        part.gameObject.GetComponent<MeshRenderer>().material = SnakeHead.gameObject.GetComponent<MeshRenderer>().material;
        snakeParts.Add(part);
        positions.Add(part.position);
    }
}
