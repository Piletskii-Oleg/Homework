using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private FirstPersonAudio fpsAudio;
    [SerializeField] private GameObject startText;
    [SerializeField] private GameObject endText;
    [SerializeField] private GameObject inputField;
    [SerializeField] private GameObject button;
    [SerializeField] private FirstPersonLook fpsLook;
    [SerializeField] private FirstPersonMovement fpsMovement;

    [HideInInspector] public int probability;

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
        gameObject.SetActive(true);
        button.SetActive(true);
        endText.SetActive(true);
        fpsLook.gameObject.transform.localRotation = Quaternion.identity;
        fpsLook.enabled = false;
        fpsMovement.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
