using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ksp_timer
{
    class ksp_timer : MonoBehaviour
    {
        private bool visible = false;

        // get ksp_timer instance
        public static ksp_timer instance { get; private set; }

        public bool Visible
        {
            get { return this.visible; }
            set { this.visible = value; }
        }

        protected void Awake()
        {
            instance = this;
        }

    }
}
