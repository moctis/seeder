using System.IO;

using UnityEngine;

public static class SimpleMeshs
{
    private static Mesh _plane;

    public static Mesh Plane = CreatePlane(1, 1);

    private static Mesh CreatePlane(float width, float height)
    {
        var mesh = new Mesh();
        var vertices = new Vector3[4]
        {
            new Vector3(0, 0, 0),
            new Vector3(width, 0, 0),
            new Vector3(0, 0, height),
            new Vector3(width, 0, height)
        };
        mesh.vertices = vertices;

        var tris = new int[6]
        {
            // lower left triangle
            0, 2, 1,
            // upper right triangle
            2, 3, 1
        };
        mesh.triangles = tris;

        var normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        mesh.normals = normals;

        var uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        mesh.uv = uv;
        return mesh;
    }
}