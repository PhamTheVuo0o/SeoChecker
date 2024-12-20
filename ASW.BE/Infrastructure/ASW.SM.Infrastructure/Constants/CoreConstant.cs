namespace ASW.SM.Infrastructure.Constants
{
    public static class CoreConstant
    {
        #region Storage
        #endregion
        #region Env Name
        public const string AZURE_DEV_ENV = "AzureDev";
        public const string AZURE_STAGING_ENV = "AzureStaging";
        public const string DOCKER_DEV_ENV = "DockerDev";
        public const string DOCKER_LOCAL_ENV = "DockerLocal";

        public const string JWT_SECRET_64_SYMBOL = "JWT_SECRET_64_SYMBOL";
        #endregion
        #region Claim
        public const string CLAIM_AVATAR = "avatar";
        public const string CLAIM_LASTNAME = "lastName";
        public const string CLAIM_FIRSTNAME = "firstName";
        public const string CLAIM_USERNAME = "userName";
        public const string CLAIM_PERMISSIONS = "permissions";
        public const string CLAIM_ROLELEVELS = "roleLevels";
        public const string CLAIM_ACCOUNT = "account";
        public const string CLAIM_EMAIL = "email";
        public const string CLAIM_SECURITY_STAMP = "securityStamp";
        public const string CLAIM_CREDENTIALSOURCE = "credentialSource";
        public const string CLAIM_ID = "Id";
        #endregion
        #region Core Constants
        public const string VALUE_ZERO = "0";
        public const string ELLIPSIS = "...";

        public const char CHAR_SEMI_COLON = ';';
        public const char CHAR_COLON = ',';
        public const char CHAR_POINT = '.';
        public const char CHAR_UNDERSCORE = '_';
        public const char CHAR_HYPHEN = '-';
        public const char CHAR_VERTICAL_BAR = '|';

        public const string STRING_BACK_SLASH = "\\";
        public const string STRING_FORWARD_SLASH = "/";
        public const string WHITE_SPACE = " ";

        public const string FLAG_YES = "Y";
        public const string FLAG_NO = "N";

        public const string LANGUAGE = "Language";
        public const string CULTURE_ENGLISH = "en-US";

        public const int DEFAULT_TIME_OUT = 120;
        public const int DEFAULT_REF_DATA_CACHE_TIME_OUT = 300;
        public const int MIN_REF_DATA_CACHE_TIME_OUT = 1;

        public const int DEFAULT_MAX_METHOD_TRIES = 3;
        public const int DEFAULT_RETRY_WAIT_TIME = 5000; //miliseconds

        public const int DEFAULT_REVISION = 0;

        public const int COMPARE_GREATER = 1;
        public const int COMPARE_EQUALS = 0;
        public const int COMPARE_LESS_THAN = -1;

        public const int DEFAULT_SEARCH_PAGE = 1;

        public const string ASYNC = "Async";

        public const string PROPERTY_IS_SUCCESS = "IsSuccess";
        public const string PROPERTY_DETAIL = "Detail";

        #endregion Core Constants
        #region Formats

        public const string DEFAULT_DECIMAL_FORMAT = "0.###";
        public const string FORMAT_HEXA_STRING = "X2";

        #endregion Formats
        #region Regular Expressions

        public const string REGEX_EMAIL = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public const string REGEX_PHONE_NUMBER = @"^\(?(([0-9]|\+)[0-9]{2})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4,7})$";
        public const string REGEX_VERSION = @"^(\d.){3}\d$";

        #endregion Regular Expressions
        #region File Types & Extensions & Filters

        public const string FILE_TYPE_ALL = "*.*";
        public const string FILE_TYPE_JPG = "*.jpg";
        public const string FILE_TYPE_JPEG = "*.jpeg";
        public const string FILE_TYPE_PNG = "*.png";
        public const string FILE_TYPE_BMP = "*.bmp";
        public const string FILE_TYPE_TIFF = "*.tif";
        public const string FILE_TYPE_J2K = "*.j2k";
        public const string FILE_TYPE_JP2 = "*.jp2";
        public const string FILE_TYPE_XML = "*.xml";
        public const string FILE_TYPE_XLS = "*.xls";
        public const string FILE_TYPE_XLSX = "*.xlsx";

        public const string FILE_TYPE_OCR = "*.ocr";
        public const string FILE_TYPE_MODEL = "*.model";

        public const string EXTENSION_JPG = ".jpg";
        public const string EXTENSION_JPEG = ".jpeg";
        public const string EXTENSION_BMP = ".bmp";
        public const string EXTENSION_PNG = ".png";
        public const string EXTENSION_JP2 = ".jp2";
        public const string EXTENSION_J2K = ".j2k";

        public const string EXTENSION_XML = ".xml";
        public const string EXTENSION_CSV = ".csv";
        public const string EXTENSION_XLS = ".xls";
        public const string EXTENSION_XLSX = ".xlsx";

        public const string EXTENSION_DLL = ".dll";
        public const string EXTENSION_EXE = ".exe";
        public const string EXTENSION_OCX = ".ocx";

        public const string EXTENSION_OCR = ".ocr";

        public const string EXTENSION_CONFIG = ".config";

        public const string DIALOG_FILTER_CSV = "Csv|*.csv";
        public const string DIALOG_FILTER_EXCEL_FROM_2007 = "Excel >= 2007 |*.xlsx";
        public const string DIALOG_FILTER_EXCEL = "Excel >= 2007 |*.xlsx|Excel|*.xls";
        public const string DIALOG_FILTER_CSV_EXCEL = "Csv|*.csv|Excel >= 2007 |*.xlsx|Excel|*.xls";
        public const string DIALOG_FILTER_EXCEL_CSV = "Excel >= 2007|*.xlsx|Excel|*.xls|Csv|*.csv";
        public const string DIALOG_FILTER_XML = "*.xml";
        public const string DIALOG_FILTER_TEXT = "Text|*.txt";

        public const string DIALOG_FILTER_JPEG = "Jpeg Files (*.jpeg)|*.jpeg";
        public const string DIALOG_FILTER_JPG = "Jpg Files (*.jpg)|*.jpg";
        public const string DIALOG_FILTER_BMP = "Bmp Files (*.bmp)|*.bmp";
        public const string DIALOG_FILTER_PNG = "Png Files (*.png)|*.png";
        public const string DIALOG_FILTER_GIF = "Gif Files (*.gif)|*.gif";
        public const string DIALOG_FILTER_IMAGES = "Images Files|*.jpeg;*.jpg;*.bmp;*.png;*.gif";

        public const string DIALOG_FILTER_ALL_IMAGE_OPTIONS = DIALOG_FILTER_JPEG + "|" + DIALOG_FILTER_BMP + "|" + DIALOG_FILTER_JPG
                                            + "|" + DIALOG_FILTER_PNG + "|" + DIALOG_FILTER_GIF + "|" + DIALOG_FILTER_IMAGES;

        public const string DIALOG_FILTER_JP2 = "Jpeg2000 (*.jp2)|*.jp2";
        public const string DIALOG_FILTER_J2K = "Jpeg2000 (*.j2k)|*.j2k";
        public const string DIALOG_FILTER_TIFF = "Tiff (*.tif)|*.tif";

        public const string DIALOG_FILTER_HTML = "HTML files (*.html)|*.html|All files(*.*)|*.*";

        public const string IMAGE_FORMAT_JPEG = "jpeg";
        public const string IMAGE_FORMAT_PNG = "png";
        public const string IMAGE_FORMAT_BMP = "bmp";
        public const string IMAGE_FORMAT_TIFF = "tif";
        public const string IMAGE_FORMAT_J2K = "j2k";

        public static readonly string[] COMMON_IMAGE_TYPES = new string[] { FILE_TYPE_BMP,
            FILE_TYPE_JPEG, FILE_TYPE_JPG, FILE_TYPE_PNG, FILE_TYPE_TIFF };

        #endregion File Types & Extensions & Filters
        #region Random Characters

        public static readonly IList<char> RANDOM_DIGIT_LIST = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public static readonly IList<char> RANDOM_CHAR_LIST = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        public static readonly IList<char> SPECIAL_CHAR_LIST = new List<char> { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };

        public static readonly IList<char> RANDOM_CHAR_LIST_WITH_SPECIAL = RANDOM_CHAR_LIST.Concat(SPECIAL_CHAR_LIST).ToList();

        #endregion Random Characters
        #region Network Constants

        public const int MAX_TRY_PING = 5;
        public const int PING_TIMEOUT = 3000;
        public const int PING_BUFFER_SIZE = 32;
        public const int PING_TTL = 1000;

        #endregion Network Constants
        #region Content Types

        public const string PDF_CONTENT_TYPE = "application/pdf";
        public const string JSON_CONTENT_TYPE = "application/json";
        public const string XML_CONTENT_TYPE = "application/xml";
        public const string FORM_URL_ENCODED_CONTENT_TYPE = "x-www-form-urlencoded";


        #endregion Content Types
        #region Services

        public const string CORRELATION_ID = "X-Correlation-Id";

        #endregion Services
        #region Data Check
        public const char STAR_CHAR = '*';
        public const string STAR_STRING = "*";

        public const char SYSTEM_SEPARATOR_CHAR = '|';
        public const string SYSTEM_SEPARATOR_STRING = "|";
        public const string DATA_SEPARATOR_STRING = "; ";

        public const char DEFAULT_EMAIL_SEPARATOR_CHAR = ';';
        public const string DEFAULT_EMAIL_SEPARATOR_STRING = ";";
        public static readonly char[] EMAIL_SEPARATOR_CHARS = new char[] { ',', ';', '|' };

        public const int DEFAULT_MAX_DEGREE_OF_PARALLELISM = 5;
        public const int DEFAULT_PROCESSING_BLOCK_SIZE = 100;
        #endregion
    }
}
