namespace SBS.Infrastructure.Constants
{
    public static class DataConstants
    {
        public static class Address
        {
            public const int AddressLineMaxLenght = 126;
        }

        public static class Article
        {
            public const int NameMaxLenght = 128;
            public const int ModelMaxLenght = 32;
            public const int TitleMaxLenght = 128;
            public const int DescriptionMaxLenght = 512;
            public const int DeliveryNumberMaxLenght = 32;
        }

        public static class City
        {
            public const int NameMaxLenght = 64;
        }

        public static class Contragent
        {
            public const int FirstNameMaxLenght = 256;
            public const int LastNameMaxLenght = 256;
            public const int VatNumberMaxLenght = 16;
        }

        public static class Country
        {
            public const int NameMaxLenght = 64;
            public const int CodeMaxLenght = 3;
        }

        internal class Store
        {
            public const int NameMaxLenght = 64;
            public const int DescriptionMaxLenght = 256;
        }

        internal class Unit
        {
            public const int NameMaxLenght = 32;
            public const int DescriptionMaxLenght = 256;
        }
    }
}
