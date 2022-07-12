using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform boderLeft;
    [SerializeField] private Transform boderRight;
    [SerializeField] private Transform boderTop;
    [SerializeField] private Transform boderBottom;


    private void Update()
    {
        Follow();
        
    }

    private void Follow()
    {
       
        Vector3 target = player.position + offset;
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(target.x, boderLeft.position.x, boderRight.position.x),
            Mathf.Clamp(target.y, boderBottom.position.y, boderTop.position.y),
            Mathf.Clamp(target.z, target.z, target.z));

        Vector3 smoothPosition = Vector3.Lerp(transform.position,boundPosition,Time.deltaTime*10);
        transform.position = smoothPosition;
        //BoderCamera();
       
    }
    private void BoderCamera()
    {
        /* if (transform.position.x <= boderLeft.position.x)
         {
             transform.position = new Vector3(boderLeft.position.x, transform.position.y, transform.position.z);
         }

         if (transform.position.x >= boderRight.position.x)
         {
             transform.position = new Vector3(boderRight.position.x, transform.position.y, transform.position.z);
         }

         if (transform.position.y <= boderBottom.position.y)
         {
             transform.position = new Vector3(transform.position.x, boderBottom.position.y, transform.position.z);
         }

         if (transform.position.y >= boderTop.position.y)
         {
             transform.position = new Vector3(transform.position.x, boderTop.position.y, transform.position.z);
         }*/

        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(transform.position.x,boderLeft.position.x,boderRight.position.x),
            Mathf.Clamp(transform.position.y,boderBottom.position.y,boderTop.position.y),
            transform.position.z);
        transform.position = boundPosition;
    }
}
