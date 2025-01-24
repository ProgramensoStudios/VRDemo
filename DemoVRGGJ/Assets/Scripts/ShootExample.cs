using System.Collections;
using UnityEngine;
using UnityEngine.XR;


public class ShootExample : MonoBehaviour
{
    private InputData _inputData;
    private bool _canShoot = true;

    [SerializeField] private float delayTime = 0.5f;

    private void Start()
    {
        _inputData = GetComponent<InputData>();
    }

    private void Update()
    {
        _inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool ispress);
        if (ispress && _canShoot)
        {
            Shoot();
            _canShoot = false;
            StartCoroutine(Delay());
        }
    }

    private void Shoot()
    {
        Debug.Log("Disparo");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        _canShoot = true;
    }
}
