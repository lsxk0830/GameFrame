namespace FrameworkDesign
{
    public interface IModel : IBelongToArchitecture,ICanSetArchitecture,ICanGetUtility,ICanSendEvent
    {
        void Init();
    }

    public abstract class AbstractModel : IModel
    {
        private IArchitecture mArchitecture1;
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return mArchitecture1;  
        }
        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecture1 = architecture;
        }

        void IModel.Init()
        {
            OnInit();
        }

        protected abstract void OnInit();
    }
}


