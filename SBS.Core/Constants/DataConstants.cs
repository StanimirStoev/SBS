namespace SBS.Core.Constants
{
    /// <summary>
    /// Constants for Core layer
    /// </summary>
    public static class DataConstants
    {
        /// <summary>
        /// Address constants
        /// </summary>
        public static class Address
        {
            /// <summary>
            /// Min Address line lenght
            /// </summary>
            public const int AddressLineMinLenght = 3;
            /// <summary>
            /// Max Address line lenght
            /// </summary>
            public const int AddressLineMaxLenght = 126;
        }

        /// <summary>
        /// Article constants
        /// </summary>
        public static class Article
        {
            /// <summary>
            /// min Article Name lenght
            /// </summary>
            public const int NameMinLenght = 5;
            /// <summary>
            /// Max Article Name lenght
            /// </summary>
            public const int NameMaxLenght = 128;
            /// <summary>
            /// Min Article Model lenght
            /// </summary>
            public const int ModelMinLenght = 3;
            /// <summary>
            /// Max Article Model lenght
            /// </summary>
            public const int ModelMaxLenght = 32;
            /// <summary>
            /// Min Article Title lenght
            /// </summary>
            public const int TitleMinLenght = 3;
            /// <summary>
            /// Max Article Title lenght
            /// </summary>
            public const int TitleMaxLenght = 128;
            /// <summary>
            /// Max Article Description lenght
            /// </summary>
            public const int DescriptionMaxLenght = 512;
            /// <summary>
            /// Min Article DeliveryNumber lenght
            /// </summary>
            public const int DeliveryNumberMinLenght = 3;
            /// <summary>
            /// Max Article DeliveryNumber lenght
            /// </summary>
            public const int DeliveryNumberMaxLenght = 32;
        }

        /// <summary>
        /// City constants
        /// </summary>
        public static class City
        {
            /// <summary>
            /// Min City Name lenght
            /// </summary>
            public const int NameMinLenght = 3;
            /// <summary>
            /// Max City Name lenght
            /// </summary>
            public const int NameMaxLenght = 64;
        }

        /// <summary>
        /// Conragent constants
        /// </summary>
        public static class Contragent
        {
            /// <summary>
            /// Min Contragent First Name lenght
            /// </summary>
            public const int FirstNameMinLenght = 3;
            /// <summary>
            /// Max Contragent First Name lenght
            /// </summary>
            public const int FirstNameMaxLenght = 256;
            /// <summary>
            /// Min Contragent Last Name lenght
            /// </summary>
            public const int LastNameMinLenght = 3;
            /// <summary>
            /// Max Contragent Last Name lenght
            /// </summary>
            public const int LastNameMaxLenght = 256;
            /// <summary>
            /// Min Contragent VAT number lenght
            /// </summary>
            public const int VatNumberMinLenght = 8;
            /// <summary>
            /// Max Contragent VAT number lenght
            /// </summary>
            public const int VatNumberMaxLenght = 16;
        }

        /// <summary>
        /// Country constants
        /// </summary>
        public static class Country
        {
            /// <summary>
            /// Min Country Name lenght
            /// </summary>
            public const int NameMinLenght = 3;
            /// <summary>
            /// Max Country Name lenght
            /// </summary>
            public const int NameMaxLenght = 64;
            /// <summary>
            /// Max Country Code lenght
            /// </summary>
            public const int CodeMaxLenght = 3;
        }

        /// <summary>
        /// Store constants
        /// </summary>
        internal class Store
        {
            /// <summary>
            /// Min Country Name lenght
            /// </summary>
            public const int NameMinLenght = 3;
            /// <summary>
            /// Max Country Name lenght
            /// </summary>
            public const int NameMaxLenght = 64;
            /// <summary>
            /// Max Country Description lenght
            /// </summary>
            public const int DescriptionMaxLenght = 256;
        }

        /// <summary>
        /// Unit constants
        /// </summary>
        internal class Unit
        {
            /// <summary>
            /// Min Unit Name lenght
            /// </summary>
            public const int NameMinLenght = 1;
            /// <summary>
            /// Max Unit Name lenght
            /// </summary>
            public const int NameMaxLenght = 32;
            /// <summary>
            /// Max Unit Description lenght
            /// </summary>
            public const int DescriptionMaxLenght = 256;
        }
    }
}
