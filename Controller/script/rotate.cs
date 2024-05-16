using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
   void FixedUpdate()
   {
        transform.Rotate(0, 0.5f, 0);
   }
}
