namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;

    public class ManagerController : IManagerController
    {
        private PlayerRepository playerRepository;
        private CardRepository cardRepository;
        public ManagerController()
        {
            this.playerRepository = new PlayerRepository();
            this.cardRepository = new CardRepository();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = null;
            if (type == "Beginner")
            {
                player = new Beginner(new CardRepository(), username);
            }
            else if (type == "Advanced")
            {
                player = new Advanced(new CardRepository(), username);
            }
            this.playerRepository.Add(player);
            return String.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = null;
            if (type == "Trap")
            {
                card = new TrapCard(name);
            }
            else if (type == "Magic")
            {
                card = new MagicCard(name);
            }
            this.cardRepository.Add(card);
            return String.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

       
        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer wantedPlayer = this.playerRepository.Players.FirstOrDefault(p => p.Username == username);
            ICard wantedCard = this.cardRepository.Cards.FirstOrDefault(c => c.Name == cardName);
            if ( wantedPlayer!=null)
            {
                wantedPlayer.CardRepository.Add(wantedCard);
                return String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
            }
            return "";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.playerRepository.Players.FirstOrDefault(p => p.Username == attackUser);
            IPlayer enemy = this.playerRepository.Players.FirstOrDefault(p => p.Username == enemyUser);
            BattleField battleField = new BattleField();
            battleField.Fight(attacker, enemy);
            return String.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);


        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in this.playerRepository.Players)
            {
                sb.AppendLine(String.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(String.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }
                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
