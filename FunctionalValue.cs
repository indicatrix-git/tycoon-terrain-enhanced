float FunctionalValueY(float snapX, float snapZ)
    {
        float snapY = 0;

        for (int Ci = 0, Cz = 0; Cz <= TerrainManager.instance.terrainWidth; Cz++)
        {
            for (int Cx = 0; Cx <= TerrainManager.instance.terrainWidth; Cx++, Ci++)
            {
                if (TerrainManager.instance.coords[Ci].x == snapX &&
                    TerrainManager.instance.coords[Ci].z == snapZ)
                {
                    snapY = TerrainManager.instance.coords[Ci].y;
                }
            }
        }
        return snapY;
    }
