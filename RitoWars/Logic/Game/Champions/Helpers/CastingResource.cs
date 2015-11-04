namespace RitoWars.Logic.Game.Champions.Helpers
{
    /// <summary>
    /// What the champion will use for their castingresource
    /// </summary>
    public enum CastingResource
    {
        /// <summary>
        /// Champion uses their hp
        /// <para>Example champ: Lee Sin</para>
        /// </summary>
        Energy,

        /// <summary>
        /// Champion uses their hp
        /// <para>Example champ: Aatrox</para>
        /// </summary>
        Health,

        /// <summary>
        /// Champion uses their hp
        /// <para>Example champ: Ahri</para>
        /// </summary>
        Mana,

        /// <summary>
        /// Champion uses their fury
        /// <para>Example champ: Tryndamere with his Q</para>
        /// </summary>
        Fury,

        /// <summary>
        /// Champion uses their Essence Of Shadow
        /// <para>ONLY champ: Akali</para>
        /// </summary>
        EssenceOfShadow,

        /// <summary>
        /// Champion uses nothing
        /// <para>Example champ: Yasuo</para>
        /// </summary>
        NoCastingResource
    }
}
