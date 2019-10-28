using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddText : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(GameObject obj)
    {
        var newObj = GameObject.Instantiate(prefab, transform);
        var newText = newObj.GetComponent<Text>();
        var oldText = obj.GetComponent<Text>();

        if (newText == null || oldText == null) return;
        newText.text = oldText.text;
        oldText.text = "";

        //newObj.transform.parent = transform;
    }
}
