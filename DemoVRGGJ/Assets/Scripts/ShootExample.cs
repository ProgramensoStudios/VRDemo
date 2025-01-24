using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;


public class ShootExample : MonoBehaviour
{
    private InputData _inputData;
    private bool _canShoot = true;

    [SerializeField] private GameObject bullet;
    [SerializeField] private float delayTime = 0.5f;
    [SerializeField] private float speed = 5f;

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
        Instantiate(bullet, transform.position, SumQuat());
    }

    private Quaternion SumQuat()
    {
        Quaternion suma = new Quaternion(transform.rotation.x + gameObject.transform.rotation.x, 
                                        transform.rotation.y + gameObject.transform.rotation.y, 
                                        transform.rotation.z + gameObject.transform.rotation.z, 
                                        transform.rotation.w + gameObject.transform.rotation.w);
        return suma;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        _canShoot = true;
    }
}
