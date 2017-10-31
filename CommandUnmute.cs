using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Commands;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fr34kyn01535.ChatControl
{
    class CommandUnmute : IRocketCommand
    {
        public List<string> Aliases
        {
            get
            {
                return new List<string>();
            }
        }

        public AllowedCaller AllowedCaller
        {
            get
            {
                return AllowedCaller.Both;
            }
        }

        public string Help
        {
            get
            {
                return "Unmutes a player globally";
            }
        }

        public string Name
        {
            get
            {
                return "unmute";
            }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string>() { "ChatControl.Unmute" };
            }
        }

        public string Syntax
        {
            get
            {
                return "<player>";
            }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = command.GetUnturnedPlayerParameter(0);
            if (player == null)
            {
                UnturnedChat.Say(caller, ChatControl.Instance.Translate("command_player_not_found"), ChatControl.MessageColor);
                return;
            }
            ChatControlPlayerComponent component = player.GetComponent<ChatControlPlayerComponent>();
            component.IsMuted = false;
            component.Warnings = 0;

            if (ChatControl.Instance.Configuration.Instance.AnnounceUnmute)
            {
                UnturnedChat.Say(ChatControl.Instance.Translate("command_unmute", player.DisplayName), ChatControl.MessageColor);
            }
            else
            {
                UnturnedChat.Say(caller, ChatControl.Instance.Translate("command_unmute", player.DisplayName), ChatControl.MessageColor);
            }
        }
    }
}
