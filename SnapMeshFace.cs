public Vector3 SnapMeshFace(Vector3 hitPoint)
    {
        Vector3[] verticesFace;
        Vector3[] normalsFace;
        Vector2[] uvFace;
        int[] trianglesFace;

        float[] Xaxis = new float[4];
        float[] Yaxis = new float[4];
        float[] Zaxis = new float[4];

        int xx = (int)hitPoint.x; float x = hitPoint.x - xx;
        int zz = (int)hitPoint.z; float z = hitPoint.z - zz;

        float dy = 0.01f;

        if (x >= 0.0f && x <= 1.0f)
        {
            Xaxis[0] = xx;
            Xaxis[1] = xx;
            Xaxis[2] = xx + 1;
            Xaxis[3] = xx + 1;
        }


        if (z >= 0.0f && z <= 1.0f)
        {
            Zaxis[0] = zz;
            Zaxis[1] = zz + 1;
            Zaxis[2] = zz + 1;
            Zaxis[3] = zz;
        }


        Yaxis[0] = FunctionalValueY(Xaxis[0], Zaxis[0]);
        Yaxis[1] = FunctionalValueY(Xaxis[1], Zaxis[1]);
        Yaxis[2] = FunctionalValueY(Xaxis[2], Zaxis[2]);
        Yaxis[3] = FunctionalValueY(Xaxis[3], Zaxis[3]);


        verticesFace = new Vector3[]
        {
            new Vector3(Xaxis[0], Yaxis[0] + dy, Zaxis[0]),
            new Vector3(Xaxis[1], Yaxis[1] + dy, Zaxis[1]),
            new Vector3(Xaxis[2], Yaxis[2] + dy, Zaxis[2]),
            new Vector3(Xaxis[3], Yaxis[3] + dy, Zaxis[3])
        };


        trianglesFace = new int[]
        {
            0, 1, 2,
            2, 3, 0
        };


        normalsFace = new Vector3[]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };


        uvFace = new Vector2[]
        {
            new Vector2(Xaxis[0], Zaxis[0]),
            new Vector2(Xaxis[1], Zaxis[1]),
            new Vector2(Xaxis[2], Zaxis[2]),
            new Vector2(Xaxis[3], Zaxis[3])
        };


        meshFace.Clear();
        meshFace.vertices = verticesFace;
        meshFace.triangles = trianglesFace;
        meshFace.normals = normalsFace;
        meshFace.uv = uvFace;
        meshFace.RecalculateNormals();

        return GetCenterFace(hitPoint);
    }
