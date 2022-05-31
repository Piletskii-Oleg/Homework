using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject stairsSegment;
    [SerializeField] private MonsterTrigger[] monsterTriggers;

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
        foreach (var trigger in monsterTriggers)
        {
            trigger.isEntered = false;
        }

        Destroy(gameObject);
    }
}
