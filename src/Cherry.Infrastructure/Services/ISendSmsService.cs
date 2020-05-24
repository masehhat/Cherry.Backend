using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cherry.Infrastructure.Services
{
    public interface ISendSmsService
    {
        Task SendSms();
    }
}
