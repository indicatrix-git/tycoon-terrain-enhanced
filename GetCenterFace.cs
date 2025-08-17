public Vector3 GetCenterFace(Vector3 hitPoint)
    {
        float[] Xaxis = new float[4];
        float[] Yaxis = new float[4];
        float[] Zaxis = new float[4];

        int xx = (int)hitPoint.x; float x = hitPoint.x - xx;
        int zz = (int)hitPoint.z; float z = hitPoint.z - zz;


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

        float dx = (Xaxis[0] < Xaxis[3]) ? (Xaxis[0] + Xaxis[3]) / 2 : (Xaxis[1] + Xaxis[2]) / 2;
        float dz = (Zaxis[0] < Zaxis[1]) ? (Zaxis[0] + Zaxis[1]) / 2 : (Zaxis[3] + Zaxis[2]) / 2;

        float dy = 0;

        Yaxis[0] = FunctionalValueY(Xaxis[0], Zaxis[0]);
        Yaxis[1] = FunctionalValueY(Xaxis[1], Zaxis[1]);
        Yaxis[2] = FunctionalValueY(Xaxis[2], Zaxis[2]);
        Yaxis[3] = FunctionalValueY(Xaxis[3], Zaxis[3]);


        for (int i = 0; i < 4; i++)
        {
            if (Yaxis[0] == Yaxis[i])
            {
                dy = Yaxis[0];
            }
            else
            {
                dy = (Yaxis[i] + Yaxis[i - 1]) / 2;
            }
        }

        return new Vector3(dx, dy, dz);
    }
