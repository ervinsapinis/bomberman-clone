using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson;
using Unity;
using UnityEngine;

namespace Assets.Scripts
{
    public class Counter : MonoBehaviour
    {
        public int playerBombCounter = 2;

        public void IncrementBombCounter()
        {
            playerBombCounter++;
        }

        public void DecrementBombCounter()
        {
            playerBombCounter--;
        }
    }
}
