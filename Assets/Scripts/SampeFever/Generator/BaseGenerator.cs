
namespace  SampleFever {
    public abstract class BaseGenerator:IHasCapacity
    {
        public abstract int getCapacityRemaining();
        internal bool isActive;
        internal int maxCapacity;
        internal int generatorSpeed;
        

    }
}
