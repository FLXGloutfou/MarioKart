using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CarControler : MonoBehaviour
{

    //Mapping
    [SerializeField]
    private string _accelerateInput, _directionalInput;

    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private LayerMask _wallLayer;

    [SerializeField]
    private Rigidbody _rb;

    private float _speed, _accelerationLerpInterpolator, rotationInput;
    [SerializeField]
    private float _accelerationFactor, _rotationSpeed = 1f;
    private bool _isAccelerating;
    private float _terrainSpeedVariator;

    public float speedMax = 3, coinSpeed;
    private float _currentSpeedMax;

    [SerializeField]
    private AnimationCurve _accelerationCurve;

    void Update()
    {
        _currentSpeedMax = speedMax;
        rotationInput = Input.GetAxis(_directionalInput);

        float accelerationInput = Input.GetAxis(_accelerateInput);
        _isAccelerating = accelerationInput > 0f;

        if (Physics.Raycast(transform.position, Vector3.down, out var info, 10, _layerMask))
        {

            Terrain terrainBellow = info.collider.GetComponent<Terrain>();
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

        if (Physics.Raycast(transform.position, transform.forward, out var wall, 1, _wallLayer))
        {
            speedMax = 0;
        }
        else
        {
            speedMax = _currentSpeedMax;
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



        _speed = _accelerationCurve.Evaluate(_accelerationLerpInterpolator) * speedMax * (1 + coinSpeed) * _terrainSpeedVariator;

        transform.eulerAngles += Vector3.up * _rotationSpeed * Time.deltaTime * rotationInput;


        _rb.MovePosition(transform.position + transform.forward * _speed * Time.fixedDeltaTime);
    }
}