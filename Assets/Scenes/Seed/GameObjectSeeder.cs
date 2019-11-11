using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class GameObjectSeeder : MonoBehaviour
{
    public GameObject Original;
    public Transform Port;
    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Instantiate()
    {
        Target = Instantiate(Original, Port.position, Port.rotation);
        Target.transform.localScale = Original.transform.localScale;
    }
}
