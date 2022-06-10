using UnityEngine;

// д�����ռ��Ǹ���ϰ��
namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour, IController
    {
        /// <summary>
        /// ����Լ�������
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