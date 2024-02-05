using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    public float sensitivityH = 9f;
    public float sensitivityV = 9f;

    public float minimumV= -45f;
    public float maximumV = 45f;

    private enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    [SerializeField] private RotationAxes axes;

    private float rotationVert = 0f;

    private float rotationHor = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(axes == RotationAxes.MouseY || axes == RotationAxes.MouseXAndY)
        {
            rotationVert -= sensitivityV * Input.GetAxis("Mouse Y");
            rotationVert = Mathf.Clamp(rotationVert, minimumV, maximumV);
        }
        
        if(axes == RotationAxes.MouseX || axes == RotationAxes.MouseXAndY)
        {
            transform.Rotate(0, sensitivityH * Input.GetAxis("Mouse X"), 0);
            float delta = Input.GetAxis("Mouse X") * sensitivityH;
            rotationHor = transform.localEulerAngles.y + delta;
            
        }
        transform.localEulerAngles = new Vector3(rotationVert, rotationHor, 0);
    }
}
