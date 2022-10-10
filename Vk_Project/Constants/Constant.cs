using Vk_Project.Utils;

namespace Vk_Project.Constants
{
    public static class Constant
    {
        public static readonly string BaseUrl = Configurator.GetConfig()["BaseUrl"];
        public static readonly string Token = Configurator.GetConfig()["Token"];
        public static readonly string V = "v=";
        public static readonly string UserId = "user_ids=";
        public const string Message = "message=";
        public const string Server = "server=";
        public const string Photo = "photo=";
        public const string Hash = "hash=";
        public const string OwnerId = "owner_id=";
        public const string PostId = "post_id=";
        public const string Type = "type=";
        public const string Attachments = "attachments=";
        public const string ItemId = "item_id=";
        public const string PostType = "post";
        public const string PhotoAttachment = "photo";
    }
}