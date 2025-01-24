using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private float _lifeTime = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.up * _speed * Time.deltaTime);
    }
}
