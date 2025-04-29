using UnityEngine;

public class CursorUnlocker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // unlock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}