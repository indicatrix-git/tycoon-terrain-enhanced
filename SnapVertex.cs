    public Vector3 SnapVertex(Vector3 hitPoint)
    {
        float snapX = 0, snapY = 0, snapZ = 0;

        int xx = (int)hitPoint.x; float x = hitPoint.x - xx;
        int zz = (int)hitPoint.z; float z = hitPoint.z - zz;

        if (x >= 0.0f && x <= 0.5f) { snapX = xx; }
        else snapX = xx + 1;

        if (z >= 0.0f && z <= 0.5f) { snapZ = zz; }
        else snapZ = zz + 1;

        snapY = FunctionalValueY(snapX, snapZ);
        snapSphere.transform.position = new Vector3(snapX, snapY, snapZ);

        return new Vector3(snapX, snapY, snapZ);
    }
