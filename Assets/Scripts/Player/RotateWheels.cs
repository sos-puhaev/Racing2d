using UnityEngine;

public class RotateWheels : MonoBehaviour
{
    [SerializeField] Transform frontLeftWheel;
    [SerializeField] Transform frontRightWheel;
    [SerializeField] float wheelTurnAngle = 30f;

    private Quaternion initialLeftRotation;
    private Quaternion initialRightRotation;

    void Start()
    {
        if (frontLeftWheel != null) initialLeftRotation = frontLeftWheel.localRotation;
        if (frontRightWheel != null) initialRightRotation = frontRightWheel.localRotation;
    }

    public void TurnWheels(float input)
    {
        float wheelRotation = input * wheelTurnAngle;

        if (frontLeftWheel != null) 
            frontLeftWheel.localRotation = initialLeftRotation * Quaternion.Euler(0, 0, -wheelRotation);

        if (frontRightWheel != null) 
            frontRightWheel.localRotation = initialRightRotation * Quaternion.Euler(0, 0, -wheelRotation);
    }
}
