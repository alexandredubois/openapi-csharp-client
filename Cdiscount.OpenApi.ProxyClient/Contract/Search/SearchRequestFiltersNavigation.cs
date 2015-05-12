using System.Runtime.Serialization;

namespace Cdiscount.OpenApi.ProxyClient.Contract.Search
{
    public enum SearchRequestFiltersNavigation
    {
        [EnumMember(Value = "all")]
        All,

        [EnumMember(Value = "pets")]
        Pets,

        [EnumMember(Value = "kitchen")]
        Kitchen,

        [EnumMember(Value = "vehicles")]
        Vehicles,

        [EnumMember(Value = "baggage")]
        Baggage,

        [EnumMember(Value = "luxury")]
        Luxury,

        [EnumMember(Value = "tools")]
        Tools,

        [EnumMember(Value = "shoes")]
        Shoes,

        [EnumMember(Value = "packaging")]
        Packaging,

        [EnumMember(Value = "entertainment")]
        Entertainment,

        [EnumMember(Value = "home")]
        Home,

        [EnumMember(Value = "hardware")]
        Hardware,

        [EnumMember(Value = "appliances")]
        Appliances,

        [EnumMember(Value = "electronics")]
        Electronics,

        [EnumMember(Value = "grocery")]
        Grocery,

        [EnumMember(Value = "cosmetics")]
        Cosmetics,

        [EnumMember(Value = "computers")]
        Computers,

        [EnumMember(Value = "musical instruments")]
        MusicalInstruments,

        [EnumMember(Value = "garden")]
        Garden,

        [EnumMember(Value = "toys")]
        Toys,

        [EnumMember(Value = "books")]
        Books,

        [EnumMember(Value = "haberdashery")]
        Haberdashery,

        [EnumMember(Value = "furniture")]
        Furniture,

        [EnumMember(Value = "cameras")]
        Cameras,

        [EnumMember(Value = "childcare")]
        Childcare,

        [EnumMember(Value = "sport")]
        Sport,

        [EnumMember(Value = "phones")]
        Phones,

        [EnumMember(Value = "tv-audio")]
        TvAudio,

        [EnumMember(Value = "clothing")]
        Clothing,

        [EnumMember(Value = "wines-spirits")]
        WinesSpirits
    }
}