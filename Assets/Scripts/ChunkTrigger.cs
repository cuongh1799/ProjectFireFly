//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ChunkTrigger : MonoBehaviour
//{
//    MapController controller;
//    public GameObject targetMap;
//    // Start is called before the first frame update
//    void Start()
//    {
//        controller = GetComponent<MapController>();
//    }

//    //Update is called once per frame
//    void Update()
//    {
//        Collider2D col = GetComponent<Collider2D>();    
//        OnTriggerExit2D(col);
//        OnTriggerStay2D(col);
//    }

//    public void OnTriggerStay2D(Collider2D col)
//    {
//        if (col.CompareTag("Player"))
//        {
//            controller.currentChunk = targetMap;
//        }
//    }

//    public void OnTriggerExit2D(Collider2D col)
//    {
//        if (!col.CompareTag("Player"))
//        {
//            if (controller.currentChunk != targetMap)
//            {
//                controller.currentChunk = null;
//            }
//        }
//    }
//}
