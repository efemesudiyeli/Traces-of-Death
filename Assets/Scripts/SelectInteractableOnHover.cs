using System.Collections;
using UnityEngine;

public class SelectInteractableOnHover : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMaskToFind;
    private IInteractable lastInteractable = null;

    // Update is called once per frame
    void Update()
    {
        FindObjectsOnMouse();

        if (lastInteractable != null && Input.GetMouseButtonDown(0))
        {
            lastInteractable.Interact();
        }
    }

    private void FindObjectsOnMouse()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo, 100f, _layerMaskToFind))
        {
            hitInfo.collider.TryGetComponent(out IInteractable interactable);
            interactable.ActivateOutline();
            lastInteractable = interactable;
        }
        else
        {
            lastInteractable?.DisableOutline();
            lastInteractable = null;
        }
    }


}
