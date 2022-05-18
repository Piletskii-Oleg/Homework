using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public GameObject stairsSegment;

    private void Spawn()
    {
        Vector3 pos = gameObject.transform.parent.position;
        pos.y -= 12.77f + Random.Range(0.0f, 0.05f);
        Quaternion rotation = gameObject.transform.parent.rotation;
        Instantiate(stairsSegment, pos, rotation);
    }

    private void OnTriggerEnter()
    {
        Spawn();
        Destroy(gameObject);
    }
}
