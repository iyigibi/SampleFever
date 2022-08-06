


namespace  SampleFever {

    public class ItemGenerator:BaseGenerator
    {
        internal int itemCount=0;
        internal float generationTime;
        internal float taskTime;
        internal float taskCompletionPercentage;
        internal bool isGenerating=false;
        internal ItemGenerator(bool _isActive,int _maxCapacity,int _generatorSpeed){
            maxCapacity=_maxCapacity;
            generatorSpeed=_generatorSpeed;
            generationTime=5.0f/generatorSpeed;
            isActive=_isActive;
        }
        internal float startGenerating(){
                isGenerating=true;
                taskTime=0;
                return generationTime;
        }
        internal void stopGenerating(){
            itemCount++;
            isGenerating=false;
        }

        internal void collectOne(){
            itemCount--;
        }


        
        internal bool isOn(){
            return (isActive && (getCapacityRemaining()>0));
        }
        public override int getCapacityRemaining(){
            return maxCapacity-itemCount;
        }
        internal float getTaskPercent(){
            float percent = taskTime/generationTime;
            if(percent>1)
            percent=1;
            return percent;
        }


        
    }

}
