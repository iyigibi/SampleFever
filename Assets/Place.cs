
using UnityEngine;
namespace  SampleFever {
    public class Place
    {   
        internal Vector3 position;
        internal bool taken;
        public Place(Vector3 _position,bool _taken){
            position= _position;
            taken=_taken;
        }

        internal void setTaken(){
            taken=true;
        }
        internal void setEmty(){
            taken=false;
        }

    };
}

