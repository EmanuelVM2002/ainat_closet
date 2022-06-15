using ainat_closet.Common;

namespace ainat_closet.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string toName, string toEmail, string subject, string body);
    }

}
