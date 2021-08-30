using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using DotvvmPatchStateDemo.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace DotvvmPatchStateDemo.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        private readonly IHubContext<ToastHub> _context;

        public string Title { get; set;}

		public DefaultViewModel(IHubContext<ToastHub> context)
        {
            _context = context;
        }

        public async Task InvokeSignalrBroadcast()
        {
            await _context.Clients.All.SendAsync("ShowToast", "signalr title");
        }
    }
}
