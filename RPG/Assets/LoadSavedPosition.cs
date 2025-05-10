/*using UnityEngine;

public class LoadSavedPosition : MonoBehaviour
{
    public float yOffset = 10f;

    void Start()
    {

        if (PlayerPrefs.HasKey("PlayerPosX"))
        {
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY") + yOffset; 
            float z = PlayerPrefs.GetFloat("PlayerPosZ");
            CharacterController cc = GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false;

            transform.position = new Vector3(x, y, z);

            if (cc != null) cc.enabled = true;

            Debug.Log("Posición del jugador cargada y ajustada: " + transform.position);
        }
    }
}
*/
