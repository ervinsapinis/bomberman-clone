using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class Destroyable : MonoBehaviour
    {
        [SerializeField] public Animator die;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.GetComponent<fuseScript>().fuseTimer = 0;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.transform.name == "player")
            {
                Debug.Log("Player is kill. No");
                die.SetTrigger("death");
            }
        }

        public void DestroyMe()
        {
            Destroy(gameObject);
        }
    }
}
