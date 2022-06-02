using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private Menu menu;
    [SerializeField] private AudioSource horrorAudio;

    private void OnTriggerEnter(Collider other)
    {
        menu.EndGame();
        while (horrorAudio.volume > 0)
        {
            horrorAudio.volume -= 0.00001f;
        }
    }
}
