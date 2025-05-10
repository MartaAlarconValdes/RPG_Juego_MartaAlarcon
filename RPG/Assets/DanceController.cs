using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionController : MonoBehaviour
{
    public GameObject initialPlayer;
    public GameObject newCharacter;

    public Camera thirdPersonCamera;
    public Camera frontCamera;

    public GameObject uiElementToHide;

    public Transform playerReturnPoint;

    private Animator newCharacterAnimator;
    private bool hasTriggered = false;

    void Start()
    {
        newCharacter.SetActive(false);
        frontCamera.enabled = false;
        newCharacterAnimator = newCharacter.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;
        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            StartCoroutine(HandleDanceSequence());
        }
    }

    private IEnumerator HandleDanceSequence()
    {
        // Desactivar jugador original y su cámara
        initialPlayer.SetActive(false);
        thirdPersonCamera.enabled = false;
        if (uiElementToHide != null)
            uiElementToHide.SetActive(false);

        // Activar nuevo personaje y su cámara
        newCharacter.SetActive(true);
        frontCamera.enabled = true;

        // Activar animación de baile
        newCharacterAnimator.SetBool("Dancing", true);

        float danceDuration = 10f;
        yield return new WaitForSeconds(danceDuration);

        // Finalizar animación de baile
        newCharacterAnimator.SetBool("Dancing", false);
        newCharacter.SetActive(false);
        frontCamera.enabled = false;

        // Mover al jugador antes de activarlo
        if (playerReturnPoint != null)
        {
            // Si usa CharacterController, deshabilitarlo momentáneamente
            CharacterController cc = initialPlayer.GetComponent<CharacterController>();
            if (cc != null)
                cc.enabled = false;

            initialPlayer.transform.position = playerReturnPoint.position;
            initialPlayer.transform.rotation = playerReturnPoint.rotation;

            // Volver a habilitar CharacterController
            if (cc != null)
                cc.enabled = true;
        }

        // Reactivar jugador original
        initialPlayer.SetActive(true);
        thirdPersonCamera.enabled = true;
        if (uiElementToHide != null)
            uiElementToHide.SetActive(true);

        hasTriggered = true;
    }
}
