using System;
using System.Collections;
using System.Windows.Forms;
using iMon.DisplayApi;

/*************************************************************************************************
 * This project makes use of the iMonDisplayAPI# (http://sourceforge.net/projects/imonapi-sharp/) 
 * I want to thank "montellese" for his work on that API
 * ***********************************************************************************************/

namespace DVBViewer_iMonDisplayPlugin
{
    public partial class FormMain : Form
    {       
        private iMonWrapperApi imon;
        private bool dvbvComInterfaceActive = false;
        private bool iMonDisplayInterfaceActive = false;
        private bool updateTimerWorking = false;
        private DVBViewerComCalls dvbvComCalls;
        private string currentDisplayText = "";
        private bool lcd = false;
        private bool vfd = false;
        private bool scrollFinished = false; //flag for scrollFinished event

        private DisplayHandler displayHandler;
        private DataHandler dataHandler;

        public FormMain()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dvbvComCalls = new DVBViewerComCalls();
            //Setup connect timer                      
            timerConnect.Interval = 1000;
            timerConnect.Start();

            //Setup update timer
            timerUpdateData.Interval = 1000;
            timerUpdateData.Start();            

            //initIMon();                      
        }

        /// <summary>
        /// Initialize the iMon Display (with help of Wrapper API)
        /// </summary>
        private void initIMon()
        {
            this.imon = new iMonWrapperApi();
            //Add Event Handlers for iMon events
            this.imon.StateChanged += wrapperApi_StateChanged;            
            this.imon.Error += wrapperApi_Error;
            this.imon.Log += wrapperApi_Log;
            this.imon.LogError += wrapperApi_LogError;
            

            this.displayHandler = new DisplayHandler(this.imon);
            this.displayHandler.RunWorkerAsync();

            this.dataHandler = new DataHandler(this.displayHandler);

            this.imon.Initialize();
        }

        /// <summary>
        /// Uninitialize the iMon Display (with help of Wrapper API)
        /// </summary>
        private void uninitIMon()
        {
            if (iMonDisplayInterfaceActive)
                imon.Uninitialize();
        }

        /// <summary>
        /// Handler for the iMonDisplayAPI# StateChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wrapperApi_StateChanged(object sender, iMonStateChangedEventArgs e)
        {           
            if (e.IsInitialized)
            {
                iMonDisplayInterfaceActive = true;
                // now you can use the display but check iMonWrapperApi.DisplayType to see what display type you have available 
                iMonDisplayType displayType = imon.DisplayType;
                if ((displayType & iMonDisplayType.LCD) == iMonDisplayType.LCD)
                {
                    //Add the ScrollFinished Event-Handler if type of display is LCD
                    //imon.LCD.ScrollFinished += wrapperApi_ScrollFinished;
                    this.lcd = true;
                    labelDisplayType.Text = "iMON LCD";
                }
                if ((displayType & iMonDisplayType.VFD) == iMonDisplayType.VFD)
                {
                    this.vfd = true;
                    labelDisplayType.Text = "iMON VFD";
                }

                pictureBoxiMonConnected.BackColor = System.Drawing.Color.GreenYellow;
            }
            else
            {                
                this.lcd = false;
                this.vfd = false;
                labelDisplayType.Text = "Unknown";
                currentDisplayText = "";

                iMonDisplayInterfaceActive = false;
                // now the display is uninitialized and you can't use it anymore
                pictureBoxiMonConnected.BackColor = System.Drawing.Color.OrangeRed;
            }
        }

        private delegate void wrapperApi_Error_Delegate(object sender, iMonErrorEventArgs e);
        /// <summary>
        /// Handler for the iMonDisplayAPI# Error event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wrapperApi_Error(object sender, iMonErrorEventArgs e) 
        {
            wrapperApi_Error_Delegate dele = wrapperApi_Error;

            if (this.InvokeRequired)
            {
                object[] args = { sender, e };
                this.BeginInvoke(dele, args);
                return;
            }
                        
            //TODO: check e.Type to find out what kind of error occured
            if (e.Type == iMonErrorType.iMonClosed)
            {
                createLog("Error: iMon closed");
            }
            if (e.Type == iMonErrorType.HardwareDisconnected)
            {
                createLog("Error: hardware diconnected");
            }
            if (e.Type == iMonErrorType.ApiNotInitialized)
            {
                createLog("Error: hardware not initialized");
            }
            if (e.Type == iMonErrorType.HardwareNotConnected)
            {
                createLog("Error: hardware not connected");
            }
            if (e.Type == iMonErrorType.HardwareNotSupported)
            {
                createLog("Error: hardware not supported");
            }
            if (e.Type == iMonErrorType.iMonNotResponding)
            {
                createLog("Error: imon not responding");
            }
            if (e.Type == iMonErrorType.InvalidArguments)
            {
                createLog("Error: invalid arguments");
            }
            if (e.Type == iMonErrorType.InvalidPointer)
            {
                createLog("Error: invalid pointer");
            }
            if (e.Type == iMonErrorType.NotInitialized)
            {
                createLog("Error: not initialized");
            }
            if (e.Type == iMonErrorType.NotInPluginMode)
            {
                createLog("Error: not in plugin mode");
            }
            if (e.Type == iMonErrorType.OutOfMemory)
            {
                createLog("Error: out of memory");
            }
            if (e.Type == iMonErrorType.PluginModeAlreadyInUse)
            {
                createLog("Error: plugin mode already in use");
            }
            if (e.Type == iMonErrorType.PluginModeDisabled)
            {
                createLog("Error: plugin mode disabled");
            }
            if (e.Type == iMonErrorType.Unknown)
            {
                createLog("Error:unknown");
            }
        }

        private delegate void wrapperApi_Log_Delegate(object sender, iMonLogEventArgs e);
        /// <summary>
        /// Handler for the iMonDisplayAPI# Log event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void wrapperApi_Log(object sender, iMonLogEventArgs e)
        {
            wrapperApi_Log_Delegate dele = wrapperApi_Log;

            if (this.InvokeRequired)
            {
                object[] args = {sender,e};
                this.BeginInvoke(dele, args);
                return;
            }

            createLog("LOG: " + e.Message);   
        }

        private delegate void wrapperApi_LogError_Delegate(object sender, iMonLogErrorEventArgs e);
        /// <summary>
        /// Handler for the iMonDisplayAPI# ErrorLog event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wrapperApi_LogError(object sender, iMonLogErrorEventArgs e)
        {
            wrapperApi_LogError_Delegate dele = wrapperApi_LogError;

            if (this.InvokeRequired)
            {
                object[] args = { sender, e };
                this.BeginInvoke(dele, args);
                return;
            }

            createLog("ERROR-LOG: " + e.Message);
        }
       
        private void timerConnect_Tick(object sender, EventArgs e)
        {
            //If COM interface is not connected -> try to connect
            if (!dvbvComInterfaceActive)
            {
                if ( dvbvComCalls.connectToDVBViewerComInterface() )
                {
                    //Initialize the imon object
                    initIMon();
                    dvbvComInterfaceActive = true;
                    createLog("Successfully connected to DVBViewer COM-Interface");
                    pictureBoxDvbvConnected.BackColor = System.Drawing.Color.GreenYellow;
                }
                else
                {
                    dvbvComInterfaceActive = false;
                    uninitIMon();
                    createLog("Failed to connect to the DVBViewer COM-Interface");
                    pictureBoxDvbvConnected.BackColor = System.Drawing.Color.OrangeRed;
                }
            }
        }

        private void timerUpdateData_Tick(object sender, EventArgs e)
        {
            //leave if timer is still working
            if (updateTimerWorking)
                return;            

            //leave if COM interface is not active
            if (!dvbvComInterfaceActive || !iMonDisplayInterfaceActive)
                return;

            updateTimerWorking = true;

            Hashtable dvbViewerDataHt = dvbvComCalls.gatherInformationFromDVBViewer();

            if (dvbViewerDataHt == null)
            {
                //There was an error somewhere in DVBViewer Com Calls
                //Set flags to false and return
                dvbvComInterfaceActive = false;
                updateTimerWorking = false;
                return;
            }

            labelActiveChannel.Text = dvbViewerDataHt["activeChannel"].ToString();

            dataHandler.handleDvbViewerData(dvbViewerDataHt);

            //displayHandler.AddText(ht["activeChannel"].ToString());
            //displayHandler.AddText(ht["title"].ToString());
            //displayHandler.SetProgress((int)ht["percentage"], 100);

            //Limit LogBox Length to 100
            if (listBoxLog.Items.Count >= 100)
                listBoxLog.Items.RemoveAt(0);

            updateTimerWorking = false;
        }

        
        /*
        private void showTextOnImonDisplay(string textToShow)
        {
            if ((currentDisplayText == textToShow) && (scrollFinished == false))
                return;

            if (iMonDisplayInterfaceActive)
            {
                if (lcd)
                {
                    imon.LCD.SetText(labelActiveChannel.Text);                    
                    scrollFinished = false;
                }
                if (vfd)
                {
                    //TODO: VFD ordentlich einbinden
                    imon.VFD.SetText(textToShow, "");
                }

                currentDisplayText = textToShow;
            }            
        }
         * */

        /*
        /// <summary>
        /// This function shows or hides all Icons on LCD displays
        /// </summary>
        /// <param name="showAllIcons">if true, all icons are shown - if false, all icons are hided</param>
        private void showAllIconsOniMonDisplay(bool showAllIcons)
        {
            //Only if API is active
            if (iMonDisplayInterfaceActive)
            {
                //Only handle if DisplayType is LCD because other Display (VFD) does currently not support icons
                if (imon.DisplayType == iMonDisplayType.LCD)
                {
                    if (showAllIcons)
                    {
                        imon.LCD.Icons.ShowAll();
                    }
                    else
                    {
                        imon.LCD.Icons.HideAll();
                    }
                }
                else
                {
                    createLog("This Display does not support to show Icons");
                }
            }
        }
         * */

        /// <summary>
        /// Creates log-entry with time and adds it to the listBoxLog.
        /// Sets the selected index to the last position
        /// </summary>
        /// <param name="message">Log Message</param>
        private void createLog(String message)
        {
            if (!checkBoxLogActive.Checked)
                return;

            String time = DateTime.Now.Hour.ToString() + ':' + DateTime.Now.Minute.ToString() + ':' + DateTime.Now.Second.ToString();
            listBoxLog.Items.Add(time + "   " + message);
            listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initIMon();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uninitIMon();            
        }

        
        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            clearLog();
        }

        /// <summary>
        /// Clears the log windowd
        /// </summary>
        private void clearLog()
        {
            listBoxLog.Items.Clear();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog ad = new AboutDialog();
            ad.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelDisplayType_Click(object sender, EventArgs e)
        {

        }
    }
}
