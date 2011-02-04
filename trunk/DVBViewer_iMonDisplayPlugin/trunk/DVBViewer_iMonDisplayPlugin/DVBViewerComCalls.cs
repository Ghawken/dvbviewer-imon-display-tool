using System;
using System.Collections;
using DVBViewerServer;
using System.Runtime.InteropServices;

namespace DVBViewer_iMonDisplayPlugin
{
    class DVBViewerComCalls
    {
        private DVBViewer dvbv;
        private Hashtable ht;

        public DVBViewerComCalls()
        {
            //DVBViewerEvents de = dvbv.Events;            
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
                //this.dvbv.Events.OnChannelChange += new IDVBViewerEvents_OnChannelChangeEventHandler(dvbv_ChannelChange);                                                
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
            /* ToDo: Check it! */
        }

        /// <summary>
        /// Gathers display-relevant information from DVBViewer COM interface
        /// </summary>
        /// <returns>returns the Hashtable with the values, null if error</returns>
        public Hashtable getInformationFromDVBViewer()
        {
            this.ht = new Hashtable();
            ht.Add("missingFieldFlag", false);
            ht.Add("comErrorFlag", false);            

            try
            {
                ht.Add("activeChannel", this.dvbv.OSD.ChannelName);
            }
            catch (COMException)
            {
                ht["comErrorFlag"] = true;
            }
            catch (Exception)
            {
                ht["missingFieldFlag"] = true;
            }

            try
            {
                ht.Add("title", this.dvbv.EPGManager.EPGNow.Title);
            }
            catch (COMException)
            {
                ht["comErrorFlag"] = true;
            }
            catch (Exception)
            {
                ht["missingFieldFlag"] = true;
            }

            try
            {
                ht.Add("isRecording", this.dvbv.TimerManager.Recording);
            }
            catch (COMException)
            {
                ht["comErrorFlag"] = true;
            }
            catch (Exception)
            {
                ht["missingFieldFlag"] = true;
            }

            try
            {                
                int progress = Convert.ToInt32(this.dvbv.propGetValue("#TV.Now.percentage"));
                ht.Add("progress", Convert.ToInt32(progress));
             
            }
            catch (COMException)
            {
                ht["comErrorFlag"] = true;
            }
            catch (Exception)
            {
                ht["missingFieldFlag"] = true;
            }

            try
            {
                ht.Add("audioMode",this.dvbv.Audiomode());
            }
            catch (COMException)
            {
                ht["comErrorFlag"] = true;
            }
            catch (Exception)
            {
                ht["missingFieldFlag"] = true;
            }
            
            try
            {
                ht.Add("volume", this.dvbv.Volume);
            }
            catch (COMException)
            {
                ht["comErrorFlag"] = true;
            }
            catch (Exception)
            {
                ht["missingFieldFlag"] = true;
            }

            try
            {
                ht.Add("percentage", Convert.ToInt32(this.dvbv.propGetValue("#percentage")));
            }
            catch (COMException)
            {
                ht["comErrorFlag"] = true;
            }
            catch (Exception)
            {
                ht["missingFieldFlag"] = true;
            }

            //TODO: Implement Menu on Display
            /*
            try
            {
                ht.Add("menuSelectedItem", this.dvbv.propGetValue("#selecteditem"));
            }
            catch (COMException)
            {
                ht["comErrorFlag"] = true;
            }
            catch (Exception)
            {
                ht["missingFieldFlag"] = true;
            }
             * */
            try
            {
                ht.Add("isMediaPlayback", this.dvbv.isMediaplayback());
            }
            catch (COMException)
            {
                ht["comErrorFlag"] = true;
            }
            catch (Exception)
            {
                ht["missingFieldFlag"] = true;
            }


            try
            {
                ht.Add("mediaArtist", this.dvbv.propGetValue("#Media.Artist"));
            }
            catch (COMException)
            {
                ht["comErrorFlag"] = true;
            }
            catch (Exception)
            {
                ht["missingFieldFlag"] = true;
            }

            try
            {
                ht.Add("mediaTitle", this.dvbv.propGetValue("#Media.title"));
            }
            catch (COMException)
            {
                ht["comErrorFlag"] = true;
            }
            catch (Exception)
            {
                ht["missingFieldFlag"] = true;
            }

            return ht;
        }
    }
}
