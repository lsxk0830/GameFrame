using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class InterfaceStructExample : MonoBehaviour
    {
        public interface ICustomScript
        {
            void Start();
            void Update();
            void Destory();
        }

        public abstract class CustomScript : ICustomScript
        {
            void ICustomScript.Start()
            {
                OnStart();
            }
            void ICustomScript.Update()
            {
                OnUpdate();
            }

            void ICustomScript.Destory()
            {
                OnDestroy();
            }

            protected abstract void OnStart();
            protected abstract void OnUpdate();
            protected abstract void OnDestroy();
        }

        public class MyScript : CustomScript
        {
            protected override void OnStart()
            {
                Debug.Log("OnStart");
            }

            protected override void OnUpdate()
            {
                Debug.Log("OnUpdate");
            }
            protected override void OnDestroy()
            {
                Debug.Log("OnDestroy");
            }
        }

        private void Start()
        {
            ICustomScript MyScript = new MyScript();
            MyScript.Start();
            MyScript.Update();
            MyScript.Destory();
        }
    }
}

