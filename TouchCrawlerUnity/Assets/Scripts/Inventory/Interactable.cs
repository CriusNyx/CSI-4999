using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Transform playerActor;
    public float radius = 3f;
    bool isFocused = false;
    bool hasInteracted = false;
    public Transform interactionTransform;

    void Start()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
    }

    void Update()
    {
        if (isFocused && !hasInteracted)
        {
            float distance = Vector3.Distance(playerActor.position, interactionTransform.position);

            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    public virtual void Interact()
    {
        // Leave empty
        Debug.Log("Interacting: " + transform.name);
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        playerActor = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocused = false;
        playerActor = null;
        hasInteracted = false;
    }
}
