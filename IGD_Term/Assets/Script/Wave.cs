using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private float r;
    private Vector3[] verts;
    private Vector3 origin;
    private Mesh mesh;

    private float timeOfImpact;

    private bool shouldWave = false;
    private int waveCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        mesh = this.GetComponent<MeshFilter>().mesh;
        verts = mesh.vertices;
        origin = verts[verts.Length / 2];
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldWave)
        {
            MyWave();
            if(waveCount < 51 && waveCount > 49)
            {
                this.GetComponent<Collider>().enabled = true;
            }
            if(waveCount >= 5000)
            {
                shouldWave = false;
                waveCount = 0;
                this.GetComponent<Collider>().enabled = true;
                FinishWave();
            }
            else
            {
                waveCount++;
            }
        }
    }
    void MyWave()
    {
        for(int v = 0; v < verts.Length; v++)
        {
            r = Mathf.Sqrt((verts[v].x - origin.x) * (verts[v].x - origin.x) + (verts[v].z - origin.z) * (verts[v].z - origin.z));
            verts[v].y = 5 * Mathf.Exp(-r - (.05f * (Time.time - timeOfImpact))) * Mathf.Cos(2 * Mathf.PI * (r - 2 * (Time.time - timeOfImpact)) / (2 * Mathf.PI));
        }
        mesh.vertices = verts;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }

    void FinishWave()
    {
        for(int v = 0; v < verts.Length; v++)
        {
            verts[v].y = 0;
        }
        mesh.vertices = verts;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 temp;
        Debug.Log("Player ran through water");
        foreach(ContactPoint contact in collision.contacts)
        {
            origin = contact.point;
        }
        if(collision.relativeVelocity.magnitude > 2)
        {
            timeOfImpact = Time.time;
            shouldWave = true;
            waveCount = 0;

            temp = transform.TransformPoint(verts[verts.Length / 2]);
            origin = origin - temp;
            this.GetComponent<Collider>().enabled = false;
        }
    }
}
