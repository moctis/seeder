using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Player : MonoBehaviour
{

    public void Start()
    {
        Debug.Log("Start");
        Shoot();
    }

    public void Shoot()
    {
        Debug.Log("We shot the sherif!");
        
    }
}
