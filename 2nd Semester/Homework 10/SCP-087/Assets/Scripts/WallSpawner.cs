using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wall;

    private void OnTriggerEnter(Collider other)
    {
        var collider = wall.GetComponent<MeshCollider>();
        var renderer = wall.GetComponent<MeshRenderer>();

        collider.enabled = true;
        renderer.enabled = true;
    }
}
