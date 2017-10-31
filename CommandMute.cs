using Rocket.API;
using Rocket.Unturned.Player;
using Rocket.Unturned.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.Unturned.Chat;

namespace fr34kyn01535.ChatControl
{
    class CommandMute : IRocketCommand
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
                return "Mutes a player globally";
            }
        }

        public string Name
        {
            get
            {
                return "mute";
            }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string>() { "ChatControl.Mute" };
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
                UnturnedChat.Say(caller, ChatControl.Instance.Translate("command_player_not_found"));
                return;
            }
            ((ChatControlPlayerComponent)player.GetComponent<ChatControlPlayerComponent>()).IsMuted = true;

            if (ChatControl.Instance.Configuration.Instance.AnnounceMute)
            {
                UnturnedChat.Say(ChatControl.Instance.Translate("command_mute", player.DisplayName),ChatControl.MessageColor);
            }
            else
            {
                UnturnedChat.Say(caller, ChatControl.Instance.Translate("command_mute", player.DisplayName), ChatControl.MessageColor);
            }
        }
    }
}
