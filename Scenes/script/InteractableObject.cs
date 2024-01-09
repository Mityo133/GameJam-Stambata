using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public float destructionRadius = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.DisplayInteractionMessage("Press E to interact");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.HideInteractionMessage();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DestroyObjectsInRadius();
        }
    }

    void DestroyObjectsInRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, destructionRadius);

        foreach (Collider collider in colliders)
        {
            // Destroy the objects within the radius
            Destroy(collider.gameObject);
        }
    }
}
