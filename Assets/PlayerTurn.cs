using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    public float sensitivityH = 9f;
    public float sensitivityV = 9f;

    public float minimumV= -45f;
    public float maximumV = 45f;

    private float rotationVert = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, sensitivityH * Input.GetAxis("Mouse X"), 0);
        rotationVert -= sensitivityV * Input.GetAxis("Mouse Y");
        rotationVert = Mathf.Clamp(rotationVert, minimumV, maximumV);

        float delta = Input.GetAxis("Mouse X") * sensitivityH;
        float rotationHor = transform.localEulerAngles.y + delta;
        transform.localEulerAngles = new Vector3(rotationVert, rotationHor, 0);
        
    }
}
