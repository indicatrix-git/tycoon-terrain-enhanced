public void TerrainCollapse(int iCoordClick)
    {
        bool repeatMapTraverse = true;

        Vector3 coordClick = coordsI[iCoordClick];

        while (repeatMapTraverse)
        {
            for (int i = 0, z = 10; z <= 30; z++)
            {
                for (int x = 10; x <= 30; x++, i++)
                {
                    Vector3 mainVertex = coordsI[i];

                    if (!((mainVertex.x == 0 || mainVertex.x == 256) && (mainVertex.z == 0 || mainVertex.z == 256)))
                    {
                        float upX = mainVertex.x + 1;
                        float downX = mainVertex.x - 1;
                        float leftZ = mainVertex.z + 1;
                        float rightZ = mainVertex.z - 1;


                        Vector3 upVertex = new Vector3(upX, FunctionalVertexValueY(upX, mainVertex.z), mainVertex.z);
                        Vector3 downVertex = new Vector3(downX, FunctionalVertexValueY(downX, mainVertex.z), mainVertex.z);
                        Vector3 leftVertex = new Vector3(mainVertex.x, FunctionalVertexValueY(mainVertex.x, leftZ), leftZ);
                        Vector3 rightVertex = new Vector3(mainVertex.x, FunctionalVertexValueY(mainVertex.x, rightZ), rightZ);


                        float n1 = DeltaY(mainVertex, upVertex);
                        float n2 = DeltaY(mainVertex, downVertex);
                        float n3 = DeltaY(mainVertex, leftVertex);
                        float n4 = DeltaY(mainVertex, rightVertex);


                        if (n1 == 2 || n2 == 2 || n3 == 2 || n4 == 2)
                        {
                            if(coordClick == mainVertex)
                            {
                                coordsI[i].y = coordsI[i].y;
                            }
                            else
                            {
                                coordsI[i].y = coordsI[i].y + 1;
                            }

                            repeatMapTraverse = true;
                        }
                        else repeatMapTraverse = false;
                    }
                }
            }
        }
    }
