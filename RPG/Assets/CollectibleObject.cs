using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    public GameObject objectInPlayer;
    public float floatHeight = 0.5f;
    public float floatSpeed = 1.0f;
    public float rotationSpeed = 50f;

    public bool isCollected = false;
    private float initialY;

    void Start()
    {
        initialY = transform.position.y;
    }

    void Update()
    {
        if (isCollected) return;

        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        float newY = initialY + yOffset;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCollected) return;

        if (other.CompareTag("Player"))
        {
            CollectObject();
        }
    }

    void CollectObject()
    {
        isCollected = true;

        if (objectInPlayer != null)
            objectInPlayer.SetActive(true);

        Destroy(gameObject);
    }
}
