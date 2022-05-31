using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private Menu menu;

    private void OnTriggerEnter(Collider other)
    {
        menu.EndGame();
    }
}
