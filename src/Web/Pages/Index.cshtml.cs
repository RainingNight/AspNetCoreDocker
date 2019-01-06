using System.Linq;
using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        public string HostName { get; set; }

        public string HostIP { get; set; }

        public void OnGet()
        {
            HostName = Dns.GetHostName();
            HostIP = Dns.GetHostEntry(HostName).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork).ToString();
        }
    }
}
