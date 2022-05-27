using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject inputField;
    [SerializeField] private Monster monster;
    [SerializeField] private FirstPersonLook fpslook;
    [SerializeField] private FirstPersonMovement fpsmovement;

    private int probability;

    public void StartGame()
    {
        if (int.TryParse(inputField.GetComponent<TMP_InputField>().text, out probability))
        {
            if (probability > 0 && probability <= 100)
            {
                monster.probability = probability;
                this.gameObject.SetActive(false);
                fpslook.enabled = true;
                fpsmovement.enabled = true;
            }
            else
            {
                inputField.GetComponent<TMP_InputField>().text = string.Empty;
            }
        }
    }
}
