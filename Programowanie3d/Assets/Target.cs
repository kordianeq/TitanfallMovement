using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int HitPoints;
    public int MaxHitPoints = 50;
    public float speed = 2f;
    int currentPoint = 0;

    public Material NormMaterial;
    public Material HitMaterial;

    public GameObject[] path;

    // Start is called before the first frame update
    void Start()
    {
        HitPoints = MaxHitPoints;   
    }

    // Update is called once per frame
    void Update()
    {
        PointManager();
        GotoPoint();
    }

    void PointManager()
    {
        Vector3 myPosition = transform.position;
        Vector3 pointPosition = path[currentPoint].transform.position;

        if(Vector3.Distance(myPosition, pointPosition) <= 0.1 )
        {
            currentPoint++;
        }

        if(currentPoint >= path.Length)
        {
            currentPoint = 0;
        }
    }

    void GotoPoint()
    {
        Vector3 myPosition = transform.position;
        Vector3 pointPosition = path[currentPoint].transform.position;

        transform.position = Vector3.MoveTowards(myPosition, pointPosition, speed*Time.deltaTime);
    }

    public void TakeDamage(int hit)
    {
        HitPoints -= hit;
        gameObject.GetComponent<Renderer>().material = HitMaterial;
        Invoke("BackToNormal", 0.2f);

        if(HitPoints<=0)
        {
            Destroy(gameObject);
        }
    }

    void BackToNormal()
    {
        gameObject.GetComponent<Renderer>().material = NormMaterial;
    }
}
