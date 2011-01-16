using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace DVBViewer_iMonDisplayPlugin
{
    class DataHandler
    {
        DisplayHandler displayHandler;
        Hashtable lastResultTable;
        string lastDisplayString = String.Empty;
        int lastAudioMode = 0;
        bool lastRecordingState = false;
        //string lastActiveChannel = String.Empty;        

        public DataHandler(DisplayHandler iDisplayHandler)
        {
            this.displayHandler = iDisplayHandler;
        }

        public void handleDvbViewerData(Hashtable iHt)
        {
            if (lastResultTable == null)
            {
                lastResultTable = iHt;
            }

            if ((bool)iHt["missingFieldFlag"])
            {
                /*
                displayHandler.SetText("ERROR");
                return;
                 * */
            }

            string displayString = String.Empty;
            string activeChannel = String.Empty;
            string title = String.Empty;
            int progress = 0;
            bool isRecording = false;
            
            foreach (DictionaryEntry o in iHt)
            {
                try
                {
                    if (o.Key.ToString() == "activeChannel")
                    {                       
                            //displayString += o.Value.ToString();                                                    
                        activeChannel = o.Value.ToString();
                    }
                    else if (o.Key.ToString() == "title")
                    {                        
                            //displayString += " - ";
                            //displayString += o.Value.ToString();
                        title = o.Value.ToString();                        
                    }
                    else if (o.Key.ToString() == "progress")
                    {
                        progress = (int)o.Value;                        
                    }
                    else if (o.Key.ToString() == "isRecording")
                    {                        
                        displayHandler.SetIcon(iMon.DisplayApi.iMonLcdIcons.Recording, (bool)o.Value);
                        if ((bool)o.Value != lastRecordingState)
                        {
                            if ((bool)o.Value)
                            {
                                displayHandler.RotateDisc(true);
                            }
                            else
                            {
                                displayHandler.HideDisc();
                            }
                            Logging.Log("Data Handler", "Recording icon switched");
                        }
                        lastRecordingState = (bool)o.Value;
                    }
                    else if (o.Key.ToString() == "audioMode")
                    {
                        /* 0=Mono 1=Stereo 2=DD2.0 3=DD5.1 */
                        if ((int)o.Value != lastAudioMode)
                        {
                            switch ((int)o.Value)
                            {
                                case 0:
                                    displayHandler.Show_DD51_AudioIcons(false);
                                    displayHandler.ShowStereoAudioIcons(false);
                                    Logging.Log("Data Handler", "Audiomode switched to 0");
                                    lastAudioMode = 0;
                                    break;
                                case 1:
                                    displayHandler.Show_DD51_AudioIcons(false);
                                    displayHandler.ShowStereoAudioIcons(true);
                                    Logging.Log("Data Handler", "Audiomode switched to 1");
                                    lastAudioMode = 1;
                                    break;
                                case 2:
                                    displayHandler.Show_DD51_AudioIcons(false);
                                    displayHandler.ShowStereoAudioIcons(true);
                                    Logging.Log("Data Handler", "Audiomode switched to 2");
                                    lastAudioMode = 2;
                                    break;
                                case 3:
                                    displayHandler.ShowStereoAudioIcons(false);
                                    displayHandler.Show_DD51_AudioIcons(true);
                                    Logging.Log("Data Handler", "Audiomode switched to 3");
                                    lastAudioMode = 3;
                                    break;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

            if (activeChannel != String.Empty)
            {
                displayString += activeChannel;
                Logging.Log("Data Handler", "Channel changed to: " + activeChannel);
            }
            if (title != String.Empty)
            {
                displayString += " - " + title;
                Logging.Log("Data Handler", "Title changed to: " + title);
            }
            if (progress >= 0)
            {
                displayHandler.SetProgress(progress, 100);
                Logging.Log("Data Handler", "Progress changed to: " + progress.ToString());
            }
            else
            {
                displayHandler.SetProgress(0, 100);
            }


            if (displayString != lastDisplayString)
            {
                displayHandler.SetText(displayString);
            }

            /*
            if ( (lastResultTable["activeChannel"].ToString() != iHt["activeChannel"].ToString()) ||
                (lastResultTable["title"].ToString() != iHt["title"].ToString()) || (firstRun == true))
            {
                //Passend für LCD und VFD Setzen!
                displayHandler.SetText(iHt["activeChannel"].ToString() + " - " + iHt["title"].ToString() ,
                                       iHt["activeChannel"].ToString(), iHt["title"].ToString());
                //displayHandler.AddText(iHt["title"].ToString());
                
               // displayHandler.SetProgress((int)iHt["percentage"], 100);
            }
            
            //if ((int)lastResultTable["percentage"] != (int)iHt["percentage"])
            //{
                displayHandler.SetProgress((int)iHt["percentage"], 100);
            //}
            */

            
            lastDisplayString = displayString;            
            lastResultTable = iHt;            
        }
    }
}
