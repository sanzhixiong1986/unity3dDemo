using model.vo;
using UnityEngine;

namespace model.proxy
{
    using PureMVC.Patterns.Proxy;
    public class RoomProxy:Proxy
    {
        public new const string NAME = "RoomProxy";

        private ResponseVo _vo;
        public RoomProxy():base(NAME)
        {
           
        }

        public void setResVo(ResponseVo responseVo)
        {
            Debug.Log("setResVo");
            _vo = responseVo;
            SendNotification("Msg_AddLevel",1);
        }
    }
}