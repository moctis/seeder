using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public GameObject targetObject;

    public void Start()
    {
        if (targetObject == null) targetObject = gameObject;
    }

}
