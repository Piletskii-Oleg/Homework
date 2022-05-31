using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTrigger : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        Destroy(transform.parent.gameObject);
    }
}
