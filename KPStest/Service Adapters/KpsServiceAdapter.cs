using ServiceReference1;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace KPStest.Service_Adapters
{
    public static class KpsServiceAdapter 
    {
        public static async Task Validate(Member member)
        {
            BasicHttpsBinding binding = new BasicHttpsBinding();
            EndpointAddress address = new EndpointAddress("https://tckimlik.nvi.gov.tr/Service/KPSPublic.asmx?WSDL");

            KPSPublicSoapClient client = new KPSPublicSoapClient(binding, address);
            await client.TCKimlikNoDogrulaAsync(member.TCKN, member.Name, member.Surname, member.Birtday);
        }
    }
}
