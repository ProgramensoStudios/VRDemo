using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 offset = new Vector3(5, 0, 0); 
    public float moveDuration = 2.0f; 

    private Vector3 pointA;
    private Vector3 pointB;
    private bool movingToB = true; 

    [SerializeField] private float timeAnimation = 1f;
    [SerializeField] private Vector3 rotationAxis = Vector3.right;
    void Start()
    {
        pointA = transform.position - offset;
        pointB = transform.position + offset;
        StartCoroutine(Move());
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Rotation());
        Destroy(gameObject, (timeAnimation + 0.5f));
    }

    private IEnumerator Move()
    {
        while (true)
        {
            Vector3 startPosition = movingToB ? pointA : pointB;
            Vector3 endPosition = movingToB ? pointB : pointA;

            float elapsedTime = 0;

            while (elapsedTime < moveDuration)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = endPosition; // Asegurarse de llegar al destino final

            movingToB = !movingToB; // Cambiar la dirección
            yield return null;
        }
    }

    IEnumerator Rotation()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(rotationAxis * 90);
        float elapsedTime = 0;

        while (elapsedTime < timeAnimation)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / timeAnimation);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation; 
    }
}
