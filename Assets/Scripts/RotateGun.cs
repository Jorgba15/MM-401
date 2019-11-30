using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public Transform cam;

    //public Transform car;

    float smooth = 5.0f;

    void FixedUpdate() {
        
        /*float targetX = cam.rotation.x * 100;
        float targetY = cam.rotation.y * 100;
        float carZ = car.rotation.z * 100;

        
        //Debug.Log(car.rotation.z);

        Quaternion target = Quaternion.Euler(targetX, targetY, carZ);
*/

        transform.rotation = cam.transform.rotation;

    }

}
