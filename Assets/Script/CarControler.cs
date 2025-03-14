using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CarControler : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private Rigidbody _rb;

    private float _speed, _accelerationLerpInterpolator,rotationInput;
    [SerializeField]
    private float _accelerationFactor, _rotationSpeed = 0.5f;
    private bool _isAccelerating;
    private float _terrainSpeedVariator;

    public float speedMax = 3;

    [SerializeField]
    private AnimationCurve _accelerationCurve;

    void Update()
    {
        rotationInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isAccelerating = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isAccelerating = false;
        }

        if (Physics.Raycast(transform.position, transform.up * -1, out var info, 1, _layerMask))
        {

            Terrain terrainBellow = info.transform.GetComponent<Terrain>();
            if (terrainBellow != null)
            {
                _terrainSpeedVariator = terrainBellow.speedVariator;
            }
            else
            {
                _terrainSpeedVariator = 1;
            }
        }
        else
        {
            _terrainSpeedVariator = 1;
        }
    }

    private void FixedUpdate()
    {

        if (_isAccelerating)
        {
            _accelerationLerpInterpolator += _accelerationFactor;
        }
        else
        {
            _accelerationLerpInterpolator -= _accelerationFactor * 2;
        }

        _accelerationLerpInterpolator = Mathf.Clamp01(_accelerationLerpInterpolator);



        _speed = _accelerationCurve.Evaluate(_accelerationLerpInterpolator) * speedMax;

        transform.eulerAngles += Vector3.up * _rotationSpeed * Time.deltaTime*rotationInput;


        _rb.MovePosition(transform.position + transform.forward * _speed * Time.fixedDeltaTime);
    }
}