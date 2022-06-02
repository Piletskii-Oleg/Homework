using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    public bool isEntered = false;
    [SerializeField] private Menu menu;
    [SerializeField] private GameObject monster;
    [SerializeField] private AudioSource horrorAudio;
    [SerializeField] private AudioClip monsterSound;

    private void OnTriggerEnter(Collider other)
    {
        if (!isEntered)
        {
            float probability = menu.probability;
            var random = Random.value;
            if (probability / 100 >= random)
            {
                var collider = monster.GetComponent<SphereCollider>();
                var renderer = monster.GetComponent<MeshRenderer>();
                renderer.enabled = true;
                collider.enabled = true;
                horrorAudio.Stop();
                horrorAudio.PlayOneShot(monsterSound);
            }

            isEntered = true;
        }
    }
}
