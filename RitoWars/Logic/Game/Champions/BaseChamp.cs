using System.Linq;
using RitoWars.Logic.Game.Champions.Helpers;
using System.Reflection;

namespace RitoWars.Logic.Game.Champions
{
    public abstract class BaseChamp
    {
        public static BaseChamp GetFromId(int champId)
        {
            return GlobalData.GetInstances<BaseChamp>().FirstOrDefault(champ => champ.ChampId == champId);
        }

        #region ChampData
        /// <summary>
        /// The champion name
        /// </summary>
        public abstract string ChampName { get; }

        /// <summary>
        /// The champion id
        /// </summary>
        public abstract int ChampId { get; }
        #endregion ChampData

        #region Health
        /// <summary>
        /// The champion's base health at level one
        /// </summary>
        public abstract double BaseHealth { get; }

        /// <summary>
        /// The champion's health gained for leveling up
        /// </summary>
        public abstract double HealthLevel { get; }

        /// <summary>
        /// The champion's amount of health regen
        /// </summary>
        public abstract double BaseHealthRegen { get; }

        /// <summary>
        /// The champion's health regen gained for leveling up
        /// </summary>
        public abstract double HealthRegenLevel { get; }
        #endregion Health

        #region SecondaryBar
        /// <summary>
        /// The champion's <seealso cref="SecondaryBar"/> resource the champion has
        /// </summary>
        public abstract SecondaryBar SecondaryBar { get; }

        #region SecondaryBarData
        /// <summary>
        /// The champion's base <seealso cref="SecondaryBar"/> amount
        /// </summary>
        public abstract double BaseSecondaryBarData { get; }

        /// <summary>
        /// The champion's <seealso cref="SecondaryBar"/> amount gained for leveling up
        /// </summary>
        public abstract double SecondaryBarDataLevel { get; }

        /// <summary>
        /// The champion's <seealso cref="SecondaryBar"/> base regen amount
        /// </summary>
        public abstract double BaseSecondaryBarRegen { get; }

        /// <summary>
        /// The champion's <seealso cref="SecondaryBar"/> regen amount gained for leveling up
        /// </summary>
        public abstract double SecondaryBarRegenLevel { get; }
        #endregion SecondaryBarData
        #endregion SecondaryBar

        #region Attacks
        /// <summary>
        /// The champion's base attack damage
        /// </summary>
        public abstract double BaseAttackDamage { get; }

        /// <summary>
        /// The champion's attack damage gained for leveling up
        /// </summary>
        public abstract double AttackDamageLevel { get; }

        /// <summary>
        /// The champion's base attack speed
        /// </summary>
        public abstract double BaseAttackSpeed { get; }

        /// <summary>
        /// The champion's attack speed percent gained for leveling up
        /// </summary>
        public abstract double AttackSpeedPercent { get; }

        /// <summary>
        /// The champion's auto attack range
        /// </summary>
        public abstract double AutoAttackRange { get; }
        #endregion Attacks

        #region Defense
        /// <summary>
        /// The champion's base armor
        /// </summary>
        public abstract double BaseArmor { get; }

        /// <summary>
        /// The champion's armor gained for leveling up
        /// </summary>
        public abstract double ArmorLevel { get; }

        /// <summary>
        /// The champion's base magic resist
        /// </summary>
        public abstract double BaseMagicResist { get; }

        /// <summary>
        /// The champion's magic resist gained for leveling up
        /// </summary>
        public abstract double MagicResistLevel { get; }
        #endregion Defense

        //TODO: Improve this because some champs have toggles or multiple states
        #region CastingResource
        /// <summary>
        /// The champion's <seealso cref="CastingResource"/> for using Q
        /// </summary>
        public abstract CastingResource Q { get; }

        /// <summary>
        /// The champion's <seealso cref="CastingResource"/> for using W
        /// </summary>
        public abstract CastingResource W { get; }

        /// <summary>
        /// The champion's <seealso cref="CastingResource"/> for using E
        /// </summary>
        public abstract CastingResource E { get; }

        /// <summary>
        /// The champion's <seealso cref="CastingResource"/> for using R
        /// </summary>
        public abstract CastingResource R { get; }
        #endregion CastingResource
    }
}
