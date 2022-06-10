using UnityEngine;

// 写命名空间是个好习惯
namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour, IController
    {
        /// <summary>
        /// 点击自己则隐藏
        /// </summary>
        private void OnMouseDown()
        {
            gameObject.SetActive(false);

            this.SendCommand<KillEnemyCommand>();
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return PointGame.Interface;
        }
    }
}