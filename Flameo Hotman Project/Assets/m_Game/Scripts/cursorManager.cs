using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(10, 10), CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
