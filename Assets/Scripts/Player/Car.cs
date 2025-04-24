using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float rotationAngle = 15f;
    [SerializeField] float rotationSpeed = 5f;
    private float _horizontalInput;
    private float _initialRotationZ;
    private bool inputControl = true;
    private IReactPlayer reaction = new RepulsionReact();
    public float InitialRotationZ => _initialRotationZ;

    private RotateWheels rotateWheels;
    private WheelSmoke wheelSmoke;


    void Start()
    {
        _initialRotationZ = transform.rotation.eulerAngles.z;
        rotateWheels = GetComponent<RotateWheels>();
        wheelSmoke = GetComponent<WheelSmoke>();
    }

    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        float newX = transform.position.x + _horizontalInput * speed * Time.deltaTime;
        transform.position = new Vector2(newX, transform.position.y);

        RotateCar();
        if (rotateWheels != null && wheelSmoke != null)
        {
            rotateWheels.TurnWheels(_horizontalInput);
            wheelSmoke.PlaySmokeEffect(_horizontalInput);
        }
    }

    public void SetInputControl(bool value)
    {
        inputControl = value;
    }

    private void RotateCar()
    {
        float targetAngle = _initialRotationZ - _horizontalInput * rotationAngle;
        targetAngle = Mathf.Clamp(targetAngle, _initialRotationZ - rotationAngle, _initialRotationZ + rotationAngle);
        float smoothAngle = Mathf.LerpAngle(transform.rotation.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, smoothAngle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitEnemyCar = collision.GetComponent<IEnemyCarHitPlayer>();
        if (hitEnemyCar != null)
        {
            Vector2 direction = collision.transform.position - transform.position;
            StartCoroutine(reaction.React(this, direction));

            hitEnemyCar.CarHitPlayer(this);
        }
    }
}
