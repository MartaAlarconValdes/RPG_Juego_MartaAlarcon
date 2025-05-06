using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    public GameObject player;  
    public float pickupDistance = 2.0f;  
    public GameObject objectInPlayer;

    public float floatHeight = 0.5f;  
    public float floatSpeed = 1.0f;  

    public float rotationSpeed = 50f; 

    private bool isCollected = false;
    private float initialY;  

    void Start()
    {
        initialY = transform.position.y;
    }

    void Update()
    {
        if (!isCollected)
        {
            // Flotación hacia arriba y hacia abajo, pero asegurándose que no pase del terreno
            float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;

            // Asegurarnos de que la posición Y nunca baje de su posición inicial
            float newY = initialY + yOffset;

            // Actualizamos la posición del objeto, limitando la Y para que no baje demasiado
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Rotación constante sobre sí mismo
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
        if (Vector3.Distance(player.transform.position, transform.position) < pickupDistance && !isCollected)
        {
            CollectObject();
        }
    }

    void CollectObject()
    {
        

        Destroy(gameObject);
        objectInPlayer.SetActive(true);    
        isCollected = true;
    }
}
