namespace RitoWars.Logic.Game.Champions.Helpers
{
    /// <summary>
    /// What is displayed for the champion's secondary bar
    /// </summary>
    public enum SecondaryBar
    {
        /// <summary>
        /// Yasuo secondary bar shows how much wind he has colected
        /// <para>Only Yasuo</para>
        /// </summary>
        Wind,
        /// <summary>
        /// Aatrox's secondary bar shows how much hp is in his bloodwell
        /// <para>Only Aatrox</para>
        /// </summary>
        BloodWell,

        /// <summary>
        /// Champion's secondary bar shows how much energy they have
        /// <para>Example champ: Lee sin</para>
        /// </summary>
        Energy,

        /// <summary>
        /// Rengar's secondary bar shows how much ferocity they have
        /// <para>Only Rengar</para>
        /// </summary>
        Ferocity,

        /// <summary>
        /// Yasuo's secondary bar shows how much flow he has
        /// <para>Only Yasuo</para>
        /// </summary>
        Flow,

        /// <summary>
        /// Champion's secondarybar shows how much fury they have
        /// <para>Example champ: Shyvana</para>
        /// </summary>
        Fury,

        /// <summary>
        /// Rumble's secondarybar shows how much heat he have
        /// <para>Only Rumble</para>
        /// </summary>
        Heat,

        /// <summary>
        /// Mordekaiser's secondarybar shows the amount of shield
        /// <para>Only Mordekaiser</para>
        /// </summary>
        IronMan,

        /// <summary>
        /// Most champions secondarybar shows the amount of mana
        /// <para>Example champ: Annie</para>
        /// </summary>
        Mana,

        /// <summary>
        /// Champion does not have a secondarybar
        /// <para>Example champ: Riven</para>
        /// </summary>
        NoSecondaryBar,

        /// <summary>
        /// Gnar's secondarybar shows how rage he has
        /// <para>Only Gnar</para>
        /// </summary>
        Rage
    }
}
