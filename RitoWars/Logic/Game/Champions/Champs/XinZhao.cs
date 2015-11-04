using RitoWars.Logic.Game.Champions.Helpers;

namespace RitoWars.Logic.Game.Champions.Champs
{
    public abstract class XinZhao : BaseChamp
    {
        #region ChampData
        /// <summary>
        /// The champion name
        /// </summary>
        public override string ChampName => "XinZhao";

        /// <summary>
        /// The champion id
        /// </summary>
        public override int ChampId => 5;

#endregion ChampData

        #region Health
        /// <summary>
        /// The champion's base health at level one
        /// </summary>
        public override double BaseHealth => 591.16;

        /// <summary>
        /// The champion's health gained for leveling up
        /// </summary>
        public override double HealthLevel => 87;

        /// <summary>
        /// The champion's amount of health regen
        /// </summary>
        public override double BaseHealthRegen => 8.175;

        /// <summary>
        /// The champion's health regen gained for leveling up
        /// </summary>
        public override double HealthRegenLevel => 0.7;
        #endregion Health

        #region SecondaryBar
        /// <summary>
        /// The champion's <seealso cref="SecondaryBar"/> resource the champion has
        /// </summary>
        public override SecondaryBar SecondaryBar => SecondaryBar.Mana;

        #region SecondaryBarData
        /// <summary>
        /// The champion's base <seealso cref="SecondaryBar"/> amount
        /// </summary>
        public override double BaseSecondaryBarData => 273.8;

        /// <summary>
        /// The champion's <seealso cref="SecondaryBar"/> amount gained for leveling up
        /// </summary>
        public override double SecondaryBarDataLevel => 35;

        /// <summary>
        /// The champion's <seealso cref="SecondaryBar"/> base regen amount
        /// </summary>
        public override double BaseSecondaryBarRegen => 7.255;

        /// <summary>
        /// The champion's <seealso cref="SecondaryBar"/> regen amount gained for leveling up
        /// </summary>
        public override double SecondaryBarRegenLevel => 0.45;
        #endregion SecondaryBarData
        #endregion SecondaryBar

        #region Attacks 
        /// <summary>
        /// The champion's base attack damage
        /// </summary>
        public override double BaseAttackDamage => 57.544;

        /// <summary>
        /// The champion's attack damage gained for leveling up
        /// </summary>
        public override double AttackDamageLevel => 3.3;

        /// <summary>
        /// The champion's base attack speed
        /// </summary>
        public override double BaseAttackSpeed => 0.672; 

        /// <summary>
        /// The champion's attack speed percent gained for leveling up
        /// </summary>
        public override double AttackSpeedPercent => 2.6; 

        /// <summary>
        /// The champion's auto attack range
        /// </summary>
        public override double AutoAttackRange => 175; 
        #endregion Attacks

        #region Defense
        /// <summary>
        /// The champion's base armor
        /// </summary>
        public override double BaseArmor => 25.88;

        /// <summary>
        /// The champion's armor gained for leveling up
        /// </summary>
        public override double ArmorLevel => 3.5;

        /// <summary>
        /// The champion's base magic resist (for most champions is 30)
        /// </summary>
        public override double BaseMagicResist => 32.1;

        /// <summary>
        /// The champion's magic resist gained for leveling up
        /// </summary>
        public override double MagicResistLevel => 1.25;
        #endregion Defense

        #region CastingResource //--------------------------------------------------->NEED TO BE VERIFIED, ALL CHAMPS ARE CURRENTLY USING MANA :P
        /// <summary>
        /// The champion's <seealso cref="CastingResource"/> for using Q
        /// </summary>
        public override CastingResource Q => CastingResource.Mana;

        /// <summary>
        /// The champion's <seealso cref="CastingResource"/> for using W
        /// </summary>
        public override CastingResource W => CastingResource.Mana;

        /// <summary>
        /// The champion's <seealso cref="CastingResource"/> for using E
        /// </summary>
        public override CastingResource E => CastingResource.Mana;

        /// <summary>
        /// The champion's <seealso cref="CastingResource"/> for using R
        /// </summary>
        public override CastingResource R => CastingResource.Mana;
        #endregion CastingResource
    }
}
