mesh = GetComponent&lt;MeshFilter&gt;().mesh;

vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 0, 2), new Vector3(1, 0, 0),
                           new Vector3(1, 0.5f, 1), new Vector3(1, 0, 2), new Vector3(2, 0, 0), new Vector3(2, 0.5f, 1),
                           new Vector3(2, 0, 2), new Vector3(3, 0, 0), new Vector3(3, 0, 1), new Vector3(3, 0, 2) };

{
    int v = 4;

    int v0 = v; //ten vertex, na ktory sme klikli mysou
    int v1 = v + 1;
    int v2 = v - 1;
    int v3 = v + 3;
    int v4 = v - 3;
    int v5 = v + 4;
    int v6 = v + 2;
    int v7 = v - 4;
    int v8 = v - 2;

    triangles01 = new int[] { v0, v1, v5, v0, v5, v3, v0, v3, v6, v0, v6, v2, v0, v2, v7, v0, v7, v4, v0, v4, v8, v0, v8, v1 };
}

{
    int v = 7;

    int v0 = v; //ten vertex, na ktory sme klikli mysou
    int v1 = v + 1;
    int v2 = v - 1;
    int v3 = v + 3;
    int v4 = v - 3;
    int v5 = v + 4;
    int v6 = v + 2;
    int v7 = v - 4;
    int v8 = v - 2;

    triangles02 = new int[] { v0, v1, v5, v0, v5, v3, v0, v3, v6, v0, v6, v2, v0, v2, v7, v0, v7, v4, v0, v4, v8, v0, v8, v1 };
}

mesh.Clear();
mesh.vertices = vertices;
mesh.triangles = triangles01.Concat(triangles02).ToArray();
