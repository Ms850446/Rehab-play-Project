using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GraphicsLineRenderer : MonoBehaviour
{

    float lineWidth = 0.05f;
    private Mesh mesh;

    

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void drawMesh(Vector3 start, Vector3 end){
        Vector3 normal = Vector3.Cross(start, end);
        Vector3 side = Vector3.Cross(normal, end-start);
        side.Normalize();
        Vector3 a = start + side * (lineWidth / 2);
        Vector3 b = start + side * (lineWidth / -2);
        Vector3 c = end + side * (lineWidth / 2);
        Vector3 d = end + side * (lineWidth / -2);
        Vector3[] vertices = new Vector3[4]{a,b,c,d};
        mesh.vertices = vertices;

    }
}
