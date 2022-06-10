using UnityEngine;

namespace FrameworkDesign
{
    public interface ICanSayHello
    {
        void SayHello();
        void SayOther();
    }

    public class InterfaceDesignExample : MonoBehaviour, ICanSayHello
    {
        public void SayHello()
        {
            Debug.Log("Hello");
        }

        void ICanSayHello.SayOther()
        {
            Debug.Log("Other");
        }

        private void Start()
        {
            this.SayHello();

            (this as ICanSayHello).SayOther();
        }
    }

}
