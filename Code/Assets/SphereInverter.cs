using UnityEngine;

public class SphereInverter : MonoBehaviour
{
    private void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        if (meshFilter != null && meshFilter.mesh != null)
        {
            // Reverse the normals of the sphere's mesh
            Vector3[] normals = meshFilter.mesh.normals;
            for (int i = 0; i < normals.Length; i++)
            {
                normals[i] = -normals[i];
            }
            meshFilter.mesh.normals = normals;

            // Reverse the winding order of the triangles
            int[] triangles = meshFilter.mesh.triangles;
            for (int i = 0; i < triangles.Length; i += 3)
            {
                int temp = triangles[i + 0];
                triangles[i + 0] = triangles[i + 1];
                triangles[i + 1] = temp;
            }
            meshFilter.mesh.triangles = triangles;
            
        }
        else
        {
            Debug.LogError("SphereInverter: Mesh or MeshFilter not found!");
        }
    }
}