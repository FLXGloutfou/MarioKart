using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CarControler : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private LayerMask _wallLayer;

    [SerializeField]
    private Rigidbody _rb;

    private float _speed, _accelerationLerpInterpolator,rotationInput;
    [SerializeField]
    private float _accelerationFactor, _rotationSpeed = 1f;
    private bool _isAccelerating;
    private float _terrainSpeedVariator;

    public float speedMax = 3;
    private float _currentSpeedMax;

    [SerializeField]
    private AnimationCurve _accelerationCurve;

    void Update()
    {
        _currentSpeedMax = speedMax ;
        rotationInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isAccelerating = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isAccelerating = false;
        }

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

        Debug.DrawRay(transform.position, transform.forward, Color.red, 2f);
        if (Physics.Raycast(transform.position, transform.forward, out var wall, 2, _wallLayer))
        {
            Debug.Log("ouaiggros");
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



        _speed = _accelerationCurve.Evaluate(_accelerationLerpInterpolator) * speedMax * _terrainSpeedVariator ;

        transform.eulerAngles += Vector3.up * _rotationSpeed * Time.deltaTime*rotationInput;


        _rb.MovePosition(transform.position + transform.forward * _speed * Time.fixedDeltaTime);
    }
}