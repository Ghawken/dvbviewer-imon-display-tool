using System.Windows.Forms;
using System.Reflection;

/***************************************************************************************************************
 * This code is based on "XBMC on iMON" Project --> http://sourceforge.net/projects/xbmc-on-imon/develop
 * *************************************************************************************************************/

namespace DVBViewer_iMonDisplayPlugin
{
    public partial class AboutDialog : Form
    {
        private const string Version = "Version=";

        public AboutDialog()
        {
            InitializeComponent();

            this.lVersion.Text = "v" + this.ProductVersion;

            object[] copyrights = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true);
            if (copyrights.Length == 1)
            {
                this.lCopyright.Text = ((AssemblyCopyrightAttribute)copyrights[0]).Copyright;
            }            

            try
            {
                Assembly iMonWrapper = Assembly.GetAssembly(typeof(global::iMon.DisplayApi.iMonWrapperApi));
                int start = iMonWrapper.FullName.IndexOf(Version) + Version.Length;
                int end = iMonWrapper.FullName.IndexOf(",", start);
                this.lImonDisplayApiWrapperVersion.Text = "v" + iMonWrapper.FullName.Substring(start, end - start);
            }
            catch
            { }
        }

        private void openLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
            }
            catch
            { }
        }
    }
}
