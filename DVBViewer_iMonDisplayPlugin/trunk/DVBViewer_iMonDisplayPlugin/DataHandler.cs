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
        bool firstRun = true;

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
            
            if ( (lastResultTable["activeChannel"].ToString() != iHt["activeChannel"].ToString()) ||
                (lastResultTable["title"].ToString() != iHt["title"].ToString()) || firstRun == true)
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
            
                lastResultTable = iHt;
                firstRun = false;
        }
    }
}
