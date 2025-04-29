using UnityEngine;

public class CursorLocker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // lock cursor to center of game window when in game scene
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // handle loss of focus
    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
