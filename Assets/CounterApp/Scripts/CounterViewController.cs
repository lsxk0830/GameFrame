using FrameworkDesign;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour,IController
    {
        private ICounterModel mCounterModel;

        //public IArchitecture Architecture { get; set; } = CounterApp.Interface;

        private void Start()
        {
            mCounterModel = this.GetModel<ICounterModel>();

            mCounterModel.Count.RegisterOnValueChanged ( OnCountChangd );
            OnCountChangd(mCounterModel.Count.Value);

            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                // 交互逻辑
                this.SendCommand<AddCountCommand>();
            });

            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                // 交互逻辑
                this.SendCommand<SubCountCommand>();
            });
        }

        private void OnCountChangd(int newCount)
        {
            transform.Find("CountText").GetComponent<Text>().text = newCount.ToString();
        }

        private void OnDestroy()
        {
            mCounterModel.Count.UnRegisterOnValueChanged (OnCountChangd);

            mCounterModel = null;
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return CounterApp.Interface;
        }
    }

    public interface ICounterModel:IModel
    {
        BindableProperty<int> Count { get; }
    }

    public class CounterModel : AbstractModel,ICounterModel
    {
        protected override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();

            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);

            Count.RegisterOnValueChanged( count =>
            {
                storage.SaveInt("COUNTER_COUNT", count);
            });
        }

        public BindableProperty<int> Count { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

    }
}

