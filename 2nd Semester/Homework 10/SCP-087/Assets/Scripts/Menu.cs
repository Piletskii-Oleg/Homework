using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private FirstPersonAudio fpsAudio;
    [SerializeField] private GameObject startText;
    [SerializeField] private GameObject endText;
    [SerializeField] private GameObject inputField;
    [SerializeField] private FirstPersonLook fpsLook;
    [SerializeField] private FirstPersonMovement fpsMovement;

    public int probability;

    public void StartGame()
    {
        if (int.TryParse(inputField.GetComponent<TMP_InputField>().text, out probability))
        {
            if (probability > 0 && probability <= 100)
            {
                gameObject.SetActive(false);
                startText.SetActive(false);
                inputField.SetActive(false);
                fpsLook.enabled = true;
                fpsMovement.enabled = true;
            }
            else
            {
                inputField.GetComponent<TMP_InputField>().text = string.Empty;
            }
        }
    }

    public void EndGame()
    {
        endText.SetActive(true);
        gameObject.SetActive(true);
        fpsLook.enabled = false;
        fpsMovement.enabled = false;
        fpsAudio.EndGame();
    }
}
