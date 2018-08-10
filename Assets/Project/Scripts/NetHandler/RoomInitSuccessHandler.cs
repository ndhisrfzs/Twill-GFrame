using GFrame;
using GN;
using Logic;
using System.Threading.Tasks;

namespace Logic
{
    [MessageHandler(AppType.Client)]
    public class RoomInitSuccessHandler : AMHandler<Session, RoomInitSuccess.Request>
    {
        protected override async Task Run(Session entity, RoomInitSuccess.Request message)
        {
            var resp = (GetRoomInfo.Response)await entity.Call(new GetRoomInfo.Request());

            if (resp.roomInfo != null)
            {
                SceneManager.Instance.OpenScene(GFrame.Scene.Room);
                UIEventSystem.Instance.Send(new EventMsgWithValue<RoomInfo>((ushort)Event.UpdateRoomInfo, resp.roomInfo));
            }
        }
    }
}
