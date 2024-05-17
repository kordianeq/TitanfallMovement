using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
        public int damage = 0;

        private void OnCollisionEnter(Collision collision)
        {
            string callTag = collision.gameObject.tag;
            

            switch (callTag)
            {
                case"DESTROY":
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                    break;
                case "Target":
                    collision.gameObject.GetComponent<Target>().TakeDamage(damage);
                    Destroy(gameObject);
                break;  
            }

        
        }

   
}
