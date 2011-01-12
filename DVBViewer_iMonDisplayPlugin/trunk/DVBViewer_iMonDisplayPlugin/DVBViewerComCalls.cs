using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DVBViewerServer;

namespace DVBViewer_iMonDisplayPlugin
{
    class DVBViewerComCalls
    {
        private DVBViewer dvbv;
        private Hashtable ht;

        public DVBViewerComCalls()
        {
            //DVBViewerEvents de = dvbv.Events;
            //de.
        }

        /// <summary>
        /// Initialize the COM Interface to DVBViewer Software
        /// </summary>
        /// <returns>true if successfully initialized, false otherwiese</returns>
        public bool connectToDVBViewerComInterface()
        {
            try
            {
                this.dvbv = (DVBViewer)System.Runtime.InteropServices.Marshal.GetActiveObject("DVBViewerServer.DVBViewer");
                //Register EventHandler for ChannelChange action
                this.dvbv.Events.OnChannelChange += new IDVBViewerEvents_OnChannelChangeEventHandler(dvbv_ChannelChange);                                                
            }
            catch (Exception)
            {                
                return false;
            }

            return true;
        }

        private void dvbv_ChannelChange(int ChannelNr)
        {
            /* do nothing --> Event Seems not to be fired every time a channel is changed */
        }

        /// <summary>
        /// Gathers display-relevant information from DVBViewer COM interface
        /// </summary>
        /// <returns>returns the Hashtable with the values, null if error</returns>
        public Hashtable gatherInformationFromDVBViewer()
        {
            ht = new Hashtable();

            /*
            string activeChannel;
            string title;
            int percentage;
            double volume;
             */

            try
            {                
                ht.Add("activeChannel", this.dvbv.OSD.ChannelName);
                ht.Add("title", this.dvbv.EPGManager.EPGNow.Title);                
                ht.Add("percentage", Convert.ToInt32(this.dvbv.propGetValue("#TV.Now.percentage")));
                ht.Add("volume", this.dvbv.Volume);            
            }
            catch (Exception)
            {
                return null;
            }

            

            return ht;
        }
    }
}
