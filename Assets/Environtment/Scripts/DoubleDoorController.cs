using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class DoubleDoorController : MonoBehaviour, IInteractable
{
    public DoorController Door1;
    public DoorController Door2;
    public bool isOpen = false;
    public bool isLocked = false;


    public string GetInteractText()
    {
        return Door1.GetInteractText(); 
    }

    public void Interact()
    {
        if (!isLocked)
        {
            Door1.InteractDoor();
            Door2.InteractDoor();

            if (!isOpen)
            {
                AudioManager.Instance.PlaySFX("MainDoor-Open", transform.position);
                isOpen = true;
            }
            else
            {
                AudioManager.Instance.PlaySFX("MainDoor-Close", transform.position);
                isOpen = false;
            }
        }
        else
        {
            AudioManager.Instance.PlaySFX("MainDoor-Locked", transform.position);
        }
        
    }

    public void OpenLock(){
        isLocked = false;       
    }
}