using UnityEngine;
namespace  SampleFever {
    
    public interface IHasCapacity {
        int getCapacityRemaining();
    }
    public interface IHasTable {
        Vector3 getTablePossition();
    }
}