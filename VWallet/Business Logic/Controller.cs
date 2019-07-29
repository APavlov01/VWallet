using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VWallet;

namespace VWallet
{
    public class Controller
    {
        private Display display = new Display();
        public void Start()
        {
            display.WelcomeScreen();
        }
    }
}
