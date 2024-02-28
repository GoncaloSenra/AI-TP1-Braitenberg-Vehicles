using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using System.Xml.Linq;
using System.Runtime.ConstrainedExecution;

public class BlockDetectorScript : MonoBehaviour
{
    public float angle = 360;
    public bool ApplyThresholds, ApplyLimits;
    public float MinX, MaxX, MinY, MaxY;
    private bool useAngle = true;

    public float output;
    public int numObjects;
    // Start is called before the first frame update
    void Start()
    {
        output = 0;
        numObjects = 0;

        if (angle > 360)
        {
            useAngle = false;
        }
        //Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] blocks;

        GameObject closestBlock = null;
        float dis = -1.0f;
        float r = 0.0f;

        blocks = GetAllBlocks();

        output = 0;
        //Debug.Log();

        //iterar todos os objetos com a tag "Block" e verificar qual é o bloco mais próximo
        foreach (GameObject block in blocks)
        {
            if (dis == -1.0f)
            {
                dis = Vector3.Distance(transform.position, block.transform.position);
                closestBlock = block;
            }
            else if (dis > Vector3.Distance(transform.position, block.transform.position))
            {
                dis = Vector3.Distance(transform.position, block.transform.position);
                closestBlock = block;
            }
        }

        //Debug.Log(dis);

        //Debug.Log(closestBlock.transform.position);

        //aumentar velocidade da roda
        output += 1.0f / ((transform.position - closestBlock.transform.position).sqrMagnitude / dis + 1);
        //Debug.Log("BLOCKS: " + output);
        //Debug.DrawLine(transform.position, closestBlock.transform.position, Color.blue);


    }
    public virtual float GetOutput() { throw new NotImplementedException(); }

    GameObject[] GetAllBlocks()
    {
        return GameObject.FindGameObjectsWithTag("Block");
    }
}