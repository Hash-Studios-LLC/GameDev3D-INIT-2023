using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject[] players;

    public bool yValue = false;

    public float averageDist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        List<Vector3> positions = new List<Vector3>();
        foreach (GameObject obj in players){
            positions.Add(obj.transform.position); }


        Vector3 vec = getMeanVector(positions);
        averageDist = getAverageDist(positions, transform.position); ;

        if (yValue){
            transform.position = vec;  }
        else{
            transform.position = new Vector3(vec.x, 0, vec.z); }

    }


    private float getAverageDist(List<Vector3> positions, Vector3 origin)
    {
        if (positions.Count == 0)
            return 0f;

        float sumDist = 0f;

        foreach (Vector3 pos in positions)
        {
            if (yValue)
            {
                sumDist += Vector3.Distance(pos, origin);
            }
            else
            {
                sumDist += Vector3.Distance(new Vector3(pos.x,0,pos.z), origin);
            }
            
        }
            

        return sumDist / positions.Count;
    }

        private Vector3 getMeanVector(List<Vector3> positions){
        if (positions.Count == 0)
            return Vector3.zero;

        float x = 0f;
        float y = 0f;
        float z = 0f;

        foreach (Vector3 pos in positions){
            x += pos.x;
            y += pos.y;
            z += pos.z;
        }
        return new Vector3(x / positions.Count, y / positions.Count, z / positions.Count);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
        foreach (GameObject obj in players)
        {
            Gizmos.DrawLine(transform.position, obj.transform.position);
        }

    }

}
