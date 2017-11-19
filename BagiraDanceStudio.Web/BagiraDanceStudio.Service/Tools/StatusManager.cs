using BagiraDanceStudio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BagiraDanceStudio.Service.Tools
{
    public class StatusManager
    {
        private IManagerExceptions _managerExceptions;
        [DefaultValue(null)]
        public Exception ErrorMessage{get; set;}
        public object ReturnValue { get; set; }
        public bool Status
        {
            get { return ErrorMessage == null; }
        }

        public StatusManager()
        {
            Prepare();
        }
        public StatusManager(Exception errorMessage) : this()
        {
            ErrorMessage = errorMessage;
        }

        private void Prepare()
        {
            _managerExceptions = new DocumentManagerExceptions();
        }

        public void Log()
        {
            _managerExceptions.Log(ErrorMessage.Message);
        }
    }
}
