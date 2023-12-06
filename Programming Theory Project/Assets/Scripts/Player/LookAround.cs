using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    [SerializeField]
    private RotationAxes axes = RotationAxes.MouseXAndY;

    private float sensitivityHor = 9.0f;
    private float sensitivityVert = 9.0f;

    private float minimumVert = -45.0f;
    private float maximumVert = 45.0f;

    private float _rotationX = 0;
    private float _rotationY = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null)
        {
            body.freezeRotation = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        switch (axes)
        {
            case RotationAxes.MouseX:
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
                break;
            case RotationAxes.MouseY:
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                _rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);

                break;
            default:
                break;
        }

    }

}
