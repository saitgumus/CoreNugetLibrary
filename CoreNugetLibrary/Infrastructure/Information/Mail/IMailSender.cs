using SG.Kernel.Response;
using SG.Kernel.Types;

namespace SG.Kernel.InformationEngine.Mail
{
    public interface IMailSender
    {
        public Response<int> Send(InformationContract contract);
    }
}