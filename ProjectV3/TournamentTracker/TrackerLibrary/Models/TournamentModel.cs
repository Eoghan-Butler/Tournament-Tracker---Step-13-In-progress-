using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TournamentModel
    {

        /// <summary>
        /// Represents the name of the tornament
        /// </summary>
        public string TournamentName { get; set; }

        /// <summary>
        /// Represents the amount for the entryfee if applicable
        /// </summary>
        public decimal EntryFee { get; set; }

        /// <summary>
        /// Represents the list of players/teams that have entered
        /// </summary>
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();

        /// <summary>
        /// Represents the prize
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();

        /// <summary>
        /// Represents the rounds for the tournament
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();



    }
}
