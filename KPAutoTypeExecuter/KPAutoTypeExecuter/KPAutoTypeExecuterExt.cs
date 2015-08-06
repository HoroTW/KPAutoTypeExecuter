using KeePass.Plugins;
using KeePass.UI;
using KeePass.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace KPAutoTypeExecuter
{
    public sealed class KPAutoTypeExecuterExt : Plugin
    {
        private IPluginHost m_host = null;

        /// <summary>
        /// Initialize method is called from KeePass
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public override bool Initialize(IPluginHost host)
        {
            m_host = host;
            KeePass.Util.AutoType.FilterSend += AutoType_FilterSend;
            KeePass.Util.AutoType.FilterSendPre += AutoType_FilterSendPre;
            GlobalWindowManager.WindowAdded += GlobalWindowManager_WindowAdded;
            AutoType.SequenceQuery += AutoType_SequenceQuery;
            AutoType.SequenceQueriesBegin += AutoType_SequenceQueriesBegin;
            AutoType.SequenceQueriesEnd += AutoType_SequenceQueriesEnd;

            return true;
        }

        private void AutoType_SequenceQueriesEnd(object sender, SequenceQueriesEventArgs e)
        {
            string x = "";
        }

        private void AutoType_SequenceQueriesBegin(object sender, SequenceQueriesEventArgs e)
        {
            string x = "";
        }

        private void AutoType_SequenceQuery(object sender, SequenceQueryEventArgs e)
        {
            string x = "";
        }

        private void GlobalWindowManager_WindowAdded(object sender, GwmWindowEventArgs e)
        {
            string x = "";
        }

        private void AutoType_FilterSendPre(object sender, AutoTypeEventArgs e)
        {
            if (e.Entry.Strings.Exists("KP_EXEC_BEFORE"))
            {
                string exectue = e.Entry.Strings.Get("KP_EXEC_BEFORE").ReadString();

                if (!string.IsNullOrEmpty(exectue))
                {
                    Process.Start("cmd", "/C \"" + exectue + "\"");
                }
            }
        }

        /// <summary>
        /// Logic for the execute statement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoType_FilterSend(object sender, AutoTypeEventArgs e)
        {
            if (e.Entry.Strings.Exists("KP_EXEC_AFTER"))
            {
                string exectue = e.Entry.Strings.Get("KP_EXEC_AFTER").ReadString();
                
                if (!string.IsNullOrEmpty(exectue))
                {
                    Process.Start("cmd", "/C \"" + exectue + "\"");
                }
            }
        }

        /// <summary>
        /// Eventhandler unsubscribing and cleanup is called from KeePass
        /// </summary>
        public override void Terminate()
        {
            KeePass.Util.AutoType.FilterSend -= AutoType_FilterSend;
        }
    }
}
