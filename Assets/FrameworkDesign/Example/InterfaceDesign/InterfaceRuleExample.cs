using UnityEngine;

namespace FrameworkDesign.Example
{
    public class CanDoEveryThing
    {
        public void DoSomething1()
        {
            Debug.Log("DoSomething1");
        }

        public void DoSomething2()
        {
            Debug.Log("DoSomething2");
        }

        public void DoSomething3()
        {
            Debug.Log("DoSomething3");
        }
    }

    public interface IHasEveryThing
    {
        CanDoEveryThing CanDoEveryThing { get; }
    }

    public interface ICanDoSomething1 : IHasEveryThing
    {

    }

    public static class ICanDoSomeThing1Extensions
    {
        public static void DoSomething1(this ICanDoSomething1 self)
        {
            self.CanDoEveryThing.DoSomething1();
        }
    }

    public interface ICanDoSomething2 : IHasEveryThing
    {

    }

    public static class ICanDoSomeThing2Extensions
    {
        public static void DoSomething2(this ICanDoSomething2 self)
        {
            self.CanDoEveryThing.DoSomething2();
        }
    }

    public interface ICanDoSomething3 : IHasEveryThing
    {

    }

    public static class ICanDoSomeThing3Extensions
    {
        public static void DoSomething3(this ICanDoSomething3 self)
        {
            self.CanDoEveryThing.DoSomething3();
        }
    }

    public class InterfaceRuleExample : MonoBehaviour
    {
        public class OnlyCanDo1 : ICanDoSomething1
        {
            CanDoEveryThing IHasEveryThing.CanDoEveryThing { get; } = new CanDoEveryThing();
        }

        public class OnlyCanDo23 : ICanDoSomething2, ICanDoSomething3
        {
            CanDoEveryThing IHasEveryThing.CanDoEveryThing { get; } = new CanDoEveryThing();
        }

        private void Start()
        {
            var onlyCanDo1 = new OnlyCanDo1();
            // 可以调用 DoSomething1
            onlyCanDo1.DoSomething1();
            // 不能调用 DoSomething2 和 3 会报编译错误
            // onlyCanDo1.DoSomething2();
            // onlyCanDo1.DoSomething3();


            var onlyCanDo23 = new OnlyCanDo23();
            // 不可以调用 DoSomething1 会报编译错误
            // onlyCanDo23.DoSomething1();
            // 可以调用 DoSomething2 和 3
            onlyCanDo23.DoSomething2();
            onlyCanDo23.DoSomething3();
        }
    }
}