using NUnit.Framework.Constraints;
using UnityEngine;
using System.IO;


public class TerrainManager : MonoBehaviour
{
    public static TerrainManager instance;
    public int terrainWidth, elementWidth;
    public TerrainElement terrainPrefab;
    [HideInInspector]
    public Vector3[] coords;
    [HideInInspector]
    public TerrainElement[] terrainElements;


    void Start()
    {
        instance = this;

        CreateMap();
        CreateTerrainElements();
    }


    private void Update()
    {

    }



    public void TerrainVertexUp(float snapX, float snapY, float snapZ)
    {
        for (int i = 0, z = 0; z <= terrainWidth; z++)
        {
            for (int x = 0; x <= terrainWidth; x++, i++)
            {
                if (coords[i].x == snapX && coords[i].y == snapY && coords[i].z == snapZ)
                {
                    coords[i].y = coords[i].y + 0.25f;
                }
            }
        }
        DeleteTerrainElements();
        CreateTerrainElements();
    }


    public void TerrainVertexDown(float snapX, float snapY, float snapZ)
    {
        for (int i = 0, z = 0; z <= terrainWidth; z++)
        {
            for (int x = 0; x <= terrainWidth; x++, i++)
            {
                if (coords[i].x == snapX && coords[i].y == snapY && coords[i].z == snapZ)
                {
                    coords[i].y = coords[i].y - 0.25f;
                }
            }
        }
        DeleteTerrainElements();
        CreateTerrainElements();
    }



    private void CreateMap()
    {
        coords = new Vector3[(terrainWidth + 1) * (terrainWidth + 1)];

        for (int i = 0, z = 0; z <= terrainWidth; z++)
        {
            for (int x = 0; x <= terrainWidth; x++, i++)
            {
                float y = 3.0f;
                coords[i] = new Vector3(x, y, z);
            }
        }
    }



    private void CreateTerrainElements()
    {
        int tilesPerSide = terrainWidth / elementWidth;
        terrainElements = new TerrainElement[tilesPerSide * tilesPerSide];

        for (int i = 0, z = 0; z < tilesPerSide; z++)
        {
            for (int x = 0; x < tilesPerSide; x++, i++)
            {
                TerrainElement elementInstance = Instantiate(terrainPrefab, this.transform);
                elementInstance.Initialize(x, z);
                terrainElements[i] = elementInstance;
            }
        }
    }



    private void DeleteTerrainElements()
    {
        int tilesPerSide = terrainWidth / elementWidth;

        for (int i = 0, z = 0; z < tilesPerSide; z++)
        {
            for (int x = 0; x < tilesPerSide; x++, i++)
            {
                string[] coordsLand = { x.ToString(), z.ToString() };

                GameObject goLandRegion = GameObject.Find(string.Join("_", coordsLand));
                Destroy(goLandRegion);
            }
        }
    }




}
