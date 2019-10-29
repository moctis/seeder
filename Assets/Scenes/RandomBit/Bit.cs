using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Bit : MonoBehaviour
{
    public BitState State = BitState.Uncertainty;
    public MeshFilter _meshFilter;
    public MeshRenderer _meshRenderer;
    private bool _value;
 
    // Start is called before the first frame update
    void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshFilter.mesh = SimpleMeshs.Plane;
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material = Materials.Black;
        UpdateMaterial();
    
        Debug.Log("Editor causes this Awake");
    }

    void Update()
    {
        UpdateMaterial();
    }
     
    private void UpdateMaterial()
    {
        switch (State)
        {
            case BitState.Off:
                _value = false;
                break;
            case BitState.On:
                _value = true;
                break;
            case BitState.Uncertainty:
                _value = SeedRandom.Seed(() => false, () => true);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        _meshRenderer.material = _value ? Materials.Black : Materials.White;
    }

    void OnMouseDown()
    {

        Debug.Log("OnMouseDown");
        switch (State)
        {
            case BitState.Uncertainty:
                State = BitState.On;
                break;
            case BitState.On:
                State = BitState.Off;
                break;
            case BitState.Off:
                State = BitState.Uncertainty;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public static class SeedRandom
{
    public static T Seed<T>(params Func<T>[] actions) 
    {
        var index = Random.Range(0, actions.Length);
        return actions[index]();
    }
}

public static class Materials
{
    public static Material Black = new Material(Shader.Find("Standard"))
    {
        color = Color.black
    };
    public static Material White = new Material(Shader.Find("Standard"))
    {
        color = Color.white
    };
}

public enum BitState
{
    Off = 0,
    On = 1,
    Uncertainty = 2,
}
