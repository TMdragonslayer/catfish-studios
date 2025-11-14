
using UnityEngine;

public class PlayerDeathSettings : MonoBehaviour
{

    public bool isAlive = true;

    private Vector3 savedPosition;
    private Quaternion savedRotation;


    public void OnDeath()
    {
        isAlive = false;
        Debug.Log($"{gameObject.name} died. Settings saved.");

    }


    public void SaveCurrentSettings()
    {
        savedPosition = transform.position;
        savedRotation = transform.rotation;


        Debug.Log($"Settings saved for {gameObject.name}");
    }


    public void RestoreSettings()
    {
        transform.position = savedPosition;
        transform.rotation = savedRotation;
        isAlive = true;


        Debug.Log($"Settings restored for {gameObject.name}");
    }
}