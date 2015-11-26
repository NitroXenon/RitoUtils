using RitoWars.Logic.Game.Maps;

namespace RitoWars.Logic.Game.Items.GlobalData
{
    public class BootsOfSpeed : BaseItem
    {
        #region UniqueItemData
        /// <summary>
        /// The item id
        /// </summary>
        public override int ItemId => 1037;
        
        /// <summary>
        /// The item's name
        /// </summary>
        public override string ItemName => "Pickaxe";

        /// <summary>
        /// The target maps
        /// </summary>
        //public override MapTypes TargetMap => MapTypes.AllMaps;

        /// <summary>
        /// The cost to buy the item
        /// </summary>
        public override int Cost => 875;

        /// <summary>
        /// The max amount of that item type you can buy
        /// </summary>
        //public override int ItemLimit => 1;
#endregion UniqueItemData

        /// <summary>
        /// The movement speed gained by buying the item
        /// </summary>
        //public override double MovementSpeedGained => 25;
    }
}