using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawLineRendered : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;
    [SerializeField]
    public Transform parentTransform;

    public LineRenderer lineRenderer;
    public float vertecCount = 12;
    public List<Vector3> pointList;
    
    
    [SerializeField]
    private Transform grabInteractableTransform;
    


    // Start is called before the first frame update
    void Start()
    {

        initPoints();
    }

    // Update is called once per frame
    void Update()
    {   
        for (int i=0; i<pointList.Count-1; i++){
            Debug.DrawLine(pointList[1],pointList[2]);
            /*
            float d1 = Vector3.Distance(pointList[i], grabInteractableTransform.localPosition);
            float d2 = Vector3.Distance(grabInteractableTransform.position, pointList[i]-parentTransform.localPosition);
            */
            //Debug.DrawRay(grabInteractableTransform.position, pointList[i], Color.green);
           /*
            if (d1 < 0.05f || d2 < 0.05f){
                Debug.Log("must remve");
                pointList.RemoveAt(i);
                lineRenderer.positionCount = pointList.Count;
                lineRenderer.SetPositions(pointList.ToArray());
            }
           
          */

        }
        


    }
    void initPoints(){
        pointList = new List<Vector3>();


        for (float ratio = 0; ratio <=1; ratio += 1/vertecCount){
            var tangent1 = Vector3.Lerp(point1.position, point2.position, ratio);
            var tangent2 = Vector3.Lerp(point2.position, point3.position, ratio);
            var curve = Vector3.Lerp(tangent1,tangent2,ratio);
            pointList.Add(curve);

        }
        lineRenderer.positionCount = pointList.Count;
        lineRenderer.SetPositions(pointList.ToArray());
    }
}
