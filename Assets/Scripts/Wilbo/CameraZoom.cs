using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraZoom : MonoBehaviour
{
    [FormerlySerializedAs("_cam")] [SerializeField] private Camera cam;
    private Vector2 _cameraClamp = new Vector2(0.5f, 30f);
    [FormerlySerializedAs("_camSize")] [SerializeField] private float camSize = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("Camera size: " + cam.orthographicSize);

        if (Input.GetKey(KeyCode.Minus))
        {
            if (cam.orthographicSize > _cameraClamp.x)
            {
                cam.orthographicSize -= camSize;
            }
        }
        if (Input.GetKey(KeyCode.Plus))
        {
            if (cam.orthographicSize > _cameraClamp.x)
            {
                cam.orthographicSize += camSize;
            }
        }
    }
}
