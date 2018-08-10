using GFrame;
using Logic;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIRoomPanel : UIBehaviour
{
    private bool isPlaying = false;
    private RoomInfo room_info = null;
	protected override void InitUI()
	{
		mUIComponents = m_IComponents as UIRoomPanelComponents;
    }

    private void OnEnable()
    {
        RegisterInvoke();
    }

    /// <summary>
    /// 注册Socket接口
    /// </summary>
    private void RegisterInvoke()
    {
        //NetworkManager.Instance.Get<GameClient>().Client.RegisterInvokeInstance(null, this, "UpdateRoom", typeof(RoomInfo));
        //NetworkManager.Instance.Get<GameClient>().Client.RegisterInvokeInstance(null, this, "LeaveResult", typeof(bool));
        //NetworkManager.Instance.Get<GameClient>().Client.RegisterInvokeInstance(null, this, "DiscardResult", typeof(bool));
    }

    protected override void RegisterUIEvent()
    {
        mUIComponents.Discard_Button.onClick.AddListener(() =>
        {
            var cards = GetCards();
            //NetworkManager.Instance.Get<GameClient>().Client.BeginInvokeServiceService((int)ServerCommand.Discard, new object[] { cards });
        });

        mUIComponents.Abandon_Button.onClick.AddListener(() =>
        {
            //NetworkManager.Instance.Get<GameClient>().Client.BeginInvokeServiceService((int)ServerCommand.Pass, new object[] { });
        });

        mUIComponents.Prompt_Button.onClick.AddListener(() =>
        {
            Prompt();
        });
        mUIComponents.ResultBack_Button.onClick.AddListener(() =>
        {
            SceneManager.Instance.OpenScene(Scene.Main);
        });
        mUIComponents.Ready_Button.onClick.AddListener(() => {
            //NetworkManager.Instance.Get<GameClient>().Client.BeginInvokeServiceService((int)ServerCommand.Ready, new object[] { });
        });
        mUIComponents.Setting_Button.onClick.AddListener(() => {
            SceneManager.Instance.OpenScene(Scene.Setting);
        });
        mUIComponents.Leave_Button.onClick.AddListener(() => {
            //NetworkManager.Instance.Get<GameClient>().Client.BeginInvokeServiceService((int)ServerCommand.Leave, new object[] { });
        });
        mUIComponents.ResultShare_Button.onClick.AddListener(() => {
            byte[] imageBytes = ScreenShot.GetScreenShot(1280 * 720, 75);
            byte[] thumbBytes = ScreenShot.GetScreenShot(426 * 240, 75);

            WXSDK.ShareImage(imageBytes, thumbBytes, WXShareType.WXSceneSession);
        });

        RegisterEvent(Event.UpdateRoomInfo, (msg) =>
        {
            EventMsgWithValue<RoomInfo> event_msg = msg as EventMsgWithValue<RoomInfo>;
            UpdateRoom(event_msg.value);
        });
    }

    ///// <summary>
    ///// 更新Room信息
    ///// </summary>
    ///// <param name="room_info"></param>
    //[MethodType(MethodTypeEnum.InvokeForServerRequest)]
    //[CommandID((int)ClientCommand.UpdateRoom)]
    public void UpdateRoom(RoomInfo room_info)
    {
        if (room_info != null)
        {
            room_info.InitSort(UserData.Instance.user.uid);
            bool init = (this.room_info == null);

            this.room_info = room_info;
            UserData.Instance.CorrectTime(room_info.now);
            if (init)
            {
                SendMsg(Event.LoadingUpdate);
                InitGameInfo();
            }

            //准备和发牌状态下需要刷新玩家信息
            if (init || room_info.game_state == GameState.Ready || room_info.game_state == GameState.DealCard)
                InitPlayerInfo();
            //出牌和发牌 结束状态下需要刷新出牌状态
            if ((init && room_info.game_state != GameState.Ready) || room_info.game_state == GameState.Discard || room_info.game_state == GameState.DealCard || room_info.game_state == GameState.GameOver)
                DiscardInit(room_info);
            //发牌状态需要处理发牌动画
            if ((init && room_info.game_state != GameState.Ready) || room_info.game_state == GameState.DealCard)
                StartCoroutine(InitHandCard());
            //游戏结束需要显示结果
            if (room_info.game_state == GameState.GameOver)
                StartCoroutine(ShowResult());
        }
    }

    ///// <summary>
    ///// 出牌
    ///// </summary>
    ///// <param name="result"></param>
    //[MethodType(MethodTypeEnum.InvokeWhenServerResponse)]
    //[CommandID((int)ServerCommand.Discard)]
    //public void DiscardResult(bool result)
    //{
    //    if (!result)
    //    {
    //        SendMsg(Event.ShowToast, "牌型错误");
    //    }
    //}

    ///// <summary>
    ///// 离开房间
    ///// </summary>
    ///// <param name="result"></param>
    //[MethodType(MethodTypeEnum.InvokeWhenServerResponse)]
    //[CommandID((int)ServerCommand.Leave)]
    //public void LeaveResult(bool result)
    //{
    //    if (!result)
    //    {
    //        SendMsg(Event.ShowToast, "离开房间失败");
    //    }
    //    else
    //    {
    //        SceneManager.Instance.OpenScene(Scene.Main);
    //    }
    //}


    private void InitGameInfo()
    {
        mUIComponents.RoomKey_Text.text = room_info.key.ToString();
        if (room_info.game == Games.Classical)
        {
            mUIComponents.Game_Text.text = "传统双扣";
        }
        else
        {
            mUIComponents.Game_Text.text = "千变双扣";
        }

        if(room_info.game_type == GameType.Friend)
        {
            mUIComponents.GameType_Text.text = "好友包房";
        }
        else
        {
            mUIComponents.GameType_Text.text = "随机匹配";
        }

        //if(room_info.model_type == ModelType.Normal)
        //{
        //    mUIComponents.GameModel_Text.text = "普通模式";
        //}
        //else
        //{
        //    mUIComponents.GameModel_Text.text = "火拼模式";
        //}
    }

    /// <summary>
    /// 初始化玩家信息
    /// </summary>
    public void InitPlayerInfo()
    {
        var players = room_info.players;
        for (int i = 0; i < 4; i++)
        {
            var player = players[i];
            if (player == null)
                continue;

            switch (i)
            {
                case 0:
                    mUIComponents.P1Name_Text.text = player.name;
                    mUIComponents.P1Score_Text.text = player.score.ToString();
                    mUIComponents.P1Ready_Image.gameObject.SetActive(player.is_ready);
                    mUIComponents.Ready_Button.gameObject.SetActive(!player.is_ready);
                    break;
                case 1:
                    mUIComponents.P2Name_Text.text = player.name;
                    mUIComponents.P2Score_Text.text = player.score.ToString();
                    mUIComponents.P2Ready_Image.gameObject.SetActive(player.is_ready);
                    mUIComponents.P2Info_Image.gameObject.SetActive(true);
                    break;
                case 2:
                    mUIComponents.P3Name_Text.text = player.name;
                    mUIComponents.P3Score_Text.text = player.score.ToString();
                    mUIComponents.P3Ready_Image.gameObject.SetActive(player.is_ready);
                    mUIComponents.P3Info_Image.gameObject.SetActive(true);
                    break;
                case 3:
                    mUIComponents.P4Name_Text.text = player.name;
                    mUIComponents.P4Score_Text.text = player.score.ToString();
                    mUIComponents.P4Ready_Image.gameObject.SetActive(player.is_ready);
                    mUIComponents.P4Info_Image.gameObject.SetActive(true);
                    break;
            }
        }
    }

    private void HideReady()
    {
        mUIComponents.P1Ready_Image.gameObject.SetActive(false);
        mUIComponents.P2Ready_Image.gameObject.SetActive(false);
        mUIComponents.P3Ready_Image.gameObject.SetActive(false);
        mUIComponents.P4Ready_Image.gameObject.SetActive(false);
    }

    /// <summary>
    /// 初始化手牌（发牌动画）
    /// </summary>
    /// <returns></returns>
    private IEnumerator InitHandCard()
    {
        HideReady();
        isPlaying = true;
        AudioManager.Instance.PlayEffect("Sound/GAME_START");

        var players = room_info.players;

        mUIComponents.P2CardNum_Text.text = players[1].hand_card_num.ToString();
        mUIComponents.P2HandCard_Image.gameObject.SetActive(true);
        mUIComponents.P3CardNum_Text.text = players[2].hand_card_num.ToString();
        mUIComponents.P3HandCard_Image.gameObject.SetActive(true);
        mUIComponents.P4CardNum_Text.text = players[3].hand_card_num.ToString();
        mUIComponents.P4HandCard_Image.gameObject.SetActive(true);

        mUIComponents.P2Info_Image.gameObject.SetActive(true);
        mUIComponents.P3Info_Image.gameObject.SetActive(true);
        mUIComponents.P4Info_Image.gameObject.SetActive(true);

        mUIComponents.HandCardGrid_Transform.gameObject.SetActive(true);
        var cards = players[0].show_cards;
        foreach(var card in cards)
        {
            CardManager.Instance.CreateCard(card).transform.SetParentAndInit(mUIComponents.HandCardGrid_Transform);
            if (room_info.game_state == GameState.DealCard)
            {
                yield return new WaitForSeconds(0.03f);
            }
        }

        DiscardInit(room_info);
    }
     
   

    private Text Timer_Text;
    /// <summary>
    /// 初始化出牌
    /// </summary>
    /// <param name="room_info"></param>
    private void DiscardInit(RoomInfo room_info)
    {
        var players = room_info.players;
        if(room_info.discard_info.pre_discard_uid > 0)
        {
            ShowDiscard(players);
        }
        //设置出牌玩家状态
        for (int i = 0; i < players.Length; i++)
        {
            if(room_info.discard_info.cur_uid == players[i].uid)
            {
                CloseAllTimer();
                switch (i)
                {
                    case 0:
                        //自己出牌，先把桌上牌回收
                        RecoverCards(mUIComponents.P1Table_Transform);
                        mUIComponents.Abandon_Button.interactable = !(room_info.discard_info.pre_discard_uid == room_info.discard_info.cur_uid);
                        mUIComponents.ButtonBar_Transform.gameObject.SetActive(true);
                        mUIComponents.P1Light_Image.gameObject.SetActive(true);
                        Timer_Text = mUIComponents.P1Time_Text;
                        break;
                    case 1:
                        mUIComponents.P2Light_Image.gameObject.SetActive(true);
                        Timer_Text = mUIComponents.P2Time_Text;
                        break;
                    case 2:
                        mUIComponents.P3Light_Image.gameObject.SetActive(true);
                        Timer_Text = mUIComponents.P3Time_Text;
                        break;
                    case 3:
                        mUIComponents.P4Light_Image.gameObject.SetActive(true);
                        Timer_Text = mUIComponents.P4Time_Text;
                        break;
                }
            }
        }
    }

    /// <summary>
    /// 所有计时器关闭
    /// </summary>
    private void CloseAllTimer()
    {
        mUIComponents.ButtonBar_Transform.gameObject.SetActive(false);
        mUIComponents.P1Light_Image.gameObject.SetActive(false);
        mUIComponents.P2Light_Image.gameObject.SetActive(false);
        mUIComponents.P3Light_Image.gameObject.SetActive(false);
        mUIComponents.P4Light_Image.gameObject.SetActive(false);
    }

    /// <summary>
    /// 重置手牌
    /// </summary>
    private void ResetHandCard(List<byte> cards, bool canSelected = true)
    {
        //回收手牌
        RecoverCards(mUIComponents.HandCardGrid_Transform);

        //重新赋值
        //var players = room_info.players;
        //var cards = players[0].show_cards;
        foreach (var card in cards)
        {
            var card_trans = CardManager.Instance.CreateCard(card).transform;
            card_trans.SetParentAndInit(mUIComponents.HandCardGrid_Transform);
            card_trans.GetComponent<SelectCard>().enabled = canSelected;
        }
        mUIComponents.HandCardGrid_Transform.GetComponent<HandCardGrid>().old_child = -1;
    }

    /// <summary>
    /// 出牌显示
    /// </summary>
    /// <param name="players"></param>
    private void ShowDiscard(PlayerInfo[] players)
    {
        if(isPlaying && room_info.discard_info.pre_discard_uid != room_info.discard_info.pre_uid)
        {
            //pass
            AudioManager.Instance.PlayEffect("Sound/PASS_CARD");
            return;
        }

        for (int i = 0; i < 4; i++)
        {
            if(players[i].uid == room_info.discard_info.pre_discard_uid)
            {
                RecoverCards();
                List<CombineResult> combines;
                if (room_info.game.IsMetallic())
                {
                    combines = TwillLogic.CheckCombines(room_info.discard_info.pre_discard_cards);
                }
                else
                {
                    combines = new List<CombineResult>() { TwillLogic.CheckCombine(room_info.discard_info.pre_discard_cards) };
                }

                foreach (var combine in combines)
                {
                    if (combine != null)
                    {
                        if (combine.combine == Combine.Bomb)
                        {
                            //炸弹
                            AudioManager.Instance.PlayEffect("Sound/BOMB");
                        }
                        else
                        {
                            //普通出牌
                            AudioManager.Instance.PlayEffect("Sound/OUT_CARD");
                        }
                    }
                }

                switch (i)
                {
                    case 0:
                        ResetHandCard(players[i].show_cards, true);
                        TableDiscard(room_info.discard_info.pre_discard_cards, mUIComponents.P1Table_Transform);
                        break;
                    case 1:
                        TableDiscard(room_info.discard_info.pre_discard_cards, mUIComponents.P2Table_Transform);
                        mUIComponents.P2CardNum_Text.text = room_info.players[i].hand_card_num.ToString();
                        break;
                    case 2:
                        TableDiscard(room_info.discard_info.pre_discard_cards, mUIComponents.P3Table_Transform);
                        mUIComponents.P3CardNum_Text.text = room_info.players[i].hand_card_num.ToString();
                        break;
                    case 3:
                        TableDiscard(room_info.discard_info.pre_discard_cards, mUIComponents.P4Table_Transform);
                        mUIComponents.P4CardNum_Text.text = room_info.players[i].hand_card_num.ToString();
                        break;
                }
            }
        }

        if (players[0].over_index > 0)
        {
            ResetHandCard(players[2].show_cards, false);
        }
    }
    /// <summary>
    /// 桌子显示牌
    /// </summary>
    /// <param name="cards"></param>
    /// <param name="table"></param>
    private void TableDiscard(List<byte> cards, Transform table)
    {
        if (cards == null || cards.Count <= 0)
            return;

        foreach (var card in cards)
        {
            var card_go = CardManager.Instance.CreateCard(card);
            card_go.transform.SetParentAndInit(table);
        }
    }

    /// <summary>
    /// 回收牌
    /// </summary>
    private void RecoverCards()
    {
        RecoverCards(mUIComponents.P1Table_Transform);
        RecoverCards(mUIComponents.P2Table_Transform);
        RecoverCards(mUIComponents.P3Table_Transform);
        RecoverCards(mUIComponents.P4Table_Transform);
    }

    /// <summary>
    /// 回收单个玩家桌上牌
    /// </summary>
    /// <param name="trans"></param>
    private void RecoverCards(Transform trans)
    {
        List<GameObject> recovers = new List<GameObject>();
        foreach (Transform tran in trans) 
        {
            recovers.Add(tran.gameObject);
        }

        foreach (var recover in recovers)
        {
            CardManager.Instance.Despawn(recover);
        }
    }

    /// <summary>
    /// 倒计时更新
    /// </summary>
    public void Update()
    {
        if (isPlaying && Timer_Text != null)
        {
            var time = ((int)(room_info.discard_info.wait_time - UserData.Instance.server_time).TotalSeconds);
            if (time < 0) time = 0;
            Timer_Text.text = time.ToString();
        }
    }

    /// <summary>
    /// 获取要出的牌
    /// </summary>
    /// <returns></returns>
    private List<byte> GetCards()
    {
        List<byte> discards = new List<byte>();
        var hand_cards = room_info.players[0].show_cards;
        int index = 0;
        foreach (Transform child in mUIComponents.HandCardGrid_Transform)
        {
            var select_card = child.GetComponent<SelectCard>();
            if (select_card.isSelected)
            {
                discards.Add(hand_cards[index]);
            }
            index++;
        }

        return discards;
    }

    /// <summary>
    /// 提示
    /// </summary>
    private void Prompt()
    {
        var hand_cards = room_info.players[0].show_cards;
        List<byte> cards;
        if (room_info.discard_info.pre_discard_uid > 0 && room_info.discard_info.pre_discard_uid != room_info.discard_info.cur_uid)
        {
            cards = TwillAI.ChooseCard(room_info.game, hand_cards, room_info.discard_info.pre_discard_cards);
        }
        else
        {
            cards = TwillAI.ChooseCard(room_info.game, hand_cards, null);
        }

        if(cards != null)
        {
            ShowPromptCards(cards);
        }
    }
    /// <summary>
    /// 显示提示的牌
    /// </summary>
    /// <param name="cards"></param>
    private void ShowPromptCards(List<byte> cards)
    {
        foreach (Transform child in mUIComponents.HandCardGrid_Transform)
        {
            byte card = byte.Parse(child.name);
            var select_card = child.GetComponent<SelectCard>();
            if (cards.Contains(card))
            {
                if (!select_card.isSelected)
                {
                    select_card.SelectMovie();
                }
                cards.Remove(card);
            }
            else
            {
                if (select_card.isSelected)
                {
                    select_card.SelectMovie();
                }
            }
        }
    }

    private IEnumerator ShowResult()
    {
        isPlaying = false;
        yield return new WaitForSeconds(1f);

        AudioManager.Instance.PlayEffect("Sound/GAME_END");

        mUIComponents.P1RName_Text.text = room_info.players[0].name;
        mUIComponents.P1RId_Text.text = room_info.players[0].uid.ToString();
        ShowBombLog(mUIComponents.P1BombGrid_Transform, room_info.players[0]);
        mUIComponents.P1RScore_Text.text = room_info.players[0].round_score.ToString();
        mUIComponents.P2RName_Text.text = room_info.players[1].name;
        mUIComponents.P2RId_Text.text = room_info.players[1].uid.ToString();
        ShowBombLog(mUIComponents.P2BombGrid_Transform, room_info.players[1]);
        mUIComponents.P2RScore_Text.text = room_info.players[1].round_score.ToString();
        mUIComponents.P3RName_Text.text = room_info.players[2].name;
        mUIComponents.P3RId_Text.text = room_info.players[2].uid.ToString();
        ShowBombLog(mUIComponents.P3BombGrid_Transform, room_info.players[2]);
        mUIComponents.P3RScore_Text.text = room_info.players[2].round_score.ToString();
        mUIComponents.P4RName_Text.text = room_info.players[3].name;
        mUIComponents.P4RId_Text.text = room_info.players[3].uid.ToString();
        ShowBombLog(mUIComponents.P4BombGrid_Transform, room_info.players[3]);
        mUIComponents.P4RScore_Text.text = room_info.players[3].round_score.ToString();
        mUIComponents.Result_Image.gameObject.SetActive(true);
    }

    private void ShowBombLog(Transform trans, PlayerInfo player)
    {
        RecoverBombLine(trans);
        foreach (var item in player.bombs.OrderBy(c=>c.Key))
        {
            var go = PoolManager.Instance.Pool<ItemsPool>().Spawn<Bomb>();
            var bomb = go.transform.GetComponent<Bomb>();
            bomb.BombStar_Text.text = item.Key.ToString();
            bomb.BombNumber_Text.text = "x " + item.Value.ToString();
            go.transform.SetParentAndInit(trans);
        }
    }

    private void RecoverBombLine(Transform trans)
    {
        foreach (Transform tran in trans)
        {
            PoolManager.Instance.Pool<ItemsPool>().Despawn<Bomb>(tran.gameObject);
        }
    }

    private void GameOver()
    {
        isPlaying = false;
        room_info = null;
        RecoverCards();
        RecoverCards(mUIComponents.HandCardGrid_Transform);
        mUIComponents.P2Info_Image.gameObject.SetActive(false);
        mUIComponents.P3Info_Image.gameObject.SetActive(false);
        mUIComponents.P4Info_Image.gameObject.SetActive(false);
        mUIComponents.Result_Image.gameObject.SetActive(false);
    }

    protected override void OnShow()
	{
		base.OnShow();
	}

	protected override void OnHide()
	{
        GameOver();
        base.OnHide();
	}

	protected override void OnClose()
	{
        UnRegisterAllEvent();
		base.OnClose();
	}

	protected override void DestoryUI()
	{
		base.DestoryUI();
	}

	void ShowLog(string content)
	{
		UnityEngine.Debug.Log("[UIRoomPanel:]" + content);
	}

	UIRoomPanelComponents mUIComponents = null;
}
