using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    public int xSize = 20;
    public int zSize = 20;

    Mesh mesh;

    Vector3[] vertices;
    int[] traingles;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.name = "Generated";

        CreateShape();
        UpdateMesh();
    }

    private void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * 0.3f, z * 0.3f) * 2f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        int vert = 0;
        int tris = 0;

        traingles = new int[xSize * zSize * 6];

        for(int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                traingles[tris + 0] = vert + 0;
                traingles[tris + 1] = vert + xSize + 1;
                traingles[tris + 2] = vert + 1;
                traingles[tris + 3] = vert + 1;
                traingles[tris + 4] = vert + xSize + 1;
                traingles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;

                //For visualizing use UpdateMesh in Update Method
                //yield return new WaitForSeconds(0.001f);
            }
            vert++;
        }

        //SimpleQuad();
    }

    private void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = traingles;

        mesh.RecalculateNormals();
    }

    //private void OnDrawGizmos()
    //{
    //    if(vertices == null)
    //    {
    //        return;
    //    }
    //    for(int i = 0; i < vertices.Length; i++)
    //    {
    //        Gizmos.DrawSphere(vertices[i], 0.1f);
    //    }
    //}

    private void SimpleQuad()
    {
        vertices = new Vector3[]
                {
            new Vector3(0,0,0),
            new Vector3(0,0,1),
            new Vector3(1,0,0),
            new Vector3(1,0,1)
                };

        traingles = new int[]
        {
            0, 1, 2,
            1, 3, 2
        };
    }
}
