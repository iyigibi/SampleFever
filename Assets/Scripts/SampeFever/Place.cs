
using UnityEngine;
namespace  SampleFever {
    public class Place
    {   
        internal Vector3 position;
        internal bool taken;
        internal GameObject item;
        public Place(Vector3 _position,bool _taken){
            position= _position;
            taken=_taken;
        }

        internal void setTaken(GameObject _item){
            item=_item;
            taken=true;
        }
        internal void setEmty(){
            taken=false;
            item=null;
        }

    };
}

