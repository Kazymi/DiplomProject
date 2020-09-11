using UnityEngine;

namespace CoverShooter
{
    /// <summary>
    /// Locks mouse cursor inside the game window. 
    /// Locked by pressing left mouse button, unlocked by pressing the escape key.
    /// </summary>
    public class MouseLock : MonoBehaviour
    {
        private void Start()
        {
            LibrarySetting i = new LibrarySetting();
            i.apply();
        }
        private bool _isLocked = true;

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RaycastHit hit;
                if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 6f))
                {
                    if (hit.collider != null)
                    {
                        hit.transform.SendMessage("E", gameObject, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                
                if (_isLocked)
                {
                    PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().mainInventory.openInventory();
                    PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().characterSystemInventory.openInventory();
                   
                }
                else
                {
                    PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().mainInventory.closeInventory();
                    PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().characterSystemInventory.closeInventory();
                    PlayerLibrary.PlayerGameObject.GetComponent<PlayerInventory>().toolTip.deactivateTooltip();

                }
                _isLocked = !_isLocked;
               
            }


            if (_isLocked && !PlayerLibrary.ActivEsc)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}